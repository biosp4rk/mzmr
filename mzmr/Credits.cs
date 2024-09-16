using mzmr.Items;
using mzmr.Utility;
using mzmr.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mzmr.Randomizers
{
    public class Credits
    {
        private Rom rom;
        private Settings settings;
        readonly string blankLine, lineBreak, creditsEnd;
        readonly Encoding ASCII;
        const int lineLength = 0x24;
        private StringBuilder credits = new StringBuilder();
        private readonly int seed;

        public Credits(Rom rom, Settings settings, int seed)
        {
            this.rom = rom;
            this.settings = settings;
            this.seed = seed;
            ASCII = Encoding.ASCII;
            byte[] str = new byte[lineLength];
            str[0] = 2;
            for (int i = 1; i < str.Length; i++)
                str[i] = 0;
            blankLine = ASCII.GetString(str);
            str[0] = 5;
            lineBreak = ASCII.GetString(str);
            str[0] = 6;
            creditsEnd = ASCII.GetString(str);

        }

        public void WriteCredits(RandomItems randomItems)
        {
            ApplyASCIIPatch();
            WriteProgramCredits();
            WriteItems(randomItems);
            //add logic settings at some point
            WriteSettings();

            //write end of credits line and write to rom
            for (int i = 0; i < 5; i++)
                credits.Append(blankLine);
            FillLine((char)2 + "Thanks for playing! :)", blankLine, 5);
            credits.Append(creditsEnd);
            byte[] data = ASCII.GetBytes(credits.ToString());
            if (data.Length > 0x20D0) //vanilla credits length
            {
                int newOffset = rom.WriteToEnd(data);
                rom.WritePtr(0x856C8, newOffset); //repoint credits
            }
            else
                rom.WriteBytes(data, 0, 0x54C10C, data.Length);
        }

        private void WriteProgramCredits()
        {
            FillLine((char)0 + "MZMR Plus Credits", blankLine, 5);
            FillLine((char)0 + "Original MZMR", lineBreak);
            FillLine((char)3 + "biospark", lineBreak);
            FillLine((char)3 + "Dragonfangs", blankLine);
            FillLine((char)0 + "MZMR Plus", lineBreak);
            FillLine((char)3 + "Captain Glitch", blankLine);
            FillLine((char)0 + "Testers", lineBreak);
            FillLine((char)3 + "Conner", lineBreak);
            FillLine((char)3 + "Darkstar", lineBreak);
            FillLine((char)3 + "Jiffy", lineBreak);
            FillLine((char)3 + "MetroidMst", lineBreak);
            FillLine((char)3 + "OneOf99", lineBreak);           
            FillLine((char)3 + "Whalerynth", lineBreak);                      
            FillLine((char)3 + "Zidj", blankLine, 5);
        }

        private void WriteSettings()
        {
            FillLine((char)1 + "Randomizer Settings", blankLine, 5);
            FillLine((char)0 + "Seed:", lineBreak);
            FillLine((char)3 + seed.ToString(), blankLine);
            FillLine((char)0 + "Settings:", lineBreak);
            FillLine((char)3 + settings.GetString(), blankLine, 3);
            FillLine((char)0 + "Item Settings", blankLine);
            FillLine((char)0 + "Game Completion", lineBreak);
            if (settings.Completion == GameCompletion.NoLogic)
                FillLine((char)3 + "No Logic", blankLine);
            else if (settings.Completion == GameCompletion.Beatable)
                FillLine((char)3 + "Beatable", blankLine);
            else
                FillLine((char)3 + "Fully Collectable", blankLine);
            FillLine((char)0 + "Abilities", lineBreak);
            FillLine((char)3 + GetSwapString(settings.AbilitySwap), blankLine);
            FillLine((char)0 + "Tanks", lineBreak);
            FillLine((char)3 + GetSwapString(settings.TankSwap), blankLine);
            FillLine((char)0 + "Items Removed", lineBreak);
            FillLine((char)3 + settings.NumItemsRemoved.ToString(), blankLine);
            FillLine((char)0 + "Enabled Options", lineBreak);
            if (settings.ObtainUnkItems)
                FillLine((char)3 + "Obtainable Unknown Items", lineBreak);
            if (settings.IceNotRequired)
                FillLine((char)3 + "Ice not Required", lineBreak);
            if (settings.PlasmaNotRequired)
                FillLine((char)3 + "Plasma not Required", lineBreak);
            if (settings.NoPBsBeforeChozodia)
                FillLine((char)3 + "No PBs Before Chozodia", lineBreak);
            if (settings.ChozoStatueHints)
                FillLine((char)3 + "Chozo Statue Hints", lineBreak);
            if (settings.EnableItemToggle)
                FillLine((char)3 + "Item Toggling", lineBreak);
            if (settings.DisableWallJump)
                FillLine((char)3 + "Disable Walljump", lineBreak);
            if (settings.PBJumping)
                FillLine((char)3 + "Powerbomb Jumping", lineBreak);
            if (settings.DisableInfiniteBombJump)
                FillLine((char)3 + "Disable IBJ", lineBreak);
            for (int i = 0; i < 3; i++)
                credits.Append(blankLine);
            FillLine((char)0 + "Enabled Enemy Settings", lineBreak);
            if (settings.RandoEnemies)
                FillLine((char)3 + "Random Enemies", lineBreak);
            if (settings.EnemyWeakness)
                FillLine((char)3 + "Random Vulnerabilities", lineBreak);
            if (settings.EnemyDrops)
                FillLine((char)3 + "Random Drop Rates", lineBreak);
            if (settings.EnemyHealth)
                FillLine((char)3 + "Random Health", lineBreak);
            if (settings.EnemyDamage)
                FillLine((char)3 + "Random Damage", lineBreak);
            if (settings.RandoBosses)
            {
                FillLine((char)3 + "Random Bosses", blankLine);
                FillLine((char)0 + "Selected Bosses", lineBreak);
                FillLine((char)3 + "Kraid replaced with " + RandomBosses.GetBoss(RandomBosses.Bosses.Kraid), lineBreak);
                FillLine((char)3 + "Ridley replaced with " + RandomBosses.GetBoss(RandomBosses.Bosses.Ridley), lineBreak);
                FillLine((char)3 + "Mecha replaced with " + RandomBosses.GetBoss(RandomBosses.Bosses.Mecha), lineBreak);
            }
            for (int i = 0; i < 3; i++)
                credits.Append(blankLine);
            FillLine((char)0 + "Palette Settings", lineBreak);
            if (settings.TilesetPalettes)
                FillLine((char)3 + "Random Tileset Palettes", lineBreak);
            if (settings.EnemyPalettes)
                FillLine((char)3 + "Random Enemy Palettes", lineBreak);
            if (settings.SamusPalettes)
                FillLine((char)3 + "Random Samus Palettes", lineBreak);
            if (settings.BeamPalettes)
                FillLine((char)3 + "Random Beam Palettes", blankLine);
            for (int i = 0; i < 3; i++)
                credits.Append(blankLine);
            FillLine((char)0 + "Music Settings", lineBreak);
            if (settings.CustomMusic)
                FillLine((char)1 + "Custom Music Enabled", blankLine);
            FillLine((char)0 + "Room Music", lineBreak);
            FillLine((char)3 + GetMusicSwapString(settings.RoomMusic), blankLine);
            FillLine((char)0 + "Boss Music", lineBreak);
            FillLine((char)3 + GetMusicSwapString(settings.BossMusic), blankLine, 3);
            FillLine((char)0 + "Text Settings", lineBreak);
            if (settings.ItemText)
                FillLine((char)3 + "Item Text", lineBreak);
            if (settings.CutsceneText)
                FillLine((char)3 + "Cutscene Text", lineBreak);
            if (settings.AreaText)
                FillLine((char)3 + "Area Text", lineBreak);
            if (settings.MiscText)
                FillLine((char)3 + "Miscellaneous Text", lineBreak);

        }

        private string GetMusicSwapString(Song swap)
        {
            if (swap == Song.Unchanged)
                return "Unchanged";
            else if (swap == Song.LocalPool)
                return "Within own pool";
            else
                return "No Logic";
        }

        private string GetSwapString(Swap swap)
        {
            if (swap == Swap.Unchanged)
                return "Unchanged";
            else if (swap == Swap.LocalPool)
                return "Within Own Pool";
            else
                return "With All Items";
        }

        private void WriteItems(RandomItems randomItems)
        {
            string str;
            switch (settings.SelectedGame)
            {
                case Game.DeepFreeze:
                    str = "Deep Freeze"; break;
                case Game.ScrollsVI:
                    str = "Scrolls VI"; break;
                case Game.Spooky:
                    str = "Spooky Mission"; break;
                case Game.Spooky2:
                    str = "Spooky Mission II"; break;
                case Game.SR387:
                    str = "SRThreeEightSeven"; break;
                case Game.WinterMission:
                    str = "Winter Mission"; break;
                case Game.Original:
                default:
                    str = "Zero Mission"; break;
            }
            FillLine((char)1 + str + " Randomizer", blankLine, 5);
            GetLogicCredits();
            FillLine((char)0 + "Item Locations", blankLine, 3);
            foreach (Location loc in randomItems.GetLocations())
            {
                FillLine((char)0 + loc.LogicName, lineBreak);
                FillLine((char)3 + loc.NewItem.ToString(), blankLine);
            }
            for (int i = 0; i < 5; i++)
                credits.Append(blankLine);
        }

        private void GetLogicCredits()
        {
            FillLine((char)0 + "Item Logic", lineBreak);
            switch (settings.SelectedGame)
            {
                case Game.DeepFreeze:
                    FillLine((char)3 + "Captain Glitch", blankLine, 3); ; break;
                case Game.ScrollsVI:
                    FillLine((char)3 + "Captain Glitch", lineBreak);
                    FillLine((char)3 + "Conner", blankLine, 3); break;
                case Game.Spooky:
                    FillLine((char)3 + "Captain Glitch", blankLine, 3); ; break;
                case Game.Spooky2:
                    FillLine((char)3 + "Captain Glitch", lineBreak);
                    FillLine((char)3 + "Conner", lineBreak);
                    FillLine((char)3 + "Jiffy", lineBreak);
                    FillLine((char)3 + "Whalerynth", blankLine, 3); break;
                case Game.SR387:
                    FillLine((char)3 + "OneOf", blankLine, 3); ; break;
                case Game.WinterMission:
                    FillLine((char)3 + "Ing Ing", blankLine, 3); ; break;
                case Game.Original:
                    FillLine((char)3 + "Dragonfangs", blankLine, 3); ; break;
            }
        }

        private void FillLine(string line, string breakStr, int count = 1)
        {
            //trim text if too long, add trailing 00s if too short
            //Large white text can only fit 0x1E chars + the start char
            //lines are 0x24 chars long including the start char
            if ((line[0] == (char)2) && (line.Length >= 0x20))
                line = line.Remove(0x20, line.Length - 0x1F);
            List<byte> bytes = new List<byte>(ASCII.GetBytes(line));
            while (bytes.Count < lineLength)
                bytes.Add(0);
            credits.Append(ASCII.GetString(bytes.ToArray()));
            //add specified line break for specified ammount
            for (int i = 0; i < count; i++)
                credits.Append(breakStr);
        }

        private void ApplyASCIIPatch()
        {
            Patch.Apply(rom, Resources.ZM_U_ASCIICredits);
            int ptr = rom.WriteToEnd(Resources.credits_font); //new gfx
            rom.WritePtr(0x855E8, ptr);
        }



    }
}
