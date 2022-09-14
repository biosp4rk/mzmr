using mzmr.Items;
using mzmr.Randomizers;
using mzmr.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormMain : Form
    {
        private Rom rom;
        private string origFile;
        private bool disableEvents;

        public FormMain()
        {
            InitializeComponent();

            FillLocations();
            Reset();
#if !DEBUG
            CheckForUpdate();
#endif
        }

        private void FillLocations()
        {
            dataGridView_locs.ColumnCount = 3;
            dataGridView_locs.Columns[0].HeaderText = "#";
            dataGridView_locs.Columns[1].HeaderText = "New item";
            dataGridView_locs.Columns[2].HeaderText = "Original item";
            dataGridView_locs.Columns[0].Width = 40;
            dataGridView_locs.Columns[1].Width = 130;
            dataGridView_locs.Columns[2].Width = 135;
            string[] itemNames = Item.Names;

            Location[] locations = Items.Location.GetLocations();
            for (int i = 0; i < locations.Length; i++)
            {
                Location loc = locations[i];
                var row = new DataGridViewRow();

                var cell1 = new DataGridViewTextBoxCell();
                cell1.Value = i;
                row.Cells.Add(cell1);
                cell1.ReadOnly = true;

                var cell2 = new DataGridViewComboBoxCell();
                cell2.DataSource = itemNames;
                cell2.Value = itemNames[0];
                row.Cells.Add(cell2);

                var cell3 = new DataGridViewTextBoxCell();
                cell3.Value = loc.OrigItem.Name();
                row.Cells.Add(cell3);
                cell3.ReadOnly = true;

                dataGridView_locs.Rows.Add(row);
            }

        }

        private void CheckForUpdate()
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            try
            {
                client.DownloadStringAsync(new Uri("http://labk.org/mzmr/version.txt"));
            }
            catch
            {
                // do nothing
            }
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled) { return; }
            if (e.Result.Length != 5) { return; }
            if (e.Result == Program.Version) { return; }

            DialogResult result = MessageBox.Show(
                $"A newer version of MZM Randomizer is available ({e.Result}). " +
                "Would you like to download it?",
                "Update Available",
                MessageBoxButtons.YesNo);
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
                    MessageBox.Show(
                        "Update could not be downloaded. You will " +
                        "be taken to the website to download it manually.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Process.Start("http://labk.org/mzmr/");
                    return;
                }
                MessageBox.Show(
                    $"File saved to\n{path}\n\nYou should close " +
                    "the program and begin using the new version",
                    "Download Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Reset()
        {
            ToggleControls(false);
            rom = null;

            if (Properties.Settings.Default.autoLoadRom)
            {
                OpenROM(Properties.Settings.Default.prevRomPath);
            }
        }

        private void ToggleControls(bool toggle)
        {
            button_randomize.Enabled = toggle;
            button_loadSettings.Enabled = toggle;
            button_saveSettings.Enabled = toggle;
            label_seed.Enabled = toggle;
            textBox_seed.Enabled = toggle;

            foreach (Control tab in tabControl_options.TabPages)
                tab.Enabled = toggle;
        }

        public void SetStateFromSettings(Settings settings)
        {
            disableEvents = true;

            // items
            comboBox_abilities.SelectedIndex = (int)settings.AbilitySwap;
            comboBox_tanks.SelectedIndex = (int)settings.TankSwap;
            numericUpDown_itemsRemove.Value = settings.NumItemsRemoved;
            UpdateRemoveItems();
            if (settings.NumItemsRemoved > 0)
            {
                int idx = 0;
                if (settings.RemoveSpecificItems)
                    idx = settings.NumAbilitiesRemoved.Value + 1;
                comboBox_abilitiesRemove.SelectedIndex = idx;
            }

            radioButton_completionNoLogic.Checked = (settings.Completion == GameCompletion.NoLogic);
            radioButton_completionBeatable.Checked = (settings.Completion == GameCompletion.Beatable);
            radioButton_completion100.Checked = (settings.Completion == GameCompletion.AllItems);

            checkBox_iceNotRequired.Checked = settings.IceNotRequired;
            checkBox_plasmaNotRequired.Checked = settings.PlasmaNotRequired;
            checkBox_noEarlyChozodia.Checked = settings.NoPBsBeforeChozodia;
            checkBox_chozoStatueHints.Checked = settings.ChozoStatueHints;

            checkBox_infiniteBombJump.Checked = settings.InfiniteBombJump;
            checkBox_wallJumping.Checked = settings.WallJumping;

            // locations
            for (int i = 0; i < dataGridView_locs.Rows.Count; i++)
            {
                if (settings.CustomAssignments.TryGetValue(i, out ItemType item))
                    dataGridView_locs.Rows[i].Cells[1].Value = item.Name();
            }

            // enemies
            checkBox_enemies.Checked = settings.RandoEnemies;

            // palettes
            checkBox_tilesetPalettes.Checked = settings.TilesetPalettes;
            checkBox_enemyPalettes.Checked = settings.EnemyPalettes;
            checkBox_samusPalettes.Checked = settings.SamusPalettes;
            checkBox_beamPalettes.Checked = settings.BeamPalettes;
            numericUpDown_hueMin.Value = settings.HueMinimum;
            numericUpDown_hueMax.Value = settings.HueMaximum;

            //music
            comboBox_musicRoom.SelectedIndex = (int)settings.RoomMusic;
            comboBox_musicBoss.SelectedIndex = (int)settings.BossMusic;
            checkBox_customMusic.Checked = settings.CustomMusic;

            //text
            checkBox_itemText.Checked = settings.ItemText;
            checkBox_areaText.Checked = settings.AreaText;
            checkBox_miscText.Checked = settings.MiscText;
            checkBox_cutsceneText.Checked = settings.CutsceneText;

            //stats
            checkBox_enemyHealth.Checked = settings.EnemyHealth;
            checkBox_enemyDamage.Checked = settings.EnemyDamage;
            checkBox_enemyWeakness.Checked = settings.EnemyWeakness;
            checkBox_enemyDrops.Checked = settings.EnemyDrops;
            numericUpDown_healthMin.Value = settings.HealthMinimum;
            numericUpDown_healthMax.Value = settings.HealthMaximum;
            numericUpDown_damageMin.Value = settings.DamageMinimum;
            numericUpDown_damageMax.Value = settings.DamageMaximum;

            // misc
            checkBox_enableItemToggle.Checked = settings.EnableItemToggle;
            checkBox_obtainUnkItems.Checked = settings.ObtainUnkItems;
            checkBox_hardModeAvailable.Checked = settings.HardModeAvailable;
            checkBox_pauseScreenInfo.Checked = settings.PauseScreenInfo;
            checkBox_removeCutscenes.Checked = settings.RemoveCutscenes;
            checkBox_skipSuitless.Checked = settings.SkipSuitless;
            checkBox_skipDoorTransitions.Checked = settings.SkipDoorTransitions;

            disableEvents = false;
        }

        private Settings GetSettingsFromState()
        {
            Settings settings = new Settings();

            // items
            settings.AbilitySwap = (Swap)comboBox_abilities.SelectedIndex;
            settings.TankSwap = (Swap)comboBox_tanks.SelectedIndex;
            settings.NumItemsRemoved = (int)numericUpDown_itemsRemove.Value;

            int idx = comboBox_abilitiesRemove.SelectedIndex;
            if (idx <= 0) settings.NumAbilitiesRemoved = null;
            else settings.NumAbilitiesRemoved = idx - 1;

            if (radioButton_completionNoLogic.Checked) settings.Completion = GameCompletion.NoLogic;
            else if (radioButton_completionBeatable.Checked) settings.Completion = GameCompletion.Beatable;
            else if (radioButton_completion100.Checked) settings.Completion = GameCompletion.AllItems;

            settings.IceNotRequired = checkBox_iceNotRequired.Checked;
            settings.PlasmaNotRequired = checkBox_plasmaNotRequired.Checked;
            settings.NoPBsBeforeChozodia = checkBox_noEarlyChozodia.Checked;
            settings.ChozoStatueHints = checkBox_chozoStatueHints.Checked;

            settings.InfiniteBombJump = checkBox_infiniteBombJump.Checked;
            settings.WallJumping = checkBox_wallJumping.Checked;

            // locations
            settings.CustomAssignments = new Dictionary<int, ItemType>();
            string[] itemNames = Item.Names;
            for (int i = 0; i < dataGridView_locs.Rows.Count; i++)
            {
                string val = (string)dataGridView_locs.Rows[i].Cells[1].Value;
                var item = (ItemType)Array.IndexOf(itemNames, val);
                if (item != ItemType.Undefined)
                    settings.CustomAssignments[i] = item;
            }

            // enemies
            settings.RandoEnemies = checkBox_enemies.Checked;

            // palettes
            settings.TilesetPalettes = checkBox_tilesetPalettes.Checked;
            settings.EnemyPalettes = checkBox_enemyPalettes.Checked;
            settings.SamusPalettes = checkBox_samusPalettes.Checked;
            settings.BeamPalettes = checkBox_beamPalettes.Checked;
            settings.HueMinimum = (int)numericUpDown_hueMin.Value;
            settings.HueMaximum = (int)numericUpDown_hueMax.Value;

            //music
            settings.RoomMusic = (Song)comboBox_musicRoom.SelectedIndex;
            settings.BossMusic = (Song)comboBox_musicBoss.SelectedIndex;
            settings.CustomMusic = checkBox_customMusic.Checked;

            //text
            settings.ItemText = checkBox_itemText.Checked;
            settings.AreaText = checkBox_areaText.Checked;
            settings.MiscText = checkBox_miscText.Checked;
            settings.CutsceneText = checkBox_cutsceneText.Checked;

            //enemy stats
            settings.EnemyHealth = checkBox_enemyHealth.Checked;
            settings.EnemyDamage = checkBox_enemyDamage.Checked;
            settings.EnemyWeakness = checkBox_enemyWeakness.Checked;
            settings.EnemyDrops = checkBox_enemyDrops.Checked;
            settings.HealthMinimum = (int)numericUpDown_healthMin.Value;
            settings.HealthMaximum = (int)numericUpDown_healthMax.Value;
            settings.DamageMinimum = (int)numericUpDown_damageMin.Value;
            settings.DamageMaximum = (int)numericUpDown_damageMax.Value;

            // misc
            settings.EnableItemToggle = checkBox_enableItemToggle.Checked;
            settings.ObtainUnkItems = checkBox_obtainUnkItems.Checked;
            settings.HardModeAvailable = checkBox_hardModeAvailable.Checked;
            settings.PauseScreenInfo = checkBox_pauseScreenInfo.Checked;
            settings.RemoveCutscenes = checkBox_removeCutscenes.Checked;
            settings.SkipSuitless = checkBox_skipSuitless.Checked;
            settings.SkipDoorTransitions = checkBox_skipDoorTransitions.Checked;

            return settings;
        }

        private void button_openROM_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "GBA ROM Files (*.gba)|*.gba";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    origFile = openFile.FileName;
                    OpenROM(origFile);
                }
            }
        }

        private void button_randomize_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.Filter = "GBA ROM Files (*.gba)|*.gba";
                    if (saveFile.ShowDialog() != DialogResult.OK) { return; }

                    if (saveFile.FileName == origFile)
                    {
                        var result = MessageBox.Show(
                            "This is the original ROM. Do you want to overwrite it?",
                            "Warning",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);
                        if (result == DialogResult.No) { continue; }
                        else if (result == DialogResult.Cancel) { return; }
                    }

                    Randomize(saveFile.FileName);
                    break;
                }
            }
            
        }

        private void button_loadSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(this);
            form.ShowDialog();
        }

        private void button_saveSettings_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Config files (*.cfg)|*.cfg";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    Settings settings = GetSettingsFromState();
                    File.WriteAllText(saveFile.FileName, settings.GetString());
                }
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
                rom = new Rom(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.prevRomPath = filename;
            Properties.Settings.Default.Save();

            Settings settings;
            if (Properties.Settings.Default.rememberSettings)
                settings = new Settings(Properties.Settings.Default.prevSettings);
            else
                settings = new Settings();

            SetStateFromSettings(settings);
            ToggleControls(true);
        }

        private void Randomize(string filename)
        {
            if (!ValidateCustomAssignments()) { return; }

            // get seed
            if (!int.TryParse(textBox_seed.Text, out int seed))
            {
                Random temp = new Random();
                seed = temp.Next();
            }

            // get settings
            Settings settings = GetSettingsFromState();
            string config = settings.GetString();
            if (Properties.Settings.Default.rememberSettings)
            {
                Properties.Settings.Default.prevSettings = config;
                Properties.Settings.Default.Save();
            }

            // randomize
            RandomAll randAll = new RandomAll(rom, settings, seed);
            bool success = randAll.Randomize();

            if (!success)
            {
                MessageBox.Show("Randomization failed.\n\nTry changing your settings.");
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
                DialogResult result = MessageBox.Show("Would you like to save a log file?", "", MessageBoxButtons.YesNo);
                saveLogFile = (result == DialogResult.Yes);
            }
            if (saveLogFile)
            {
                string path = Path.ChangeExtension(filename, "log");
                File.WriteAllText(path, randAll.GetLog());
                writtenFiles += $"Log file saved to\n{path}\n\n";
            }

            // map images
            if (settings.SwapOrRemoveItems)
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
                    writtenFiles += $"Map images saved to\n{path}";
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
            form.Dispose();

            // clean up
            Reset();
        }

        private ItemType GetCustomAssignment(int number)
        {
            string[] itemNames = Item.Names;
            string val = (string)dataGridView_locs.Rows[number].Cells[1].Value;
            return (ItemType)Array.IndexOf(itemNames, val);
        }

        private bool ValidateCustomAssignments()
        {
            // count each type selected
            Dictionary<ItemType, int> counts = new Dictionary<ItemType, int>();
            for (int i = 0; i < 100; i++)
            {
                ItemType item = GetCustomAssignment(i);
                if (item == ItemType.Undefined) { continue; }

                if (counts.ContainsKey(item))
                {
                    counts[item]++;
                }
                else
                {
                    counts[item] = 1;
                }
            }
            // check each type against maximum count
            foreach (KeyValuePair<ItemType, int> kvp in counts)
            {
                ItemType item = kvp.Key;
                int max = item.MaxNumber();
                if (kvp.Value > max)
                {
                    string name = item.Name();
                    if (max > 1) { name += "s"; }
                    MessageBox.Show(
                        $"More than {max} {name} selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void UpdateRemoveItems()
        {
            int numItems = (int)numericUpDown_itemsRemove.Value;
            bool enable = numItems > 0;
            int prevIdx = comboBox_abilitiesRemove.SelectedIndex;
            comboBox_abilitiesRemove.Items.Clear();

            if (enable)
            {
                int end = Math.Min(numItems, 10);
                comboBox_abilitiesRemove.Items.Add("Random");
                comboBox_abilitiesRemove.Items.AddRange(Arrays.IntRange(end + 1));
                if (prevIdx == -1)
                    comboBox_abilitiesRemove.SelectedIndex = 0;
                else
                    comboBox_abilitiesRemove.SelectedIndex = Math.Min(prevIdx, end);
            }
            else
                comboBox_abilitiesRemove.SelectedIndex = -1;

            label_abilitiesRemove.Enabled = enable;
            comboBox_abilitiesRemove.Enabled = enable;
        }

        private void NumericUpDown_itemsRemove_ValueChanged(object sender, EventArgs e)
        {
            if (disableEvents) return;
            disableEvents = true;
            UpdateRemoveItems();
            disableEvents = false;
        }

        private void NumericUpDown_hueMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMax.Minimum = numericUpDown_hueMin.Value;
        }

        private void NumericUpDown_hueMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMin.Maximum = numericUpDown_hueMax.Value;
        }

        private void NumericUpDown_healthMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_healthMax.Minimum = numericUpDown_healthMin.Value;
        }

        private void NumericUpDown_healthMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_healthMin.Maximum = numericUpDown_healthMax.Value;
        }

        private void NumericUpDown_damageMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_damageMax.Minimum = numericUpDown_damageMin.Value;
        }

        private void NumericUpDown_damageMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_damageMin.Maximum = numericUpDown_damageMax.Value;
        }
    }
}
