namespace mzmr
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.textBox_config = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(97, 90);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(74, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROM was randomized successfully!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Config:";
            // 
            // textBox_seed
            // 
            this.textBox_seed.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_seed.Location = new System.Drawing.Point(58, 34);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.ReadOnly = true;
            this.textBox_seed.Size = new System.Drawing.Size(196, 20);
            this.textBox_seed.TabIndex = 4;
            // 
            // textBox_config
            // 
            this.textBox_config.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_config.Location = new System.Drawing.Point(58, 60);
            this.textBox_config.Name = "textBox_config";
            this.textBox_config.ReadOnly = true;
            this.textBox_config.Size = new System.Drawing.Size(196, 20);
            this.textBox_config.TabIndex = 5;
            // 
            // FormComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 125);
            this.Controls.Add(this.textBox_config);
            this.Controls.Add(this.textBox_seed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.TextBox textBox_config;
    }
}