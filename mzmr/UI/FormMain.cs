using Common.Key;
using Common.SaveData;
using mzmr.Items;
using mzmr.Randomizers;
using mzmr.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace mzmr.UI
{
    public partial class FormMain : Form
    {
        private Rom rom;
        private SaveData logicData;
        private string origFile;
        private bool disableEvents;
        private string logicFile;

        public FormMain()
        {
            InitializeComponent();

            FillLocations();
            Reset();
        }

        private void FillLocations()
        {
            dataGridView_locs.ColumnCount = 4;
            dataGridView_locs.Columns[0].HeaderText = "#";
            dataGridView_locs.Columns[1].HeaderText = "Location";
            dataGridView_locs.Columns[2].HeaderText = "New item";
            dataGridView_locs.Columns[3].HeaderText = "Original item";
            dataGridView_locs.Columns[0].Width = 35;
            dataGridView_locs.Columns[1].Width = 110;
            dataGridView_locs.Columns[2].Width = 125;
            dataGridView_locs.Columns[3].Width = 120;
            string[] itemNames = Item.Names;

            Location[] locations = Items.Location.GetLocations();
            for (int i = 0; i < locations.Length; i++)
            {
                Location loc = locations[i];
                var row = new DataGridViewRow();

                var cell0 = new DataGridViewTextBoxCell();
                cell0.Value = i;
                row.Cells.Add(cell0);
                cell0.ReadOnly = true;

                var cell1 = new DataGridViewTextBoxCell();
                string areaName = Rom.AreaNames[loc.Area];
                string ls = $"{areaName} ({loc.MinimapX}, {loc.MinimapY})";
                cell1.Value = ls;
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

        private void Reset()
        {
            // disable controls
            ToggleControls(false);
            rom = null;
            disableEvents = true;

            checkBox_saveLogFile.Checked = Properties.Settings.Default.saveLogFile;
            checkBox_saveMapImages.Checked = Properties.Settings.Default.saveMapImages;

            // try loading last rom used
            string path = Properties.Settings.Default.prevRomPath;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                OpenROM(path);

            disableEvents = false;
        }

        private void ToggleControls(bool toggle)
        {
            button_randomize.Enabled = toggle;
            label_seed.Enabled = toggle;
            textBox_seed.Enabled = toggle;
            label_settings.Enabled = toggle;
            textBox_settings.Enabled = toggle;
            button_loadSettings.Enabled = toggle;
            button_saveSettings.Enabled = toggle;
            checkBox_saveLogFile.Enabled = toggle;
            checkBox_saveMapImages.Enabled = toggle;

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

            // locations
            for (int i = 0; i < dataGridView_locs.Rows.Count; i++)
            {
                if (!settings.CustomAssignments.TryGetValue(i, out ItemType item))
                    item = ItemType.Undefined;

                dataGridView_locs.Rows[i].Cells[2].Value = item.Name();
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

            // rules
            SetItemRulesFromSettings(settings.rules);

            // logic
            if (settings.customLogic)
                radioButton_customLogic.Checked = true;
            else
                radioButton_defaultLogic.Checked = true;
            settings.logicData = logicData;
            UpdateLogicSettings();
            SetLogicSettingsFromSettings(settings.logicSettings);

            // misc
            checkBox_enableItemToggle.Checked = settings.EnableItemToggle;
            checkBox_obtainUnkItems.Checked = settings.ObtainUnkItems;
            checkBox_hardModeAvailable.Checked = settings.HardModeAvailable;
            checkBox_pauseScreenInfo.Checked = settings.PauseScreenInfo;
            checkBox_removeCutscenes.Checked = settings.RemoveCutscenes;
            checkBox_skipSuitless.Checked = settings.SkipSuitless;
            checkBox_skipDoorTransitions.Checked = settings.SkipDoorTransitions;
            checkBox_disableInfiniteBombJump.Checked = settings.DisableInfiniteBombJump;
            checkBox_disableWalljump.Checked = settings.DisableWallJump;

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
            if (idx <= 0) { settings.NumAbilitiesRemoved = null; }
            else settings.NumAbilitiesRemoved = idx - 1;

            if (radioButton_completionNoLogic.Checked) settings.Completion = GameCompletion.NoLogic;
            else if (radioButton_completionBeatable.Checked) settings.Completion = GameCompletion.Beatable;
            else if (radioButton_completion100.Checked) settings.Completion = GameCompletion.AllItems;

            settings.IceNotRequired = checkBox_iceNotRequired.Checked;
            settings.PlasmaNotRequired = checkBox_plasmaNotRequired.Checked;
            settings.NoPBsBeforeChozodia = checkBox_noEarlyChozodia.Checked;
            settings.ChozoStatueHints = checkBox_chozoStatueHints.Checked;

            // locations
            settings.CustomAssignments = new Dictionary<int, ItemType>();
            string[] itemNames = Item.Names;
            for (int i = 0; i < dataGridView_locs.Rows.Count; i++)
            {
                string val = (string)dataGridView_locs.Rows[i].Cells[2].Value;
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

            // rules
            settings.rules = GetItemRules();

            // logic
            settings.customLogic = radioButton_customLogic.Checked;
            settings.logicData = logicData;
            settings.logicSettings = GetLogicSettings();

            // misc
            settings.EnableItemToggle = checkBox_enableItemToggle.Checked;
            settings.ObtainUnkItems = checkBox_obtainUnkItems.Checked;
            settings.HardModeAvailable = checkBox_hardModeAvailable.Checked;
            settings.PauseScreenInfo = checkBox_pauseScreenInfo.Checked;
            settings.RemoveCutscenes = checkBox_removeCutscenes.Checked;
            settings.SkipSuitless = checkBox_skipSuitless.Checked;
            settings.SkipDoorTransitions = checkBox_skipDoorTransitions.Checked;
            settings.DisableInfiniteBombJump = checkBox_disableInfiniteBombJump.Checked;
            settings.DisableWallJump = checkBox_disableWalljump.Checked;

            return settings;
        }

        #region Top

        private void Button_openROM_Click(object sender, EventArgs e)
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

        private void Button_randomize_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.Filter = "GBA ROM Files (*.gba)|*.gba";
                    if (saveFile.ShowDialog() != DialogResult.OK)
                        return;

                    if (saveFile.FileName == origFile)
                    {
                        var result = MessageBox.Show(
                            "This is the original ROM. Do you want to overwrite it?",
                            "Warning",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                            continue;
                        else if (result == DialogResult.Cancel)
                            return;
                    }

                    Randomize(saveFile.FileName);
                    break;
                }
            }
            
        }

        private void TextBox_settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_settings.Text == "")
                    return;

                SetSettingsFromString();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Button_loadSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Config files (*.cfg)|*.cfg";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_settings.Text = File.ReadAllText(openFile.FileName);
                }
                catch
                {
                    MessageBox.Show("File could not be read.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            SetSettingsFromString();
        }

        private void Button_saveSettings_Click(object sender, EventArgs e)
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

        private void CheckBox_saveLogFile_CheckedChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            Properties.Settings.Default.saveLogFile = checkBox_saveLogFile.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBox_saveMapImages_CheckedChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            Properties.Settings.Default.saveMapImages = checkBox_saveMapImages.Checked;
            Properties.Settings.Default.Save();
        }

        private void SetSettingsFromString()
        {
            Settings settings;

            try
            {
                settings = new Settings(textBox_settings.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetStateFromSettings(settings);
        }

        private void OpenROM(string filename)
        {
            ToggleControls(false);

            try
            {
                rom = new Rom(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // save previous rom path
            Properties.Settings.Default.prevRomPath = filename;
            Properties.Settings.Default.Save();

            Settings settings = new Settings(Properties.Settings.Default.prevSettings);
            SetStateFromSettings(settings);
            ToggleControls(true);
        }

        private void Randomize(string filename)
        {
            if (!ValidateCustomAssignments())
                return;

            // get seed
            if (!int.TryParse(textBox_seed.Text, out int seed))
            {
                Random temp = new Random();
                seed = temp.Next();
            }

            // get settings and save as previous
            Settings settings = GetSettingsFromState();

            if (!ValidateLogicLoaded(settings))
                return;

            string config = settings.GetString();
            Properties.Settings.Default.prevSettings = config;
            Properties.Settings.Default.Save();

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

            // log file
            string logPath = null;
            if (Properties.Settings.Default.saveLogFile)
            {
                logPath = Path.ChangeExtension(filename, "log");
                File.WriteAllText(logPath, randAll.GetLog());
            }

            // map images
            string mapsPath = null;
            if (settings.SwapOrRemoveItems &&
                Properties.Settings.Default.saveMapImages)
            {
                mapsPath = Path.ChangeExtension(filename, null) + "_maps";
                Directory.CreateDirectory(mapsPath);
                Bitmap[] minimaps = randAll.GetMaps();
                minimaps[0].Save(Path.Combine(mapsPath, "brinstar.png"));
                minimaps[1].Save(Path.Combine(mapsPath, "kraid.png"));
                minimaps[2].Save(Path.Combine(mapsPath, "norfair.png"));
                minimaps[3].Save(Path.Combine(mapsPath, "ridley.png"));
                minimaps[4].Save(Path.Combine(mapsPath, "tourian.png"));
                minimaps[5].Save(Path.Combine(mapsPath, "crateria.png"));
                minimaps[6].Save(Path.Combine(mapsPath, "chozodia.png"));
            }

            // display seed and settings
            FormComplete form = new FormComplete(seed, config, logPath, mapsPath);
            form.ShowDialog();
            form.Dispose();

            // clean up
            Reset();
        }

        #endregion

        #region Items

        private ItemType GetCustomAssignment(int number)
        {
            string[] itemNames = Item.Names;
            string val = (string)dataGridView_locs.Rows[number].Cells[2].Value;
            return (ItemType)Array.IndexOf(itemNames, val);
        }

        private bool ValidateCustomAssignments()
        {
            // count each type selected
            Dictionary<ItemType, int> counts = new Dictionary<ItemType, int>();
            for (int i = 0; i < 100; i++)
            {
                ItemType item = GetCustomAssignment(i);
                if (item == ItemType.Undefined)
                    continue;

                if (counts.ContainsKey(item))
                    counts[item]++;
                else
                    counts[item] = 1;
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

        #endregion

        #region Logic

        private bool ValidateLogicLoaded(Settings settings)
        {
            if (settings.logicData == null)
            {
                MessageBox.Show(
                    $"No logic file loaded",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Button_customLogicPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Logic Files (*.lgc)|*.lgc";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    SetCustomLogic(openFile.FileName);

                    if (!radioButton_customLogic.Checked)
                        radioButton_customLogic.Checked = true;
                    else
                        UpdateLogicSettings();
                }
            }
        }

        public void SetCustomLogic(string logicPath)
        {
            logicFile = logicPath;
            textBox_customLogicPath.Text = logicFile;

            if (!string.IsNullOrEmpty(logicFile))
            {
                // Scroll text in textbox to end
                textBox_customLogicPath.SelectionStart = textBox_customLogicPath.Text.Length - 1;
                textBox_customLogicPath.SelectionLength = 0;
                textBox_customLogicPath.ScrollToCaret();
            }
        }

        private void RadioButton_logic_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogicSettings();
        }

        private bool LoadDefaultLogic()
        {
            try
            {
                var resourceReader = new StreamReader(
                    new MemoryStream(Properties.Resources.Item_Logic));
                var data = JsonConvert.DeserializeObject<SaveData>(resourceReader.ReadToEnd());
                logicData = data;
            }
            catch (Exception)
            {
                MessageBox.Show("Logic data couldn't be loaded",
                    "Logic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateLogicSettings()
        {
            logicData = null;

            if (radioButton_defaultLogic.Checked)
            {
                if (!LoadDefaultLogic())
                    return;
            }
            else if (radioButton_customLogic.Checked)
            {
                // load custom logic file
                if (!string.IsNullOrWhiteSpace(textBox_customLogicPath.Text))
                {
                    try
                    {
                        var data = JsonConvert.DeserializeObject<SaveData>(
                            File.ReadAllText(textBox_customLogicPath.Text));
                        logicData = data;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Custom Logic file \"{textBox_customLogicPath.Text}\" couldn't be loaded",
                            "Logic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // add settings to Logic tab
            tableLayoutPanel_customSettings.Controls.Clear();
            if (logicData != null)
            {
                KeyManager.Initialize(logicData);
                var customSettings = KeyManager.GetSettingKeys()
                    .Where(key => !key.Static).OrderBy(setting => setting.Name);

                // add checkbox for each setting
                foreach (var setting in customSettings)
                {
                    CheckBox cb = new CheckBox()
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
            for (int i = 0; i < checkBoxes.Count(); i++)
                indexList[i] = checkBoxes.ElementAt(i).Checked;

            return indexList;
        }

        private void SetLogicSettingsFromSettings(bool[] logicSettings)
        {
            if (logicSettings == null)
                return;

            var checkBoxes = tableLayoutPanel_customSettings.Controls.OfType<CheckBox>();
            for (int i = 0; i < checkBoxes.Count() && i < logicSettings.Length; i++)
                checkBoxes.ElementAt(i).Checked = logicSettings[i];
        }

        #endregion

        #region Rules

        private void ButtonNewRule_Click(object sender, EventArgs e)
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

        private void DataGridViewRules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void DataGridViewRules_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridViewRules.EndEdit();
        }

        private void DataGridViewRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != columnDelete.Index)
                return;

            dataGridViewRules.Rows.RemoveAt(e.RowIndex);
        }

        private void DataGridViewRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < columnItem.Index)
                return;

            dataGridViewRules.BeginEdit(true);
            var control = (ComboBox)dataGridViewRules.EditingControl;
            if (control != null)
                control.DroppedDown = true;
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

        #endregion

        #region Palette

        private void NumericUpDown_hueMin_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMax.Minimum = numericUpDown_hueMin.Value;
        }

        private void NumericUpDown_hueMax_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_hueMin.Maximum = numericUpDown_hueMax.Value;
        }

        #endregion

    }
}
