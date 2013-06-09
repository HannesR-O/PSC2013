namespace PSC2013.ES.GUI.Simulation.Panels
{
    partial class SimulationStartlocationPanel
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
            this.ListBox_Departments = new System.Windows.Forms.ListBox();
            this.PictBox_SelectedDepartments = new System.Windows.Forms.PictureBox();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.TextBox_Hint = new System.Windows.Forms.TextBox();
            this.seperator1 = new PSC2013.ES.GUI.Miscellaneous.Seperator();
            this.Comp_InfectedCount = new PSC2013.ES.GUI.Components.IntComponent();
            this.GrpBox_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictBox_SelectedDepartments)).BeginInit();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.TextBox_Hint);
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.seperator1);
            this.GrpBox_Main.Controls.Add(this.Comp_InfectedCount);
            this.GrpBox_Main.Controls.Add(this.PictBox_SelectedDepartments);
            this.GrpBox_Main.Controls.Add(this.ListBox_Departments);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(274, 431);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Startlocations";
            // 
            // ListBox_Departments
            // 
            this.ListBox_Departments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Departments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox_Departments.FormattingEnabled = true;
            this.ListBox_Departments.IntegralHeight = false;
            this.ListBox_Departments.Location = new System.Drawing.Point(6, 19);
            this.ListBox_Departments.Name = "ListBox_Departments";
            this.ListBox_Departments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_Departments.Size = new System.Drawing.Size(262, 125);
            this.ListBox_Departments.TabIndex = 0;
            // 
            // PictBox_SelectedDepartments
            // 
            this.PictBox_SelectedDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictBox_SelectedDepartments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictBox_SelectedDepartments.Location = new System.Drawing.Point(7, 150);
            this.PictBox_SelectedDepartments.Name = "PictBox_SelectedDepartments";
            this.PictBox_SelectedDepartments.Size = new System.Drawing.Size(260, 151);
            this.PictBox_SelectedDepartments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictBox_SelectedDepartments.TabIndex = 1;
            this.PictBox_SelectedDepartments.TabStop = false;
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Next);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 399);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(268, 29);
            this.FlowPanel_Bottom.TabIndex = 4;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(190, 3);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 0;
            this.Btn_Next.Text = "Next >";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // TextBox_Hint
            // 
            this.TextBox_Hint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Hint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Hint.Enabled = false;
            this.TextBox_Hint.Location = new System.Drawing.Point(10, 348);
            this.TextBox_Hint.Multiline = true;
            this.TextBox_Hint.Name = "TextBox_Hint";
            this.TextBox_Hint.ReadOnly = true;
            this.TextBox_Hint.Size = new System.Drawing.Size(254, 45);
            this.TextBox_Hint.TabIndex = 5;
            this.TextBox_Hint.Text = "Hint: Use the above list to select the departments in which the first infected hu" +
    "mans occur. The \"Infected\"-field indicates how many people are there to be infec" +
    "ted.";
            // 
            // seperator1
            // 
            this.seperator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seperator1.BackColor = System.Drawing.Color.Transparent;
            this.seperator1.Location = new System.Drawing.Point(6, 337);
            this.seperator1.Name = "seperator1";
            this.seperator1.Size = new System.Drawing.Size(262, 5);
            this.seperator1.TabIndex = 3;
            // 
            // Comp_InfectedCount
            // 
            this.Comp_InfectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_InfectedCount.BackColor = System.Drawing.Color.Transparent;
            this.Comp_InfectedCount.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.None;
            this.Comp_InfectedCount.LabelText = "Infected:";
            this.Comp_InfectedCount.Location = new System.Drawing.Point(6, 307);
            this.Comp_InfectedCount.Name = "Comp_InfectedCount";
            this.Comp_InfectedCount.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_InfectedCount.Size = new System.Drawing.Size(262, 24);
            this.Comp_InfectedCount.TabIndex = 2;
            this.Comp_InfectedCount.ToolTip = "Indicates how many humans shall be infected at the beginning.";
            // 
            // SimulationStartlocationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationStartlocationPanel";
            this.Size = new System.Drawing.Size(274, 431);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictBox_SelectedDepartments)).EndInit();
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private System.Windows.Forms.PictureBox PictBox_SelectedDepartments;
        private System.Windows.Forms.ListBox ListBox_Departments;
        private Components.IntComponent Comp_InfectedCount;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Next;
        private Miscellaneous.Seperator seperator1;
        private System.Windows.Forms.TextBox TextBox_Hint;
    }
}
