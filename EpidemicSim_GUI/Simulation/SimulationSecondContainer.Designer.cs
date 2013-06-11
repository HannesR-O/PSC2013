namespace PSC2013.ES.GUI.Simulation
{
    partial class SimulationSecondContainer
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
            this.simulationFinalSettingsPanel = new PSC2013.ES.GUI.Simulation.Panels.SimulationFinalSettingsPanel();
            this.simulationOutputPanel = new PSC2013.ES.GUI.Simulation.Panels.SimulationOutputPanel();
            this.WorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlow
            // 
            this.WorkFlow.BackColor = System.Drawing.SystemColors.Control;
            this.WorkFlow.Controls.Add(this.simulationFinalSettingsPanel);
            this.WorkFlow.Controls.Add(this.simulationOutputPanel);
            this.WorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlow.Location = new System.Drawing.Point(0, 0);
            this.WorkFlow.Margin = new System.Windows.Forms.Padding(0);
            this.WorkFlow.Name = "WorkFlow";
            this.WorkFlow.Padding = new System.Windows.Forms.Padding(3);
            this.WorkFlow.Size = new System.Drawing.Size(771, 483);
            this.WorkFlow.TabIndex = 0;
            // 
            // simulationFinalSettingsPanel
            // 
            this.simulationFinalSettingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.simulationFinalSettingsPanel.Location = new System.Drawing.Point(6, 6);
            this.simulationFinalSettingsPanel.Name = "simulationFinalSettingsPanel";
            this.simulationFinalSettingsPanel.Size = new System.Drawing.Size(272, 421);
            this.simulationFinalSettingsPanel.TabIndex = 0;
            // 
            // simulationOutputPanel
            // 
            this.simulationOutputPanel.BackColor = System.Drawing.Color.Transparent;
            this.simulationOutputPanel.Enabled = false;
            this.simulationOutputPanel.Location = new System.Drawing.Point(284, 6);
            this.simulationOutputPanel.Name = "simulationOutputPanel";
            this.simulationOutputPanel.Size = new System.Drawing.Size(443, 421);
            this.simulationOutputPanel.TabIndex = 1;
            // 
            // SimulationSecondContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.WorkFlow);
            this.Name = "SimulationSecondContainer";
            this.Size = new System.Drawing.Size(771, 483);
            this.WorkFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WorkFlow;
        private Panels.SimulationFinalSettingsPanel simulationFinalSettingsPanel;
        private Panels.SimulationOutputPanel simulationOutputPanel;
    }
}
