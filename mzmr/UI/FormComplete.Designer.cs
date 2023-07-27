namespace mzmr.UI
{
    partial class FormComplete
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
            this.button_ok = new System.Windows.Forms.Button();
            this.label_success = new System.Windows.Forms.Label();
            this.label_seed = new System.Windows.Forms.Label();
            this.label_config = new System.Windows.Forms.Label();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.textBox_config = new System.Windows.Forms.TextBox();
            this.label_maps = new System.Windows.Forms.Label();
            this.label_log = new System.Windows.Forms.Label();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.textBox_mapsPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(256, 324);
            this.button_ok.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(198, 54);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // label_success
            // 
            this.label_success.AutoSize = true;
            this.label_success.Location = new System.Drawing.Point(126, 21);
            this.label_success.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_success.Name = "label_success";
            this.label_success.Size = new System.Drawing.Size(461, 32);
            this.label_success.TabIndex = 1;
            this.label_success.Text = "ROM was randomized successfully!";
            // 
            // label_seed
            // 
            this.label_seed.AutoSize = true;
            this.label_seed.Location = new System.Drawing.Point(32, 89);
            this.label_seed.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_seed.Name = "label_seed";
            this.label_seed.Size = new System.Drawing.Size(89, 32);
            this.label_seed.TabIndex = 2;
            this.label_seed.Text = "Seed:";
            // 
            // label_config
            // 
            this.label_config.AutoSize = true;
            this.label_config.Location = new System.Drawing.Point(32, 151);
            this.label_config.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_config.Name = "label_config";
            this.label_config.Size = new System.Drawing.Size(105, 32);
            this.label_config.TabIndex = 3;
            this.label_config.Text = "Config:";
            // 
            // textBox_seed
            // 
            this.textBox_seed.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_seed.Location = new System.Drawing.Point(154, 81);
            this.textBox_seed.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.ReadOnly = true;
            this.textBox_seed.Size = new System.Drawing.Size(516, 38);
            this.textBox_seed.TabIndex = 4;
            // 
            // textBox_config
            // 
            this.textBox_config.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_config.Location = new System.Drawing.Point(154, 143);
            this.textBox_config.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.textBox_config.Name = "textBox_config";
            this.textBox_config.ReadOnly = true;
            this.textBox_config.Size = new System.Drawing.Size(516, 38);
            this.textBox_config.TabIndex = 5;
            // 
            // label_maps
            // 
            this.label_maps.AutoSize = true;
            this.label_maps.Location = new System.Drawing.Point(32, 275);
            this.label_maps.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_maps.Name = "label_maps";
            this.label_maps.Size = new System.Drawing.Size(91, 32);
            this.label_maps.TabIndex = 7;
            this.label_maps.Text = "Maps:";
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(32, 213);
            this.label_log.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(70, 32);
            this.label_log.TabIndex = 6;
            this.label_log.Text = "Log:";
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_logPath.Location = new System.Drawing.Point(154, 205);
            this.textBox_logPath.Margin = new System.Windows.Forms.Padding(8);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.ReadOnly = true;
            this.textBox_logPath.Size = new System.Drawing.Size(516, 38);
            this.textBox_logPath.TabIndex = 10;
            this.textBox_logPath.Text = "None";
            // 
            // textBox_mapsPath
            // 
            this.textBox_mapsPath.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_mapsPath.Location = new System.Drawing.Point(154, 267);
            this.textBox_mapsPath.Margin = new System.Windows.Forms.Padding(8);
            this.textBox_mapsPath.Name = "textBox_mapsPath";
            this.textBox_mapsPath.ReadOnly = true;
            this.textBox_mapsPath.Size = new System.Drawing.Size(516, 38);
            this.textBox_mapsPath.TabIndex = 11;
            this.textBox_mapsPath.Text = "None";
            // 
            // FormComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 403);
            this.Controls.Add(this.textBox_mapsPath);
            this.Controls.Add(this.textBox_logPath);
            this.Controls.Add(this.label_maps);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.textBox_config);
            this.Controls.Add(this.textBox_seed);
            this.Controls.Add(this.label_config);
            this.Controls.Add(this.label_seed);
            this.Controls.Add(this.label_success);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormComplete";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randomization Complete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_success;
        private System.Windows.Forms.Label label_seed;
        private System.Windows.Forms.Label label_config;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.TextBox textBox_config;
        private System.Windows.Forms.Label label_maps;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.TextBox textBox_mapsPath;
    }
}