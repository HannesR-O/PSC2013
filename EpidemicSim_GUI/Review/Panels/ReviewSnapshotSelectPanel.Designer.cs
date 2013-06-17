namespace PSC2013.ES.GUI.Review.Panels
{
    partial class ReviewSnapshotSelectPanel
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
            this.GrpBox_Main = new System.Windows.Forms.GroupBox();
            this.ListBox_Snapshots = new System.Windows.Forms.ListBox();
            this.separator_1 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.TextBox_Hint = new System.Windows.Forms.TextBox();
            this.ProgressBar_Main = new System.Windows.Forms.ProgressBar();
            this.GrpBox_Main.SuspendLayout();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.TextBox_Hint);
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.separator_1);
            this.GrpBox_Main.Controls.Add(this.ListBox_Snapshots);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(279, 429);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Snapshots";
            // 
            // ListBox_Snapshots
            // 
            this.ListBox_Snapshots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Snapshots.FormattingEnabled = true;
            this.ListBox_Snapshots.IntegralHeight = false;
            this.ListBox_Snapshots.Location = new System.Drawing.Point(6, 19);
            this.ListBox_Snapshots.Name = "ListBox_Snapshots";
            this.ListBox_Snapshots.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_Snapshots.Size = new System.Drawing.Size(267, 250);
            this.ListBox_Snapshots.TabIndex = 0;
            // 
            // separator_1
            // 
            this.separator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_1.BackColor = System.Drawing.Color.Transparent;
            this.separator_1.Location = new System.Drawing.Point(6, 275);
            this.separator_1.Name = "separator_1";
            this.separator_1.Size = new System.Drawing.Size(267, 5);
            this.separator_1.TabIndex = 1;
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Next);
            this.FlowPanel_Bottom.Controls.Add(this.ProgressBar_Main);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 397);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(273, 29);
            this.FlowPanel_Bottom.TabIndex = 2;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(195, 3);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 0;
            this.Btn_Next.Text = "Next >";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // TextBox_Hint
            // 
            this.TextBox_Hint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Hint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Hint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox_Hint.Enabled = false;
            this.TextBox_Hint.Location = new System.Drawing.Point(10, 286);
            this.TextBox_Hint.Multiline = true;
            this.TextBox_Hint.Name = "TextBox_Hint";
            this.TextBox_Hint.ReadOnly = true;
            this.TextBox_Hint.Size = new System.Drawing.Size(259, 105);
            this.TextBox_Hint.TabIndex = 3;
            this.TextBox_Hint.Text = "Hint: Select those snapshots you would like to have graphics of here.";
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.Location = new System.Drawing.Point(34, 3);
            this.ProgressBar_Main.MarqueeAnimationSpeed = 50;
            this.ProgressBar_Main.Maximum = 1;
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(155, 23);
            this.ProgressBar_Main.Step = 1;
            this.ProgressBar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar_Main.TabIndex = 1;
            this.ProgressBar_Main.Value = 1;
            // 
            // ReviewSnapshotSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "ReviewSnapshotSelectPanel";
            this.Size = new System.Drawing.Size(279, 429);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private System.Windows.Forms.ListBox ListBox_Snapshots;
        private Miscellaneous.Separator separator_1;
        private System.Windows.Forms.TextBox TextBox_Hint;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.ProgressBar ProgressBar_Main;
    }
}
