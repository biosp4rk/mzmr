namespace mzmr
{
    partial class FormAppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppSettings));
            this.checkBox_autoLoadROM = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberSettings = new System.Windows.Forms.CheckBox();
            this.checkBox_saveLogFile = new System.Windows.Forms.CheckBox();
            this.checkBox_saveMapImages = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_autoLoadROM
            // 
            this.checkBox_autoLoadROM.AutoSize = true;
            this.checkBox_autoLoadROM.Location = new System.Drawing.Point(12, 12);
            this.checkBox_autoLoadROM.Name = "checkBox_autoLoadROM";
            this.checkBox_autoLoadROM.Size = new System.Drawing.Size(182, 17);
            this.checkBox_autoLoadROM.TabIndex = 0;
            this.checkBox_autoLoadROM.Text = "Automatically load previous ROM";
            this.checkBox_autoLoadROM.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberSettings
            // 
            this.checkBox_rememberSettings.AutoSize = true;
            this.checkBox_rememberSettings.Location = new System.Drawing.Point(12, 39);
            this.checkBox_rememberSettings.Name = "checkBox_rememberSettings";
            this.checkBox_rememberSettings.Size = new System.Drawing.Size(227, 17);
            this.checkBox_rememberSettings.TabIndex = 8;
            this.checkBox_rememberSettings.Text = "Remember previous randomization settings";
            this.checkBox_rememberSettings.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveLogFile
            // 
            this.checkBox_saveLogFile.AutoSize = true;
            this.checkBox_saveLogFile.Location = new System.Drawing.Point(12, 66);
            this.checkBox_saveLogFile.Name = "checkBox_saveLogFile";
            this.checkBox_saveLogFile.Size = new System.Drawing.Size(127, 17);
            this.checkBox_saveLogFile.TabIndex = 9;
            this.checkBox_saveLogFile.Text = "Always save a log file";
            this.checkBox_saveLogFile.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveMapImages
            // 
            this.checkBox_saveMapImages.AutoSize = true;
            this.checkBox_saveMapImages.Location = new System.Drawing.Point(12, 93);
            this.checkBox_saveMapImages.Name = "checkBox_saveMapImages";
            this.checkBox_saveMapImages.Size = new System.Drawing.Size(144, 17);
            this.checkBox_saveMapImages.TabIndex = 10;
            this.checkBox_saveMapImages.Text = "Always save map images";
            this.checkBox_saveMapImages.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(83, 120);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 11;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(164, 120);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 12;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // FormAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 155);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkBox_saveMapImages);
            this.Controls.Add(this.checkBox_saveLogFile);
            this.Controls.Add(this.checkBox_rememberSettings);
            this.Controls.Add(this.checkBox_autoLoadROM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAppSettings";
            this.Text = "Application Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_autoLoadROM;
        private System.Windows.Forms.CheckBox checkBox_rememberSettings;
        private System.Windows.Forms.CheckBox checkBox_saveLogFile;
        private System.Windows.Forms.CheckBox checkBox_saveMapImages;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}