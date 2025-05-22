using System.Collections.Generic;

namespace mzmr.Utility
{
    public static class Room
    {
        //Import rooms for boss rando
        public static void Import(Rom rom, byte[] roomData, byte roomID, byte areaID)
        {
            ByteStream data = new ByteStream(roomData);
            int headerOffset = rom.ReadPtr(Rom.AreaRoomEntryOffset + areaID * 4) + (roomID * 0x3C);
            int start = 0x20;
            data.Seek(start);

            //import BG Data
            rom.Write8(headerOffset, data.Read8()); //tileset
            byte BG0Prop = data.Read8();
            rom.Write8(headerOffset + 1, BG0Prop); 
            rom.Write8(headerOffset + 2, data.Read8());
            rom.Write8(headerOffset + 3, data.Read8());
            rom.Write8(headerOffset + 4, data.Read8());
            int BG0Offset = data.Read32();
            int BG1Offset = data.Read32();
            int BG2Offset = data.Read32();
            int ClipOffset = data.Read32();
            int BG3Offset = data.Read32();
            //clipdata, BG2, and BG1 are always RLE
            //since mage room files place bg data back to back
            //sizes are quickly determined by subtracting their pointers
            BG0Offset = ImportBG(BG0Prop, BG0Offset, BG1Offset - BG0Offset, data, rom);
            BG1Offset = ImportBG(0x10, BG1Offset, BG2Offset - BG1Offset, data, rom);
            BG2Offset = ImportBG(0x10, BG2Offset, ClipOffset - BG2Offset, data, rom);
            ClipOffset = ImportBG(0x10, ClipOffset, BG3Offset - ClipOffset, data, rom); 
            if (BG0Offset != 0)
                rom.WritePtr(headerOffset + 0x8, BG0Offset);
            rom.WritePtr(headerOffset + 0x10, BG2Offset);   //assume other layers are not disabled
            rom.WritePtr(headerOffset + 0xC, BG1Offset);    
            rom.WritePtr(headerOffset + 0x14, ClipOffset);
            //BG3 will always already exist and is often the same as original room
            //if it is different, will be set manually in the boss rando function

            //import sprite data
            data.Seek(start + 0x20);
            int spritedata0Offset = data.Read32();
            byte spriteset0 = data.Read8();
            byte spriteset1Event = data.Read8();

            int spritedata1Offset = data.Read32();
            byte spriteset1 = data.Read8();
            byte spriteset2Event = data.Read8();

            int spritedata2Offset = data.Read32();
            byte spriteset2 = data.Read8();
            rom.WritePtr(headerOffset + 0x20, ImportSpriteList(spritedata0Offset, data, rom));
            rom.Write8(headerOffset + 0x24, spriteset0);
            rom.Write8(headerOffset + 0x25, spriteset1Event);
            if (spriteset1Event > 0)
            {
                rom.WritePtr(headerOffset + 0x28, ImportSpriteList(spritedata1Offset, data, rom)); 
                rom.Write8(headerOffset + 0x2C, spriteset1);
            }
            else
            {
                rom.WritePtr(headerOffset + 0x28, 0x33DFD8); //pointer for blank sprite list
                rom.Write8(headerOffset + 0x2C, 0);
            }
            rom.Write8(headerOffset + 0x2D, spriteset2Event);
            if (spriteset2Event > 0)
            {
                rom.WritePtr(headerOffset + 0x30, ImportSpriteList(spritedata2Offset, data, rom)); 
                rom.Write8(headerOffset + 0x24, spriteset2);
            }
            else
            {
                rom.WritePtr(headerOffset + 0x30, 0x33DFD8); //pointer for blank sprite list
                rom.Write8(headerOffset + 0x34, 0);
            }

            //import door data
            data.Seek(0x5C);
            ImportDoors(data.Read32(), areaID, data, rom);

            //import scroll data
            data.Seek(0x60);
            ImportScrolls(data.Read32(), areaID, roomID, data, rom);

            //final header data
            data.Seek(start + 0x37);
            rom.Write8(headerOffset + 0x37, data.Read8());
            rom.Write8(headerOffset + 0x38, data.Read8());
            //music will be same as default room so need need to import that data


        }

        private static int ImportBG(byte prop, int offset, int size, ByteStream data, Rom rom)
        {
            //copy BG data directly to end of rom
            data.Seek(offset + 2);
            byte[] roomData;
            if (((prop & 0x10) == 0) && ((prop & 0x40) == 0))
                    return 0;
            data.Seek(offset);
            roomData = new byte[size];
            data.CopyToArray(data.Position, roomData, 0, size);
            return rom.WriteToEnd(roomData);
        }

        private static int ImportSpriteList(int offset, ByteStream data, Rom rom)
        {
            List<byte> spritelist = new List<byte>();
            data.Seek(offset);
            for (int i = 0; i < 24; i++)
            {
                byte yPos = data.Read8();
                byte xPos = data.Read8();
                byte prop = data.Read8();
                if (yPos == 0xFF && xPos == 0xFF && prop == 0xFF) { break; }
                spritelist.Add(yPos);
                spritelist.Add(xPos);
                spritelist.Add(prop);
            }
            spritelist.Add(0xFF); //marks end of sprite list
            spritelist.Add(0xFF);
            spritelist.Add(0xFF);
            return rom.WriteToEnd(spritelist.ToArray());
        }

        private static void ImportDoors(int offset, byte area, ByteStream data, Rom rom)
        {
            //rooms will always use same doors as original room
            data.Seek(offset);
            byte doorCount = data.Read8();
            int areaOffset = rom.ReadPtr(0x75FAA8 + area * 4);
            List<byte> doorData = new List<byte>();
            for (int i = 0; i < doorCount; i++)
            {
                byte doorNum = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (j < 9)
                        doorData.Add(data.Read8());
                    else
                        doorNum = data.Read8();
                }
                doorData.Add(0);
                doorData.Add(0);
                doorData.Add(0);
                rom.WriteBytes(doorData.ToArray(), 0, areaOffset + (doorNum * 12), doorData.Count); //write based on door number
                data.Seek(data.Position + 2);
                doorData.Clear();
            }


        }

        private static void ImportScrolls(int offset, byte area, byte room, ByteStream data, Rom rom) 
        {
            //rooms will always use same number of scrolls as original room
            data.Seek(offset);
            byte count = data.Read8();
            int areaOffset = rom.ReadPtr(0x75FD28 + area * 4);
            int scrollOffset = rom.ReadPtr(areaOffset);
            byte roomID = rom.Read8(scrollOffset);
           while (roomID != 0xFF) 
            {
                if (roomID < room)
                {
                    areaOffset += 4;
                    scrollOffset = rom.ReadPtr(areaOffset);
                    roomID = rom.Read8(scrollOffset);
                    continue;
                }
                else if (roomID == room)
                {
                    List<byte> scrollData = new List<byte>();
                    for (int i = 0; i < count; i++)
                        for (int j = 0; j < 8; j++)
                            scrollData.Add(data.Read8());
                    rom.WriteBytes(scrollData.ToArray(), 0, scrollOffset + 2, scrollData.Count);
                    break;
                }
                else
                    break;
            }

        }

    }






}


