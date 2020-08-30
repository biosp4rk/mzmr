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
            this.numericUpDown_itemsRemove = new System.Windows.Forms.NumericUpDown();
            this.label_itemsRemove = new System.Windows.Forms.Label();
            this.checkBox_itemsTanks = new System.Windows.Forms.CheckBox();
            this.checkBox_itemsAbilities = new System.Windows.Forms.CheckBox();
            this.groupBox_itemOptions = new System.Windows.Forms.GroupBox();
            this.checkBox_chozoStatueHints = new System.Windows.Forms.CheckBox();
            this.checkBox_noPBsBeforeChozodia = new System.Windows.Forms.CheckBox();
            this.checkBox_iceNotRequired = new System.Windows.Forms.CheckBox();
            this.checkBox_plasmaNotRequired = new System.Windows.Forms.CheckBox();
            this.groupBox_gameCompletion = new System.Windows.Forms.GroupBox();
            this.radioButton_completion100 = new System.Windows.Forms.RadioButton();
            this.radioButton_completionBeatable = new System.Windows.Forms.RadioButton();
            this.radioButton_completionUnchanged = new System.Windows.Forms.RadioButton();
            this.tabPage_locs = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_locs = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_enemies = new System.Windows.Forms.CheckBox();
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
            this.checkBox_skipDoorTransitions = new System.Windows.Forms.CheckBox();
            this.checkBox_skipSuitless = new System.Windows.Forms.CheckBox();
            this.checkBox_removeCutscenes = new System.Windows.Forms.CheckBox();
            this.checkBox_obtainUnkItems = new System.Windows.Forms.CheckBox();
            this.checkBox_enableItemToggle = new System.Windows.Forms.CheckBox();
            this.checkBox_pauseScreenInfo = new System.Windows.Forms.CheckBox();
            this.checkBox_hardModeAvailable = new System.Windows.Forms.CheckBox();
            this.button_openROM = new System.Windows.Forms.Button();
            this.button_randomize = new System.Windows.Forms.Button();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label_seed = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_appSettings = new System.Windows.Forms.Button();
            this.tabControl_options.SuspendLayout();
            this.tabPage_items.SuspendLayout();
            this.groupBox_tricks.SuspendLayout();
            this.groupBox_items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).BeginInit();
            this.groupBox_itemOptions.SuspendLayout();
            this.groupBox_gameCompletion.SuspendLayout();
            this.tabPage_locs.SuspendLayout();
            this.tabPage_palettes.SuspendLayout();
            this.groupBox_hue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).BeginInit();
            this.groupBox_palettes.SuspendLayout();
            this.tabPage_misc.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_loadSettings
            // 
            this.button_loadSettings.Enabled = false;
            this.button_loadSettings.Location = new System.Drawing.Point(327, 15);
            this.button_loadSettings.Margin = new System.Windows.Forms.Padding(4);
            this.button_loadSettings.Name = "button_loadSettings";
            this.button_loadSettings.Size = new System.Drawing.Size(113, 28);
            this.button_loadSettings.TabIndex = 2;
            this.button_loadSettings.Text = "Load Settings";
            this.toolTip.SetToolTip(this.button_loadSettings, "Load settings from a file or string.");
            this.button_loadSettings.UseVisualStyleBackColor = true;
            this.button_loadSettings.Click += new System.EventHandler(this.button_loadSettings_Click);
            // 
            // button_saveSettings
            // 
            this.button_saveSettings.Enabled = false;
            this.button_saveSettings.Location = new System.Drawing.Point(328, 50);
            this.button_saveSettings.Margin = new System.Windows.Forms.Padding(4);
            this.button_saveSettings.Name = "button_saveSettings";
            this.button_saveSettings.Size = new System.Drawing.Size(113, 28);
            this.button_saveSettings.TabIndex = 3;
            this.button_saveSettings.Text = "Save Settings";
            this.toolTip.SetToolTip(this.button_saveSettings, "Save settings to a file.");
            this.button_saveSettings.UseVisualStyleBackColor = true;
            this.button_saveSettings.Click += new System.EventHandler(this.button_saveSettings_Click);
            // 
            // tabControl_options
            // 
            this.tabControl_options.Controls.Add(this.tabPage_items);
            this.tabControl_options.Controls.Add(this.tabPage_locs);
            this.tabControl_options.Controls.Add(this.tabPage_palettes);
            this.tabControl_options.Controls.Add(this.tabPage_misc);
            this.tabControl_options.Location = new System.Drawing.Point(16, 86);
            this.tabControl_options.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl_options.Name = "tabControl_options";
            this.tabControl_options.SelectedIndex = 0;
            this.tabControl_options.Size = new System.Drawing.Size(464, 271);
            this.tabControl_options.TabIndex = 6;
            // 
            // tabPage_items
            // 
            this.tabPage_items.Controls.Add(this.groupBox_tricks);
            this.tabPage_items.Controls.Add(this.groupBox_items);
            this.tabPage_items.Controls.Add(this.groupBox_itemOptions);
            this.tabPage_items.Controls.Add(this.groupBox_gameCompletion);
            this.tabPage_items.Location = new System.Drawing.Point(4, 25);
            this.tabPage_items.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_items.Name = "tabPage_items";
            this.tabPage_items.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_items.Size = new System.Drawing.Size(456, 242);
            this.tabPage_items.TabIndex = 0;
            this.tabPage_items.Text = "Items";
            // 
            // groupBox_tricks
            // 
            this.groupBox_tricks.Controls.Add(this.checkBox_infiniteBombJump);
            this.groupBox_tricks.Controls.Add(this.checkBox_wallJumping);
            this.groupBox_tricks.Location = new System.Drawing.Point(231, 151);
            this.groupBox_tricks.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_tricks.Name = "groupBox_tricks";
            this.groupBox_tricks.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_tricks.Size = new System.Drawing.Size(215, 80);
            this.groupBox_tricks.TabIndex = 3;
            this.groupBox_tricks.TabStop = false;
            this.groupBox_tricks.Text = "Tricks";
            // 
            // checkBox_infiniteBombJump
            // 
            this.checkBox_infiniteBombJump.AutoSize = true;
            this.checkBox_infiniteBombJump.Location = new System.Drawing.Point(8, 23);
            this.checkBox_infiniteBombJump.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_infiniteBombJump.Name = "checkBox_infiniteBombJump";
            this.checkBox_infiniteBombJump.Size = new System.Drawing.Size(144, 21);
            this.checkBox_infiniteBombJump.TabIndex = 6;
            this.checkBox_infiniteBombJump.Text = "Infinite bomb jump";
            this.toolTip.SetToolTip(this.checkBox_infiniteBombJump, "You are able to perform infinite bomb jumps, both vertical and diagonal (excludes" +
        " horizontal bomb jumps).");
            this.checkBox_infiniteBombJump.UseVisualStyleBackColor = true;
            // 
            // checkBox_wallJumping
            // 
            this.checkBox_wallJumping.AutoSize = true;
            this.checkBox_wallJumping.Location = new System.Drawing.Point(8, 52);
            this.checkBox_wallJumping.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_wallJumping.Name = "checkBox_wallJumping";
            this.checkBox_wallJumping.Size = new System.Drawing.Size(110, 21);
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
            this.groupBox_items.Location = new System.Drawing.Point(8, 7);
            this.groupBox_items.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_items.Name = "groupBox_items";
            this.groupBox_items.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_items.Size = new System.Drawing.Size(215, 108);
            this.groupBox_items.TabIndex = 0;
            this.groupBox_items.TabStop = false;
            this.groupBox_items.Text = "Items";
            // 
            // numericUpDown_itemsRemove
            // 
            this.numericUpDown_itemsRemove.Location = new System.Drawing.Point(83, 76);
            this.numericUpDown_itemsRemove.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_itemsRemove.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_itemsRemove.Name = "numericUpDown_itemsRemove";
            this.numericUpDown_itemsRemove.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown_itemsRemove.TabIndex = 5;
            // 
            // label_itemsRemove
            // 
            this.label_itemsRemove.AutoSize = true;
            this.label_itemsRemove.Location = new System.Drawing.Point(8, 79);
            this.label_itemsRemove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_itemsRemove.Name = "label_itemsRemove";
            this.label_itemsRemove.Size = new System.Drawing.Size(64, 17);
            this.label_itemsRemove.TabIndex = 4;
            this.label_itemsRemove.Text = "Remove:";
            // 
            // checkBox_itemsTanks
            // 
            this.checkBox_itemsTanks.AutoSize = true;
            this.checkBox_itemsTanks.Location = new System.Drawing.Point(8, 52);
            this.checkBox_itemsTanks.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_itemsTanks.Name = "checkBox_itemsTanks";
            this.checkBox_itemsTanks.Size = new System.Drawing.Size(69, 21);
            this.checkBox_itemsTanks.TabIndex = 1;
            this.checkBox_itemsTanks.Text = "Tanks";
            this.toolTip.SetToolTip(this.checkBox_itemsTanks, "Shuffles the location of tanks.");
            this.checkBox_itemsTanks.UseVisualStyleBackColor = true;
            // 
            // checkBox_itemsAbilities
            // 
            this.checkBox_itemsAbilities.AutoSize = true;
            this.checkBox_itemsAbilities.Location = new System.Drawing.Point(8, 23);
            this.checkBox_itemsAbilities.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_itemsAbilities.Name = "checkBox_itemsAbilities";
            this.checkBox_itemsAbilities.Size = new System.Drawing.Size(78, 21);
            this.checkBox_itemsAbilities.TabIndex = 0;
            this.checkBox_itemsAbilities.Text = "Abilities";
            this.toolTip.SetToolTip(this.checkBox_itemsAbilities, "Shuffles the location of abilities.");
            this.checkBox_itemsAbilities.UseVisualStyleBackColor = true;
            // 
            // groupBox_itemOptions
            // 
            this.groupBox_itemOptions.Controls.Add(this.checkBox_chozoStatueHints);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_noPBsBeforeChozodia);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_iceNotRequired);
            this.groupBox_itemOptions.Controls.Add(this.checkBox_plasmaNotRequired);
            this.groupBox_itemOptions.Location = new System.Drawing.Point(231, 7);
            this.groupBox_itemOptions.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_itemOptions.Name = "groupBox_itemOptions";
            this.groupBox_itemOptions.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_itemOptions.Size = new System.Drawing.Size(215, 137);
            this.groupBox_itemOptions.TabIndex = 2;
            this.groupBox_itemOptions.TabStop = false;
            this.groupBox_itemOptions.Text = "Options";
            // 
            // checkBox_chozoStatueHints
            // 
            this.checkBox_chozoStatueHints.AutoSize = true;
            this.checkBox_chozoStatueHints.Location = new System.Drawing.Point(8, 108);
            this.checkBox_chozoStatueHints.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_chozoStatueHints.Name = "checkBox_chozoStatueHints";
            this.checkBox_chozoStatueHints.Size = new System.Drawing.Size(147, 21);
            this.checkBox_chozoStatueHints.TabIndex = 7;
            this.checkBox_chozoStatueHints.Text = "Chozo statue hints";
            this.toolTip.SetToolTip(this.checkBox_chozoStatueHints, "Chozo statues that show item locations will show the new location of each item.");
            this.checkBox_chozoStatueHints.UseVisualStyleBackColor = true;
            // 
            // checkBox_noPBsBeforeChozodia
            // 
            this.checkBox_noPBsBeforeChozodia.AutoSize = true;
            this.checkBox_noPBsBeforeChozodia.Location = new System.Drawing.Point(8, 80);
            this.checkBox_noPBsBeforeChozodia.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_noPBsBeforeChozodia.Name = "checkBox_noPBsBeforeChozodia";
            this.checkBox_noPBsBeforeChozodia.Size = new System.Drawing.Size(185, 21);
            this.checkBox_noPBsBeforeChozodia.TabIndex = 6;
            this.checkBox_noPBsBeforeChozodia.Text = "No PBs before Chozodia";
            this.toolTip.SetToolTip(this.checkBox_noPBsBeforeChozodia, "Places power bombs in locations that don\'t allow early access to Chozodia (Mother" +
        " Brain must be defeated).");
            this.checkBox_noPBsBeforeChozodia.UseVisualStyleBackColor = true;
            // 
            // checkBox_iceNotRequired
            // 
            this.checkBox_iceNotRequired.AutoSize = true;
            this.checkBox_iceNotRequired.Location = new System.Drawing.Point(8, 23);
            this.checkBox_iceNotRequired.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_iceNotRequired.Name = "checkBox_iceNotRequired";
            this.checkBox_iceNotRequired.Size = new System.Drawing.Size(168, 21);
            this.checkBox_iceNotRequired.TabIndex = 4;
            this.checkBox_iceNotRequired.Text = "Ice beam not required";
            this.toolTip.SetToolTip(this.checkBox_iceNotRequired, "Makes Metroids vulnerable to missiles without having to be frozen.");
            this.checkBox_iceNotRequired.UseVisualStyleBackColor = true;
            // 
            // checkBox_plasmaNotRequired
            // 
            this.checkBox_plasmaNotRequired.AutoSize = true;
            this.checkBox_plasmaNotRequired.Location = new System.Drawing.Point(8, 52);
            this.checkBox_plasmaNotRequired.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_plasmaNotRequired.Name = "checkBox_plasmaNotRequired";
            this.checkBox_plasmaNotRequired.Size = new System.Drawing.Size(197, 21);
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
            this.groupBox_gameCompletion.Location = new System.Drawing.Point(8, 123);
            this.groupBox_gameCompletion.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_gameCompletion.Name = "groupBox_gameCompletion";
            this.groupBox_gameCompletion.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_gameCompletion.Size = new System.Drawing.Size(215, 108);
            this.groupBox_gameCompletion.TabIndex = 1;
            this.groupBox_gameCompletion.TabStop = false;
            this.groupBox_gameCompletion.Text = "Game Completion";
            // 
            // radioButton_completion100
            // 
            this.radioButton_completion100.AutoSize = true;
            this.radioButton_completion100.Location = new System.Drawing.Point(8, 80);
            this.radioButton_completion100.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_completion100.Name = "radioButton_completion100";
            this.radioButton_completion100.Size = new System.Drawing.Size(65, 21);
            this.radioButton_completion100.TabIndex = 2;
            this.radioButton_completion100.TabStop = true;
            this.radioButton_completion100.Text = "100%";
            this.toolTip.SetToolTip(this.radioButton_completion100, "Ensures that all items can be collected. Other settings are taken into account.");
            this.radioButton_completion100.UseVisualStyleBackColor = true;
            // 
            // radioButton_completionBeatable
            // 
            this.radioButton_completionBeatable.AutoSize = true;
            this.radioButton_completionBeatable.Location = new System.Drawing.Point(8, 52);
            this.radioButton_completionBeatable.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_completionBeatable.Name = "radioButton_completionBeatable";
            this.radioButton_completionBeatable.Size = new System.Drawing.Size(85, 21);
            this.radioButton_completionBeatable.TabIndex = 1;
            this.radioButton_completionBeatable.TabStop = true;
            this.radioButton_completionBeatable.Text = "Beatable";
            this.toolTip.SetToolTip(this.radioButton_completionBeatable, "Ensures that the game can be beaten. Other settings are taken into account.");
            this.radioButton_completionBeatable.UseVisualStyleBackColor = true;
            // 
            // radioButton_completionUnchanged
            // 
            this.radioButton_completionUnchanged.AutoSize = true;
            this.radioButton_completionUnchanged.Location = new System.Drawing.Point(8, 23);
            this.radioButton_completionUnchanged.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_completionUnchanged.Name = "radioButton_completionUnchanged";
            this.radioButton_completionUnchanged.Size = new System.Drawing.Size(102, 21);
            this.radioButton_completionUnchanged.TabIndex = 0;
            this.radioButton_completionUnchanged.TabStop = true;
            this.radioButton_completionUnchanged.Text = "Unchanged";
            this.toolTip.SetToolTip(this.radioButton_completionUnchanged, "Doesn\'t check if game can be beaten or if any item can be collected.");
            this.radioButton_completionUnchanged.UseVisualStyleBackColor = true;
            // 
            // tabPage_locs
            // 
            this.tabPage_locs.AutoScroll = true;
            this.tabPage_locs.Controls.Add(this.tableLayoutPanel_locs);
            this.tabPage_locs.Location = new System.Drawing.Point(4, 25);
            this.tabPage_locs.Name = "tabPage_locs";
            this.tabPage_locs.Size = new System.Drawing.Size(456, 242);
            this.tabPage_locs.TabIndex = 3;
            this.tabPage_locs.Text = "Locations";
            // 
            // tableLayoutPanel_locs
            // 
            this.tableLayoutPanel_locs.AutoSize = true;
            this.tableLayoutPanel_locs.ColumnCount = 2;
            this.tableLayoutPanel_locs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_locs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_locs.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_locs.Name = "tableLayoutPanel_locs";
            this.tableLayoutPanel_locs.RowCount = 1;
            this.tableLayoutPanel_locs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_locs.Size = new System.Drawing.Size(150, 150);
            this.tableLayoutPanel_locs.TabIndex = 0;
            // 
            // checkBox_enemies
            // 
            this.checkBox_enemies.AutoSize = true;
            this.checkBox_enemies.Location = new System.Drawing.Point(247, 92);
            this.checkBox_enemies.Name = "checkBox_enemies";
            this.checkBox_enemies.Size = new System.Drawing.Size(158, 21);
            this.checkBox_enemies.TabIndex = 0;
            this.checkBox_enemies.Text = "Randomize enemies";
            this.checkBox_enemies.UseVisualStyleBackColor = true;
            // 
            // tabPage_palettes
            // 
            this.tabPage_palettes.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_palettes.Controls.Add(this.groupBox_hue);
            this.tabPage_palettes.Controls.Add(this.groupBox_palettes);
            this.tabPage_palettes.Location = new System.Drawing.Point(4, 25);
            this.tabPage_palettes.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_palettes.Name = "tabPage_palettes";
            this.tabPage_palettes.Size = new System.Drawing.Size(456, 242);
            this.tabPage_palettes.TabIndex = 2;
            this.tabPage_palettes.Text = "Palettes";
            // 
            // groupBox_hue
            // 
            this.groupBox_hue.Controls.Add(this.label_hueMax);
            this.groupBox_hue.Controls.Add(this.label_hueMin);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMax);
            this.groupBox_hue.Controls.Add(this.numericUpDown_hueMin);
            this.groupBox_hue.Location = new System.Drawing.Point(231, 7);
            this.groupBox_hue.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_hue.Name = "groupBox_hue";
            this.groupBox_hue.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_hue.Size = new System.Drawing.Size(215, 108);
            this.groupBox_hue.TabIndex = 1;
            this.groupBox_hue.TabStop = false;
            this.groupBox_hue.Text = "Hue Rotation";
            // 
            // label_hueMax
            // 
            this.label_hueMax.AutoSize = true;
            this.label_hueMax.Location = new System.Drawing.Point(8, 60);
            this.label_hueMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hueMax.Name = "label_hueMax";
            this.label_hueMax.Size = new System.Drawing.Size(70, 17);
            this.label_hueMax.TabIndex = 2;
            this.label_hueMax.Text = "Maximum:";
            this.toolTip.SetToolTip(this.label_hueMax, "Rotates hue by no more than this amount.");
            // 
            // label_hueMin
            // 
            this.label_hueMin.AutoSize = true;
            this.label_hueMin.Location = new System.Drawing.Point(8, 28);
            this.label_hueMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hueMin.Name = "label_hueMin";
            this.label_hueMin.Size = new System.Drawing.Size(67, 17);
            this.label_hueMin.TabIndex = 0;
            this.label_hueMin.Text = "Minimum:";
            this.toolTip.SetToolTip(this.label_hueMin, "Rotates hue by at least this amount.");
            // 
            // numericUpDown_hueMax
            // 
            this.numericUpDown_hueMax.Location = new System.Drawing.Point(88, 58);
            this.numericUpDown_hueMax.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_hueMax.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMax.Name = "numericUpDown_hueMax";
            this.numericUpDown_hueMax.Size = new System.Drawing.Size(67, 22);
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
            this.numericUpDown_hueMin.Location = new System.Drawing.Point(88, 26);
            this.numericUpDown_hueMin.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_hueMin.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_hueMin.Name = "numericUpDown_hueMin";
            this.numericUpDown_hueMin.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown_hueMin.TabIndex = 1;
            this.toolTip.SetToolTip(this.numericUpDown_hueMin, "Rotates hue by at least this amount.");
            this.numericUpDown_hueMin.ValueChanged += new System.EventHandler(this.numericUpDown_hueMin_ValueChanged);
            // 
            // groupBox_palettes
            // 
            this.groupBox_palettes.Controls.Add(this.checkBox_beamPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_enemyPalettes);
            this.groupBox_palettes.Controls.Add(this.checkBox_tilesetPalettes);
            this.groupBox_palettes.Location = new System.Drawing.Point(8, 7);
            this.groupBox_palettes.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_palettes.Name = "groupBox_palettes";
            this.groupBox_palettes.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_palettes.Size = new System.Drawing.Size(215, 108);
            this.groupBox_palettes.TabIndex = 0;
            this.groupBox_palettes.TabStop = false;
            this.groupBox_palettes.Text = "Palettes";
            // 
            // checkBox_beamPalettes
            // 
            this.checkBox_beamPalettes.AutoSize = true;
            this.checkBox_beamPalettes.Location = new System.Drawing.Point(8, 80);
            this.checkBox_beamPalettes.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_beamPalettes.Name = "checkBox_beamPalettes";
            this.checkBox_beamPalettes.Size = new System.Drawing.Size(73, 21);
            this.checkBox_beamPalettes.TabIndex = 2;
            this.checkBox_beamPalettes.Text = "Beams";
            this.toolTip.SetToolTip(this.checkBox_beamPalettes, "Changes the colors of Samus\'s beams.");
            this.checkBox_beamPalettes.UseVisualStyleBackColor = true;
            // 
            // checkBox_enemyPalettes
            // 
            this.checkBox_enemyPalettes.AutoSize = true;
            this.checkBox_enemyPalettes.Location = new System.Drawing.Point(8, 52);
            this.checkBox_enemyPalettes.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_enemyPalettes.Name = "checkBox_enemyPalettes";
            this.checkBox_enemyPalettes.Size = new System.Drawing.Size(84, 21);
            this.checkBox_enemyPalettes.TabIndex = 1;
            this.checkBox_enemyPalettes.Text = "Enemies";
            this.toolTip.SetToolTip(this.checkBox_enemyPalettes, "Changes the colors of enemies and other sprites.");
            this.checkBox_enemyPalettes.UseVisualStyleBackColor = true;
            // 
            // checkBox_tilesetPalettes
            // 
            this.checkBox_tilesetPalettes.AutoSize = true;
            this.checkBox_tilesetPalettes.Location = new System.Drawing.Point(8, 23);
            this.checkBox_tilesetPalettes.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_tilesetPalettes.Name = "checkBox_tilesetPalettes";
            this.checkBox_tilesetPalettes.Size = new System.Drawing.Size(79, 21);
            this.checkBox_tilesetPalettes.TabIndex = 0;
            this.checkBox_tilesetPalettes.Text = "Tilesets";
            this.toolTip.SetToolTip(this.checkBox_tilesetPalettes, "Changes the colors of tilesets (backgrounds of rooms).");
            this.checkBox_tilesetPalettes.UseVisualStyleBackColor = true;
            // 
            // tabPage_misc
            // 
            this.tabPage_misc.Controls.Add(this.checkBox_enemies);
            this.tabPage_misc.Controls.Add(this.checkBox_skipDoorTransitions);
            this.tabPage_misc.Controls.Add(this.checkBox_skipSuitless);
            this.tabPage_misc.Controls.Add(this.checkBox_removeCutscenes);
            this.tabPage_misc.Controls.Add(this.checkBox_obtainUnkItems);
            this.tabPage_misc.Controls.Add(this.checkBox_enableItemToggle);
            this.tabPage_misc.Controls.Add(this.checkBox_pauseScreenInfo);
            this.tabPage_misc.Controls.Add(this.checkBox_hardModeAvailable);
            this.tabPage_misc.Location = new System.Drawing.Point(4, 25);
            this.tabPage_misc.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_misc.Name = "tabPage_misc";
            this.tabPage_misc.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_misc.Size = new System.Drawing.Size(456, 242);
            this.tabPage_misc.TabIndex = 1;
            this.tabPage_misc.Text = "Misc";
            // 
            // checkBox_skipDoorTransitions
            // 
            this.checkBox_skipDoorTransitions.AutoSize = true;
            this.checkBox_skipDoorTransitions.Location = new System.Drawing.Point(8, 92);
            this.checkBox_skipDoorTransitions.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_skipDoorTransitions.Name = "checkBox_skipDoorTransitions";
            this.checkBox_skipDoorTransitions.Size = new System.Drawing.Size(159, 21);
            this.checkBox_skipDoorTransitions.TabIndex = 8;
            this.checkBox_skipDoorTransitions.Text = "Skip door transitions";
            this.toolTip.SetToolTip(this.checkBox_skipDoorTransitions, "Makes all door transitions instant.");
            this.checkBox_skipDoorTransitions.UseVisualStyleBackColor = true;
            // 
            // checkBox_skipSuitless
            // 
            this.checkBox_skipSuitless.AutoSize = true;
            this.checkBox_skipSuitless.Location = new System.Drawing.Point(247, 64);
            this.checkBox_skipSuitless.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_skipSuitless.Name = "checkBox_skipSuitless";
            this.checkBox_skipSuitless.Size = new System.Drawing.Size(174, 21);
            this.checkBox_skipSuitless.TabIndex = 7;
            this.checkBox_skipSuitless.Text = "Skip suitless sequence";
            this.toolTip.SetToolTip(this.checkBox_skipSuitless, "Places the player before the Chozo ghost fight after escaping Tourian.");
            this.checkBox_skipSuitless.UseVisualStyleBackColor = true;
            // 
            // checkBox_removeCutscenes
            // 
            this.checkBox_removeCutscenes.AutoSize = true;
            this.checkBox_removeCutscenes.Location = new System.Drawing.Point(8, 64);
            this.checkBox_removeCutscenes.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_removeCutscenes.Name = "checkBox_removeCutscenes";
            this.checkBox_removeCutscenes.Size = new System.Drawing.Size(150, 21);
            this.checkBox_removeCutscenes.TabIndex = 4;
            this.checkBox_removeCutscenes.Text = "Remove cutscenes";
            this.toolTip.SetToolTip(this.checkBox_removeCutscenes, "Removes most cutscenes in the game.");
            this.checkBox_removeCutscenes.UseVisualStyleBackColor = true;
            // 
            // checkBox_obtainUnkItems
            // 
            this.checkBox_obtainUnkItems.AutoSize = true;
            this.checkBox_obtainUnkItems.Location = new System.Drawing.Point(247, 7);
            this.checkBox_obtainUnkItems.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_obtainUnkItems.Name = "checkBox_obtainUnkItems";
            this.checkBox_obtainUnkItems.Size = new System.Drawing.Size(169, 21);
            this.checkBox_obtainUnkItems.TabIndex = 1;
            this.checkBox_obtainUnkItems.Text = "Obtain unknown items";
            this.toolTip.SetToolTip(this.checkBox_obtainUnkItems, "Allows unknown items to be obtained and activated before obtaining the fully powe" +
        "red suit.");
            this.checkBox_obtainUnkItems.UseVisualStyleBackColor = true;
            // 
            // checkBox_enableItemToggle
            // 
            this.checkBox_enableItemToggle.AutoSize = true;
            this.checkBox_enableItemToggle.Location = new System.Drawing.Point(8, 7);
            this.checkBox_enableItemToggle.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_enableItemToggle.Name = "checkBox_enableItemToggle";
            this.checkBox_enableItemToggle.Size = new System.Drawing.Size(147, 21);
            this.checkBox_enableItemToggle.TabIndex = 0;
            this.checkBox_enableItemToggle.Text = "Enable item toggle";
            this.toolTip.SetToolTip(this.checkBox_enableItemToggle, "Allows items to be toggled on or off from the status screen.");
            this.checkBox_enableItemToggle.UseVisualStyleBackColor = true;
            // 
            // checkBox_pauseScreenInfo
            // 
            this.checkBox_pauseScreenInfo.AutoSize = true;
            this.checkBox_pauseScreenInfo.Location = new System.Drawing.Point(247, 36);
            this.checkBox_pauseScreenInfo.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_pauseScreenInfo.Name = "checkBox_pauseScreenInfo";
            this.checkBox_pauseScreenInfo.Size = new System.Drawing.Size(181, 21);
            this.checkBox_pauseScreenInfo.TabIndex = 3;
            this.checkBox_pauseScreenInfo.Text = "Show pause screen info";
            this.toolTip.SetToolTip(this.checkBox_pauseScreenInfo, "Shows in-game timer and items collected on the pause screen.");
            this.checkBox_pauseScreenInfo.UseVisualStyleBackColor = true;
            // 
            // checkBox_hardModeAvailable
            // 
            this.checkBox_hardModeAvailable.AutoSize = true;
            this.checkBox_hardModeAvailable.Location = new System.Drawing.Point(8, 36);
            this.checkBox_hardModeAvailable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_hardModeAvailable.Name = "checkBox_hardModeAvailable";
            this.checkBox_hardModeAvailable.Size = new System.Drawing.Size(206, 21);
            this.checkBox_hardModeAvailable.TabIndex = 2;
            this.checkBox_hardModeAvailable.Text = "Hard Mode always available";
            this.toolTip.SetToolTip(this.checkBox_hardModeAvailable, "Makes Hard Mode available on brand new save files.");
            this.checkBox_hardModeAvailable.UseVisualStyleBackColor = true;
            // 
            // button_openROM
            // 
            this.button_openROM.Location = new System.Drawing.Point(16, 15);
            this.button_openROM.Margin = new System.Windows.Forms.Padding(4);
            this.button_openROM.Name = "button_openROM";
            this.button_openROM.Size = new System.Drawing.Size(107, 28);
            this.button_openROM.TabIndex = 0;
            this.button_openROM.Text = "Open ROM";
            this.toolTip.SetToolTip(this.button_openROM, "Open an unmodified Zero Mission ROM to randomize.");
            this.button_openROM.UseVisualStyleBackColor = true;
            this.button_openROM.Click += new System.EventHandler(this.button_openROM_Click);
            // 
            // button_randomize
            // 
            this.button_randomize.Enabled = false;
            this.button_randomize.Location = new System.Drawing.Point(16, 50);
            this.button_randomize.Margin = new System.Windows.Forms.Padding(4);
            this.button_randomize.Name = "button_randomize";
            this.button_randomize.Size = new System.Drawing.Size(107, 28);
            this.button_randomize.TabIndex = 1;
            this.button_randomize.Text = "Randomize";
            this.toolTip.SetToolTip(this.button_randomize, "Randomize and save the ROM.");
            this.button_randomize.UseVisualStyleBackColor = true;
            this.button_randomize.Click += new System.EventHandler(this.button_randomize_Click);
            // 
            // textBox_seed
            // 
            this.textBox_seed.Enabled = false;
            this.textBox_seed.Location = new System.Drawing.Point(193, 18);
            this.textBox_seed.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(109, 22);
            this.textBox_seed.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBox_seed, "Seed to use for randomization. Must be a number between 0 and 2147483647. Leave b" +
        "lank for a random seed.");
            // 
            // label_seed
            // 
            this.label_seed.AutoSize = true;
            this.label_seed.Enabled = false;
            this.label_seed.Location = new System.Drawing.Point(140, 21);
            this.label_seed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_seed.Name = "label_seed";
            this.label_seed.Size = new System.Drawing.Size(45, 17);
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
            this.button_appSettings.Location = new System.Drawing.Point(448, 14);
            this.button_appSettings.Margin = new System.Windows.Forms.Padding(4);
            this.button_appSettings.Name = "button_appSettings";
            this.button_appSettings.Size = new System.Drawing.Size(32, 30);
            this.button_appSettings.TabIndex = 7;
            this.button_appSettings.UseVisualStyleBackColor = true;
            this.button_appSettings.Click += new System.EventHandler(this.button_appSettings_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 368);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "MZM Randomizer";
            this.tabControl_options.ResumeLayout(false);
            this.tabPage_items.ResumeLayout(false);
            this.groupBox_tricks.ResumeLayout(false);
            this.groupBox_tricks.PerformLayout();
            this.groupBox_items.ResumeLayout(false);
            this.groupBox_items.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemsRemove)).EndInit();
            this.groupBox_itemOptions.ResumeLayout(false);
            this.groupBox_itemOptions.PerformLayout();
            this.groupBox_gameCompletion.ResumeLayout(false);
            this.groupBox_gameCompletion.PerformLayout();
            this.tabPage_locs.ResumeLayout(false);
            this.tabPage_locs.PerformLayout();
            this.tabPage_palettes.ResumeLayout(false);
            this.groupBox_hue.ResumeLayout(false);
            this.groupBox_hue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hueMin)).EndInit();
            this.groupBox_palettes.ResumeLayout(false);
            this.groupBox_palettes.PerformLayout();
            this.tabPage_misc.ResumeLayout(false);
            this.tabPage_misc.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBox_hardModeAvailable;
        private System.Windows.Forms.CheckBox checkBox_pauseScreenInfo;
        private System.Windows.Forms.CheckBox checkBox_enableItemToggle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPage_items;
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
        private System.Windows.Forms.CheckBox checkBox_skipDoorTransitions;
        private System.Windows.Forms.TabPage tabPage_locs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_locs;
        private System.Windows.Forms.CheckBox checkBox_enemies;
    }
}

