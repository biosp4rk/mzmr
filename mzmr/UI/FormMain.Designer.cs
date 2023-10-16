﻿namespace mzmr.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl_options = new System.Windows.Forms.TabControl();
            this.tabPage_items = new System.Windows.Forms.TabPage();
            this.groupBox_remove = new System.Windows.Forms.GroupBox();
            this.label_itemsRemove = new System.Windows.Forms.Label();
            this.label_abilitiesRemove = new System.Windows.Forms.Label();
            this.numericUpDown_itemsRemove = new System.Windows.Forms.NumericUpDown();
            this.comboBox_abilitiesRemove = new System.Windows.Forms.ComboBox();
            this.groupBox_gameCompletion = new System.Windows.Forms.GroupBox();
            this.radioButton_completion100 = new System.Windows.Forms.RadioButton();
            this.radioButton_completionBeatable = new System.Windows.Forms.RadioButton();
            this.radioButton_completionNoLogic = new System.Windows.Forms.RadioButton();
            this.groupBox_items = new System.Windows.Forms.GroupBox();
            this.comboBox_abilities = new System.Windows.Forms.ComboBox();
            this.label_abilities = new System.Windows.Forms.Label();
            this.comboBox_tanks = new System.Windows.Forms.ComboBox();
            this.label_tanks = new System.Windows.Forms.Label();
            this.groupBox_itemOptions = new System.Windows.Forms.GroupBox();
            this.checkBox_disableWalljump = new System.Windows.Forms.CheckBox();
            this.checkBox_disableInfiniteBombJump = new System.Windows.Forms.CheckBox();
            this.checkBox_chozoStatueHints = new System.Windows.Forms.CheckBox();
            this.checkBox_noEarlyChozodia = new System.Windows.Forms.CheckBox();
            this.checkBox_iceNotRequired = new System.Windows.Forms.CheckBox();
            this.checkBox_plasmaNotRequired = new System.Windows.Forms.CheckBox();
            this.tabPage_locs = new System.Windows.Forms.TabPage();
            this.dataGridView_locs = new System.Windows.Forms.DataGridView();
            this.tabPage_logic = new System.Windows.Forms.TabPage();
            this.radioButton_customLogic = new System.Windows.Forms.RadioButton();
            this.radioButton_defaultLogic = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel_customSettings = new System.Windows.Forms.TableLayoutPanel();
            this.button_customLogicPath = new System.Windows.Forms.Button();
            this.textBox_customLogicPath = new System.Windows.Forms.TextBox();
            this.label_customLogicPath = new System.Windows.Forms.Label();
            this.tabPage_rules = new System.Windows.Forms.TabPage();
            this.buttonNewRule = new System.Windows.Forms.Button();
            this.dataGridViewRules = new System.Windows.Forms.DataGridView();
            this.columnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnData = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage_palettes = new System.Windows.Forms.TabPage();
            this.groupBox_hue = new System.Windows.Forms.GroupBox();
            this.label_hueMax = new System.Windows.Forms.Label();
            this.label_hueMin = new System.Windows.Forms.Label();
            this.numericUpDown_hueMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hueMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox_palettes = new System.Windows.Forms.GroupBox();
            this.checkBox_samusPalettes = new System.Windows.Forms.CheckBox();
            this.checkBox_beamPalettes = new System.Windows.Forms.CheckBox();
            this.checkBox_enemyPalettes = new System.Windows.Forms.CheckBox();
            this.checkBox_tilesetPalettes = new System.Windows.Forms.CheckBox();
            this.tabPage_enemies = new System.Windows.Forms.TabPage();
            this.checkBox_RandoBosses = new System.Windows.Forms.CheckBox();
            this.checkBox_enemies = new System.Windows.Forms.CheckBox();
            this.groupBox_stats = new System.Windows.Forms.GroupBox();
            this.checkBox_enemyDrops = new System.Windows.Forms.CheckBox();
            this.checkBox_enemyWeakness = new System.Windows.Forms.CheckBox();
            this.checkBox_enemyDamage = new System.Windows.Forms.CheckBox();
            this.checkBox_enemyHealth = new System.Windows.Forms.CheckBox();
            this.groupBox_statRanges = new System.Windows.Forms.GroupBox();
            this.numericUpDown_damageMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_damageMin = new System.Windows.Forms.NumericUpDown();
            this.label_damageMin = new System.Windows.Forms.Label();
            this.label_damageMax = new System.Windows.Forms.Label();
            this.label_healthMax = new System.Windows.Forms.Label();
            this.label_minHealth = new System.Windows.Forms.Label();
            this.numericUpDown_healthMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_healthMin = new System.Windows.Forms.NumericUpDown();
            this.tabPage_misc = new System.Windows.Forms.TabPage();
            this.checkBox_skipDoorTransitions = new System.Windows.Forms.CheckBox();
            this.checkBox_skipSuitless = new System.Windows.Forms.CheckBox();
            this.checkBox_removeCutscenes = new System.Windows.Forms.CheckBox();
            this.checkBox_obtainUnkItems = new System.Windows.Forms.CheckBox();
            this.checkBox_enableItemToggle = new System.Windows.Forms.CheckBox();
            this.checkBox_pauseScreenInfo = new System.Windows.Forms.CheckBox();
            this.checkBox_hardModeAvailable = new System.Windows.Forms.CheckBox();
            this.groupBox_text = new System.Windows.Forms.GroupBox();
            this.checkBox_areaText = new System.Windows.Forms.CheckBox();
            this.checkBox_miscText = new System.Windows.Forms.CheckBox();
            this.checkBox_cutsceneText = new System.Windows.Forms.CheckBox();
            this.checkBox_itemText = new System.Windows.Forms.CheckBox();
            this.groupBox_music = new System.Windows.Forms.GroupBox();
            this.checkBox_customMusic = new System.Windows.Forms.CheckBox();
            this.comboBox_musicBoss = new System.Windows.Forms.ComboBox();
            this.label_musicBoss = new System.Windows.Forms.Label();
            this.label_musicRoom = new System.Windows.Forms.Label();
            this.comboBox_musicRoom = new System.Windows.Forms.ComboBox();
            this.button_openROM = new System.Windows.Forms.Button();
            this.button_randomize = new System.Windows.Forms.Button();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label_seed = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_settings = new System.Windows.Forms.Button();
            this.checkBox_saveMapImages = new System.Windows.Forms.CheckBox();
            this.checkBox_saveLogFile = new System.Windows.Forms.CheckBox();
            this.label_game = new System.Windows.Forms.Label();
            this.comboBox_game = new System.Windows.Forms.ComboBox();
            this.tabControl_options.SuspendLayout();
            this.tabPage_items.SuspendLayout();
            this.groupBox_remove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).BeginInit();
            this.groupBox_gameCompletion.SuspendLayout();
            this.groupBox_items.SuspendLayout();
            this.groupBox_itemOptions.SuspendLayout();
            this.tabPage_locs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_locs)).BeginInit();
            this.tabPage_logic.SuspendLayout();
            this.tabPage_rules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).BeginInit();
            this.tabPage_palettes.SuspendLayout();
            this.groupBox_hue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).BeginInit();
            this.groupBox_palettes.SuspendLayout();
            this.tabPage_enemies.SuspendLayout();
            this.groupBox_stats.SuspendLayout();
            this.groupBox_statRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damageMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damageMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healthMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healthMin)).BeginInit();
            this.tabPage_misc.SuspendLayout();
            this.groupBox_text.SuspendLayout();
            this.groupBox_music.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_options
            // 
            this.tabControl_options.Controls.Add(this.tabPage_items);
            this.tabControl_options.Controls.Add(this.tabPage_locs);
            this.tabControl_options.Controls.Add(this.tabPage_logic);
            this.tabControl_options.Controls.Add(this.tabPage_rules);
            this.tabControl_options.Controls.Add(this.tabPage_palettes);
            this.tabControl_options.Controls.Add(this.tabPage_enemies);
            this.tabControl_options.Controls.Add(this.tabPage_misc);
            this.tabControl_options.Location = new System.Drawing.Point(12, 102);
            this.tabControl_options.Name = "tabControl_options";
            this.tabControl_options.SelectedIndex = 0;
            this.tabControl_options.Size = new System.Drawing.Size(427, 282);
            this.tabControl_options.TabIndex = 7;
            // 
            // tabPage_items
            // 
            this.tabPage_items.Controls.Add(this.groupBox_remove);
            this.tabPage_items.Controls.Add(this.groupBox_gameCompletion);
            this.tabPage_items.Controls.Add(this.groupBox_items);
            this.tabPage_items.Controls.Add(this.groupBox_itemOptions);
            this.tabPage_items.Location = new System.Drawing.Point(4, 22);
            this.tabPage_items.Name = "tabPage_items";
            this.tabPage_items.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_items.Size = new System.Drawing.Size(419, 256);
            this.tabPage_items.TabIndex = 0;
            this.tabPage_items.Text = "Items";
            // 
            // groupBox_remove
            // 
            this.groupBox_remove.Controls.Add(this.label_itemsRemove);
            this.groupBox_remove.Controls.Add(this.label_abilitiesRemove);
            this.groupBox_remove.Controls.Add(this.numericUpDown_itemsRemove);
            this.groupBox_remove.Controls.Add(this.comboBox_abilitiesRemove);
            this.groupBox_remove.Location = new System.Drawing.Point(184, 6);
            this.groupBox_remove.Name = "groupBox_remove";
            this.groupBox_remove.Size = new System.Drawing.Size(150, 72);
            this.groupBox_remove.TabIndex = 1;
            this.groupBox_remove.TabStop = false;
            this.groupBox_remove.Text = "Remove";
            // 
            // label_itemsRemove
            // 
            this.label_itemsRemove.AutoSize = true;
            this.label_itemsRemove.Location = new System.Drawing.Point(6, 21);
            this.label_itemsRemove.Name = "label_itemsRemove";
            this.label_itemsRemove.Size = new System.Drawing.Size(35, 13);
            this.label_itemsRemove.TabIndex = 0;
            this.label_itemsRemove.Text = "Items:";
            // 
            // label_abilitiesRemove
            // 
            this.label_abilitiesRemove.AutoSize = true;
            this.label_abilitiesRemove.Location = new System.Drawing.Point(6, 47);
            this.label_abilitiesRemove.Name = "label_abilitiesRemove";
            this.label_abilitiesRemove.Size = new System.Drawing.Size(45, 13);
            this.label_abilitiesRemove.TabIndex = 2;
            this.label_abilitiesRemove.Text = "Abilities:";
            // 
            // numericUpDown_itemsRemove
            // 
            this.numericUpDown_itemsRemove.Location = new System.Drawing.Point(56, 20);
            this.numericUpDown_itemsRemove.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_itemsRemove.Name = "numericUpDown_itemsRemove";
            this.numericUpDown_itemsRemove.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown_itemsRemove.TabIndex = 1;
            this.numericUpDown_itemsRemove.ValueChanged += new System.EventHandler(this.NumericUpDown_itemsRemove_ValueChanged);
            // 
            // comboBox_abilitiesRemove
            // 
            this.comboBox_abilitiesRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_abilitiesRemove.FormattingEnabled = true;
            this.comboBox_abilitiesRemove.Location = new System.Drawing.Point(56, 45);
            this.comboBox_abilitiesRemove.Name = "comboBox_abilitiesRemove";
            this.comboBox_abilitiesRemove.Size = new System.Drawing.Size(72, 21);
            this.comboBox_abilitiesRemove.TabIndex = 3;
            // 
            // groupBox_gameCompletion
            // 
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completion100);
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completionBeatable);
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completionNoLogic);
            this.groupBox_gameCompletion.Location = new System.Drawing.Point(173, 85);
            this.groupBox_gameCompletion.Name = "groupBox_gameCompletion";
            this.groupBox_gameCompletion.Size = new System.Drawing.Size(112, 89);
            this.groupBox_gameCompletion.TabIndex = 3;
            this.groupBox_gameCompletion.TabStop = false;
            this.groupBox_gameCompletion.Text = "Game Completion";
            // 
            // radioButton_completion100
            // 
            this.radioButton_completion100.AutoSize = true;
            this.radioButton_completion100.Location = new System.Drawing.Point(5, 66);
            this.radioButton_completion100.Name = "radioButton_completion100";
            this.radioButton_completion100.Size = new System.Drawing.Size(51, 17);
            this.radioButton_completion100.TabIndex = 2;
            this.radioButton_completion100.TabStop = true;
            this.radioButton_completion100.Text = "100%";
            this.toolTip.SetToolTip(this.radioButton_completion100, "Ensures that all items can be collected. Other settings are taken into account.");
            this.radioButton_completion100.UseVisualStyleBackColor = true;
            // 
            // radioButton_completionBeatable
            // 
            this.radioButton_completionBeatable.AutoSize = true;
            this.radioButton_completionBeatable.Location = new System.Drawing.Point(6, 42);
            this.radioButton_completionBeatable.Name = "radioButton_completionBeatable";
            this.radioButton_completionBeatable.Size = new System.Drawing.Size(67, 17);
            this.radioButton_completionBeatable.TabIndex = 1;
            this.radioButton_completionBeatable.TabStop = true;
            this.radioButton_completionBeatable.Text = "Beatable";
            this.toolTip.SetToolTip(this.radioButton_completionBeatable, "Ensures that the game can be beaten. Other settings are taken into account.");
            this.radioButton_completionBeatable.UseVisualStyleBackColor = true;
            // 
            // radioButton_completionNoLogic
            // 
            this.radioButton_completionNoLogic.AutoSize = true;
            this.radioButton_completionNoLogic.Location = new System.Drawing.Point(6, 19);
            this.radioButton_completionNoLogic.Name = "radioButton_completionNoLogic";
            this.radioButton_completionNoLogic.Size = new System.Drawing.Size(64, 17);
            this.radioButton_completionNoLogic.TabIndex = 0;
            this.radioButton_completionNoLogic.TabStop = true;
            this.radioButton_completionNoLogic.Text = "No logic";
            this.toolTip.SetToolTip(this.radioButton_completionNoLogic, "Doesn\'t check if game can be beaten or if any item can be collected.");
            this.radioButton_completionNoLogic.UseVisualStyleBackColor = true;
            // 
            // groupBox_items
            // 
            this.groupBox_items.Controls.Add(this.comboBox_abilities);
            this.groupBox_items.Controls.Add(this.label_abilities);
            this.groupBox_items.Controls.Add(this.comboBox_tanks);
            this.groupBox_items.Controls.Add(this.label_tanks);
            this.groupBox_items.Location = new System.Drawing.Point(6, 6);
            this.groupBox_items.Name = "groupBox_items";
            this.groupBox_items.Size = new System.Drawing.Size(172, 72);
            this.groupBox_items.TabIndex = 0;
            this.groupBox_items.TabStop = false;
            this.groupBox_items.Text = "Items";
            // 
            // comboBox_abilities
            // 
            this.comboBox_abilities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_abilities.FormattingEnabled = true;
            this.comboBox_abilities.Items.AddRange(new object[] {
            "Unchanged",
            "Within own pool",
            "With all items"});
            this.comboBox_abilities.Location = new System.Drawing.Point(58, 19);
            this.comboBox_abilities.Name = "comboBox_abilities";
            this.comboBox_abilities.Size = new System.Drawing.Size(106, 21);
            this.comboBox_abilities.TabIndex = 1;
            // 
            // label_abilities
            // 
            this.label_abilities.AutoSize = true;
            this.label_abilities.Location = new System.Drawing.Point(6, 21);
            this.label_abilities.Name = "label_abilities";
            this.label_abilities.Size = new System.Drawing.Size(45, 13);
            this.label_abilities.TabIndex = 0;
            this.label_abilities.Text = "Abilities:";
            // 
            // comboBox_tanks
            // 
            this.comboBox_tanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tanks.FormattingEnabled = true;
            this.comboBox_tanks.Items.AddRange(new object[] {
            "Unchanged",
            "Within own pool",
            "With all items"});
            this.comboBox_tanks.Location = new System.Drawing.Point(58, 45);
            this.comboBox_tanks.Name = "comboBox_tanks";
            this.comboBox_tanks.Size = new System.Drawing.Size(106, 21);
            this.comboBox_tanks.TabIndex = 3;
            // 
            // label_tanks
            // 
            this.label_tanks.AutoSize = true;
            this.label_tanks.Location = new System.Drawing.Point(6, 47);
            this.label_tanks.Name = "label_tanks";
            this.label_tanks.Size = new System.Drawing.Size(40, 13);
            this.label_tanks.TabIndex = 2;
            this.label_tanks.Text = "Tanks:";
            // 
            // groupBox_itemOptions
            // 
            this.groupBox_itemOptions.Controls.Add(this.checkBox_disableWalljump);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_disableInfiniteBombJump);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_chozoStatueHints);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_noEarlyChozodia);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_iceNotRequired);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_plasmaNotRequired);
            this.groupBox_itemOptions.Location = new System.Drawing.Point(6, 85);
            this.groupBox_itemOptions.Name = "groupBox_itemOptions";
            this.groupBox_itemOptions.Size = new System.Drawing.Size(161, 162);
            this.groupBox_itemOptions.TabIndex = 4;
            this.groupBox_itemOptions.TabStop = false;
            this.groupBox_itemOptions.Text = "Options";
            // 
            // checkBox_disableWalljump
            // 
            this.checkBox_disableWalljump.AutoSize = true;
            this.checkBox_disableWalljump.Location = new System.Drawing.Point(6, 135);
            this.checkBox_disableWalljump.Name = "checkBox_disableWalljump";
            this.checkBox_disableWalljump.Size = new System.Drawing.Size(107, 17);
            this.checkBox_disableWalljump.TabIndex = 5;
            this.checkBox_disableWalljump.Text = "Disable Walljump";
            this.toolTip.SetToolTip(this.checkBox_disableWalljump, "Chozo statues that show item locations will show the new location of each item.");
            this.checkBox_disableWalljump.UseVisualStyleBackColor = true;
            // 
            // checkBox_disableInfiniteBombJump
            // 
            this.checkBox_disableInfiniteBombJump.AutoSize = true;
            this.checkBox_disableInfiniteBombJump.Location = new System.Drawing.Point(6, 112);
            this.checkBox_disableInfiniteBombJump.Name = "checkBox_disableInfiniteBombJump";
            this.checkBox_disableInfiniteBombJump.Size = new System.Drawing.Size(153, 17);
            this.checkBox_disableInfiniteBombJump.TabIndex = 4;
            this.checkBox_disableInfiniteBombJump.Text = "Disable Infinite Bomb Jump";
            this.toolTip.SetToolTip(this.checkBox_disableInfiniteBombJump, "Chozo statues that show item locations will show the new location of each item.");
            this.checkBox_disableInfiniteBombJump.UseVisualStyleBackColor = true;
            // 
            // checkBox_chozoStatueHints
            // 
            this.checkBox_chozoStatueHints.AutoSize = true;
            this.checkBox_chozoStatueHints.Location = new System.Drawing.Point(6, 89);
            this.checkBox_chozoStatueHints.Name = "checkBox_chozoStatueHints";
            this.checkBox_chozoStatueHints.Size = new System.Drawing.Size(113, 17);
            this.checkBox_chozoStatueHints.TabIndex = 3;
            this.checkBox_chozoStatueHints.Text = "Chozo statue hints";
            this.toolTip.SetToolTip(this.checkBox_chozoStatueHints, "Chozo statues that show item locations will show the new location of each item.");
            this.checkBox_chozoStatueHints.UseVisualStyleBackColor = true;
            // 
            // checkBox_noEarlyChozodia
            // 
            this.checkBox_noEarlyChozodia.AutoSize = true;
            this.checkBox_noEarlyChozodia.Location = new System.Drawing.Point(6, 66);
            this.checkBox_noEarlyChozodia.Name = "checkBox_noEarlyChozodia";
            this.checkBox_noEarlyChozodia.Size = new System.Drawing.Size(142, 17);
            this.checkBox_noEarlyChozodia.TabIndex = 2;
            this.checkBox_noEarlyChozodia.Text = "No PBs before Chozodia";
            this.toolTip.SetToolTip(this.checkBox_noEarlyChozodia, "Places power bombs in locations that don\'t allow early access to Chozodia (Mother" +
        " Brain must be defeated).");
            this.checkBox_noEarlyChozodia.UseVisualStyleBackColor = true;
            // 
            // checkBox_iceNotRequired
            // 
            this.checkBox_iceNotRequired.AutoSize = true;
            this.checkBox_iceNotRequired.Location = new System.Drawing.Point(6, 19);
            this.checkBox_iceNotRequired.Name = "checkBox_iceNotRequired";
            this.checkBox_iceNotRequired.Size = new System.Drawing.Size(129, 17);
            this.checkBox_iceNotRequired.TabIndex = 0;
            this.checkBox_iceNotRequired.Text = "Ice beam not required";
            this.toolTip.SetToolTip(this.checkBox_iceNotRequired, "Makes Metroids vulnerable to missiles without having to be frozen.");
            this.checkBox_iceNotRequired.UseVisualStyleBackColor = true;
            // 
            // checkBox_plasmaNotRequired
            // 
            this.checkBox_plasmaNotRequired.AutoSize = true;
            this.checkBox_plasmaNotRequired.Location = new System.Drawing.Point(6, 42);
            this.checkBox_plasmaNotRequired.Name = "checkBox_plasmaNotRequired";
            this.checkBox_plasmaNotRequired.Size = new System.Drawing.Size(149, 17);
            this.checkBox_plasmaNotRequired.TabIndex = 1;
            this.checkBox_plasmaNotRequired.Text = "Plasma Beam not required";
            this.toolTip.SetToolTip(this.checkBox_plasmaNotRequired, "Makes black space pirates vulnerable to all beams.");
            this.checkBox_plasmaNotRequired.UseVisualStyleBackColor = true;
            // 
            // tabPage_locs
            // 
            this.tabPage_locs.AutoScroll = true;
            this.tabPage_locs.Controls.Add(this.dataGridView_locs);
            this.tabPage_locs.Location = new System.Drawing.Point(4, 22);
            this.tabPage_locs.Name = "tabPage_locs";
            this.tabPage_locs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_locs.Size = new System.Drawing.Size(419, 256);
            this.tabPage_locs.TabIndex = 3;
            this.tabPage_locs.Text = "Locations";
            // 
            // dataGridView_locs
            // 
            this.dataGridView_locs.AllowUserToAddRows = false;
            this.dataGridView_locs.AllowUserToDeleteRows = false;
            this.dataGridView_locs.AllowUserToResizeRows = false;
            this.dataGridView_locs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_locs.Location = new System.Drawing.Point(5, 6);
            this.dataGridView_locs.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_locs.MultiSelect = false;
            this.dataGridView_locs.Name = "dataGridView_locs";
            this.dataGridView_locs.RowHeadersVisible = false;
            this.dataGridView_locs.RowHeadersWidth = 51;
            this.dataGridView_locs.RowTemplate.Height = 24;
            this.dataGridView_locs.Size = new System.Drawing.Size(410, 225);
            this.dataGridView_locs.TabIndex = 1;
            // 
            // tabPage_logic
            // 
            this.tabPage_logic.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_logic.Controls.Add(this.radioButton_customLogic);
            this.tabPage_logic.Controls.Add(this.radioButton_defaultLogic);
            this.tabPage_logic.Controls.Add(this.tableLayoutPanel_customSettings);
            this.tabPage_logic.Controls.Add(this.button_customLogicPath);
            this.tabPage_logic.Controls.Add(this.textBox_customLogicPath);
            this.tabPage_logic.Controls.Add(this.label_customLogicPath);
            this.tabPage_logic.Location = new System.Drawing.Point(4, 22);
            this.tabPage_logic.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_logic.Name = "tabPage_logic";
            this.tabPage_logic.Size = new System.Drawing.Size(419, 256);
            this.tabPage_logic.TabIndex = 4;
            this.tabPage_logic.Text = "Logic";
            // 
            // radioButton_customLogic
            // 
            this.radioButton_customLogic.AutoSize = true;
            this.radioButton_customLogic.Location = new System.Drawing.Point(4, 27);
            this.radioButton_customLogic.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_customLogic.Name = "radioButton_customLogic";
            this.radioButton_customLogic.Size = new System.Drawing.Size(85, 17);
            this.radioButton_customLogic.TabIndex = 10;
            this.radioButton_customLogic.TabStop = true;
            this.radioButton_customLogic.Text = "Custom logic";
            this.radioButton_customLogic.UseVisualStyleBackColor = true;
            // 
            // radioButton_defaultLogic
            // 
            this.radioButton_defaultLogic.AutoSize = true;
            this.radioButton_defaultLogic.Location = new System.Drawing.Point(4, 5);
            this.radioButton_defaultLogic.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_defaultLogic.Name = "radioButton_defaultLogic";
            this.radioButton_defaultLogic.Size = new System.Drawing.Size(84, 17);
            this.radioButton_defaultLogic.TabIndex = 9;
            this.radioButton_defaultLogic.TabStop = true;
            this.radioButton_defaultLogic.Text = "Default logic";
            this.radioButton_defaultLogic.UseVisualStyleBackColor = true;
            this.radioButton_defaultLogic.CheckedChanged += new System.EventHandler(this.radioButton_defaultLogic_CheckedChanged);
            // 
            // tableLayoutPanel_customSettings
            // 
            this.tableLayoutPanel_customSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_customSettings.AutoScroll = true;
            this.tableLayoutPanel_customSettings.ColumnCount = 1;
            this.tableLayoutPanel_customSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_customSettings.Location = new System.Drawing.Point(134, 5);
            this.tableLayoutPanel_customSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_customSettings.Name = "tableLayoutPanel_customSettings";
            this.tableLayoutPanel_customSettings.RowCount = 1;
            this.tableLayoutPanel_customSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_customSettings.Size = new System.Drawing.Size(284, 251);
            this.tableLayoutPanel_customSettings.TabIndex = 7;
            // 
            // button_customLogicPath
            // 
            this.button_customLogicPath.Location = new System.Drawing.Point(106, 64);
            this.button_customLogicPath.Margin = new System.Windows.Forms.Padding(2);
            this.button_customLogicPath.Name = "button_customLogicPath";
            this.button_customLogicPath.Size = new System.Drawing.Size(24, 24);
            this.button_customLogicPath.TabIndex = 6;
            this.button_customLogicPath.Text = "...";
            this.button_customLogicPath.UseVisualStyleBackColor = true;
            this.button_customLogicPath.Click += new System.EventHandler(this.Button_customLogicPath_Click);
            // 
            // textBox_customLogicPath
            // 
            this.textBox_customLogicPath.Location = new System.Drawing.Point(4, 67);
            this.textBox_customLogicPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_customLogicPath.Name = "textBox_customLogicPath";
            this.textBox_customLogicPath.ReadOnly = true;
            this.textBox_customLogicPath.Size = new System.Drawing.Size(98, 20);
            this.textBox_customLogicPath.TabIndex = 5;
            // 
            // label_customLogicPath
            // 
            this.label_customLogicPath.AutoSize = true;
            this.label_customLogicPath.Location = new System.Drawing.Point(4, 48);
            this.label_customLogicPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_customLogicPath.Name = "label_customLogicPath";
            this.label_customLogicPath.Size = new System.Drawing.Size(98, 13);
            this.label_customLogicPath.TabIndex = 4;
            this.label_customLogicPath.Text = "Custom Logic path:";
            // 
            // tabPage_rules
            // 
            this.tabPage_rules.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_rules.Controls.Add(this.buttonNewRule);
            this.tabPage_rules.Controls.Add(this.dataGridViewRules);
            this.tabPage_rules.Location = new System.Drawing.Point(4, 22);
            this.tabPage_rules.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_rules.Name = "tabPage_rules";
            this.tabPage_rules.Size = new System.Drawing.Size(419, 256);
            this.tabPage_rules.TabIndex = 5;
            this.tabPage_rules.Text = "Rules";
            // 
            // buttonNewRule
            // 
            this.buttonNewRule.Location = new System.Drawing.Point(5, 6);
            this.buttonNewRule.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewRule.Name = "buttonNewRule";
            this.buttonNewRule.Size = new System.Drawing.Size(56, 20);
            this.buttonNewRule.TabIndex = 1;
            this.buttonNewRule.Text = "New Rule";
            this.buttonNewRule.UseVisualStyleBackColor = true;
            this.buttonNewRule.Click += new System.EventHandler(this.ButtonNewRule_Click);
            // 
            // dataGridViewRules
            // 
            this.dataGridViewRules.AllowUserToAddRows = false;
            this.dataGridViewRules.AllowUserToDeleteRows = false;
            this.dataGridViewRules.AllowUserToResizeRows = false;
            this.dataGridViewRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRules.ColumnHeadersVisible = false;
            this.dataGridViewRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDelete,
            this.columnItem,
            this.columnType,
            this.columnData});
            this.dataGridViewRules.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewRules.Location = new System.Drawing.Point(5, 31);
            this.dataGridViewRules.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRules.Name = "dataGridViewRules";
            this.dataGridViewRules.RowHeadersVisible = false;
            this.dataGridViewRules.RowHeadersWidth = 51;
            this.dataGridViewRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewRules.Size = new System.Drawing.Size(413, 225);
            this.dataGridViewRules.TabIndex = 0;
            this.dataGridViewRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRules_CellClick);
            this.dataGridViewRules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRules_CellContentClick);
            this.dataGridViewRules.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRules_CellValueChanged);
            this.dataGridViewRules.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewRules_CurrentCellDirtyStateChanged);
            // 
            // columnDelete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnDelete.Frozen = true;
            this.columnDelete.HeaderText = "Delete";
            this.columnDelete.MinimumWidth = 6;
            this.columnDelete.Name = "columnDelete";
            this.columnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnDelete.Text = "X";
            this.columnDelete.UseColumnTextForButtonValue = true;
            this.columnDelete.Width = 25;
            // 
            // columnItem
            // 
            this.columnItem.HeaderText = "Item";
            this.columnItem.MinimumWidth = 6;
            this.columnItem.Name = "columnItem";
            this.columnItem.Width = 125;
            // 
            // columnType
            // 
            this.columnType.HeaderText = "Type";
            this.columnType.MinimumWidth = 6;
            this.columnType.Name = "columnType";
            this.columnType.Width = 180;
            // 
            // columnData
            // 
            this.columnData.HeaderText = "Data";
            this.columnData.MinimumWidth = 6;
            this.columnData.Name = "columnData";
            this.columnData.Width = 125;
            // 
            // tabPage_palettes
            // 
            this.tabPage_palettes.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_palettes.Controls.Add(this.groupBox_hue);
            this.tabPage_palettes.Controls.Add(this.groupBox_palettes);
            this.tabPage_palettes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_palettes.Name = "tabPage_palettes";
            this.tabPage_palettes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_palettes.Size = new System.Drawing.Size(419, 256);
            this.tabPage_palettes.TabIndex = 2;
            this.tabPage_palettes.Text = "Palettes";
            // 
            // groupBox_hue
            // 
            this.groupBox_hue.Controls.Add(this.label_hueMax);
            this.groupBox_hue.Controls.Add(this.label_hueMin);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMax);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMin);
            this.groupBox_hue.Location = new System.Drawing.Point(110, 6);
            this.groupBox_hue.Name = "groupBox_hue";
            this.groupBox_hue.Size = new System.Drawing.Size(135, 71);
            this.groupBox_hue.TabIndex = 1;
            this.groupBox_hue.TabStop = false;
            this.groupBox_hue.Text = "Hue Rotation";
            // 
            // label_hueMax
            // 
            this.label_hueMax.AutoSize = true;
            this.label_hueMax.Location = new System.Drawing.Point(6, 46);
            this.label_hueMax.Name = "label_hueMax";
            this.label_hueMax.Size = new System.Drawing.Size(54, 13);
            this.label_hueMax.TabIndex = 2;
            this.label_hueMax.Text = "Maximum:";
            this.toolTip.SetToolTip(this.label_hueMax, "Rotates hue by no more than this amount.");
            // 
            // label_hueMin
            // 
            this.label_hueMin.AutoSize = true;
            this.label_hueMin.Location = new System.Drawing.Point(6, 20);
            this.label_hueMin.Name = "label_hueMin";
            this.label_hueMin.Size = new System.Drawing.Size(51, 13);
            this.label_hueMin.TabIndex = 0;
            this.label_hueMin.Text = "Minimum:";
            this.toolTip.SetToolTip(this.label_hueMin, "Rotates hue by at least this amount.");
            // 
            // numericUpDown_hueMax
            // 
            this.numericUpDown_hueMax.Location = new System.Drawing.Point(66, 45);
            this.numericUpDown_hueMax.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMax.Name = "numericUpDown_hueMax";
            this.numericUpDown_hueMax.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_hueMax.TabIndex = 3;
            this.toolTip.SetToolTip(this.numericUpDown_hueMax, "Rotates hue by no more than this amount.");
            this.numericUpDown_hueMax.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMax.ValueChanged += new System.EventHandler(this.NumericUpDown_hueMax_ValueChanged);
            // 
            // numericUpDown_hueMin
            // 
            this.numericUpDown_hueMin.Location = new System.Drawing.Point(66, 19);
            this.numericUpDown_hueMin.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMin.Name = "numericUpDown_hueMin";
            this.numericUpDown_hueMin.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_hueMin.TabIndex = 1;
            this.toolTip.SetToolTip(this.numericUpDown_hueMin, "Rotates hue by at least this amount.");
            this.numericUpDown_hueMin.ValueChanged += new System.EventHandler(this.NumericUpDown_hueMin_ValueChanged);
            // 
            // groupBox_palettes
            // 
            this.groupBox_palettes.Controls.Add(this.checkBox_samusPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_beamPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_enemyPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_tilesetPalettes);
            this.groupBox_palettes.Location = new System.Drawing.Point(6, 6);
            this.groupBox_palettes.Name = "groupBox_palettes";
            this.groupBox_palettes.Size = new System.Drawing.Size(98, 113);
            this.groupBox_palettes.TabIndex = 0;
            this.groupBox_palettes.TabStop = false;
            this.groupBox_palettes.Text = "Palettes";
            // 
            // checkBox_samusPalettes
            // 
            this.checkBox_samusPalettes.AutoSize = true;
            this.checkBox_samusPalettes.Location = new System.Drawing.Point(6, 66);
            this.checkBox_samusPalettes.Name = "checkBox_samusPalettes";
            this.checkBox_samusPalettes.Size = new System.Drawing.Size(58, 17);
            this.checkBox_samusPalettes.TabIndex = 2;
            this.checkBox_samusPalettes.Text = "Samus";
            this.toolTip.SetToolTip(this.checkBox_samusPalettes, "Changes the colors of Samus.");
            this.checkBox_samusPalettes.UseVisualStyleBackColor = true;
            // 
            // checkBox_beamPalettes
            // 
            this.checkBox_beamPalettes.AutoSize = true;
            this.checkBox_beamPalettes.Location = new System.Drawing.Point(6, 89);
            this.checkBox_beamPalettes.Name = "checkBox_beamPalettes";
            this.checkBox_beamPalettes.Size = new System.Drawing.Size(58, 17);
            this.checkBox_beamPalettes.TabIndex = 3;
            this.checkBox_beamPalettes.Text = "Beams";
            this.toolTip.SetToolTip(this.checkBox_beamPalettes, "Changes the colors of Samus\'s beams.");
            this.checkBox_beamPalettes.UseVisualStyleBackColor = true;
            // 
            // checkBox_enemyPalettes
            // 
            this.checkBox_enemyPalettes.AutoSize = true;
            this.checkBox_enemyPalettes.Location = new System.Drawing.Point(6, 42);
            this.checkBox_enemyPalettes.Name = "checkBox_enemyPalettes";
            this.checkBox_enemyPalettes.Size = new System.Drawing.Size(66, 17);
            this.checkBox_enemyPalettes.TabIndex = 1;
            this.checkBox_enemyPalettes.Text = "Enemies";
            this.toolTip.SetToolTip(this.checkBox_enemyPalettes, "Changes the colors of enemies and other sprites.");
            this.checkBox_enemyPalettes.UseVisualStyleBackColor = true;
            // 
            // checkBox_tilesetPalettes
            // 
            this.checkBox_tilesetPalettes.AutoSize = true;
            this.checkBox_tilesetPalettes.Location = new System.Drawing.Point(6, 19);
            this.checkBox_tilesetPalettes.Name = "checkBox_tilesetPalettes";
            this.checkBox_tilesetPalettes.Size = new System.Drawing.Size(62, 17);
            this.checkBox_tilesetPalettes.TabIndex = 0;
            this.checkBox_tilesetPalettes.Text = "Tilesets";
            this.toolTip.SetToolTip(this.checkBox_tilesetPalettes, "Changes the colors of tilesets (backgrounds of rooms).");
            this.checkBox_tilesetPalettes.UseVisualStyleBackColor = true;
            // 
            // tabPage_enemies
            // 
            this.tabPage_enemies.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_enemies.Controls.Add(this.checkBox_RandoBosses);
            this.tabPage_enemies.Controls.Add(this.checkBox_enemies);
            this.tabPage_enemies.Controls.Add(this.groupBox_stats);
            this.tabPage_enemies.Location = new System.Drawing.Point(4, 22);
            this.tabPage_enemies.Name = "tabPage_enemies";
            this.tabPage_enemies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_enemies.Size = new System.Drawing.Size(419, 256);
            this.tabPage_enemies.TabIndex = 6;
            this.tabPage_enemies.Text = "Enemies";
            // 
            // checkBox_RandoBosses
            // 
            this.checkBox_RandoBosses.AutoSize = true;
            this.checkBox_RandoBosses.Location = new System.Drawing.Point(13, 128);
            this.checkBox_RandoBosses.Name = "checkBox_RandoBosses";
            this.checkBox_RandoBosses.Size = new System.Drawing.Size(115, 17);
            this.checkBox_RandoBosses.TabIndex = 11;
            this.checkBox_RandoBosses.Text = "Randomize bosses";
            this.toolTip.SetToolTip(this.checkBox_RandoBosses, "Randomizes Kraid, Ridley, and Mecha between a handful of other bosses.");
            this.checkBox_RandoBosses.UseVisualStyleBackColor = false;
            // 
            // checkBox_enemies
            // 
            this.checkBox_enemies.AutoSize = true;
            this.checkBox_enemies.Location = new System.Drawing.Point(13, 151);
            this.checkBox_enemies.Name = "checkBox_enemies";
            this.checkBox_enemies.Size = new System.Drawing.Size(121, 17);
            this.checkBox_enemies.TabIndex = 10;
            this.checkBox_enemies.Text = "Randomize enemies";
            this.checkBox_enemies.UseVisualStyleBackColor = true;
            // 
            // groupBox_stats
            // 
            this.groupBox_stats.Controls.Add(this.checkBox_enemyDrops);
            this.groupBox_stats.Controls.Add(this.checkBox_enemyWeakness);
            this.groupBox_stats.Controls.Add(this.checkBox_enemyDamage);
            this.groupBox_stats.Controls.Add(this.checkBox_enemyHealth);
            this.groupBox_stats.Controls.Add(this.groupBox_statRanges);
            this.groupBox_stats.Location = new System.Drawing.Point(6, 6);
            this.groupBox_stats.Name = "groupBox_stats";
            this.groupBox_stats.Size = new System.Drawing.Size(325, 116);
            this.groupBox_stats.TabIndex = 2;
            this.groupBox_stats.TabStop = false;
            this.groupBox_stats.Text = "Enemy Stats";
            // 
            // checkBox_enemyDrops
            // 
            this.checkBox_enemyDrops.AutoSize = true;
            this.checkBox_enemyDrops.Location = new System.Drawing.Point(7, 86);
            this.checkBox_enemyDrops.Name = "checkBox_enemyDrops";
            this.checkBox_enemyDrops.Size = new System.Drawing.Size(54, 17);
            this.checkBox_enemyDrops.TabIndex = 9;
            this.checkBox_enemyDrops.Text = "Drops";
            this.toolTip.SetToolTip(this.checkBox_enemyDrops, "Randomizes drops of enemies.");
            this.checkBox_enemyDrops.UseVisualStyleBackColor = true;
            // 
            // checkBox_enemyWeakness
            // 
            this.checkBox_enemyWeakness.AutoSize = true;
            this.checkBox_enemyWeakness.Location = new System.Drawing.Point(7, 63);
            this.checkBox_enemyWeakness.Name = "checkBox_enemyWeakness";
            this.checkBox_enemyWeakness.Size = new System.Drawing.Size(90, 17);
            this.checkBox_enemyWeakness.TabIndex = 8;
            this.checkBox_enemyWeakness.Text = "Vulnerabilities";
            this.toolTip.SetToolTip(this.checkBox_enemyWeakness, "Randomized some sprites vulnerabilities. Bosses are unchanged.");
            this.checkBox_enemyWeakness.UseVisualStyleBackColor = true;
            // 
            // checkBox_enemyDamage
            // 
            this.checkBox_enemyDamage.AutoSize = true;
            this.checkBox_enemyDamage.Location = new System.Drawing.Point(7, 42);
            this.checkBox_enemyDamage.Name = "checkBox_enemyDamage";
            this.checkBox_enemyDamage.Size = new System.Drawing.Size(66, 17);
            this.checkBox_enemyDamage.TabIndex = 7;
            this.checkBox_enemyDamage.Text = "Damage";
            this.toolTip.SetToolTip(this.checkBox_enemyDamage, "Randomized sprite damage based on set ranges.");
            this.checkBox_enemyDamage.UseVisualStyleBackColor = true;
            // 
            // checkBox_enemyHealth
            // 
            this.checkBox_enemyHealth.AutoSize = true;
            this.checkBox_enemyHealth.Location = new System.Drawing.Point(7, 20);
            this.checkBox_enemyHealth.Name = "checkBox_enemyHealth";
            this.checkBox_enemyHealth.Size = new System.Drawing.Size(57, 17);
            this.checkBox_enemyHealth.TabIndex = 6;
            this.checkBox_enemyHealth.Text = "Health";
            this.toolTip.SetToolTip(this.checkBox_enemyHealth, "Randomizes health of most sprites based on set ranges.");
            this.checkBox_enemyHealth.UseVisualStyleBackColor = true;
            // 
            // groupBox_statRanges
            // 
            this.groupBox_statRanges.Controls.Add(this.numericUpDown_damageMax);
            this.groupBox_statRanges.Controls.Add(this.numericUpDown_damageMin);
            this.groupBox_statRanges.Controls.Add(this.label_damageMin);
            this.groupBox_statRanges.Controls.Add(this.label_damageMax);
            this.groupBox_statRanges.Controls.Add(this.label_healthMax);
            this.groupBox_statRanges.Controls.Add(this.label_minHealth);
            this.groupBox_statRanges.Controls.Add(this.numericUpDown_healthMax);
            this.groupBox_statRanges.Controls.Add(this.numericUpDown_healthMin);
            this.groupBox_statRanges.Location = new System.Drawing.Point(185, 0);
            this.groupBox_statRanges.Name = "groupBox_statRanges";
            this.groupBox_statRanges.Size = new System.Drawing.Size(144, 116);
            this.groupBox_statRanges.TabIndex = 5;
            this.groupBox_statRanges.TabStop = false;
            this.groupBox_statRanges.Text = "Percentage Ranges";
            // 
            // numericUpDown_damageMax
            // 
            this.numericUpDown_damageMax.Location = new System.Drawing.Point(73, 92);
            this.numericUpDown_damageMax.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_damageMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_damageMax.Name = "numericUpDown_damageMax";
            this.numericUpDown_damageMax.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_damageMax.TabIndex = 9;
            this.toolTip.SetToolTip(this.numericUpDown_damageMax, "Max possible possible for sprite is the percentage of this value and the sprite\'s" +
        " default damage.");
            this.numericUpDown_damageMax.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_damageMax.ValueChanged += new System.EventHandler(this.NumericUpDown_damageMax_ValueChanged);
            // 
            // numericUpDown_damageMin
            // 
            this.numericUpDown_damageMin.Location = new System.Drawing.Point(73, 66);
            this.numericUpDown_damageMin.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_damageMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_damageMin.Name = "numericUpDown_damageMin";
            this.numericUpDown_damageMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_damageMin.TabIndex = 8;
            this.toolTip.SetToolTip(this.numericUpDown_damageMin, "Min damage possible for sprite is the percentage of this value and the sprite\'s d" +
        "efault damage.");
            this.numericUpDown_damageMin.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_damageMin.ValueChanged += new System.EventHandler(this.NumericUpDown_damageMin_ValueChanged);
            // 
            // label_damageMin
            // 
            this.label_damageMin.AutoSize = true;
            this.label_damageMin.Location = new System.Drawing.Point(3, 68);
            this.label_damageMin.Name = "label_damageMin";
            this.label_damageMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_damageMin.Size = new System.Drawing.Size(70, 13);
            this.label_damageMin.TabIndex = 7;
            this.label_damageMin.Text = "Damage Min:";
            // 
            // label_damageMax
            // 
            this.label_damageMax.AutoSize = true;
            this.label_damageMax.Location = new System.Drawing.Point(3, 94);
            this.label_damageMax.Name = "label_damageMax";
            this.label_damageMax.Size = new System.Drawing.Size(73, 13);
            this.label_damageMax.TabIndex = 6;
            this.label_damageMax.Text = "Damage Max:";
            // 
            // label_healthMax
            // 
            this.label_healthMax.AutoSize = true;
            this.label_healthMax.Location = new System.Drawing.Point(6, 42);
            this.label_healthMax.Name = "label_healthMax";
            this.label_healthMax.Size = new System.Drawing.Size(64, 13);
            this.label_healthMax.TabIndex = 5;
            this.label_healthMax.Text = "Health Max:";
            // 
            // label_minHealth
            // 
            this.label_minHealth.AutoSize = true;
            this.label_minHealth.Location = new System.Drawing.Point(6, 16);
            this.label_minHealth.Name = "label_minHealth";
            this.label_minHealth.Size = new System.Drawing.Size(61, 13);
            this.label_minHealth.TabIndex = 4;
            this.label_minHealth.Text = "Health Min:";
            // 
            // numericUpDown_healthMax
            // 
            this.numericUpDown_healthMax.Location = new System.Drawing.Point(73, 40);
            this.numericUpDown_healthMax.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_healthMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_healthMax.Name = "numericUpDown_healthMax";
            this.numericUpDown_healthMax.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_healthMax.TabIndex = 3;
            this.toolTip.SetToolTip(this.numericUpDown_healthMax, "Max health possible for sprite is the percentage of this value and the sprite\'s d" +
        "efault health.");
            this.numericUpDown_healthMax.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_healthMax.ValueChanged += new System.EventHandler(this.NumericUpDown_healthMax_ValueChanged);
            // 
            // numericUpDown_healthMin
            // 
            this.numericUpDown_healthMin.Location = new System.Drawing.Point(73, 14);
            this.numericUpDown_healthMin.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_healthMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_healthMin.Name = "numericUpDown_healthMin";
            this.numericUpDown_healthMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_healthMin.TabIndex = 2;
            this.toolTip.SetToolTip(this.numericUpDown_healthMin, "Min health possible for sprite is the percentage of this value and the sprite\'s d" +
        "efault health.");
            this.numericUpDown_healthMin.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_healthMin.ValueChanged += new System.EventHandler(this.NumericUpDown_healthMin_ValueChanged);
            // 
            // tabPage_misc
            // 
            this.tabPage_misc.Controls.Add(this.checkBox_skipDoorTransitions);
            this.tabPage_misc.Controls.Add(this.checkBox_skipSuitless);
            this.tabPage_misc.Controls.Add(this.checkBox_removeCutscenes);
            this.tabPage_misc.Controls.Add(this.checkBox_obtainUnkItems);
            this.tabPage_misc.Controls.Add(this.checkBox_enableItemToggle);
            this.tabPage_misc.Controls.Add(this.checkBox_pauseScreenInfo);
            this.tabPage_misc.Controls.Add(this.checkBox_hardModeAvailable);
            this.tabPage_misc.Controls.Add(this.groupBox_text);
            this.tabPage_misc.Controls.Add(this.groupBox_music);
            this.tabPage_misc.Location = new System.Drawing.Point(4, 22);
            this.tabPage_misc.Name = "tabPage_misc";
            this.tabPage_misc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_misc.Size = new System.Drawing.Size(419, 256);
            this.tabPage_misc.TabIndex = 1;
            this.tabPage_misc.Text = "Misc";
            // 
            // checkBox_skipDoorTransitions
            // 
            this.checkBox_skipDoorTransitions.AutoSize = true;
            this.checkBox_skipDoorTransitions.Location = new System.Drawing.Point(15, 183);
            this.checkBox_skipDoorTransitions.Name = "checkBox_skipDoorTransitions";
            this.checkBox_skipDoorTransitions.Size = new System.Drawing.Size(121, 17);
            this.checkBox_skipDoorTransitions.TabIndex = 18;
            this.checkBox_skipDoorTransitions.Text = "Skip door transitions";
            this.toolTip.SetToolTip(this.checkBox_skipDoorTransitions, "Makes all door transitions instant.");
            this.checkBox_skipDoorTransitions.UseVisualStyleBackColor = true;
            // 
            // checkBox_skipSuitless
            // 
            this.checkBox_skipSuitless.AutoSize = true;
            this.checkBox_skipSuitless.Location = new System.Drawing.Point(172, 160);
            this.checkBox_skipSuitless.Name = "checkBox_skipSuitless";
            this.checkBox_skipSuitless.Size = new System.Drawing.Size(134, 17);
            this.checkBox_skipSuitless.TabIndex = 17;
            this.checkBox_skipSuitless.Text = "Skip suitless sequence";
            this.toolTip.SetToolTip(this.checkBox_skipSuitless, "Places the player before the Chozo ghost fight after escaping Tourian.");
            this.checkBox_skipSuitless.UseVisualStyleBackColor = true;
            // 
            // checkBox_removeCutscenes
            // 
            this.checkBox_removeCutscenes.AutoSize = true;
            this.checkBox_removeCutscenes.Location = new System.Drawing.Point(15, 160);
            this.checkBox_removeCutscenes.Name = "checkBox_removeCutscenes";
            this.checkBox_removeCutscenes.Size = new System.Drawing.Size(118, 17);
            this.checkBox_removeCutscenes.TabIndex = 16;
            this.checkBox_removeCutscenes.Text = "Remove cutscenes";
            this.toolTip.SetToolTip(this.checkBox_removeCutscenes, "Removes most cutscenes in the game.");
            this.checkBox_removeCutscenes.UseVisualStyleBackColor = true;
            // 
            // checkBox_obtainUnkItems
            // 
            this.checkBox_obtainUnkItems.AutoSize = true;
            this.checkBox_obtainUnkItems.Location = new System.Drawing.Point(172, 112);
            this.checkBox_obtainUnkItems.Name = "checkBox_obtainUnkItems";
            this.checkBox_obtainUnkItems.Size = new System.Drawing.Size(131, 17);
            this.checkBox_obtainUnkItems.TabIndex = 13;
            this.checkBox_obtainUnkItems.Text = "Obtain unknown items";
            this.toolTip.SetToolTip(this.checkBox_obtainUnkItems, "Allows unknown items to be obtained and activated before obtaining the fully powe" +
        "red suit.");
            this.checkBox_obtainUnkItems.UseVisualStyleBackColor = true;
            // 
            // checkBox_enableItemToggle
            // 
            this.checkBox_enableItemToggle.AutoSize = true;
            this.checkBox_enableItemToggle.Location = new System.Drawing.Point(15, 112);
            this.checkBox_enableItemToggle.Name = "checkBox_enableItemToggle";
            this.checkBox_enableItemToggle.Size = new System.Drawing.Size(113, 17);
            this.checkBox_enableItemToggle.TabIndex = 12;
            this.checkBox_enableItemToggle.Text = "Enable item toggle";
            this.toolTip.SetToolTip(this.checkBox_enableItemToggle, "Allows items to be toggled on or off from the status screen.");
            this.checkBox_enableItemToggle.UseVisualStyleBackColor = true;
            // 
            // checkBox_pauseScreenInfo
            // 
            this.checkBox_pauseScreenInfo.AutoSize = true;
            this.checkBox_pauseScreenInfo.Location = new System.Drawing.Point(172, 136);
            this.checkBox_pauseScreenInfo.Name = "checkBox_pauseScreenInfo";
            this.checkBox_pauseScreenInfo.Size = new System.Drawing.Size(140, 17);
            this.checkBox_pauseScreenInfo.TabIndex = 15;
            this.checkBox_pauseScreenInfo.Text = "Show pause screen info";
            this.toolTip.SetToolTip(this.checkBox_pauseScreenInfo, "Shows in-game timer and items collected on the pause screen.");
            this.checkBox_pauseScreenInfo.UseVisualStyleBackColor = true;
            // 
            // checkBox_hardModeAvailable
            // 
            this.checkBox_hardModeAvailable.AutoSize = true;
            this.checkBox_hardModeAvailable.Location = new System.Drawing.Point(15, 136);
            this.checkBox_hardModeAvailable.Name = "checkBox_hardModeAvailable";
            this.checkBox_hardModeAvailable.Size = new System.Drawing.Size(159, 17);
            this.checkBox_hardModeAvailable.TabIndex = 14;
            this.checkBox_hardModeAvailable.Text = "Hard Mode always available";
            this.toolTip.SetToolTip(this.checkBox_hardModeAvailable, "Makes Hard Mode available on brand new save files.");
            this.checkBox_hardModeAvailable.UseVisualStyleBackColor = true;
            // 
            // groupBox_text
            // 
            this.groupBox_text.Controls.Add(this.checkBox_areaText);
            this.groupBox_text.Controls.Add(this.checkBox_miscText);
            this.groupBox_text.Controls.Add(this.checkBox_cutsceneText);
            this.groupBox_text.Controls.Add(this.checkBox_itemText);
            this.groupBox_text.Location = new System.Drawing.Point(167, 6);
            this.groupBox_text.Name = "groupBox_text";
            this.groupBox_text.Size = new System.Drawing.Size(164, 100);
            this.groupBox_text.TabIndex = 11;
            this.groupBox_text.TabStop = false;
            this.groupBox_text.Text = "Text";
            // 
            // checkBox_areaText
            // 
            this.checkBox_areaText.AutoSize = true;
            this.checkBox_areaText.Location = new System.Drawing.Point(77, 22);
            this.checkBox_areaText.Name = "checkBox_areaText";
            this.checkBox_areaText.Size = new System.Drawing.Size(53, 17);
            this.checkBox_areaText.TabIndex = 3;
            this.checkBox_areaText.Text = "Areas";
            this.toolTip.SetToolTip(this.checkBox_areaText, "Randomizes area messages. Does not change title or pause screen area names.");
            this.checkBox_areaText.UseVisualStyleBackColor = true;
            // 
            // checkBox_miscText
            // 
            this.checkBox_miscText.AutoSize = true;
            this.checkBox_miscText.Location = new System.Drawing.Point(77, 42);
            this.checkBox_miscText.Name = "checkBox_miscText";
            this.checkBox_miscText.Size = new System.Drawing.Size(48, 17);
            this.checkBox_miscText.TabIndex = 2;
            this.checkBox_miscText.Text = "Misc";
            this.toolTip.SetToolTip(this.checkBox_miscText, "Randomizes various other messages, such as difficulty text.");
            this.checkBox_miscText.UseVisualStyleBackColor = true;
            // 
            // checkBox_cutsceneText
            // 
            this.checkBox_cutsceneText.AutoSize = true;
            this.checkBox_cutsceneText.Location = new System.Drawing.Point(5, 42);
            this.checkBox_cutsceneText.Name = "checkBox_cutsceneText";
            this.checkBox_cutsceneText.Size = new System.Drawing.Size(76, 17);
            this.checkBox_cutsceneText.TabIndex = 1;
            this.checkBox_cutsceneText.Text = "Cutscenes";
            this.toolTip.SetToolTip(this.checkBox_cutsceneText, "Randomizes the three major text cutscenes.");
            this.checkBox_cutsceneText.UseVisualStyleBackColor = true;
            // 
            // checkBox_itemText
            // 
            this.checkBox_itemText.AutoSize = true;
            this.checkBox_itemText.Location = new System.Drawing.Point(5, 22);
            this.checkBox_itemText.Name = "checkBox_itemText";
            this.checkBox_itemText.Size = new System.Drawing.Size(51, 17);
            this.checkBox_itemText.TabIndex = 0;
            this.checkBox_itemText.Text = "Items";
            this.toolTip.SetToolTip(this.checkBox_itemText, "All items will have randomized names and descriptions. Does not change status scr" +
        "een.");
            this.checkBox_itemText.UseVisualStyleBackColor = true;
            // 
            // groupBox_music
            // 
            this.groupBox_music.Controls.Add(this.checkBox_customMusic);
            this.groupBox_music.Controls.Add(this.comboBox_musicBoss);
            this.groupBox_music.Controls.Add(this.label_musicBoss);
            this.groupBox_music.Controls.Add(this.label_musicRoom);
            this.groupBox_music.Controls.Add(this.comboBox_musicRoom);
            this.groupBox_music.Location = new System.Drawing.Point(6, 6);
            this.groupBox_music.Name = "groupBox_music";
            this.groupBox_music.Size = new System.Drawing.Size(155, 100);
            this.groupBox_music.TabIndex = 10;
            this.groupBox_music.TabStop = false;
            this.groupBox_music.Text = "Music";
            // 
            // checkBox_customMusic
            // 
            this.checkBox_customMusic.AutoSize = true;
            this.checkBox_customMusic.Location = new System.Drawing.Point(9, 70);
            this.checkBox_customMusic.Name = "checkBox_customMusic";
            this.checkBox_customMusic.Size = new System.Drawing.Size(97, 17);
            this.checkBox_customMusic.TabIndex = 6;
            this.checkBox_customMusic.Text = "Custom Tracks";
            this.toolTip.SetToolTip(this.checkBox_customMusic, "Checking this enables various custom tracks into the music pool.");
            this.checkBox_customMusic.UseVisualStyleBackColor = true;
            // 
            // comboBox_musicBoss
            // 
            this.comboBox_musicBoss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_musicBoss.FormattingEnabled = true;
            this.comboBox_musicBoss.Items.AddRange(new object[] {
            "Unchanged",
            "No Logic",
            "With Own Pool"});
            this.comboBox_musicBoss.Location = new System.Drawing.Point(50, 43);
            this.comboBox_musicBoss.Name = "comboBox_musicBoss";
            this.comboBox_musicBoss.Size = new System.Drawing.Size(99, 21);
            this.comboBox_musicBoss.TabIndex = 5;
            this.toolTip.SetToolTip(this.comboBox_musicBoss, "Settings for randomizing boss encounter music.");
            // 
            // label_musicBoss
            // 
            this.label_musicBoss.AutoSize = true;
            this.label_musicBoss.Location = new System.Drawing.Point(6, 46);
            this.label_musicBoss.Name = "label_musicBoss";
            this.label_musicBoss.Size = new System.Drawing.Size(44, 13);
            this.label_musicBoss.TabIndex = 4;
            this.label_musicBoss.Text = "Bosses:";
            // 
            // label_musicRoom
            // 
            this.label_musicRoom.AutoSize = true;
            this.label_musicRoom.Location = new System.Drawing.Point(6, 23);
            this.label_musicRoom.Name = "label_musicRoom";
            this.label_musicRoom.Size = new System.Drawing.Size(38, 13);
            this.label_musicRoom.TabIndex = 3;
            this.label_musicRoom.Text = "Room:";
            // 
            // comboBox_musicRoom
            // 
            this.comboBox_musicRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_musicRoom.FormattingEnabled = true;
            this.comboBox_musicRoom.Items.AddRange(new object[] {
            "Unchanged",
            "No Logic",
            "With Own Pool"});
            this.comboBox_musicRoom.Location = new System.Drawing.Point(50, 17);
            this.comboBox_musicRoom.Name = "comboBox_musicRoom";
            this.comboBox_musicRoom.Size = new System.Drawing.Size(99, 21);
            this.comboBox_musicRoom.TabIndex = 2;
            this.toolTip.SetToolTip(this.comboBox_musicRoom, "Settings for randomizing room music.");
            // 
            // button_openROM
            // 
            this.button_openROM.Location = new System.Drawing.Point(12, 12);
            this.button_openROM.Name = "button_openROM";
            this.button_openROM.Size = new System.Drawing.Size(80, 23);
            this.button_openROM.TabIndex = 0;
            this.button_openROM.Text = "Open ROM";
            this.toolTip.SetToolTip(this.button_openROM, "Open an unmodified Zero Mission ROM to randomize.");
            this.button_openROM.UseVisualStyleBackColor = true;
            this.button_openROM.Click += new System.EventHandler(this.Button_openROM_Click);
            // 
            // button_randomize
            // 
            this.button_randomize.Enabled = false;
            this.button_randomize.Location = new System.Drawing.Point(12, 41);
            this.button_randomize.Name = "button_randomize";
            this.button_randomize.Size = new System.Drawing.Size(80, 23);
            this.button_randomize.TabIndex = 1;
            this.button_randomize.Text = "Randomize";
            this.toolTip.SetToolTip(this.button_randomize, "Randomize and save the ROM.");
            this.button_randomize.UseVisualStyleBackColor = true;
            this.button_randomize.Click += new System.EventHandler(this.Button_randomize_Click);
            // 
            // textBox_seed
            // 
            this.textBox_seed.Enabled = false;
            this.textBox_seed.Location = new System.Drawing.Point(196, 15);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(121, 20);
            this.textBox_seed.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBox_seed, "Seed to use for randomization. Must be a number between 0 and 2147483647. Leave b" +
        "lank for a random seed.");
            // 
            // label_seed
            // 
            this.label_seed.AutoSize = true;
            this.label_seed.Enabled = false;
            this.label_seed.Location = new System.Drawing.Point(122, 17);
            this.label_seed.Name = "label_seed";
            this.label_seed.Size = new System.Drawing.Size(35, 13);
            this.label_seed.TabIndex = 2;
            this.label_seed.Text = "Seed:";
            this.toolTip.SetToolTip(this.label_seed, "Seed to use for randomization. Must be a number between 0 and 2147483647. Leave b" +
        "lank for a random seed.");
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // button_settings
            // 
            this.button_settings.Enabled = false;
            this.button_settings.Location = new System.Drawing.Point(12, 70);
            this.button_settings.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(80, 22);
            this.button_settings.TabIndex = 16;
            this.button_settings.Text = "Settings";
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.Button_settings_Click);
            // 
            // checkBox_saveMapImages
            // 
            this.checkBox_saveMapImages.AutoSize = true;
            this.checkBox_saveMapImages.Checked = true;
            this.checkBox_saveMapImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveMapImages.Location = new System.Drawing.Point(332, 42);
            this.checkBox_saveMapImages.Name = "checkBox_saveMapImages";
            this.checkBox_saveMapImages.Size = new System.Drawing.Size(110, 17);
            this.checkBox_saveMapImages.TabIndex = 12;
            this.checkBox_saveMapImages.Text = "Save map images";
            this.checkBox_saveMapImages.UseVisualStyleBackColor = true;
            this.checkBox_saveMapImages.CheckedChanged += new System.EventHandler(this.CheckBox_saveMapImages_CheckedChanged);
            // 
            // checkBox_saveLogFile
            // 
            this.checkBox_saveLogFile.AutoSize = true;
            this.checkBox_saveLogFile.Checked = true;
            this.checkBox_saveLogFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveLogFile.Location = new System.Drawing.Point(332, 15);
            this.checkBox_saveLogFile.Name = "checkBox_saveLogFile";
            this.checkBox_saveLogFile.Size = new System.Drawing.Size(93, 17);
            this.checkBox_saveLogFile.TabIndex = 11;
            this.checkBox_saveLogFile.Text = "Save a log file";
            this.checkBox_saveLogFile.UseVisualStyleBackColor = true;
            this.checkBox_saveLogFile.CheckedChanged += new System.EventHandler(this.CheckBox_saveLogFile_CheckedChanged);
            // 
            // label_game
            // 
            this.label_game.AutoSize = true;
            this.label_game.Location = new System.Drawing.Point(105, 51);
            this.label_game.Name = "label_game";
            this.label_game.Size = new System.Drawing.Size(85, 13);
            this.label_game.TabIndex = 5;
            this.label_game.Text = "Game Selection:";
            // 
            // comboBox_game
            // 
            this.comboBox_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_game.Enabled = false;
            this.comboBox_game.FormattingEnabled = true;
            this.comboBox_game.Items.AddRange(new object[] {
            "Metroid Zero Mission",
            "Deep Freeze",
            "Spooky Mission"});
            this.comboBox_game.Location = new System.Drawing.Point(196, 48);
            this.comboBox_game.Name = "comboBox_game";
            this.comboBox_game.Size = new System.Drawing.Size(121, 21);
            this.comboBox_game.TabIndex = 17;
            this.comboBox_game.SelectedIndexChanged += new System.EventHandler(this.comboBox_game_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 391);
            this.Controls.Add(this.comboBox_game);
            this.Controls.Add(this.label_game);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.checkBox_saveMapImages);
            this.Controls.Add(this.checkBox_saveLogFile);
            this.Controls.Add(this.label_seed);
            this.Controls.Add(this.textBox_seed);
            this.Controls.Add(this.button_randomize);
            this.Controls.Add(this.button_openROM);
            this.Controls.Add(this.tabControl_options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "MZM Randomizer Plus";
            this.tabControl_options.ResumeLayout(false);
            this.tabPage_items.ResumeLayout(false);
            this.groupBox_remove.ResumeLayout(false);
            this.groupBox_remove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).EndInit();
            this.groupBox_gameCompletion.ResumeLayout(false);
            this.groupBox_gameCompletion.PerformLayout();
            this.groupBox_items.ResumeLayout(false);
            this.groupBox_items.PerformLayout();
            this.groupBox_itemOptions.ResumeLayout(false);
            this.groupBox_itemOptions.PerformLayout();
            this.tabPage_locs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_locs)).EndInit();
            this.tabPage_logic.ResumeLayout(false);
            this.tabPage_logic.PerformLayout();
            this.tabPage_rules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).EndInit();
            this.tabPage_palettes.ResumeLayout(false);
            this.groupBox_hue.ResumeLayout(false);
            this.groupBox_hue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).EndInit();
            this.groupBox_palettes.ResumeLayout(false);
            this.groupBox_palettes.PerformLayout();
            this.tabPage_enemies.ResumeLayout(false);
            this.tabPage_enemies.PerformLayout();
            this.groupBox_stats.ResumeLayout(false);
            this.groupBox_stats.PerformLayout();
            this.groupBox_statRanges.ResumeLayout(false);
            this.groupBox_statRanges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damageMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_damageMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healthMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healthMin)).EndInit();
            this.tabPage_misc.ResumeLayout(false);
            this.tabPage_misc.PerformLayout();
            this.groupBox_text.ResumeLayout(false);
            this.groupBox_text.PerformLayout();
            this.groupBox_music.ResumeLayout(false);
            this.groupBox_music.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl_options;
        private System.Windows.Forms.TabPage tabPage_misc;
        private System.Windows.Forms.Button button_openROM;
        private System.Windows.Forms.Button button_randomize;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.Label label_seed;
        private System.Windows.Forms.CheckBox checkBox_plasmaNotRequired;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPage_items;
        private System.Windows.Forms.GroupBox groupBox_gameCompletion;
        private System.Windows.Forms.RadioButton radioButton_completionNoLogic;
        private System.Windows.Forms.RadioButton radioButton_completion100;
        private System.Windows.Forms.RadioButton radioButton_completionBeatable;
        private System.Windows.Forms.GroupBox groupBox_itemOptions;
        private System.Windows.Forms.GroupBox groupBox_items;
        private System.Windows.Forms.CheckBox checkBox_iceNotRequired;
        private System.Windows.Forms.TabPage tabPage_palettes;
        private System.Windows.Forms.GroupBox groupBox_hue;
        private System.Windows.Forms.GroupBox groupBox_palettes;
        private System.Windows.Forms.CheckBox checkBox_enemyPalettes;
        private System.Windows.Forms.CheckBox checkBox_tilesetPalettes;
        private System.Windows.Forms.Label label_hueMax;
        private System.Windows.Forms.Label label_hueMin;
        private System.Windows.Forms.NumericUpDown numericUpDown_hueMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_hueMin;
        private System.Windows.Forms.CheckBox checkBox_beamPalettes;
        private System.Windows.Forms.CheckBox checkBox_noEarlyChozodia;
        private System.Windows.Forms.CheckBox checkBox_chozoStatueHints;
        private System.Windows.Forms.NumericUpDown numericUpDown_itemsRemove;
        private System.Windows.Forms.TabPage tabPage_locs;
        private System.Windows.Forms.Label label_abilitiesRemove;
        private System.Windows.Forms.DataGridView dataGridView_locs;
        private System.Windows.Forms.ComboBox comboBox_abilities;
        private System.Windows.Forms.ComboBox comboBox_tanks;
        private System.Windows.Forms.Label label_tanks;
        private System.Windows.Forms.Label label_abilities;
        private System.Windows.Forms.GroupBox groupBox_remove;
        private System.Windows.Forms.CheckBox checkBox_samusPalettes;
        private System.Windows.Forms.ComboBox comboBox_abilitiesRemove;
        private System.Windows.Forms.Label label_itemsRemove;
        private System.Windows.Forms.TabPage tabPage_logic;
        private System.Windows.Forms.Button button_customLogicPath;
        private System.Windows.Forms.TextBox textBox_customLogicPath;
        private System.Windows.Forms.Label label_customLogicPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_customSettings;
        private System.Windows.Forms.TabPage tabPage_rules;
        private System.Windows.Forms.DataGridView dataGridViewRules;
        private System.Windows.Forms.Button buttonNewRule;
        private System.Windows.Forms.DataGridViewButtonColumn columnDelete;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnType;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnData;
        private System.Windows.Forms.CheckBox checkBox_saveMapImages;
        private System.Windows.Forms.CheckBox checkBox_saveLogFile;
        private System.Windows.Forms.RadioButton radioButton_customLogic;
        private System.Windows.Forms.RadioButton radioButton_defaultLogic;
        private System.Windows.Forms.CheckBox checkBox_disableWalljump;
        private System.Windows.Forms.CheckBox checkBox_disableInfiniteBombJump;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.TabPage tabPage_enemies;
        private System.Windows.Forms.GroupBox groupBox_stats;
        private System.Windows.Forms.CheckBox checkBox_enemyDrops;
        private System.Windows.Forms.CheckBox checkBox_enemyWeakness;
        private System.Windows.Forms.CheckBox checkBox_enemyDamage;
        private System.Windows.Forms.CheckBox checkBox_enemyHealth;
        private System.Windows.Forms.GroupBox groupBox_statRanges;
        private System.Windows.Forms.NumericUpDown numericUpDown_damageMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_damageMin;
        private System.Windows.Forms.Label label_damageMin;
        private System.Windows.Forms.Label label_damageMax;
        private System.Windows.Forms.Label label_healthMax;
        private System.Windows.Forms.Label label_minHealth;
        private System.Windows.Forms.NumericUpDown numericUpDown_healthMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_healthMin;
        private System.Windows.Forms.CheckBox checkBox_skipDoorTransitions;
        private System.Windows.Forms.CheckBox checkBox_skipSuitless;
        private System.Windows.Forms.CheckBox checkBox_removeCutscenes;
        private System.Windows.Forms.CheckBox checkBox_obtainUnkItems;
        private System.Windows.Forms.CheckBox checkBox_enableItemToggle;
        private System.Windows.Forms.CheckBox checkBox_pauseScreenInfo;
        private System.Windows.Forms.CheckBox checkBox_hardModeAvailable;
        private System.Windows.Forms.GroupBox groupBox_text;
        private System.Windows.Forms.CheckBox checkBox_areaText;
        private System.Windows.Forms.CheckBox checkBox_miscText;
        private System.Windows.Forms.CheckBox checkBox_cutsceneText;
        private System.Windows.Forms.CheckBox checkBox_itemText;
        private System.Windows.Forms.GroupBox groupBox_music;
        private System.Windows.Forms.CheckBox checkBox_customMusic;
        private System.Windows.Forms.ComboBox comboBox_musicBoss;
        private System.Windows.Forms.Label label_musicBoss;
        private System.Windows.Forms.Label label_musicRoom;
        private System.Windows.Forms.ComboBox comboBox_musicRoom;
        private System.Windows.Forms.CheckBox checkBox_RandoBosses;
        private System.Windows.Forms.CheckBox checkBox_enemies;
        private System.Windows.Forms.Label label_game;
        private System.Windows.Forms.ComboBox comboBox_game;
    }
}
