﻿namespace PSC2013.ES.GUI.Simulation.Panels
{
    partial class SimulationFinalSettingsPanel
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
            this.separator_1 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_Starttime = new PSC2013.ES.GUI.Components.DateTimeComponent();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Comp_Destination = new PSC2013.ES.GUI.Components.PathComponent();
            this.SaveSimFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.GrpBox_Main.SuspendLayout();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.TextBox_Hint);
            this.GrpBox_Main.Controls.Add(this.separator_1);
            this.GrpBox_Main.Controls.Add(this.Comp_Starttime);
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.Comp_Destination);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(272, 421);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Final settings";
            // 
            // TextBox_Hint
            // 
            this.TextBox_Hint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Hint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Hint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox_Hint.Enabled = false;
            this.TextBox_Hint.Location = new System.Drawing.Point(10, 116);
            this.TextBox_Hint.Multiline = true;
            this.TextBox_Hint.Name = "TextBox_Hint";
            this.TextBox_Hint.ReadOnly = true;
            this.TextBox_Hint.Size = new System.Drawing.Size(252, 267);
            this.TextBox_Hint.TabIndex = 4;
            this.TextBox_Hint.Text = "Hint: The starttime defines at which time the simulation virtually starts. Differ" +
    "ent components are affected by this date/time.";
            // 
            // separator_1
            // 
            this.separator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_1.BackColor = System.Drawing.Color.Transparent;
            this.separator_1.Location = new System.Drawing.Point(6, 105);
            this.separator_1.Name = "separator_1";
            this.separator_1.Size = new System.Drawing.Size(260, 5);
            this.separator_1.TabIndex = 3;
            // 
            // Comp_Starttime
            // 
            this.Comp_Starttime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Starttime.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Starttime.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.StartTime;
            this.Comp_Starttime.LabelText = "Starttime:";
            this.Comp_Starttime.Location = new System.Drawing.Point(6, 19);
            this.Comp_Starttime.Name = "Comp_Starttime";
            this.Comp_Starttime.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Starttime.Size = new System.Drawing.Size(260, 24);
            this.Comp_Starttime.TabIndex = 2;
            this.Comp_Starttime.ToolTip = "Sets the time on which the simulation will emulate to start. This mainly affects " +
    "the movement.";
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Start);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 389);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(266, 29);
            this.FlowPanel_Bottom.TabIndex = 1;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(188, 3);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            // 
            // Comp_Destination
            // 
            this.Comp_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Destination.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Destination.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.None;
            this.Comp_Destination.Dialog = this.SaveSimFileDialog;
            this.Comp_Destination.LabelText = "Destination:";
            this.Comp_Destination.Location = new System.Drawing.Point(6, 49);
            this.Comp_Destination.Name = "Comp_Destination";
            this.Comp_Destination.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Destination.Size = new System.Drawing.Size(260, 50);
            this.Comp_Destination.TabIndex = 0;
            this.Comp_Destination.ToolTip = "Path where to save the simulation.";
            // 
            // SaveSimFileDialog
            // 
            this.SaveSimFileDialog.Filter = "Simulation file (*.sim)|*.sim|All files (*.*)|*.*";
            // 
            // SimulationFinalSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationFinalSettingsPanel";
            this.Size = new System.Drawing.Size(272, 421);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private Components.PathComponent Comp_Destination;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.SaveFileDialog SaveSimFileDialog;
        private Components.DateTimeComponent Comp_Starttime;
        private System.Windows.Forms.TextBox TextBox_Hint;
        private Miscellaneous.Separator separator_1;
    }
}
