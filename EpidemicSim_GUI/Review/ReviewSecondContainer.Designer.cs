namespace PSC2013.ES.GUI.Review
{
    partial class ReviewSecondContainer
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
            this.reviewOutputPanel = new PSC2013.ES.GUI.Review.Panels.ReviewOutputPanel();
            this.reviewViewPanel = new PSC2013.ES.GUI.Review.Panels.ReviewViewPanel();
            this.WorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlow
            // 
            this.WorkFlow.Controls.Add(this.reviewOutputPanel);
            this.WorkFlow.Controls.Add(this.reviewViewPanel);
            this.WorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlow.Location = new System.Drawing.Point(0, 0);
            this.WorkFlow.Margin = new System.Windows.Forms.Padding(0);
            this.WorkFlow.Name = "WorkFlow";
            this.WorkFlow.Padding = new System.Windows.Forms.Padding(3);
            this.WorkFlow.Size = new System.Drawing.Size(877, 475);
            this.WorkFlow.TabIndex = 0;
            // 
            // reviewOutputPanel
            // 
            this.reviewOutputPanel.BackColor = System.Drawing.Color.Transparent;
            this.reviewOutputPanel.Location = new System.Drawing.Point(6, 6);
            this.reviewOutputPanel.Name = "reviewOutputPanel";
            this.reviewOutputPanel.Size = new System.Drawing.Size(300, 461);
            this.reviewOutputPanel.TabIndex = 0;
            // 
            // reviewViewPanel
            // 
            this.reviewViewPanel.BackColor = System.Drawing.Color.Transparent;
            this.reviewViewPanel.Location = new System.Drawing.Point(312, 6);
            this.reviewViewPanel.Name = "reviewViewPanel";
            this.reviewViewPanel.Size = new System.Drawing.Size(547, 461);
            this.reviewViewPanel.TabIndex = 1;
            // 
            // ReviewSecondContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkFlow);
            this.Name = "ReviewSecondContainer";
            this.Size = new System.Drawing.Size(877, 475);
            this.WorkFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WorkFlow;
        private Panels.ReviewOutputPanel reviewOutputPanel;
        private Panels.ReviewViewPanel reviewViewPanel;
    }
}
