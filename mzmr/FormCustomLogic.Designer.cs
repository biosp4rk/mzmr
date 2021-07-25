namespace mzmr
{
    partial class FormCustomLogic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomLogic));
            this.textBox_customLogicPath = new System.Windows.Forms.TextBox();
            this.button_open_settings = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_customLogicPath
            // 
            this.textBox_customLogicPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_customLogicPath.Location = new System.Drawing.Point(15, 51);
            this.textBox_customLogicPath.Name = "textBox_customLogicPath";
            this.textBox_customLogicPath.ReadOnly = true;
            this.textBox_customLogicPath.Size = new System.Drawing.Size(256, 20);
            this.textBox_customLogicPath.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBox_customLogicPath, "Put settings string here or load it from a file.");
            // 
            // button_open_settings
            // 
            this.button_open_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_open_settings.Location = new System.Drawing.Point(277, 50);
            this.button_open_settings.Name = "button_open_settings";
            this.button_open_settings.Size = new System.Drawing.Size(25, 22);
            this.button_open_settings.TabIndex = 5;
            this.button_open_settings.Text = "...";
            this.toolTip.SetToolTip(this.button_open_settings, "Load settings string from a file.");
            this.button_open_settings.UseVisualStyleBackColor = true;
            this.button_open_settings.Click += new System.EventHandler(this.Button_open_settings_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(145, 77);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(226, 77);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Skip";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.Button_cancel_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "The settings that were loaded used a Custom Logic, please input where this logic " +
    "is located on your machine.";
            // 
            // FormCustomLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_customLogicPath);
            this.Controls.Add(this.button_open_settings);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCustomLogic";
            this.Text = "Load Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_customLogicPath;
        private System.Windows.Forms.Button button_open_settings;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
    }
}