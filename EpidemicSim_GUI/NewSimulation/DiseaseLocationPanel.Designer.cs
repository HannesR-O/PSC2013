namespace PSC2013.ES.GUI.NewSimulation
{
    partial class DiseaseLocationPanel
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
            this.GrpBox_location = new System.Windows.Forms.GroupBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ListBoxDepartments = new System.Windows.Forms.ListBox();
            this.GrpBox_location.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_location
            // 
            this.GrpBox_location.Controls.Add(this.ListBoxDepartments);
            this.GrpBox_location.Controls.Add(this.ProgressBar);
            this.GrpBox_location.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_location.Location = new System.Drawing.Point(5, 5);
            this.GrpBox_location.Name = "GrpBox_location";
            this.GrpBox_location.Size = new System.Drawing.Size(240, 390);
            this.GrpBox_location.TabIndex = 0;
            this.GrpBox_location.TabStop = false;
            this.GrpBox_location.Text = "Startlocation";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(6, 361);
            this.ProgressBar.MarqueeAnimationSpeed = 25;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(228, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.TabIndex = 0;
            // 
            // lstBox_departments
            // 
            this.ListBoxDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxDepartments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxDepartments.FormattingEnabled = true;
            this.ListBoxDepartments.IntegralHeight = false;
            this.ListBoxDepartments.Location = new System.Drawing.Point(6, 19);
            this.ListBoxDepartments.Name = "lstBox_departments";
            this.ListBoxDepartments.Size = new System.Drawing.Size(228, 336);
            this.ListBoxDepartments.TabIndex = 1;
            // 
            // DiseaseLocationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpBox_location);
            this.Name = "DiseaseLocationPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(250, 400);
            this.GrpBox_location.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_location;
        public System.Windows.Forms.ProgressBar ProgressBar;
        public System.Windows.Forms.ListBox ListBoxDepartments;
    }
}
