namespace mzmr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.button_loadSettings = new System.Windows.Forms.Button();
            this.button_saveSettings = new System.Windows.Forms.Button();
            this.tabControl_options = new System.Windows.Forms.TabControl();
            this.tabPage_items = new System.Windows.Forms.TabPage();
            this.groupBox_tricks = new System.Windows.Forms.GroupBox();
            this.checkBox_infiniteBombJump = new System.Windows.Forms.CheckBox();
            this.checkBox_wallJumping = new System.Windows.Forms.CheckBox();
            this.groupBox_items = new System.Windows.Forms.GroupBox();
            this.checkBox_itemsTanks = new System.Windows.Forms.CheckBox();
            this.checkBox_itemsAbilities = new System.Windows.Forms.CheckBox();
            this.textBox_itemsExcluded = new System.Windows.Forms.TextBox();
            this.label_itemsExcluded = new System.Windows.Forms.Label();
            this.groupBox_itemOptions = new System.Windows.Forms.GroupBox();
            this.checkBox_chozoStatueHints = new System.Windows.Forms.CheckBox();
            this.checkBox_noPBsBeforeChozodia = new System.Windows.Forms.CheckBox();
            this.checkBox_iceNotRequired = new System.Windows.Forms.CheckBox();
            this.checkBox_plasmaNotRequired = new System.Windows.Forms.CheckBox();
            this.groupBox_gameCompletion = new System.Windows.Forms.GroupBox();
            this.radioButton_completion100 = new System.Windows.Forms.RadioButton();
            this.radioButton_completionBeatable = new System.Windows.Forms.RadioButton();
            this.radioButton_completionUnchanged = new System.Windows.Forms.RadioButton();
            this.tabPage_palettes = new System.Windows.Forms.TabPage();
            this.groupBox_hue = new System.Windows.Forms.GroupBox();
            this.label_hueMax = new System.Windows.Forms.Label();
            this.label_hueMin = new System.Windows.Forms.Label();
            this.numericUpDown_hueMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hueMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox_palettes = new System.Windows.Forms.GroupBox();
            this.checkBox_beamPalettes = new System.Windows.Forms.CheckBox();
            this.checkBox_enemyPalettes = new System.Windows.Forms.CheckBox();
            this.checkBox_tilesetPalettes = new System.Windows.Forms.CheckBox();
            this.tabPage_misc = new System.Windows.Forms.TabPage();
            this.checkBox_skipSuitless = new System.Windows.Forms.CheckBox();
            this.checkBox_removeCutscenes = new System.Windows.Forms.CheckBox();
            this.checkBox_obtainUnkItems = new System.Windows.Forms.CheckBox();
            this.checkBox_enableItemToggle = new System.Windows.Forms.CheckBox();
            this.checkBox_pauseScreenInfo = new System.Windows.Forms.CheckBox();
            this.checkBox_hardModeAvailable = new System.Windows.Forms.CheckBox();
            this.checkBox_removeVariaAnimation = new System.Windows.Forms.CheckBox();
            this.checkBox_removeNorfairVine = new System.Windows.Forms.CheckBox();
            this.button_openROM = new System.Windows.Forms.Button();
            this.button_randomize = new System.Windows.Forms.Button();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label_seed = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_appSettings = new System.Windows.Forms.Button();
            this.label_itemsRemove = new System.Windows.Forms.Label();
            this.numericUpDown_itemsRemove = new System.Windows.Forms.NumericUpDown();
            this.tabControl_options.SuspendLayout();
            this.tabPage_items.SuspendLayout();
            this.groupBox_tricks.SuspendLayout();
            this.groupBox_items.SuspendLayout();
            this.groupBox_itemOptions.SuspendLayout();
            this.groupBox_gameCompletion.SuspendLayout();
            this.tabPage_palettes.SuspendLayout();
            this.groupBox_hue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).BeginInit();
            this.groupBox_palettes.SuspendLayout();
            this.tabPage_misc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loadSettings
            // 
            this.button_loadSettings.Enabled = false;
            this.button_loadSettings.Location = new System.Drawing.Point(184, 12);
            this.button_loadSettings.Name = "button_loadSettings";
            this.button_loadSettings.Size = new System.Drawing.Size(85, 23);
            this.button_loadSettings.TabIndex = 2;
            this.button_loadSettings.Text = "Load Settings";
            this.toolTip.SetToolTip(this.button_loadSettings, "Load settings from a file or string.");
            this.button_loadSettings.UseVisualStyleBackColor = true;
            this.button_loadSettings.Click += new System.EventHandler(this.button_loadSettings_Click);
            // 
            // button_saveSettings
            // 
            this.button_saveSettings.Enabled = false;
            this.button_saveSettings.Location = new System.Drawing.Point(275, 12);
            this.button_saveSettings.Name = "button_saveSettings";
            this.button_saveSettings.Size = new System.Drawing.Size(85, 23);
            this.button_saveSettings.TabIndex = 3;
            this.button_saveSettings.Text = "Save Settings";
            this.toolTip.SetToolTip(this.button_saveSettings, "Save settings to a file.");
            this.button_saveSettings.UseVisualStyleBackColor = true;
            this.button_saveSettings.Click += new System.EventHandler(this.button_saveSettings_Click);
            // 
            // tabControl_options
            // 
            this.tabControl_options.Controls.Add(this.tabPage_items);
            this.tabControl_options.Controls.Add(this.tabPage_palettes);
            this.tabControl_options.Controls.Add(this.tabPage_misc);
            this.tabControl_options.Location = new System.Drawing.Point(12, 70);
            this.tabControl_options.Name = "tabControl_options";
            this.tabControl_options.SelectedIndex = 0;
            this.tabControl_options.Size = new System.Drawing.Size(348, 220);
            this.tabControl_options.TabIndex = 6;
            // 
            // tabPage_items
            // 
            this.tabPage_items.Controls.Add(this.groupBox_tricks);
            this.tabPage_items.Controls.Add(this.groupBox_items);
            this.tabPage_items.Controls.Add(this.groupBox_itemOptions);
            this.tabPage_items.Controls.Add(this.groupBox_gameCompletion);
            this.tabPage_items.Location = new System.Drawing.Point(4, 22);
            this.tabPage_items.Name = "tabPage_items";
            this.tabPage_items.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_items.Size = new System.Drawing.Size(340, 194);
            this.tabPage_items.TabIndex = 0;
            this.tabPage_items.Text = "Items";
            // 
            // groupBox_tricks
            // 
            this.groupBox_tricks.Controls.Add(this.checkBox_infiniteBombJump);
            this.groupBox_tricks.Controls.Add(this.checkBox_wallJumping);
            this.groupBox_tricks.Location = new System.Drawing.Point(173, 123);
            this.groupBox_tricks.Name = "groupBox_tricks";
            this.groupBox_tricks.Size = new System.Drawing.Size(161, 65);
            this.groupBox_tricks.TabIndex = 3;
            this.groupBox_tricks.TabStop = false;
            this.groupBox_tricks.Text = "Tricks";
            // 
            // checkBox_infiniteBombJump
            // 
            this.checkBox_infiniteBombJump.AutoSize = true;
            this.checkBox_infiniteBombJump.Location = new System.Drawing.Point(6, 19);
            this.checkBox_infiniteBombJump.Name = "checkBox_infiniteBombJump";
            this.checkBox_infiniteBombJump.Size = new System.Drawing.Size(111, 17);
            this.checkBox_infiniteBombJump.TabIndex = 6;
            this.checkBox_infiniteBombJump.Text = "Infinite bomb jump";
            this.toolTip.SetToolTip(this.checkBox_infiniteBombJump, "You are able to perform infinite bomb jumps, both vertical and diagonal (excludes" +
        " horizontal bomb jumps).");
            this.checkBox_infiniteBombJump.UseVisualStyleBackColor = true;
            // 
            // checkBox_wallJumping
            // 
            this.checkBox_wallJumping.AutoSize = true;
            this.checkBox_wallJumping.Location = new System.Drawing.Point(6, 42);
            this.checkBox_wallJumping.Name = "checkBox_wallJumping";
            this.checkBox_wallJumping.Size = new System.Drawing.Size(86, 17);
            this.checkBox_wallJumping.TabIndex = 7;
            this.checkBox_wallJumping.Text = "Wall jumping";
            this.toolTip.SetToolTip(this.checkBox_wallJumping, "You are able to perform multiple wall jumps along the same wall.");
            this.checkBox_wallJumping.UseVisualStyleBackColor = true;
            // 
            // groupBox_items
            // 
            this.groupBox_items.Controls.Add(this.numericUpDown_itemsRemove);
            this.groupBox_items.Controls.Add(this.label_itemsRemove);
            this.groupBox_items.Controls.Add(this.checkBox_itemsTanks);
            this.groupBox_items.Controls.Add(this.checkBox_itemsAbilities);
            this.groupBox_items.Controls.Add(this.textBox_itemsExcluded);
            this.groupBox_items.Controls.Add(this.label_itemsExcluded);
            this.groupBox_items.Location = new System.Drawing.Point(6, 6);
            this.groupBox_items.Name = "groupBox_items";
            this.groupBox_items.Size = new System.Drawing.Size(161, 88);
            this.groupBox_items.TabIndex = 0;
            this.groupBox_items.TabStop = false;
            this.groupBox_items.Text = "Items";
            // 
            // checkBox_itemsTanks
            // 
            this.checkBox_itemsTanks.AutoSize = true;
            this.checkBox_itemsTanks.Location = new System.Drawing.Point(6, 42);
            this.checkBox_itemsTanks.Name = "checkBox_itemsTanks";
            this.checkBox_itemsTanks.Size = new System.Drawing.Size(56, 17);
            this.checkBox_itemsTanks.TabIndex = 1;
            this.checkBox_itemsTanks.Text = "Tanks";
            this.toolTip.SetToolTip(this.checkBox_itemsTanks, "Shuffles the location of tanks.");
            this.checkBox_itemsTanks.UseVisualStyleBackColor = true;
            // 
            // checkBox_itemsAbilities
            // 
            this.checkBox_itemsAbilities.AutoSize = true;
            this.checkBox_itemsAbilities.Location = new System.Drawing.Point(6, 19);
            this.checkBox_itemsAbilities.Name = "checkBox_itemsAbilities";
            this.checkBox_itemsAbilities.Size = new System.Drawing.Size(61, 17);
            this.checkBox_itemsAbilities.TabIndex = 0;
            this.checkBox_itemsAbilities.Text = "Abilities";
            this.toolTip.SetToolTip(this.checkBox_itemsAbilities, "Shuffles the location of abilities.");
            this.checkBox_itemsAbilities.UseVisualStyleBackColor = true;
            // 
            // textBox_itemsExcluded
            // 
            this.textBox_itemsExcluded.Location = new System.Drawing.Point(66, 62);
            this.textBox_itemsExcluded.Name = "textBox_itemsExcluded";
            this.textBox_itemsExcluded.Size = new System.Drawing.Size(89, 20);
            this.textBox_itemsExcluded.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBox_itemsExcluded, "Items to exclude from randomization, from 0 to 99, separated by commas.");
            // 
            // label_itemsExcluded
            // 
            this.label_itemsExcluded.AutoSize = true;
            this.label_itemsExcluded.Location = new System.Drawing.Point(6, 65);
            this.label_itemsExcluded.Name = "label_itemsExcluded";
            this.label_itemsExcluded.Size = new System.Drawing.Size(54, 13);
            this.label_itemsExcluded.TabIndex = 2;
            this.label_itemsExcluded.Text = "Excluded:";
            this.toolTip.SetToolTip(this.label_itemsExcluded, "Items to exclude from randomization, from 0 to 99, separated by commas.");
            // 
            // groupBox_itemOptions
            // 
            this.groupBox_itemOptions.Controls.Add(this.checkBox_chozoStatueHints);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_noPBsBeforeChozodia);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_iceNotRequired);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_plasmaNotRequired);
            this.groupBox_itemOptions.Location = new System.Drawing.Point(173, 6);
            this.groupBox_itemOptions.Name = "groupBox_itemOptions";
            this.groupBox_itemOptions.Size = new System.Drawing.Size(161, 111);
            this.groupBox_itemOptions.TabIndex = 2;
            this.groupBox_itemOptions.TabStop = false;
            this.groupBox_itemOptions.Text = "Options";
            // 
            // checkBox_chozoStatueHints
            // 
            this.checkBox_chozoStatueHints.AutoSize = true;
            this.checkBox_chozoStatueHints.Location = new System.Drawing.Point(6, 88);
            this.checkBox_chozoStatueHints.Name = "checkBox_chozoStatueHints";
            this.checkBox_chozoStatueHints.Size = new System.Drawing.Size(113, 17);
            this.checkBox_chozoStatueHints.TabIndex = 7;
            this.checkBox_chozoStatueHints.Text = "Chozo statue hints";
            this.toolTip.SetToolTip(this.checkBox_chozoStatueHints, "Chozo statues that show item locations will show the new location of each item.");
            this.checkBox_chozoStatueHints.UseVisualStyleBackColor = true;
            // 
            // checkBox_noPBsBeforeChozodia
            // 
            this.checkBox_noPBsBeforeChozodia.AutoSize = true;
            this.checkBox_noPBsBeforeChozodia.Location = new System.Drawing.Point(6, 65);
            this.checkBox_noPBsBeforeChozodia.Name = "checkBox_noPBsBeforeChozodia";
            this.checkBox_noPBsBeforeChozodia.Size = new System.Drawing.Size(142, 17);
            this.checkBox_noPBsBeforeChozodia.TabIndex = 6;
            this.checkBox_noPBsBeforeChozodia.Text = "No PBs before Chozodia";
            this.toolTip.SetToolTip(this.checkBox_noPBsBeforeChozodia, "Places power bombs in locations that don\'t allow early access to Chozodia (Mother" +
        " Brain must be defeated).");
            this.checkBox_noPBsBeforeChozodia.UseVisualStyleBackColor = true;
            // 
            // checkBox_iceNotRequired
            // 
            this.checkBox_iceNotRequired.AutoSize = true;
            this.checkBox_iceNotRequired.Location = new System.Drawing.Point(6, 19);
            this.checkBox_iceNotRequired.Name = "checkBox_iceNotRequired";
            this.checkBox_iceNotRequired.Size = new System.Drawing.Size(129, 17);
            this.checkBox_iceNotRequired.TabIndex = 4;
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
            this.checkBox_plasmaNotRequired.TabIndex = 5;
            this.checkBox_plasmaNotRequired.Text = "Plasma Beam not required";
            this.toolTip.SetToolTip(this.checkBox_plasmaNotRequired, "Makes black space pirates vulnerable to all beams.");
            this.checkBox_plasmaNotRequired.UseVisualStyleBackColor = true;
            // 
            // groupBox_gameCompletion
            // 
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completion100);
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completionBeatable);
            this.groupBox_gameCompletion.Controls.Add(this.radioButton_completionUnchanged);
            this.groupBox_gameCompletion.Location = new System.Drawing.Point(6, 100);
            this.groupBox_gameCompletion.Name = "groupBox_gameCompletion";
            this.groupBox_gameCompletion.Size = new System.Drawing.Size(161, 88);
            this.groupBox_gameCompletion.TabIndex = 1;
            this.groupBox_gameCompletion.TabStop = false;
            this.groupBox_gameCompletion.Text = "Game Completion";
            // 
            // radioButton_completion100
            // 
            this.radioButton_completion100.AutoSize = true;
            this.radioButton_completion100.Location = new System.Drawing.Point(6, 65);
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
            // radioButton_completionUnchanged
            // 
            this.radioButton_completionUnchanged.AutoSize = true;
            this.radioButton_completionUnchanged.Location = new System.Drawing.Point(6, 19);
            this.radioButton_completionUnchanged.Name = "radioButton_completionUnchanged";
            this.radioButton_completionUnchanged.Size = new System.Drawing.Size(81, 17);
            this.radioButton_completionUnchanged.TabIndex = 0;
            this.radioButton_completionUnchanged.TabStop = true;
            this.radioButton_completionUnchanged.Text = "Unchanged";
            this.toolTip.SetToolTip(this.radioButton_completionUnchanged, "Doesn\'t check if game can be beaten or if any item can be collected.");
            this.radioButton_completionUnchanged.UseVisualStyleBackColor = true;
            // 
            // tabPage_palettes
            // 
            this.tabPage_palettes.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_palettes.Controls.Add(this.groupBox_hue);
            this.tabPage_palettes.Controls.Add(this.groupBox_palettes);
            this.tabPage_palettes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_palettes.Name = "tabPage_palettes";
            this.tabPage_palettes.Size = new System.Drawing.Size(340, 194);
            this.tabPage_palettes.TabIndex = 2;
            this.tabPage_palettes.Text = "Palettes";
            // 
            // groupBox_hue
            // 
            this.groupBox_hue.Controls.Add(this.label_hueMax);
            this.groupBox_hue.Controls.Add(this.label_hueMin);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMax);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMin);
            this.groupBox_hue.Location = new System.Drawing.Point(173, 6);
            this.groupBox_hue.Name = "groupBox_hue";
            this.groupBox_hue.Size = new System.Drawing.Size(161, 88);
            this.groupBox_hue.TabIndex = 1;
            this.groupBox_hue.TabStop = false;
            this.groupBox_hue.Text = "Hue Rotation";
            // 
            // label_hueMax
            // 
            this.label_hueMax.AutoSize = true;
            this.label_hueMax.Location = new System.Drawing.Point(6, 49);
            this.label_hueMax.Name = "label_hueMax";
            this.label_hueMax.Size = new System.Drawing.Size(54, 13);
            this.label_hueMax.TabIndex = 2;
            this.label_hueMax.Text = "Maximum:";
            this.toolTip.SetToolTip(this.label_hueMax, "Rotates hue by no more than this amount.");
            // 
            // label_hueMin
            // 
            this.label_hueMin.AutoSize = true;
            this.label_hueMin.Location = new System.Drawing.Point(6, 23);
            this.label_hueMin.Name = "label_hueMin";
            this.label_hueMin.Size = new System.Drawing.Size(51, 13);
            this.label_hueMin.TabIndex = 0;
            this.label_hueMin.Text = "Minimum:";
            this.toolTip.SetToolTip(this.label_hueMin, "Rotates hue by at least this amount.");
            // 
            // numericUpDown_hueMax
            // 
            this.numericUpDown_hueMax.Location = new System.Drawing.Point(66, 47);
            this.numericUpDown_hueMax.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMax.Name = "numericUpDown_hueMax";
            this.numericUpDown_hueMax.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_hueMax.TabIndex = 3;
            this.toolTip.SetToolTip(this.numericUpDown_hueMax, "Rotates hue by no more than this amount.");
            this.numericUpDown_hueMax.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMax.ValueChanged += new System.EventHandler(this.numericUpDown_hueMax_ValueChanged);
            // 
            // numericUpDown_hueMin
            // 
            this.numericUpDown_hueMin.Location = new System.Drawing.Point(66, 21);
            this.numericUpDown_hueMin.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMin.Name = "numericUpDown_hueMin";
            this.numericUpDown_hueMin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_hueMin.TabIndex = 1;
            this.toolTip.SetToolTip(this.numericUpDown_hueMin, "Rotates hue by at least this amount.");
            this.numericUpDown_hueMin.ValueChanged += new System.EventHandler(this.numericUpDown_hueMin_ValueChanged);
            // 
            // groupBox_palettes
            // 
            this.groupBox_palettes.Controls.Add(this.checkBox_beamPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_enemyPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_tilesetPalettes);
            this.groupBox_palettes.Location = new System.Drawing.Point(6, 6);
            this.groupBox_palettes.Name = "groupBox_palettes";
            this.groupBox_palettes.Size = new System.Drawing.Size(161, 88);
            this.groupBox_palettes.TabIndex = 0;
            this.groupBox_palettes.TabStop = false;
            this.groupBox_palettes.Text = "Palettes";
            // 
            // checkBox_beamPalettes
            // 
            this.checkBox_beamPalettes.AutoSize = true;
            this.checkBox_beamPalettes.Location = new System.Drawing.Point(6, 65);
            this.checkBox_beamPalettes.Name = "checkBox_beamPalettes";
            this.checkBox_beamPalettes.Size = new System.Drawing.Size(58, 17);
            this.checkBox_beamPalettes.TabIndex = 2;
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
            // tabPage_misc
            // 
            this.tabPage_misc.Controls.Add(this.checkBox_skipSuitless);
            this.tabPage_misc.Controls.Add(this.checkBox_removeCutscenes);
            this.tabPage_misc.Controls.Add(this.checkBox_obtainUnkItems);
            this.tabPage_misc.Controls.Add(this.checkBox_enableItemToggle);
            this.tabPage_misc.Controls.Add(this.checkBox_pauseScreenInfo);
            this.tabPage_misc.Controls.Add(this.checkBox_hardModeAvailable);
            this.tabPage_misc.Controls.Add(this.checkBox_removeVariaAnimation);
            this.tabPage_misc.Controls.Add(this.checkBox_removeNorfairVine);
            this.tabPage_misc.Location = new System.Drawing.Point(4, 22);
            this.tabPage_misc.Name = "tabPage_misc";
            this.tabPage_misc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_misc.Size = new System.Drawing.Size(340, 194);
            this.tabPage_misc.TabIndex = 1;
            this.tabPage_misc.Text = "Misc";
            // 
            // checkBox_skipSuitless
            // 
            this.checkBox_skipSuitless.AutoSize = true;
            this.checkBox_skipSuitless.Location = new System.Drawing.Point(185, 75);
            this.checkBox_skipSuitless.Name = "checkBox_skipSuitless";
            this.checkBox_skipSuitless.Size = new System.Drawing.Size(134, 17);
            this.checkBox_skipSuitless.TabIndex = 7;
            this.checkBox_skipSuitless.Text = "Skip suitless sequence";
            this.toolTip.SetToolTip(this.checkBox_skipSuitless, "Places the player before the Chozo ghost fight after escaping Tourian.");
            this.checkBox_skipSuitless.UseVisualStyleBackColor = true;
            // 
            // checkBox_removeCutscenes
            // 
            this.checkBox_removeCutscenes.AutoSize = true;
            this.checkBox_removeCutscenes.Location = new System.Drawing.Point(6, 52);
            this.checkBox_removeCutscenes.Name = "checkBox_removeCutscenes";
            this.checkBox_removeCutscenes.Size = new System.Drawing.Size(118, 17);
            this.checkBox_removeCutscenes.TabIndex = 4;
            this.checkBox_removeCutscenes.Text = "Remove cutscenes";
            this.toolTip.SetToolTip(this.checkBox_removeCutscenes, "Removes most cutscenes in the game.");
            this.checkBox_removeCutscenes.UseVisualStyleBackColor = true;
            // 
            // checkBox_obtainUnkItems
            // 
            this.checkBox_obtainUnkItems.AutoSize = true;
            this.checkBox_obtainUnkItems.Location = new System.Drawing.Point(185, 6);
            this.checkBox_obtainUnkItems.Name = "checkBox_obtainUnkItems";
            this.checkBox_obtainUnkItems.Size = new System.Drawing.Size(131, 17);
            this.checkBox_obtainUnkItems.TabIndex = 1;
            this.checkBox_obtainUnkItems.Text = "Obtain unknown items";
            this.toolTip.SetToolTip(this.checkBox_obtainUnkItems, "Allows unknown items to be obtained and activated before obtaining the fully powe" +
        "red suit.");
            this.checkBox_obtainUnkItems.UseVisualStyleBackColor = true;
            // 
            // checkBox_enableItemToggle
            // 
            this.checkBox_enableItemToggle.AutoSize = true;
            this.checkBox_enableItemToggle.Location = new System.Drawing.Point(6, 6);
            this.checkBox_enableItemToggle.Name = "checkBox_enableItemToggle";
            this.checkBox_enableItemToggle.Size = new System.Drawing.Size(113, 17);
            this.checkBox_enableItemToggle.TabIndex = 0;
            this.checkBox_enableItemToggle.Text = "Enable item toggle";
            this.toolTip.SetToolTip(this.checkBox_enableItemToggle, "Allows items to be toggled on or off from the status screen.");
            this.checkBox_enableItemToggle.UseVisualStyleBackColor = true;
            // 
            // checkBox_pauseScreenInfo
            // 
            this.checkBox_pauseScreenInfo.AutoSize = true;
            this.checkBox_pauseScreenInfo.Location = new System.Drawing.Point(185, 29);
            this.checkBox_pauseScreenInfo.Name = "checkBox_pauseScreenInfo";
            this.checkBox_pauseScreenInfo.Size = new System.Drawing.Size(140, 17);
            this.checkBox_pauseScreenInfo.TabIndex = 3;
            this.checkBox_pauseScreenInfo.Text = "Show pause screen info";
            this.toolTip.SetToolTip(this.checkBox_pauseScreenInfo, "Shows in-game timer and items collected on the pause screen.");
            this.checkBox_pauseScreenInfo.UseVisualStyleBackColor = true;
            // 
            // checkBox_hardModeAvailable
            // 
            this.checkBox_hardModeAvailable.AutoSize = true;
            this.checkBox_hardModeAvailable.Location = new System.Drawing.Point(6, 29);
            this.checkBox_hardModeAvailable.Name = "checkBox_hardModeAvailable";
            this.checkBox_hardModeAvailable.Size = new System.Drawing.Size(159, 17);
            this.checkBox_hardModeAvailable.TabIndex = 2;
            this.checkBox_hardModeAvailable.Text = "Hard Mode always available";
            this.toolTip.SetToolTip(this.checkBox_hardModeAvailable, "Makes Hard Mode available on brand new save files.");
            this.checkBox_hardModeAvailable.UseVisualStyleBackColor = true;
            // 
            // checkBox_removeVariaAnimation
            // 
            this.checkBox_removeVariaAnimation.AutoSize = true;
            this.checkBox_removeVariaAnimation.Location = new System.Drawing.Point(6, 75);
            this.checkBox_removeVariaAnimation.Name = "checkBox_removeVariaAnimation";
            this.checkBox_removeVariaAnimation.Size = new System.Drawing.Size(162, 17);
            this.checkBox_removeVariaAnimation.TabIndex = 6;
            this.checkBox_removeVariaAnimation.Text = "Remove Varia Suit animation";
            this.toolTip.SetToolTip(this.checkBox_removeVariaAnimation, "Removes the short animation that plays upon collecting Varia Suit.");
            this.checkBox_removeVariaAnimation.UseVisualStyleBackColor = true;
            // 
            // checkBox_removeNorfairVine
            // 
            this.checkBox_removeNorfairVine.AutoSize = true;
            this.checkBox_removeNorfairVine.Location = new System.Drawing.Point(185, 52);
            this.checkBox_removeNorfairVine.Name = "checkBox_removeNorfairVine";
            this.checkBox_removeNorfairVine.Size = new System.Drawing.Size(123, 17);
            this.checkBox_removeNorfairVine.TabIndex = 5;
            this.checkBox_removeNorfairVine.Text = "Remove Norfair vine";
            this.toolTip.SetToolTip(this.checkBox_removeNorfairVine, "Removes the vine in Norfair that normally disappears after collecting power grip." +
        "");
            this.checkBox_removeNorfairVine.UseVisualStyleBackColor = true;
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
            this.button_openROM.Click += new System.EventHandler(this.button_openROM_Click);
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
            this.button_randomize.Click += new System.EventHandler(this.button_randomize_Click);
            // 
            // textBox_seed
            // 
            this.textBox_seed.Enabled = false;
            this.textBox_seed.Location = new System.Drawing.Point(227, 43);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(83, 20);
            this.textBox_seed.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBox_seed, "Seed to use for randomization. Must be a number between 0 and 2147483647. Leave b" +
        "lank for a random seed.");
            // 
            // label_seed
            // 
            this.label_seed.AutoSize = true;
            this.label_seed.Enabled = false;
            this.label_seed.Location = new System.Drawing.Point(185, 45);
            this.label_seed.Name = "label_seed";
            this.label_seed.Size = new System.Drawing.Size(35, 13);
            this.label_seed.TabIndex = 4;
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
            // button_appSettings
            // 
            this.button_appSettings.Image = global::mzmr.Properties.Resources.cog;
            this.button_appSettings.Location = new System.Drawing.Point(336, 40);
            this.button_appSettings.Name = "button_appSettings";
            this.button_appSettings.Size = new System.Drawing.Size(24, 24);
            this.button_appSettings.TabIndex = 7;
            this.button_appSettings.UseVisualStyleBackColor = true;
            this.button_appSettings.Click += new System.EventHandler(this.button_appSettings_Click);
            // 
            // label_itemsRemove
            // 
            this.label_itemsRemove.AutoSize = true;
            this.label_itemsRemove.Location = new System.Drawing.Point(89, 20);
            this.label_itemsRemove.Name = "label_itemsRemove";
            this.label_itemsRemove.Size = new System.Drawing.Size(50, 13);
            this.label_itemsRemove.TabIndex = 4;
            this.label_itemsRemove.Text = "Remove:";
            // 
            // numericUpDown_itemsRemove
            // 
            this.numericUpDown_itemsRemove.Location = new System.Drawing.Point(92, 36);
            this.numericUpDown_itemsRemove.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_itemsRemove.Name = "numericUpDown_itemsRemove";
            this.numericUpDown_itemsRemove.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_itemsRemove.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 299);
            this.Controls.Add(this.button_appSettings);
            this.Controls.Add(this.label_seed);
            this.Controls.Add(this.textBox_seed);
            this.Controls.Add(this.button_randomize);
            this.Controls.Add(this.button_openROM);
            this.Controls.Add(this.tabControl_options);
            this.Controls.Add(this.button_saveSettings);
            this.Controls.Add(this.button_loadSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "MZM Randomizer";
            this.tabControl_options.ResumeLayout(false);
            this.tabPage_items.ResumeLayout(false);
            this.groupBox_tricks.ResumeLayout(false);
            this.groupBox_tricks.PerformLayout();
            this.groupBox_items.ResumeLayout(false);
            this.groupBox_items.PerformLayout();
            this.groupBox_itemOptions.ResumeLayout(false);
            this.groupBox_itemOptions.PerformLayout();
            this.groupBox_gameCompletion.ResumeLayout(false);
            this.groupBox_gameCompletion.PerformLayout();
            this.tabPage_palettes.ResumeLayout(false);
            this.groupBox_hue.ResumeLayout(false);
            this.groupBox_hue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).EndInit();
            this.groupBox_palettes.ResumeLayout(false);
            this.groupBox_palettes.PerformLayout();
            this.tabPage_misc.ResumeLayout(false);
            this.tabPage_misc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loadSettings;
        private System.Windows.Forms.Button button_saveSettings;
        private System.Windows.Forms.TabControl tabControl_options;
        private System.Windows.Forms.TabPage tabPage_misc;
        private System.Windows.Forms.Button button_openROM;
        private System.Windows.Forms.Button button_randomize;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.Label label_seed;
        private System.Windows.Forms.CheckBox checkBox_plasmaNotRequired;
        private System.Windows.Forms.CheckBox checkBox_removeNorfairVine;
        private System.Windows.Forms.CheckBox checkBox_removeVariaAnimation;
        private System.Windows.Forms.CheckBox checkBox_hardModeAvailable;
        private System.Windows.Forms.CheckBox checkBox_pauseScreenInfo;
        private System.Windows.Forms.CheckBox checkBox_enableItemToggle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPage_items;
        private System.Windows.Forms.TextBox textBox_itemsExcluded;
        private System.Windows.Forms.Label label_itemsExcluded;
        private System.Windows.Forms.GroupBox groupBox_gameCompletion;
        private System.Windows.Forms.RadioButton radioButton_completionUnchanged;
        private System.Windows.Forms.RadioButton radioButton_completion100;
        private System.Windows.Forms.RadioButton radioButton_completionBeatable;
        private System.Windows.Forms.GroupBox groupBox_itemOptions;
        private System.Windows.Forms.GroupBox groupBox_items;
        private System.Windows.Forms.CheckBox checkBox_obtainUnkItems;
        private System.Windows.Forms.CheckBox checkBox_iceNotRequired;
        private System.Windows.Forms.CheckBox checkBox_removeCutscenes;
        private System.Windows.Forms.TabPage tabPage_palettes;
        private System.Windows.Forms.GroupBox groupBox_hue;
        private System.Windows.Forms.GroupBox groupBox_palettes;
        private System.Windows.Forms.CheckBox checkBox_enemyPalettes;
        private System.Windows.Forms.CheckBox checkBox_tilesetPalettes;
        private System.Windows.Forms.Label label_hueMax;
        private System.Windows.Forms.Label label_hueMin;
        private System.Windows.Forms.NumericUpDown numericUpDown_hueMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_hueMin;
        private System.Windows.Forms.CheckBox checkBox_itemsAbilities;
        private System.Windows.Forms.CheckBox checkBox_beamPalettes;
        private System.Windows.Forms.CheckBox checkBox_skipSuitless;
        private System.Windows.Forms.CheckBox checkBox_noPBsBeforeChozodia;
        private System.Windows.Forms.CheckBox checkBox_itemsTanks;
        private System.Windows.Forms.CheckBox checkBox_chozoStatueHints;
        private System.Windows.Forms.GroupBox groupBox_tricks;
        private System.Windows.Forms.CheckBox checkBox_infiniteBombJump;
        private System.Windows.Forms.CheckBox checkBox_wallJumping;
        private System.Windows.Forms.Button button_appSettings;
        private System.Windows.Forms.NumericUpDown numericUpDown_itemsRemove;
        private System.Windows.Forms.Label label_itemsRemove;
    }
}

