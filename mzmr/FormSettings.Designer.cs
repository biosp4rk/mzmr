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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.textBox_string = new System.Windows.Forms.TextBox();
            this.label_file = new System.Windows.Forms.Label();
            this.label_string = new System.Windows.Forms.Label();
            this.label_or = new System.Windows.Forms.Label();
            this.button_open = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_file
            // 
            this.textBox_file.Location = new System.Drawing.Point(55, 12);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(200, 20);
            this.textBox_file.TabIndex = 0;
            // 
            // textBox_string
            // 
            this.textBox_string.Location = new System.Drawing.Point(55, 55);
            this.textBox_string.Name = "textBox_string";
            this.textBox_string.Size = new System.Drawing.Size(200, 20);
            this.textBox_string.TabIndex = 1;
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(12, 15);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(26, 13);
            this.label_file.TabIndex = 2;
            this.label_file.Text = "File:";
            // 
            // label_string
            // 
            this.label_string.AutoSize = true;
            this.label_string.Location = new System.Drawing.Point(12, 58);
            this.label_string.Name = "label_string";
            this.label_string.Size = new System.Drawing.Size(37, 13);
            this.label_string.TabIndex = 3;
            this.label_string.Text = "String:";
            // 
            // label_or
            // 
            this.label_or.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_or.Location = new System.Drawing.Point(55, 35);
            this.label_or.Name = "label_or";
            this.label_or.Size = new System.Drawing.Size(200, 17);
            this.label_or.TabIndex = 4;
            this.label_or.Text = "OR";
            this.label_or.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(261, 11);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(25, 22);
            this.button_open.TabIndex = 5;
            this.button_open.Text = "...";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(100, 83);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(181, 83);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 118);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.label_or);
            this.Controls.Add(this.label_string);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.textBox_string);
            this.Controls.Add(this.textBox_file);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Load Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.TextBox textBox_string;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Label label_string;
        private System.Windows.Forms.Label label_or;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}