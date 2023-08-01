namespace mzmr.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label_settings = new System.Windows.Forms.Label();
            this.textBox_settings = new System.Windows.Forms.TextBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.label_copied = new System.Windows.Forms.Label();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_settings
            // 
            this.label_settings.AutoSize = true;
            this.label_settings.Location = new System.Drawing.Point(32, 40);
            this.label_settings.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_settings.Name = "label_settings";
            this.label_settings.Size = new System.Drawing.Size(182, 32);
            this.label_settings.TabIndex = 0;
            this.label_settings.Text = "Config string:";
            // 
            // textBox_settings
            // 
            this.textBox_settings.Location = new System.Drawing.Point(38, 97);
            this.textBox_settings.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox_settings.Multiline = true;
            this.textBox_settings.Name = "textBox_settings";
            this.textBox_settings.Size = new System.Drawing.Size(725, 190);
            this.textBox_settings.TabIndex = 3;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(230, 28);
            this.button_copy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(150, 55);
            this.button_copy.TabIndex = 1;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.Button_copy_Click);
            // 
            // label_copied
            // 
            this.label_copied.AutoSize = true;
            this.label_copied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_copied.Location = new System.Drawing.Point(396, 40);
            this.label_copied.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_copied.Name = "label_copied";
            this.label_copied.Size = new System.Drawing.Size(172, 32);
            this.label_copied.TabIndex = 2;
            this.label_copied.Text = "Text copied";
            this.label_copied.Visible = false;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(321, 306);
            this.button_apply.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(213, 55);
            this.button_apply.TabIndex = 4;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.Button_apply_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(550, 306);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(213, 55);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.Button_cancel_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.label_copied);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.label_settings);
            this.Controls.Add(this.textBox_settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.TextBox textBox_settings;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Label label_copied;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_cancel;
    }
}