using PSC2013.ES.GUI.Simulation.Panels;
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
            this.simulationSettingsPanel = new PSC2013.ES.GUI.Simulation.Panels.SimulationSettingsPanel();
            this.simulationDiseasePanel = new PSC2013.ES.GUI.Simulation.Panels.SimulationDiseasePanel();
            this.simulationStartlocationPanel = new PSC2013.ES.GUI.Simulation.Panels.SimulationStartlocationPanel();
            this.WorkFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlow
            // 
            this.WorkFlow.BackColor = System.Drawing.SystemColors.Control;
            this.WorkFlow.Controls.Add(this.simulationSettingsPanel);
            this.WorkFlow.Controls.Add(this.simulationDiseasePanel);
            this.WorkFlow.Controls.Add(this.simulationStartlocationPanel);
            this.WorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlow.Location = new System.Drawing.Point(0, 0);
            this.WorkFlow.Margin = new System.Windows.Forms.Padding(0);
            this.WorkFlow.Name = "WorkFlow";
            this.WorkFlow.Padding = new System.Windows.Forms.Padding(3);
            this.WorkFlow.Size = new System.Drawing.Size(852, 434);
            this.WorkFlow.TabIndex = 0;
            // 
            // simulationSettingsPanel
            // 
            this.simulationSettingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.simulationSettingsPanel.Location = new System.Drawing.Point(6, 6);
            this.simulationSettingsPanel.Name = "simulationSettingsPanel";
            this.simulationSettingsPanel.Size = new System.Drawing.Size(276, 420);
            this.simulationSettingsPanel.TabIndex = 0;
            // 
            // simulationDiseasePanel
            // 
            this.simulationDiseasePanel.BackColor = System.Drawing.Color.Transparent;
            this.simulationDiseasePanel.Enabled = false;
            this.simulationDiseasePanel.Location = new System.Drawing.Point(288, 6);
            this.simulationDiseasePanel.Name = "simulationDiseasePanel";
            this.simulationDiseasePanel.Size = new System.Drawing.Size(275, 420);
            this.simulationDiseasePanel.TabIndex = 1;
            // 
            // simulationStartlocationPanel
            // 
            this.simulationStartlocationPanel.BackColor = System.Drawing.Color.Transparent;
            this.simulationStartlocationPanel.Enabled = false;
            this.simulationStartlocationPanel.Location = new System.Drawing.Point(569, 6);
            this.simulationStartlocationPanel.Name = "simulationStartlocationPanel";
            this.simulationStartlocationPanel.Size = new System.Drawing.Size(269, 420);
            this.simulationStartlocationPanel.TabIndex = 2;
            // 
            // SimulationFirstContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.WorkFlow);
            this.Name = "SimulationFirstContainer";
            this.Size = new System.Drawing.Size(852, 434);
            this.WorkFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel WorkFlow;
        private SimulationSettingsPanel simulationSettingsPanel;
        private SimulationDiseasePanel simulationDiseasePanel;
        private SimulationStartlocationPanel simulationStartlocationPanel;
    }
}
