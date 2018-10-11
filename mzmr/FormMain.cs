using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormMain : Form
    {
        // fields
        private ROM rom;

        public FormMain()
        {
            InitializeComponent();

            Reset();
            CheckForUpdate();

            if (Properties.Settings.Default.autoLoadRom)
            {
                OpenROM(Properties.Settings.Default.prevRomPath);
            }
        }

        private void CheckForUpdate()
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_DownloadStringCompleted;

            try
            {
                client.DownloadStringAsync(new Uri("http://labk.org/mzmr/version.txt"));
            }
            catch
            {
                // do nothing
            }
        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled) { return; }
            if (e.Result.Length != 5) { return; }
            if (e.Result == Program.Version) { return; }

            var result = MessageBox.Show("A newer version of MZM Randomizer is available (" + e.Result +
                "). Would you like to download it?", "Update Available", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                WebClient client = new WebClient();
                string path = Path.Combine(Application.StartupPath, "mzmr-" + e.Result + ".zip");
                try
                {
                    client.DownloadFile("http://labk.org/mzmr/mzmr.zip", path);
                }
                catch
                {
                    result = MessageBox.Show("Update could not be downloaded. You will be taken to the " +
                        "website to download it manually.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("http://labk.org/mzmr/");
                    return;
                }
                MessageBox.Show("File saved to\n" + path + "\n\nYou should close the program and begin using " +
                    "the new version.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Reset()
        {
            ToggleControls(false);
            rom = null;
        }

        private void ToggleControls(bool toggle)
        {
            button_randomize.Enabled = toggle;
            button_loadSettings.Enabled = toggle;
            button_saveSettings.Enabled = toggle;
            label_seed.Enabled = toggle;
            textBox_seed.Enabled = toggle;

            foreach (Control tab in tabControl_options.TabPages)
            {
                tab.Enabled = toggle;
            }
        }

        public void SetStateFromSettings(Settings settings)
        {
            // items
            checkBox_itemsAbilities.Checked = settings.randomAbilities;
            checkBox_itemsTanks.Checked = settings.randomTanks;

            // excluded items
            StringBuilder sb = new StringBuilder();
            foreach (int i in settings.excludedItems)
            {
                sb.Append(i + ",");
            }
            string excludedItems = sb.ToString();
            textBox_itemsExcluded.Text = excludedItems.TrimEnd(',');

            radioButton_completionUnchanged.Checked = (settings.gameCompletion == GameCompletion.Unchanged);
            radioButton_completionBeatable.Checked = (settings.gameCompletion == GameCompletion.Beatable);
            radioButton_completion100.Checked = (settings.gameCompletion == GameCompletion.AllItems);

            checkBox_iceNotRequired.Checked = settings.iceNotRequired;
            checkBox_plasmaNotRequired.Checked = settings.plasmaNotRequired;
            checkBox_noPBsBeforeChozodia.Checked = settings.noPBsBeforeChozodia;
            checkBox_chozoStatueHints.Checked = settings.chozoStatueHints;

            checkBox_infiniteBombJump.Checked = settings.infiniteBombJump;
            checkBox_wallJumping.Checked = settings.wallJumping;

            // palettes
            checkBox_tilesetPalettes.Checked = settings.tilesetPalettes;
            checkBox_enemyPalettes.Checked = settings.enemyPalettes;
            checkBox_beamPalettes.Checked = settings.beamPalettes;
            numericUpDown_hueMin.Value = settings.hueMinimum;
            numericUpDown_hueMax.Value = settings.hueMaximum;

            // misc
            checkBox_enableItemToggle.Checked = settings.enableItemToggle;
            checkBox_obtainUnkItems.Checked = settings.obtainUnkItems;
            checkBox_hardModeAvailable.Checked = settings.hardModeAvailable;
            checkBox_pauseScreenInfo.Checked = settings.pauseScreenInfo;
            checkBox_removeCutscenes.Checked = settings.removeCutscenes;
            checkBox_removeNorfairVine.Checked = settings.removeNorfairVine;
            checkBox_removeVariaAnimation.Checked = settings.removeVariaAnimation;
            checkBox_skipSuitless.Checked = settings.skipSuitless;
        }

        private Settings GetSettingsFromState()
        {
            Settings settings = new Settings();

            // items
            settings.randomAbilities = checkBox_itemsAbilities.Checked;
            settings.randomTanks = checkBox_itemsTanks.Checked;

            // excluded items
            MatchCollection mc = Regex.Matches(textBox_itemsExcluded.Text, @"\d+");
            bool[] isExcluded = new bool[100];
            foreach (Match m in mc)
            {
                int item;
                if (int.TryParse(m.Value, out item))
                {
                    if (item >= 0 && item <= 99)
                    {
                        isExcluded[item] = true;
                    }
                }
            }

            List<int> excludedItems = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                if (isExcluded[i])
                {
                    excludedItems.Add(i);
                }
            }
            settings.excludedItems = excludedItems;

            if (radioButton_completionUnchanged.Checked) { settings.gameCompletion = GameCompletion.Unchanged; }
            else if (radioButton_completionBeatable.Checked) { settings.gameCompletion = GameCompletion.Beatable; }
            else if (radioButton_completion100.Checked) { settings.gameCompletion = GameCompletion.AllItems; }

            settings.iceNotRequired = checkBox_iceNotRequired.Checked;
            settings.plasmaNotRequired = checkBox_plasmaNotRequired.Checked;
            settings.noPBsBeforeChozodia = checkBox_noPBsBeforeChozodia.Checked;
            settings.chozoStatueHints = checkBox_chozoStatueHints.Checked;

            settings.infiniteBombJump = checkBox_infiniteBombJump.Checked;
            settings.wallJumping = checkBox_wallJumping.Checked;

            // palettes
            settings.tilesetPalettes = checkBox_tilesetPalettes.Checked;
            settings.enemyPalettes = checkBox_enemyPalettes.Checked;
            settings.beamPalettes = checkBox_beamPalettes.Checked;
            settings.hueMinimum = (int)numericUpDown_hueMin.Value;
            settings.hueMaximum = (int)numericUpDown_hueMax.Value;

            // misc
            settings.enableItemToggle = checkBox_enableItemToggle.Checked;
            settings.obtainUnkItems = checkBox_obtainUnkItems.Checked;
            settings.hardModeAvailable = checkBox_hardModeAvailable.Checked;
            settings.pauseScreenInfo = checkBox_pauseScreenInfo.Checked;
            settings.removeCutscenes = checkBox_removeCutscenes.Checked;
            settings.removeNorfairVine = checkBox_removeNorfairVine.Checked;
            settings.removeVariaAnimation = checkBox_removeVariaAnimation.Checked;
            settings.skipSuitless = checkBox_skipSuitless.Checked;

            return settings;
        }

        private void button_openROM_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "GBA ROM Files (*.gba)|*.gba";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                OpenROM(openFile.FileName);
            }
        }

        private void button_randomize_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "GBA ROM Files (*.gba)|*.gba";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Randomize(saveFile.FileName);
            }
        }

        private void button_loadSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(this);
            form.ShowDialog();
        }

        private void button_saveSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Config files (*.cfg)|*.cfg";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Settings settings = GetSettingsFromState();
                byte[] config = settings.ConvertToStringBytes();
                File.WriteAllBytes(saveFile.FileName, config);
            }
        }

        private void button_appSettings_Click(object sender, EventArgs e)
        {
            FormAppSettings form = new FormAppSettings();
            form.Show();
        }

        private void OpenROM(string filename)
        {
            try
            {
                rom = new ROM(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Properties.Settings.Default.autoLoadRom)
            {
                Properties.Settings.Default.prevRomPath = filename;
                Properties.Settings.Default.Save();
            }

            Settings settings;
            if (Properties.Settings.Default.rememberSettings)
            {
                settings = new Settings(Properties.Settings.Default.prevSettings);
            }
            else
            {
                settings = new Settings();
            }

            SetStateFromSettings(settings);
            ToggleControls(true);
        }

        private void Randomize(string filename)
        {
            // get settings
            Settings settings = GetSettingsFromState();
            string config = settings.ConvertToString();
            if (Properties.Settings.Default.rememberSettings)
            {
                Properties.Settings.Default.prevSettings = config;
                Properties.Settings.Default.Save();
            }

            // get seed
            int seed;
            if (!int.TryParse(textBox_seed.Text, out seed))
            {
                Random temp = new Random();
                seed = temp.Next();
            }

            // randomize
            RandomAll randAll = new RandomAll(rom, settings, seed);
            bool success = randAll.Randomize();

            if (!success)
            {
                MessageBox.Show("Randomization failed.");
                return;
            }

            // save ROM
            rom.Save(filename);

            // write files
            string writtenFiles = "";

            // log file
            bool saveLogFile = Properties.Settings.Default.saveLogFile;
            if (!saveLogFile)
            {
                var result = MessageBox.Show("Would you like to save a log file?", "", MessageBoxButtons.YesNo);
                saveLogFile = (result == DialogResult.Yes);
            }
            if (saveLogFile)
            {
                string logFile = Path.ChangeExtension(filename, "log");
                File.WriteAllText(logFile, randAll.GetLog());
                writtenFiles += "Log file saved to\n" + logFile + "\n\n";
            }

            // map images
            if (settings.randomAbilities || settings.randomTanks)
            {
                bool saveMapImages = Properties.Settings.Default.saveMapImages;
                if (!saveMapImages)
                {
                    var result = MessageBox.Show("Would you like to save map images?", "", MessageBoxButtons.YesNo);
                    saveMapImages = (result == DialogResult.Yes);
                }
                if (saveMapImages)
                {
                    string path = Path.ChangeExtension(filename, null) + "_maps";
                    Directory.CreateDirectory(path);
                    Bitmap[] minimaps = randAll.GetMaps();
                    minimaps[0].Save(Path.Combine(path, "brinstar.png"));
                    minimaps[1].Save(Path.Combine(path, "kraid.png"));
                    minimaps[2].Save(Path.Combine(path, "norfair.png"));
                    minimaps[3].Save(Path.Combine(path, "ridley.png"));
                    minimaps[4].Save(Path.Combine(path, "tourian.png"));
                    minimaps[5].Save(Path.Combine(path, "crateria.png"));
                    minimaps[6].Save(Path.Combine(path, "chozodia.png"));
                    writtenFiles += "Map images saved to\n" + path;
                }
            }

            // display written files
            if (writtenFiles != "")
            {
                MessageBox.Show(writtenFiles.TrimEnd('\n'), "", MessageBoxButtons.OK);
            }

            // display seed and settings
            FormComplete form = new FormComplete(seed, config);
            form.ShowDialog();

            // clean up
            Reset();
        }

        private void numericUpDown_hueMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMax.Minimum = numericUpDown_hueMin.Value;
        }

        private void numericUpDown_hueMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMin.Maximum = numericUpDown_hueMax.Value;
        }

        private void DocToResource()
        {
            string[] lines = File.ReadAllLines("zmr.tsv");
            System.IO.StreamWriter sw = new System.IO.StreamWriter("locations.txt");

            string[] areas = new string[] { "Brinstar", "Kraid", "Norfair", "Ridley", "Tourian", "Crateria", "Chozodia" };
            Dictionary<string, string> itemNames = new Dictionary<string, string>()
            {
                { "Energy Tank", "Energy" },
                { "Missile Tank", "Missile" },
                { "Super Missile Tank", "Super" },
                { "Power Bomb Tank", "Power" },
                { "Long Beam", "Long" },
                { "Charge Beam", "Charge" },
                { "Ice Beam", "Ice" },
                { "Wave Beam", "Wave" },
                { "Plasma Beam", "Plasma" },
                { "Bomb", "Bomb" },
                { "Varia Suit", "Varia" },
                { "Gravity Suit", "Gravity" },
                { "Morph Ball", "Morph" },
                { "Speed Booster", "Speed" },
                { "Hi-Jump", "Hi" },
                { "Screw Attack", "Screw" },
                { "Space Jump", "Space" },
                { "Power Grip", "Grip" }
            };

            for (int i = 1; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                sw.WriteLine("[Location]");

                int num = int.Parse(items[0]);
                sw.WriteLine("Number=" + Convert.ToString(num, 16).ToUpper());

                int area = Array.IndexOf(areas, items[1]);
                if (area == -1) { throw new FormatException("Bad area"); }
                sw.WriteLine("Area={0}", area);

                sw.WriteLine("Room={0}", items[2]);

                if (!Regex.IsMatch(items[3], @"\([0-9A-F]+,\s[0-9A-F]+\)"))
                {
                    throw new FormatException("Bad minimap");
                }
                sw.WriteLine("Minimap={0}", Regex.Replace(items[3], @"\s+", ""));

                sw.WriteLine("Item={0}", itemNames[items[4]]);

                if (items[5] != "0")
                {
                    sw.WriteLine("Clip={0}", items[5]);
                }

                if (items[6] != "0")
                {
                    sw.WriteLine("BG1={0}", items[6]);
                }

                if (items[7] != "disable")
                {
                    if (!Regex.IsMatch(items[7], @"\([0-9A-F]+,\s[0-9A-F]+\)"))
                    {
                        throw new FormatException("Bad Varia");
                    }
                    sw.WriteLine("Varia={0}", Regex.Replace(items[7], @"\s+", ""));
                }

                if (items[8] != "None")
                {
                    sw.WriteLine("Requirements={0}", items[8]);
                }

                sw.WriteLine();
            }

            sw.Close();
        }

        private string FormatExpression(string expression)
        {
            expression = Regex.Replace(expression, @"(Energy|Missile|Super|Power)(\d+)", "$1X($2)");
            expression = expression.Replace("&", "&&");
            return expression.Replace("|", "||");
        }

        private void PrintReplacements()
        {
            string[] lines = File.ReadAllLines("replacements.tsv");
            List<string> variables = new List<string>();
            List<string> expressions = new List<string>();
            int i = 0;
            foreach (string line in lines)
            {
                string[] items = line.Split('\t');
                if (items.Length != 2)
                {
                    throw new FormatException("Bad line: " + line);
                }

                string name = items[0];
                string replacement = FormatExpression(items[1]);

                variables.Add("private bool " + name + ";");
                expressions.Add(
                    string.Format(
                    "case {0}:\n    {1} = {2};\n    if ({1}) {{ toRemove.Add({0}); }} break;",
                    i, name, replacement));
                i++;
            }

            File.WriteAllLines("variables.txt", variables.ToArray());
            File.WriteAllLines("expressions.txt", expressions.ToArray());
        }

        private void PrintRequirements()
        {
            string[] lines = File.ReadAllLines("items.txt");
            List<string> requirements = new List<string>();
            int i = 0;
            foreach (string line in lines)
            {
                string replacement = FormatExpression(line);
                requirements.Add(string.Format("case {0}:\n    return {1};", i, replacement));
                i++;
            }

            File.WriteAllLines("requirements.txt", requirements.ToArray());
        }


    }
}
