namespace PSC2013.ES.GUI.Simulation
{
    partial class SimulationFirstContainer
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
            this.settingsPanel = new PSC2013.ES.GUI.Simulation.SimulationSettingsPanel();
            this.WorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlow
            // 
            this.WorkFlow.BackColor = System.Drawing.SystemColors.Control;
            this.WorkFlow.Controls.Add(this.settingsPanel);
            this.WorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlow.Location = new System.Drawing.Point(0, 0);
            this.WorkFlow.Margin = new System.Windows.Forms.Padding(0);
            this.WorkFlow.Name = "WorkFlow";
            this.WorkFlow.Padding = new System.Windows.Forms.Padding(3);
            this.WorkFlow.Size = new System.Drawing.Size(936, 434);
            this.WorkFlow.TabIndex = 0;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.settingsPanel.Location = new System.Drawing.Point(6, 6);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(276, 420);
            this.settingsPanel.TabIndex = 0;
            // 
            // SimulationFirstContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.WorkFlow);
            this.Name = "SimulationFirstContainer";
            this.Size = new System.Drawing.Size(936, 434);
            this.WorkFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WorkFlow;
        private SimulationSettingsPanel settingsPanel;
    }
}
