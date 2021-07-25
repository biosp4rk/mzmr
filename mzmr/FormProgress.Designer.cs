namespace mzmr
{
    partial class FormProgress
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgressInfo = new System.Windows.Forms.Label();
            this.buttonAction = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.detailLogView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(301, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // labelProgressInfo
            // 
            this.labelProgressInfo.AutoSize = true;
            this.labelProgressInfo.Location = new System.Drawing.Point(13, 42);
            this.labelProgressInfo.Name = "labelProgressInfo";
            this.labelProgressInfo.Size = new System.Drawing.Size(68, 13);
            this.labelProgressInfo.TabIndex = 1;
            this.labelProgressInfo.Text = "Randomizing";
            // 
            // buttonAction
            // 
            this.buttonAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAction.Location = new System.Drawing.Point(237, 384);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(75, 23);
            this.buttonAction.TabIndex = 2;
            this.buttonAction.Text = "Abort";
            this.buttonAction.UseVisualStyleBackColor = true;
            this.buttonAction.Click += new System.EventHandler(this.ButtonAction_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDetails.Enabled = false;
            this.buttonDetails.Location = new System.Drawing.Point(12, 384);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 3;
            this.buttonDetails.Text = "Detailed Log";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.ButtonDetails_Click);
            // 
            // detailLogView
            // 
            this.detailLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLogView.Location = new System.Drawing.Point(12, 58);
            this.detailLogView.Name = "detailLogView";
            this.detailLogView.Size = new System.Drawing.Size(301, 320);
            this.detailLogView.TabIndex = 4;
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 419);
            this.Controls.Add(this.detailLogView);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.labelProgressInfo);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgress";
            this.ShowIcon = false;
            this.Text = "Randomization progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgressInfo;
        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.TreeView detailLogView;
    }
}