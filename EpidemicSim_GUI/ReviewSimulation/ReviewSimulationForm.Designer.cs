namespace PSC2013.ES.GUI.ReviewSimulation
{
    partial class ReviewSimulationForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel_grpBox_bottom = new System.Windows.Forms.GroupBox();
            this.MainPanel_grpBox_main = new System.Windows.Forms.GroupBox();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainPanel_grpBox_main);
            this.MainPanel.Controls.Add(this.MainPanel_grpBox_bottom);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MainPanel.Size = new System.Drawing.Size(284, 262);
            this.MainPanel.TabIndex = 0;
            // 
            // MainPanel_grpBox_bottom
            // 
            this.MainPanel_grpBox_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel_grpBox_bottom.Location = new System.Drawing.Point(3, 209);
            this.MainPanel_grpBox_bottom.Name = "MainPanel_grpBox_bottom";
            this.MainPanel_grpBox_bottom.Size = new System.Drawing.Size(278, 50);
            this.MainPanel_grpBox_bottom.TabIndex = 0;
            this.MainPanel_grpBox_bottom.TabStop = false;
            // 
            // MainPanel_grpBox_main
            // 
            this.MainPanel_grpBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel_grpBox_main.Location = new System.Drawing.Point(3, 3);
            this.MainPanel_grpBox_main.Name = "MainPanel_grpBox_main";
            this.MainPanel_grpBox_main.Size = new System.Drawing.Size(278, 206);
            this.MainPanel_grpBox_main.TabIndex = 1;
            this.MainPanel_grpBox_main.TabStop = false;
            this.MainPanel_grpBox_main.Text = "Settings";
            // 
            // ReviewSimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MainPanel);
            this.Name = "ReviewSimulationForm";
            this.Text = "ReviewSimulationForm";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox MainPanel_grpBox_bottom;
        private System.Windows.Forms.GroupBox MainPanel_grpBox_main;

    }
}