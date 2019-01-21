namespace mzmr
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.textBox_settings = new System.Windows.Forms.TextBox();
            this.button_open_settings = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_open_custom = new System.Windows.Forms.Button();
            this.textBox_custom = new System.Windows.Forms.TextBox();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_settings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_settings
            // 
            this.textBox_settings.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_settings.Location = new System.Drawing.Point(6, 20);
            this.textBox_settings.Name = "textBox_settings";
            this.textBox_settings.Size = new System.Drawing.Size(231, 20);
            this.textBox_settings.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBox_settings, "Put settings string here or load it from a file.");
            // 
            // button_open_settings
            // 
            this.button_open_settings.Location = new System.Drawing.Point(243, 19);
            this.button_open_settings.Name = "button_open_settings";
            this.button_open_settings.Size = new System.Drawing.Size(25, 22);
            this.button_open_settings.TabIndex = 5;
            this.button_open_settings.Text = "...";
            this.toolTip.SetToolTip(this.button_open_settings, "Load settings string from a file.");
            this.button_open_settings.UseVisualStyleBackColor = true;
            this.button_open_settings.Click += new System.EventHandler(this.button_open_settings_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(130, 198);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(211, 198);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_open_custom
            // 
            this.button_open_custom.Location = new System.Drawing.Point(243, 19);
            this.button_open_custom.Name = "button_open_custom";
            this.button_open_custom.Size = new System.Drawing.Size(25, 22);
            this.button_open_custom.TabIndex = 9;
            this.button_open_custom.Text = "...";
            this.toolTip.SetToolTip(this.button_open_custom, "Load item assignments from a file.");
            this.button_open_custom.UseVisualStyleBackColor = true;
            this.button_open_custom.Click += new System.EventHandler(this.button_open_custom_Click);
            // 
            // textBox_custom
            // 
            this.textBox_custom.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_custom.Location = new System.Drawing.Point(6, 20);
            this.textBox_custom.Multiline = true;
            this.textBox_custom.Name = "textBox_custom";
            this.textBox_custom.Size = new System.Drawing.Size(231, 100);
            this.textBox_custom.TabIndex = 8;
            this.toolTip.SetToolTip(this.textBox_custom, "Put item assignments here or load them from a file. Check the readme for more inf" +
        "o.");
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.textBox_settings);
            this.groupBox_settings.Controls.Add(this.button_open_settings);
            this.groupBox_settings.Location = new System.Drawing.Point(12, 12);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Size = new System.Drawing.Size(274, 47);
            this.groupBox_settings.TabIndex = 10;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Text = "Randomizer Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_open_custom);
            this.groupBox1.Controls.Add(this.textBox_custom);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 127);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Item Assignments";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 233);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_settings);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Load Settings";
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_settings;
        private System.Windows.Forms.Button button_open_settings;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_open_custom;
        private System.Windows.Forms.TextBox textBox_custom;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}