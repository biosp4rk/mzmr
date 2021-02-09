﻿using Common.Key;
using Common.SaveData;
using mzmr.Items;
using mzmr.Randomizers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormMain : Form
    {
        private Rom rom;
        private SaveData logicData;
        private string origFile;
        private string logicFile;

        public FormMain()
        {
            InitializeComponent();

            FillLocations();
            Reset();
            CheckForUpdate();
        }

        private void FillLocations()
        {
            // get item names for dropdown
            Array itemTypes = Enum.GetValues(typeof(ItemType));
            List<string> options = new List<string>();
            foreach (ItemType item in itemTypes)
            {
                options.Add(item.Name());
            }
            string[] itemNames = options.ToArray();

            // add row for each location
            Location[] locations = Items.Location.GetLocations();
            for (int i = 0; i < 100; i++)
            {
                Label label1 = new Label
                {
                    AutoSize = true,
                    Margin = new Padding(4, 5, 4, 0),
                    Text = i.ToString()
                };
                ComboBox cb = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Name = $"loc{i}"
                };
                cb.Items.AddRange(itemNames);
                Label label2 = new Label
                {
                    Margin = new Padding(4, 5, 4, 0),
                    Text = locations[i].OrigItem.Name()
                };

                tableLayoutPanel_locs.Controls.Add(label1);
                tableLayoutPanel_locs.Controls.Add(cb);
                tableLayoutPanel_locs.Controls.Add(label2);
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

            DialogResult result = MessageBox.Show(
                $"A newer version of MZM Randomizer is available ({e.Result}). Would you like to download it?",
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
            {
                tab.Enabled = toggle;
            }
        }

        public void SetStateFromSettings(Settings settings)
        {
            // items
            checkBox_itemsAbilities.Checked = settings.randomAbilities;
            checkBox_itemsTanks.Checked = settings.randomTanks;
            numericUpDown_itemsRemove.Value = settings.numItemsRemoved;

            radioButton_completionUnchanged.Checked = (settings.gameCompletion == GameCompletion.Unchanged);
            radioButton_completionBeatable.Checked = (settings.gameCompletion == GameCompletion.Beatable);
            radioButton_completion100.Checked = (settings.gameCompletion == GameCompletion.AllItems);

            checkBox_iceNotRequired.Checked = settings.iceNotRequired;
            checkBox_plasmaNotRequired.Checked = settings.plasmaNotRequired;
            checkBox_noPBsBeforeChozodia.Checked = settings.noPBsBeforeChozodia;
            checkBox_chozoStatueHints.Checked = settings.chozoStatueHints;

            checkBox_infiniteBombJump.Checked = settings.infiniteBombJump;
            checkBox_wallJumping.Checked = settings.wallJumping;

            // locations
            for (int i = 0; i < 100; i++)
            {
                int index = 0;
                if (settings.customAssignments.TryGetValue(i, out ItemType item))
                {
                    index = (int)item;
                }
                string key = $"loc{i}";
                ComboBox cb = tableLayoutPanel_locs.Controls[key] as ComboBox;
                cb.SelectedIndex = index;
            }

            // enemies
            checkBox_enemies.Checked = settings.randomEnemies;

            // palettes
            checkBox_tilesetPalettes.Checked = settings.tilesetPalettes;
            checkBox_enemyPalettes.Checked = settings.enemyPalettes;
            checkBox_beamPalettes.Checked = settings.beamPalettes;
            numericUpDown_hueMin.Value = settings.hueMinimum;
            numericUpDown_hueMax.Value = settings.hueMaximum;

            // rules
            SetItemRulesFromSettings(settings.rules);

            // logic
            switch(settings.logicType)
            {
                case LogicType.Old:
                    radioButton_oldLogic.Checked = true;
                    break;
                case LogicType.New:
                    radioButton_newLogic.Checked = true;
                    break;
                case LogicType.Custom:
                    radioButton_customLogic.Checked = true;
                    break;
            }

            settings.logicData = logicData;
            UpdateLogicSettings(null, null);
            SetLogicSettingsFromSettings(settings.logicSettings);

            // misc
            checkBox_enableItemToggle.Checked = settings.enableItemToggle;
            checkBox_obtainUnkItems.Checked = settings.obtainUnkItems;
            checkBox_hardModeAvailable.Checked = settings.hardModeAvailable;
            checkBox_pauseScreenInfo.Checked = settings.pauseScreenInfo;
            checkBox_removeCutscenes.Checked = settings.removeCutscenes;
            checkBox_skipSuitless.Checked = settings.skipSuitless;
            checkBox_skipDoorTransitions.Checked = settings.skipDoorTransitions;
        }

        private Settings GetSettingsFromState()
        {
            Settings settings = new Settings();

            // items
            settings.randomAbilities = checkBox_itemsAbilities.Checked;
            settings.randomTanks = checkBox_itemsTanks.Checked;
            settings.numItemsRemoved = (int)numericUpDown_itemsRemove.Value;

            if (radioButton_completionUnchanged.Checked) { settings.gameCompletion = GameCompletion.Unchanged; }
            else if (radioButton_completionBeatable.Checked) { settings.gameCompletion = GameCompletion.Beatable; }
            else if (radioButton_completion100.Checked) { settings.gameCompletion = GameCompletion.AllItems; }

            settings.iceNotRequired = checkBox_iceNotRequired.Checked;
            settings.plasmaNotRequired = checkBox_plasmaNotRequired.Checked;
            settings.noPBsBeforeChozodia = checkBox_noPBsBeforeChozodia.Checked;
            settings.chozoStatueHints = checkBox_chozoStatueHints.Checked;

            settings.infiniteBombJump = checkBox_infiniteBombJump.Checked;
            settings.wallJumping = checkBox_wallJumping.Checked;

            // locations
            settings.customAssignments = new Dictionary<int, ItemType>();
            for (int i = 0; i < 100; i++)
            {
                ItemType item = GetCustomAssignment(i);
                if (item != ItemType.Undefined)
                {
                    settings.customAssignments[i] = item;
                }
            }

            // enemies
            settings.randomEnemies = checkBox_enemies.Checked;

            // palettes
            settings.tilesetPalettes = checkBox_tilesetPalettes.Checked;
            settings.enemyPalettes = checkBox_enemyPalettes.Checked;
            settings.beamPalettes = checkBox_beamPalettes.Checked;
            settings.hueMinimum = (int)numericUpDown_hueMin.Value;
            settings.hueMaximum = (int)numericUpDown_hueMax.Value;

            // rules
            settings.rules = GetItemRules();

            // logic
            if (radioButton_oldLogic.Checked) { settings.logicType = LogicType.Old; }
            else if (radioButton_newLogic.Checked) { settings.logicType = LogicType.New; }
            else if (radioButton_customLogic.Checked) { settings.logicType = LogicType.Custom; }
            settings.logicData = logicData;
            settings.logicSettings = GetLogicSettings();

            // misc
            settings.enableItemToggle = checkBox_enableItemToggle.Checked;
            settings.obtainUnkItems = checkBox_obtainUnkItems.Checked;
            settings.hardModeAvailable = checkBox_hardModeAvailable.Checked;
            settings.pauseScreenInfo = checkBox_pauseScreenInfo.Checked;
            settings.removeCutscenes = checkBox_removeCutscenes.Checked;
            settings.skipSuitless = checkBox_skipSuitless.Checked;
            settings.skipDoorTransitions = checkBox_skipDoorTransitions.Checked;

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
            if (!ValidateCustomAssignments()) { return; }
            if (!ValidateRules()) { return; }

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

            var randAll = new RandomAll(rom, settings, seed);

            var randomForm = new FormProgress(randAll);
            randomForm.StartPosition = FormStartPosition.CenterParent;
            randomForm.ShowDialog();

            if (randomForm.Result == RandomizationResult.Aborted)
            {
                Reset();
                return;
            }

            if (randomForm.Result == RandomizationResult.Failed)
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
            string key = $"loc{number}";
            ComboBox cb = tableLayoutPanel_locs.Controls[key] as ComboBox;
            return (ItemType)cb.SelectedIndex;
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

        private void numericUpDown_hueMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMax.Minimum = numericUpDown_hueMin.Value;
        }

        private void numericUpDown_hueMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMin.Maximum = numericUpDown_hueMax.Value;
        }

        private void button_customLogicPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Logic Files (*.lgc)|*.lgc";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    logicFile = openFile.FileName;
                    textBox_customLogicPath.Text = logicFile;

                    // Scroll text in textbox to end
                    textBox_customLogicPath.SelectionStart = textBox_customLogicPath.Text.Length - 1;
                    textBox_customLogicPath.SelectionLength = 0;
                    textBox_customLogicPath.ScrollToCaret();

                    if (!radioButton_customLogic.Checked)
                    {
                        radioButton_customLogic.Checked = true;
                    }
                    else
                    {
                        UpdateLogicSettings(sender, e);
                    }
                }
            }
        }

        private void UpdateLogicSettings(object sender, EventArgs e)
        {
            logicData = null;
            if (radioButton_newLogic.Checked)
            {
                try
                {
                    var resourceReader = new StreamReader(new MemoryStream(Properties.Resources.Item_Logic));
                    var data = JsonConvert.DeserializeObject<SaveData>(resourceReader.ReadToEnd());
                    logicData = data;
                }
                catch (Exception)
                {
                    MessageBox.Show("Logic data couldn't be loaded", "Logic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (radioButton_customLogic.Checked)
            {
                logicData = null;
                if (!string.IsNullOrWhiteSpace(textBox_customLogicPath.Text))
                {
                    try
                    {
                        var data = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(textBox_customLogicPath.Text));
                        logicData = data;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Custom Logic file \"{textBox_customLogicPath.Text}\" couldn't be loaded", "Logic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            tableLayoutPanel_customSettings.Controls.Clear();
            if (logicData != null)
            {
                KeyManager.Initialize(logicData);
                var customSettings = KeyManager.GetSettingKeys().Where(key => !key.Static).OrderBy(setting => setting.Name);

                // Add checkbox for each setting
                foreach (var setting in customSettings)
                {
                    var cb = new CheckBox()
                    {
                        AutoSize = true,
                        Text = setting.Name,
                        Tag = setting.Id,
                    };

                    tableLayoutPanel_customSettings.Controls.Add(cb);
                }
            }
        }

        private bool[] GetLogicSettings()
        {
            var checkBoxes = tableLayoutPanel_customSettings.Controls.OfType<CheckBox>();

            var indexList = new bool[checkBoxes.Count()];
            for(int i = 0; i < checkBoxes.Count(); i++)
            {
                indexList[i] = checkBoxes.ElementAt(i).Checked;
            }

            return indexList;
        }

        private void SetLogicSettingsFromSettings(bool[] logicSettings)
        {
            var checkBoxes = tableLayoutPanel_customSettings.Controls.OfType<CheckBox>();

            for (int i = 0; i < checkBoxes.Count() && i < logicSettings.Length; i++)
            {
                checkBoxes.ElementAt(i).Checked = logicSettings[i];
            }
        }

        private void buttonNewRule_Click(object sender, EventArgs e)
        {
            var row = dataGridViewRules.Rows[dataGridViewRules.Rows.Add()];

            var cell1 = (DataGridViewComboBoxCell)row.Cells[columnItem.Index];
            var itemTypes = ItemRules.RuleTypes.GetItemTypeNames();
            cell1.DataSource = itemTypes;
            cell1.Value = itemTypes[0];

            var cell2 = (DataGridViewComboBoxCell)row.Cells[columnType.Index];
            var ruleNames = ItemRules.RuleTypes.GetRuleDescriptions();
            cell2.DataSource = ruleNames;
            cell2.Value = ruleNames[0];

            SetDataGridValueColumn(row, 0);
        }

        private void dataGridViewRules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == columnType.Index)
            {
                var row = dataGridViewRules.Rows[e.RowIndex];

                SetDataGridValueColumn(row, 0);
            }
        }

        private void SetDataGridValueColumn(DataGridViewRow row, int value)
        {
            var typeCell = row.Cells[columnType.Index];
            var typeName = (string)typeCell.Value;

            var valueCell = (DataGridViewComboBoxCell)row.Cells[columnData.Index];

            switch (ItemRules.RuleTypes.RuleDescriptionToType(typeName))
            {
                case ItemRules.RuleTypes.RuleType.RestrictedBeforeSearchDepth:
                case ItemRules.RuleTypes.RuleType.PrioritizedAfterSearchDepth:
                    var numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", };

                    valueCell.DataSource = numbers;
                    valueCell.Value = numbers[value < numbers.Length ? value : 0];
                    valueCell.ReadOnly = false;
                    break;
                case ItemRules.RuleTypes.RuleType.InLocation:
                case ItemRules.RuleTypes.RuleType.NotInLocation:
                    var locations = Items.Location.GetLocations().Select(location => location.LogicName).ToList();

                    valueCell.DataSource = locations;
                    valueCell.Value = locations[value < locations.Count ? value : 0];
                    valueCell.ReadOnly = false;
                    break;
                case ItemRules.RuleTypes.RuleType.InArea:
                case ItemRules.RuleTypes.RuleType.NotInArea:
                    var areas = ItemRules.RuleTypes.GetAreaNames();

                    valueCell.DataSource = areas;
                    valueCell.Value = ItemRules.RuleTypes.AreaIndexToName(value);
                    valueCell.ReadOnly = false;
                    break;
                default:
                    valueCell.DataSource = null;
                    valueCell.Value = null;
                    valueCell.ReadOnly = true;
                    break;
            }
        }

        private void dataGridViewRules_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridViewRules.EndEdit();
        }

        private void dataGridViewRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != columnDelete.Index)
                return;

            dataGridViewRules.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridViewRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < columnItem.Index)
                return;

            dataGridViewRules.BeginEdit(true);
            var control = (ComboBox)dataGridViewRules.EditingControl;
            if (control != null)
            {
                control.DroppedDown = true;
            }
        }

        private void SetItemRulesFromSettings(List<ItemRules.ItemRule> rules)
        {
            dataGridViewRules.Rows.Clear();

            if (rules == null)
                return;

            foreach (var rule in rules)
            {
                var row = dataGridViewRules.Rows[dataGridViewRules.Rows.Add()];

                var cell1 = (DataGridViewComboBoxCell)row.Cells[columnItem.Index];
                var itemTypes = ItemRules.RuleTypes.GetItemTypeNames();
                cell1.DataSource = itemTypes;
                cell1.Value = ItemRules.RuleTypes.ItemTypeToName(rule.ItemType);

                var cell2 = (DataGridViewComboBoxCell)row.Cells[columnType.Index];
                var ruleNames = ItemRules.RuleTypes.GetRuleDescriptions();
                cell2.DataSource = ruleNames;
                cell2.Value = ItemRules.RuleTypes.RuleTypeToDescription(rule.RuleType);

                SetDataGridValueColumn(row, rule.Value);
            }
        }

        private List<ItemRules.ItemRule> GetItemRules()
        {
            var ruleList = new List<ItemRules.ItemRule>();
            foreach (DataGridViewRow row in dataGridViewRules.Rows)
            {
                var rule = new ItemRules.ItemRule();
                rule.ItemType = ItemRules.RuleTypes.ItemNameToType((string)row.Cells[columnItem.Index].Value);
                rule.RuleType = ItemRules.RuleTypes.RuleDescriptionToType((string)row.Cells[columnType.Index].Value);
                var dataCellValue = (string)row.Cells[columnData.Index].Value;
                switch (rule.RuleType)
                {
                    case ItemRules.RuleTypes.RuleType.RestrictedBeforeSearchDepth:
                    case ItemRules.RuleTypes.RuleType.PrioritizedAfterSearchDepth:
                        rule.Value = int.Parse(dataCellValue);
                        break;
                    case ItemRules.RuleTypes.RuleType.InLocation:
                    case ItemRules.RuleTypes.RuleType.NotInLocation:
                        rule.Value = Items.Location.GetLocations().FirstOrDefault(x => x.LogicName == dataCellValue).Number;
                        break;
                    case ItemRules.RuleTypes.RuleType.InArea:
                    case ItemRules.RuleTypes.RuleType.NotInArea:
                        rule.Value = ItemRules.RuleTypes.AreaNameToIndex(dataCellValue);
                        break;
                }

                ruleList.Add(rule);
            }

            return ruleList.Distinct().ToList();
        }

        private bool ValidateRules()
        {
            var errors = new List<string>();
            var rules = GetItemRules();
            var groupedRules = rules.GroupBy(x => x.ItemType);
            foreach (var itemGrouping in groupedRules)
            {
                Items.Location.GetLocations().Select(location => location.LogicName).ToList();
                var requiredLocations = itemGrouping.Where(x => x.RuleType == ItemRules.RuleTypes.RuleType.InLocation).Select(x => x.Value).ToList();
                requiredLocations.AddRange(itemGrouping.Where(x => x.RuleType == ItemRules.RuleTypes.RuleType.InArea)
                    .SelectMany(rule => Items.Location.GetLocations().Where(location => location.Area == rule.Value).Select(x => x.Number)));
                
                var restrictedLocations = itemGrouping.Where(x => x.RuleType == ItemRules.RuleTypes.RuleType.NotInLocation).Select(x => x.Value).ToList();
                restrictedLocations.AddRange(itemGrouping.Where(x => x.RuleType == ItemRules.RuleTypes.RuleType.NotInArea)
                    .SelectMany(rule => Items.Location.GetLocations().Where(location => location.Area == rule.Value).Select(x => x.Number)));

                var intersectingLocations = requiredLocations.Intersect(restrictedLocations);
                foreach(var location in intersectingLocations)
                {
                    errors.Add($"\"{itemGrouping.Key.ToString()}\" can't both be and NOT be in \"{location}\".");
                }

                foreach (var item in groupedRules)
                {
                    var itemRules = item.Where(rule => rule.RuleType == ItemRules.RuleTypes.RuleType.InLocation).Select(rule => rule.Value);
                    
                    if (requiredLocations.Intersect(itemRules).Any() && requiredLocations.Except(itemRules).Any())
                    {
                        errors.Add($"\"{itemGrouping.Key.ToString()}\" is sharing some but not all required locations with \"{item.Key.ToString()}\".");
                    }
                }
            }

            if (errors.Any())
            {
                MessageBox.Show(
                    $"The following errors occured:" + Environment.NewLine + errors.Aggregate((x, y) => x + Environment.NewLine + y),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}
