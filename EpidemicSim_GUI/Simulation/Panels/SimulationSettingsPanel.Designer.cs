﻿namespace PSC2013.ES.GUI.Simulation.Panels
{
    partial class SimulationSettingsPanel
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
            this.seperator_1 = new PSC2013.ES.GUI.Miscellaneous.Seperator();
            this.Comp_SnapshotIntervall = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_SimulationIntervall = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_SimulationDuration = new PSC2013.ES.GUI.Components.LongComponent();
            this.GrpBox_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.seperator_1);
            this.GrpBox_Main.Controls.Add(this.Comp_SnapshotIntervall);
            this.GrpBox_Main.Controls.Add(this.Comp_SimulationIntervall);
            this.GrpBox_Main.Controls.Add(this.Comp_SimulationDuration);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(276, 420);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Simulation";
            // 
            // seperator_1
            // 
            this.seperator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seperator_1.BackColor = System.Drawing.Color.Transparent;
            this.seperator_1.Location = new System.Drawing.Point(6, 109);
            this.seperator_1.Name = "seperator_1";
            this.seperator_1.Size = new System.Drawing.Size(264, 5);
            this.seperator_1.TabIndex = 3;
            // 
            // Comp_SnapshotIntervall
            // 
            this.Comp_SnapshotIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_SnapshotIntervall.BackColor = System.Drawing.Color.Transparent;
            this.Comp_SnapshotIntervall.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.SnapshotIntervall;
            this.Comp_SnapshotIntervall.LabelText = "Snapshot intervall:";
            this.Comp_SnapshotIntervall.Location = new System.Drawing.Point(6, 79);
            this.Comp_SnapshotIntervall.Name = "Comp_SnapshotIntervall";
            this.Comp_SnapshotIntervall.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_SnapshotIntervall.Size = new System.Drawing.Size(264, 24);
            this.Comp_SnapshotIntervall.TabIndex = 2;
            this.Comp_SnapshotIntervall.ToolTip = "The intervall in hours a snapshot will be taken.";
            // 
            // Comp_SimulationIntervall
            // 
            this.Comp_SimulationIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_SimulationIntervall.BackColor = System.Drawing.Color.Transparent;
            this.Comp_SimulationIntervall.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.SimulationIntervall;
            this.Comp_SimulationIntervall.LabelText = "Simulation intervall:";
            this.Comp_SimulationIntervall.Location = new System.Drawing.Point(6, 49);
            this.Comp_SimulationIntervall.Name = "Comp_SimulationIntervall";
            this.Comp_SimulationIntervall.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_SimulationIntervall.Size = new System.Drawing.Size(264, 24);
            this.Comp_SimulationIntervall.TabIndex = 1;
            this.Comp_SimulationIntervall.ToolTip = "The hours, one tick shall emulate.";
            // 
            // Comp_SimulationDuration
            // 
            this.Comp_SimulationDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_SimulationDuration.BackColor = System.Drawing.SystemColors.Control;
            this.Comp_SimulationDuration.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.SimulationDuration;
            this.Comp_SimulationDuration.LabelText = "Simulation duration:";
            this.Comp_SimulationDuration.Location = new System.Drawing.Point(6, 19);
            this.Comp_SimulationDuration.Name = "Comp_SimulationDuration";
            this.Comp_SimulationDuration.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_SimulationDuration.Size = new System.Drawing.Size(264, 24);
            this.Comp_SimulationDuration.TabIndex = 0;
            this.Comp_SimulationDuration.ToolTip = "The hours, the simulation shall emulate.";
            // 
            // SimulationSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationSettingsPanel";
            this.Size = new System.Drawing.Size(276, 420);
            this.GrpBox_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private Components.LongComponent Comp_SimulationDuration;
        private Components.IntComponent Comp_SimulationIntervall;
        private Components.IntComponent Comp_SnapshotIntervall;
        private Miscellaneous.Seperator seperator_1;
    }
}
