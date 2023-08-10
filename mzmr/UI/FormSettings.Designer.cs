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
            this.label_new = new System.Windows.Forms.Label();
            this.textBox_new = new System.Windows.Forms.TextBox();
            this.button_paste = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label_copied = new System.Windows.Forms.Label();
            this.button_copy = new System.Windows.Forms.Button();
            this.label_current = new System.Windows.Forms.Label();
            this.textBox_current = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_new
            // 
            this.label_new.AutoSize = true;
            this.label_new.Location = new System.Drawing.Point(32, 328);
            this.label_new.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_new.Name = "label_new";
            this.label_new.Size = new System.Drawing.Size(78, 32);
            this.label_new.TabIndex = 0;
            this.label_new.Text = "New:";
            // 
            // textBox_new
            // 
            this.textBox_new.Location = new System.Drawing.Point(38, 385);
            this.textBox_new.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox_new.Multiline = true;
            this.textBox_new.Name = "textBox_new";
            this.textBox_new.Size = new System.Drawing.Size(725, 190);
            this.textBox_new.TabIndex = 3;
            // 
            // button_paste
            // 
            this.button_paste.Location = new System.Drawing.Point(164, 316);
            this.button_paste.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_paste.Name = "button_paste";
            this.button_paste.Size = new System.Drawing.Size(150, 55);
            this.button_paste.TabIndex = 1;
            this.button_paste.Text = "Paste";
            this.button_paste.UseVisualStyleBackColor = true;
            this.button_paste.Click += new System.EventHandler(this.Button_paste_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(321, 594);
            this.button_apply.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(213, 55);
            this.button_apply.TabIndex = 4;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.Button_apply_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(550, 594);
            this.button_close.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(213, 55);
            this.button_close.TabIndex = 5;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.Button_close_Click);
            // 
            // label_copied
            // 
            this.label_copied.AutoSize = true;
            this.label_copied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_copied.Location = new System.Drawing.Point(330, 40);
            this.label_copied.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_copied.Name = "label_copied";
            this.label_copied.Size = new System.Drawing.Size(172, 32);
            this.label_copied.TabIndex = 8;
            this.label_copied.Text = "Text copied";
            this.label_copied.Visible = false;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(164, 28);
            this.button_copy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(150, 55);
            this.button_copy.TabIndex = 7;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.Button_copy_Click);
            // 
            // label_current
            // 
            this.label_current.AutoSize = true;
            this.label_current.Location = new System.Drawing.Point(32, 40);
            this.label_current.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_current.Name = "label_current";
            this.label_current.Size = new System.Drawing.Size(116, 32);
            this.label_current.TabIndex = 6;
            this.label_current.Text = "Current:";
            // 
            // textBox_current
            // 
            this.textBox_current.Location = new System.Drawing.Point(38, 97);
            this.textBox_current.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox_current.Multiline = true;
            this.textBox_current.Name = "textBox_current";
            this.textBox_current.ReadOnly = true;
            this.textBox_current.Size = new System.Drawing.Size(725, 190);
            this.textBox_current.TabIndex = 9;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 676);
            this.Controls.Add(this.label_copied);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.label_current);
            this.Controls.Add(this.textBox_current);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_paste);
            this.Controls.Add(this.label_new);
            this.Controls.Add(this.textBox_new);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_new;
        private System.Windows.Forms.TextBox textBox_new;
        private System.Windows.Forms.Button button_paste;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label_copied;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Label label_current;
        private System.Windows.Forms.TextBox textBox_current;
    }
}