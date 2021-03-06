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
            this.TextBox_Hint = new System.Windows.Forms.TextBox();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.separator_2 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_EnableMovement = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_EnableMindset = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_EnableDiseaseTick = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_EnableInfection = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_EnableAgeing = new PSC2013.ES.GUI.Components.BoolComponent();
            this.separator_1 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_SnapshotIntervall = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_SimulationIntervall = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_SimulationDuration = new PSC2013.ES.GUI.Components.LongComponent();
            this.Comp_EnableDiseaseDeath = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_EnableDiseaseHealing = new PSC2013.ES.GUI.Components.BoolComponent();
            this.GrpBox_Main.SuspendLayout();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.Comp_EnableDiseaseHealing);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableDiseaseDeath);
            this.GrpBox_Main.Controls.Add(this.TextBox_Hint);
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.separator_2);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableMovement);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableMindset);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableDiseaseTick);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableInfection);
            this.GrpBox_Main.Controls.Add(this.Comp_EnableAgeing);
            this.GrpBox_Main.Controls.Add(this.separator_1);
            this.GrpBox_Main.Controls.Add(this.Comp_SnapshotIntervall);
            this.GrpBox_Main.Controls.Add(this.Comp_SimulationIntervall);
            this.GrpBox_Main.Controls.Add(this.Comp_SimulationDuration);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(276, 446);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Simulation";
            // 
            // TextBox_Hint
            // 
            this.TextBox_Hint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Hint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Hint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox_Hint.Enabled = false;
            this.TextBox_Hint.Location = new System.Drawing.Point(10, 341);
            this.TextBox_Hint.Multiline = true;
            this.TextBox_Hint.Name = "TextBox_Hint";
            this.TextBox_Hint.ReadOnly = true;
            this.TextBox_Hint.Size = new System.Drawing.Size(256, 67);
            this.TextBox_Hint.TabIndex = 12;
            this.TextBox_Hint.Text = "Hint: HERE SHOULD be some important hints to the settings from above";
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Next);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 414);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(270, 29);
            this.FlowPanel_Bottom.TabIndex = 13;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(192, 3);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 0;
            this.Btn_Next.Text = "Next >";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // separator_2
            // 
            this.separator_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_2.BackColor = System.Drawing.Color.Transparent;
            this.separator_2.Location = new System.Drawing.Point(6, 330);
            this.separator_2.Name = "separator_2";
            this.separator_2.Size = new System.Drawing.Size(264, 5);
            this.separator_2.TabIndex = 11;
            // 
            // Comp_EnableMovement
            // 
            this.Comp_EnableMovement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableMovement.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableMovement.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MovementComponent;
            this.Comp_EnableMovement.LabelText = "Enable movement:";
            this.Comp_EnableMovement.Location = new System.Drawing.Point(6, 300);
            this.Comp_EnableMovement.Name = "Comp_EnableMovement";
            this.Comp_EnableMovement.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableMovement.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableMovement.TabIndex = 10;
            this.Comp_EnableMovement.ToolTip = "If enabled humans move around (fancy as f*ck).";
            // 
            // Comp_EnableMindset
            // 
            this.Comp_EnableMindset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableMindset.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableMindset.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MindsetComponent;
            this.Comp_EnableMindset.LabelText = "Enable mindsets:";
            this.Comp_EnableMindset.Location = new System.Drawing.Point(6, 270);
            this.Comp_EnableMindset.Name = "Comp_EnableMindset";
            this.Comp_EnableMindset.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableMindset.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableMindset.TabIndex = 9;
            this.Comp_EnableMindset.ToolTip = "If enabled humans mindsets can change if affected by the disease.";
            // 
            // Comp_EnableDiseaseTick
            // 
            this.Comp_EnableDiseaseTick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableDiseaseTick.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableDiseaseTick.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.DiseaseTickComponent;
            this.Comp_EnableDiseaseTick.LabelText = "Enable disease-effect:";
            this.Comp_EnableDiseaseTick.Location = new System.Drawing.Point(6, 180);
            this.Comp_EnableDiseaseTick.Name = "Comp_EnableDiseaseTick";
            this.Comp_EnableDiseaseTick.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableDiseaseTick.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableDiseaseTick.TabIndex = 6;
            this.Comp_EnableDiseaseTick.ToolTip = "If enabled the disease can take action (i.e. spreading, diseased).";
            // 
            // Comp_EnableInfection
            // 
            this.Comp_EnableInfection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableInfection.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableInfection.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.InfectionComponent;
            this.Comp_EnableInfection.LabelText = "Enable infecting:";
            this.Comp_EnableInfection.Location = new System.Drawing.Point(6, 150);
            this.Comp_EnableInfection.Name = "Comp_EnableInfection";
            this.Comp_EnableInfection.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableInfection.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableInfection.TabIndex = 5;
            this.Comp_EnableInfection.ToolTip = "We admit: if disabled this whole thing does not make sense.";
            // 
            // Comp_EnableAgeing
            // 
            this.Comp_EnableAgeing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableAgeing.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableAgeing.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.AgeingComponent;
            this.Comp_EnableAgeing.LabelText = "Enable ageing:";
            this.Comp_EnableAgeing.Location = new System.Drawing.Point(6, 120);
            this.Comp_EnableAgeing.Name = "Comp_EnableAgeing";
            this.Comp_EnableAgeing.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableAgeing.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableAgeing.TabIndex = 4;
            this.Comp_EnableAgeing.ToolTip = "If enabled (checked) humans age when years pass.";
            // 
            // separator_1
            // 
            this.separator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_1.BackColor = System.Drawing.Color.Transparent;
            this.separator_1.Location = new System.Drawing.Point(6, 109);
            this.separator_1.Name = "separator_1";
            this.separator_1.Size = new System.Drawing.Size(264, 5);
            this.separator_1.TabIndex = 3;
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
            // Comp_EnableDiseaseDeath
            // 
            this.Comp_EnableDiseaseDeath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableDiseaseDeath.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableDiseaseDeath.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.DiseaseDeathComponent;
            this.Comp_EnableDiseaseDeath.LabelText = "Enable death:";
            this.Comp_EnableDiseaseDeath.Location = new System.Drawing.Point(6, 210);
            this.Comp_EnableDiseaseDeath.Name = "Comp_EnableDiseaseDeath";
            this.Comp_EnableDiseaseDeath.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableDiseaseDeath.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableDiseaseDeath.TabIndex = 7;
            this.Comp_EnableDiseaseDeath.ToolTip = "If enabled humans can die as cause of the disease (does not affect death through " +
    "ageing).";
            // 
            // Comp_EnableDiseaseHealing
            // 
            this.Comp_EnableDiseaseHealing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_EnableDiseaseHealing.BackColor = System.Drawing.Color.Transparent;
            this.Comp_EnableDiseaseHealing.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.DiseaseHealingComponent;
            this.Comp_EnableDiseaseHealing.LabelText = "Enable healing:";
            this.Comp_EnableDiseaseHealing.Location = new System.Drawing.Point(6, 240);
            this.Comp_EnableDiseaseHealing.Name = "Comp_EnableDiseaseHealing";
            this.Comp_EnableDiseaseHealing.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_EnableDiseaseHealing.Size = new System.Drawing.Size(264, 24);
            this.Comp_EnableDiseaseHealing.TabIndex = 8;
            this.Comp_EnableDiseaseHealing.ToolTip = "If enabled humans can be healed.";
            // 
            // SimulationSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationSettingsPanel";
            this.Size = new System.Drawing.Size(276, 446);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private Components.LongComponent Comp_SimulationDuration;
        private Components.IntComponent Comp_SimulationIntervall;
        private Components.IntComponent Comp_SnapshotIntervall;
        private Miscellaneous.Separator separator_1;
        private Components.BoolComponent Comp_EnableAgeing;
        private Components.BoolComponent Comp_EnableInfection;
        private Components.BoolComponent Comp_EnableDiseaseTick;
        private Components.BoolComponent Comp_EnableMindset;
        private Miscellaneous.Separator separator_2;
        private Components.BoolComponent Comp_EnableMovement;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.TextBox TextBox_Hint;
        private Components.BoolComponent Comp_EnableDiseaseDeath;
        private Components.BoolComponent Comp_EnableDiseaseHealing;
    }
}
