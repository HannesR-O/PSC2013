namespace PSC2013.ES.GUI.Review
{
    partial class ReviewFirstContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WorkFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.reviewSettingsPanel = new PSC2013.ES.GUI.Review.Panels.ReviewSettingsPanel();
            this.reviewInformationPanel1 = new PSC2013.ES.GUI.Review.Panels.ReviewInformationPanel();
            this.reviewSnapshotSelectPanel = new PSC2013.ES.GUI.Review.Panels.ReviewSnapshotSelectPanel();
            this.WorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlow
            // 
            this.WorkFlow.Controls.Add(this.reviewSettingsPanel);
            this.WorkFlow.Controls.Add(this.reviewInformationPanel1);
            this.WorkFlow.Controls.Add(this.reviewSnapshotSelectPanel);
            this.WorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlow.Location = new System.Drawing.Point(0, 0);
            this.WorkFlow.Margin = new System.Windows.Forms.Padding(0);
            this.WorkFlow.Name = "WorkFlow";
            this.WorkFlow.Padding = new System.Windows.Forms.Padding(3);
            this.WorkFlow.Size = new System.Drawing.Size(979, 493);
            this.WorkFlow.TabIndex = 0;
            // 
            // reviewSettingsPanel
            // 
            this.reviewSettingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.reviewSettingsPanel.Location = new System.Drawing.Point(6, 6);
            this.reviewSettingsPanel.Name = "reviewSettingsPanel";
            this.reviewSettingsPanel.Size = new System.Drawing.Size(331, 478);
            this.reviewSettingsPanel.TabIndex = 0;
            // 
            // reviewInformationPanel1
            // 
            this.reviewInformationPanel1.BackColor = System.Drawing.Color.Transparent;
            this.reviewInformationPanel1.Location = new System.Drawing.Point(343, 6);
            this.reviewInformationPanel1.Name = "reviewInformationPanel1";
            this.reviewInformationPanel1.Size = new System.Drawing.Size(326, 478);
            this.reviewInformationPanel1.TabIndex = 1;
            // 
            // reviewSnapshotSelectPanel
            // 
            this.reviewSnapshotSelectPanel.BackColor = System.Drawing.Color.Transparent;
            this.reviewSnapshotSelectPanel.Location = new System.Drawing.Point(675, 6);
            this.reviewSnapshotSelectPanel.Name = "reviewSnapshotSelectPanel";
            this.reviewSnapshotSelectPanel.Size = new System.Drawing.Size(279, 478);
            this.reviewSnapshotSelectPanel.TabIndex = 2;
            // 
            // ReviewFirstContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkFlow);
            this.Name = "ReviewFirstContainer";
            this.Size = new System.Drawing.Size(979, 493);
            this.WorkFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WorkFlow;
        private Panels.ReviewSettingsPanel reviewSettingsPanel;
        private Panels.ReviewInformationPanel reviewInformationPanel1;
        private Panels.ReviewSnapshotSelectPanel reviewSnapshotSelectPanel;
    }
}
