using System;

namespace mzmr
{
    public class Tileset
    {
        private ushort[] palette;
        private ushort[] tileTable;
        private byte[] animTileset;

        private ROM rom;
        private int addr;
        private byte number;

        public Tileset(ROM rom, byte tsNum)
        {
            this.rom = rom;
            this.addr = rom.TilesetOffset + tsNum * 0x14;
            this.number = tsNum;

            // get palette
            int paletteOffset = rom.ReadPtr(addr + 4);
            palette = new ushort[0xE0];
            rom.RomToArray(palette, paletteOffset, 0, 0x1C0);

            // get tile table
            int ttbOffset = rom.ReadPtr(addr + 0xC);
            byte rows = rom.Read8(ttbOffset + 1);
            tileTable = new ushort[rows * 0x40 + 1];
            rom.RomToArray(tileTable, ttbOffset, 0, tileTable.Length * 2);

            // get animTileset
            byte atsNum = rom.Read8(addr + 0x10);
            int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
            animTileset = new byte[0x30];
            rom.RomToArray(animTileset, atsOffset, 0, 0x30);
        }

        public byte AddAbility(ItemType item)
        {
            byte animGfxNum = (byte)(ROM.NumOfAnimGfx + item - ItemType.Long);

            // find empty spot in palette
            int palRow = 15;
            for (int r = 1; r < 14; r++)
            {
                int index = r * 16 + 1;
                ushort color = palette[index++];
                bool blank = true;

                for (int c = 2; c < 16; c++)
                {
                    if (palette[index++] != color)
                    {
                        blank = false;
                        break;
                    }
                }

                if (blank)
                {
                    byte[] pal = item.AbilityPalette();
                    Buffer.BlockCopy(pal, 0, palette, r * 0x20, 0x20);
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
            for (int i = 0x4C; i < 0x50; i++)
            {
                int offset = i * 4 + 1;

                if (tileTable[offset] == 0x40 && tileTable[offset + 1] == 0x40 &&
                    tileTable[offset + 2] == 0x40 && tileTable[offset + 3] == 0x40)
                {
                    tileVal = (palRow << 12) | (animGfxSlot * 4);
                    tileTable[offset] = (ushort)tileVal;
                    tileTable[offset + 1] = (ushort)(tileVal + 1);
                    tileTable[offset + 2] = (ushort)(tileVal + 2);
                    tileTable[offset + 3] = (ushort)(tileVal + 3);
                    blockNum = i;
                    break;
                }
            }

            // fix TileTable400
            int ttb400Offset = rom.TileTable400Offset + (0xD0 + item - ItemType.Long) * 8;
            rom.Write16(ttb400Offset, (ushort)tileVal);
            rom.Write16(ttb400Offset + 2, (ushort)(tileVal + 1));
            rom.Write16(ttb400Offset + 4, (ushort)(tileVal + 2));
            rom.Write16(ttb400Offset + 6, (ushort)(tileVal + 3));

            return (byte)blockNum;
        }

        public void Write(byte tsNum)
        {
            if (tsNum == number)
            {
                // replace
                // write palette
                int paletteOffset = rom.ReadPtr(addr + 4);
                rom.ArrayToRom(palette, 0, paletteOffset, 0x1C0);

                // write tile table
                int ttbOffset = rom.ReadPtr(addr + 0xC);
                rom.ArrayToRom(tileTable, 0, ttbOffset, tileTable.Length * 2);

                // write animTileset
                byte atsNum = rom.Read8(addr + 0x10);
                int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
                rom.ArrayToRom(animTileset, 0, atsOffset, 0x30);                
            }
            else
            {
                // copy
                int newAddr = rom.TilesetOffset + tsNum * 0x14;

                // copy levelGfx pointer
                int levelGfxOffset = rom.ReadPtr(addr);
                rom.WritePtr(newAddr, levelGfxOffset);

                // write palette
                int newPaletteOffset = rom.WriteToEnd(palette, 0x1C0);
                rom.WritePtr(newAddr + 4, newPaletteOffset);

                // copy BG3gfx pointer
                int BG3gfxOffset = rom.ReadPtr(addr + 8);
                rom.WritePtr(newAddr + 8, BG3gfxOffset);

                // write tile table
                int newTtbOffset = rom.WriteToEnd(tileTable, tileTable.Length * 2);
                rom.WritePtr(newAddr + 0xC, newTtbOffset);

                // write animTileset
                int diff = tsNum - ROM.NumOfTilesets;
                byte atsNum = (byte)(ROM.NumOfAnimTilesets + diff);
                int atsOffset = rom.AnimTilesetOffset + atsNum * 0x30;
                rom.ArrayToRom(animTileset, 0, atsOffset, 0x30);
                rom.Write8(newAddr + 0x10, atsNum);

                // copy animPalette number
                byte apNum = rom.Read8(addr + 0x11);
                rom.Write8(newAddr + 0x11, apNum);
            }
        }


    }
}
