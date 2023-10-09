using mzmr.Items;
using System;

namespace mzmr.Data
{
    public class Tileset
    {
        private Palette palette;
        private Tilemap tilemap;
        private byte[] animTileset;

        private readonly Rom rom;
        private readonly int addr;
        private readonly byte number;

        // TODO: clean up everything!
        public Tileset(Rom rom, byte tsNum)
        {
            this.rom = rom;
            addr = rom.TilesetOffset + tsNum * 0x14;
            number = tsNum;

            int palOffset = rom.ReadPtr(addr + 4);
            palette = new Palette(rom, palOffset, 14);
            tilemap = new Tilemap(rom, addr + 0xC);

            // get animTileset
            byte atsNum = rom.Read8(addr + 0x10);
            int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
            animTileset = new byte[0x30];
            rom.ReadBytes(animTileset, atsOffset, 0, 0x30);
        }

        public byte AddAbility(ItemType item)
        {
            byte animGfxNum = (byte)(Rom.NumOfAnimGfx + item - ItemType.Long);

            // find empty spot in palette
            int palRow = 15;
            for (int r = 1; r < 14; r++)
            {
                ushort color = palette.GetColor(r, 1);
                bool blank = true;

                for (int c = 2; c < 16; c++)
                {
                    if (palette.GetColor(r, c) != color)
                    {
                        blank = false;
                        break;
                    }
                }

                if (blank)
                {
                    Palette itemPal = item.AbilityPalette();
                    palette.CopyRows(itemPal, 0, r, 1);
                    palRow = r + 2;
                    break;
                }
            }

            // find empty spot in animGfx
            int animGfxSlot = 0;
            for (int i = 0; i < 0x10; i++)
            {
                if (animTileset[i * 3] == 0)
                {
                    animTileset[i * 3] = animGfxNum;
                    animGfxSlot = i;
                    break;
                }
            }

            // find empty spot in tile table
            int blockNum = 0x4C;
            int tileVal = 0x40;
            for (int i = 0x4C; i < 0x5F; i++) //default max is 50
            {
                int offset = i * 4 + 1;

                if (tilemap[offset] == 0x40 && tilemap[offset + 1] == 0x40 &&
                    tilemap[offset + 2] == 0x40 && tilemap[offset + 3] == 0x40)
                {
                    tileVal = (palRow << 12) | (animGfxSlot * 4);
                    tilemap[offset] = (ushort)tileVal;
                    tilemap[offset + 1] = (ushort)(tileVal + 1);
                    tilemap[offset + 2] = (ushort)(tileVal + 2);
                    tilemap[offset + 3] = (ushort)(tileVal + 3);
                    blockNum = i;
                    break;
                }
            }

            // fix Tilemap400
            int tm400Offset = rom.Tilemap400Offset + (0xD0 + item - ItemType.Long) * 8;
            rom.Write16(tm400Offset, (ushort)tileVal);
            rom.Write16(tm400Offset + 2, (ushort)(tileVal + 1));
            rom.Write16(tm400Offset + 4, (ushort)(tileVal + 2));
            rom.Write16(tm400Offset + 6, (ushort)(tileVal + 3));

            return (byte)blockNum;
        }

        public void Write(byte tsNum)
        {
            if (tsNum == number)
            {
                // replace
                // write palette
                palette.Write();

                // write tile table
                tilemap.Write();

                // write animTileset
                byte atsNum = rom.Read8(addr + 0x10);
                int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
                rom.WriteBytes(animTileset, 0, atsOffset, 0x30);                
            }
            else
            {
                // copy
                int newAddr = rom.TilesetOffset + tsNum * 0x14;

                // copy levelGfx pointer
                int levelGfxOffset = rom.ReadPtr(addr);
                rom.WritePtr(newAddr, levelGfxOffset);

                // write palette
                palette.WriteCopy(newAddr + 4);

                // copy BG3gfx pointer
                int BG3gfxOffset = rom.ReadPtr(addr + 8);
                rom.WritePtr(newAddr + 8, BG3gfxOffset);

                // write tile table
                tilemap.WriteCopy(newAddr + 0xC);

                // write animTileset
                int diff = tsNum - Rom.NumOfTilesets;
                byte atsNum = (byte)(Rom.NumOfAnimTilesets + diff);
                int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
                rom.WriteBytes(animTileset, 0, atsOffset, 0x30);
                rom.Write8(newAddr + 0x10, atsNum);

                // copy animPalette number
                byte apNum = rom.Read8(addr + 0x11);
                rom.Write8(newAddr + 0x11, apNum);
            }
        }

    }
}
