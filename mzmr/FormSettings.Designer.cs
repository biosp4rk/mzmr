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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_settings
            // 
            this.textBox_settings.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_settings.Location = new System.Drawing.Point(13, 13);
            this.textBox_settings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_settings.Name = "textBox_settings";
            this.textBox_settings.Size = new System.Drawing.Size(307, 23);
            this.textBox_settings.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBox_settings, "Put settings string here or load it from a file.");
            // 
            // button_open_settings
            // 
            this.button_open_settings.Location = new System.Drawing.Point(329, 11);
            this.button_open_settings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_open_settings.Name = "button_open_settings";
            this.button_open_settings.Size = new System.Drawing.Size(33, 27);
            this.button_open_settings.TabIndex = 5;
            this.button_open_settings.Text = "...";
            this.toolTip.SetToolTip(this.button_open_settings, "Load settings string from a file.");
            this.button_open_settings.UseVisualStyleBackColor = true;
            this.button_open_settings.Click += new System.EventHandler(this.button_open_settings_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(154, 46);
            this.button_ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 28);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(262, 46);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 28);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 87);
            this.Controls.Add(this.textBox_settings);
            this.Controls.Add(this.button_open_settings);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Load Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_settings;
        private System.Windows.Forms.Button button_open_settings;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}