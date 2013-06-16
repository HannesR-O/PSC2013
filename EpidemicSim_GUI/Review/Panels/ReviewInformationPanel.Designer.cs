namespace PSC2013.ES.GUI.Review.Panels
{
    partial class ReviewInformationPanel
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
            this.Panel_Female = new System.Windows.Forms.Panel();
            this.Panel_Male = new System.Windows.Forms.Panel();
            this.Comp_FemaleSenior = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_FemaleAdult = new PSC2013.ES.GUI.Components.BoolComponent();
            this.separator_2 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_FemaleChild = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_Female = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_FemaleBaby = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_MaleSenior = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_MaleAdult = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_MaleChild = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_MaleBaby = new PSC2013.ES.GUI.Components.BoolComponent();
            this.separator_1 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_Male = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_All = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_Category = new PSC2013.ES.GUI.Components.SwitchComponent();
            this.Comp_Infected = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_Diseased = new PSC2013.ES.GUI.Components.BoolComponent();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.GrpBox_Main.SuspendLayout();
            this.Panel_Female.SuspendLayout();
            this.Panel_Male.SuspendLayout();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.Comp_Diseased);
            this.GrpBox_Main.Controls.Add(this.Comp_Infected);
            this.GrpBox_Main.Controls.Add(this.Panel_Female);
            this.GrpBox_Main.Controls.Add(this.Panel_Male);
            this.GrpBox_Main.Controls.Add(this.Comp_All);
            this.GrpBox_Main.Controls.Add(this.Comp_Category);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(326, 461);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Information";
            // 
            // Panel_Female
            // 
            this.Panel_Female.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Female.Controls.Add(this.Comp_FemaleSenior);
            this.Panel_Female.Controls.Add(this.Comp_FemaleAdult);
            this.Panel_Female.Controls.Add(this.separator_2);
            this.Panel_Female.Controls.Add(this.Comp_FemaleChild);
            this.Panel_Female.Controls.Add(this.Comp_Female);
            this.Panel_Female.Controls.Add(this.Comp_FemaleBaby);
            this.Panel_Female.Location = new System.Drawing.Point(166, 82);
            this.Panel_Female.Name = "Panel_Female";
            this.Panel_Female.Size = new System.Drawing.Size(154, 160);
            this.Panel_Female.TabIndex = 3;
            // 
            // Panel_Male
            // 
            this.Panel_Male.Controls.Add(this.Comp_MaleSenior);
            this.Panel_Male.Controls.Add(this.Comp_MaleAdult);
            this.Panel_Male.Controls.Add(this.Comp_MaleChild);
            this.Panel_Male.Controls.Add(this.Comp_MaleBaby);
            this.Panel_Male.Controls.Add(this.separator_1);
            this.Panel_Male.Controls.Add(this.Comp_Male);
            this.Panel_Male.Location = new System.Drawing.Point(6, 82);
            this.Panel_Male.Name = "Panel_Male";
            this.Panel_Male.Size = new System.Drawing.Size(154, 160);
            this.Panel_Male.TabIndex = 2;
            // 
            // Comp_FemaleSenior
            // 
            this.Comp_FemaleSenior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_FemaleSenior.BackColor = System.Drawing.Color.Transparent;
            this.Comp_FemaleSenior.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleSenior;
            this.Comp_FemaleSenior.LabelText = "Senior:";
            this.Comp_FemaleSenior.Location = new System.Drawing.Point(3, 134);
            this.Comp_FemaleSenior.Name = "Comp_FemaleSenior";
            this.Comp_FemaleSenior.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_FemaleSenior.Size = new System.Drawing.Size(148, 24);
            this.Comp_FemaleSenior.TabIndex = 9;
            this.Comp_FemaleSenior.ToolTip = "";
            // 
            // Comp_FemaleAdult
            // 
            this.Comp_FemaleAdult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_FemaleAdult.BackColor = System.Drawing.Color.Transparent;
            this.Comp_FemaleAdult.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleAdult;
            this.Comp_FemaleAdult.LabelText = "Adult:";
            this.Comp_FemaleAdult.Location = new System.Drawing.Point(3, 104);
            this.Comp_FemaleAdult.Name = "Comp_FemaleAdult";
            this.Comp_FemaleAdult.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_FemaleAdult.Size = new System.Drawing.Size(148, 24);
            this.Comp_FemaleAdult.TabIndex = 8;
            this.Comp_FemaleAdult.ToolTip = "";
            // 
            // separator_2
            // 
            this.separator_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_2.BackColor = System.Drawing.Color.Transparent;
            this.separator_2.Location = new System.Drawing.Point(3, 33);
            this.separator_2.Name = "separator_2";
            this.separator_2.Size = new System.Drawing.Size(148, 5);
            this.separator_2.TabIndex = 2;
            // 
            // Comp_FemaleChild
            // 
            this.Comp_FemaleChild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_FemaleChild.BackColor = System.Drawing.Color.Transparent;
            this.Comp_FemaleChild.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleChild;
            this.Comp_FemaleChild.LabelText = "Child:";
            this.Comp_FemaleChild.Location = new System.Drawing.Point(3, 74);
            this.Comp_FemaleChild.Name = "Comp_FemaleChild";
            this.Comp_FemaleChild.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_FemaleChild.Size = new System.Drawing.Size(148, 24);
            this.Comp_FemaleChild.TabIndex = 7;
            this.Comp_FemaleChild.ToolTip = "";
            // 
            // Comp_Female
            // 
            this.Comp_Female.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Female.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Female.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.None;
            this.Comp_Female.LabelText = "Select all female:";
            this.Comp_Female.Location = new System.Drawing.Point(3, 3);
            this.Comp_Female.Name = "Comp_Female";
            this.Comp_Female.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Female.Size = new System.Drawing.Size(148, 24);
            this.Comp_Female.TabIndex = 0;
            this.Comp_Female.ToolTip = "Same as \'Select all\', just for all females.";
            // 
            // Comp_FemaleBaby
            // 
            this.Comp_FemaleBaby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_FemaleBaby.BackColor = System.Drawing.Color.Transparent;
            this.Comp_FemaleBaby.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleBaby;
            this.Comp_FemaleBaby.LabelText = "Baby:";
            this.Comp_FemaleBaby.Location = new System.Drawing.Point(3, 44);
            this.Comp_FemaleBaby.Name = "Comp_FemaleBaby";
            this.Comp_FemaleBaby.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_FemaleBaby.Size = new System.Drawing.Size(148, 24);
            this.Comp_FemaleBaby.TabIndex = 6;
            this.Comp_FemaleBaby.ToolTip = "";
            // 
            // Comp_MaleSenior
            // 
            this.Comp_MaleSenior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleSenior.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleSenior.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleSenior;
            this.Comp_MaleSenior.LabelText = "Senior:";
            this.Comp_MaleSenior.Location = new System.Drawing.Point(3, 134);
            this.Comp_MaleSenior.Name = "Comp_MaleSenior";
            this.Comp_MaleSenior.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleSenior.Size = new System.Drawing.Size(148, 24);
            this.Comp_MaleSenior.TabIndex = 5;
            this.Comp_MaleSenior.ToolTip = "";
            // 
            // Comp_MaleAdult
            // 
            this.Comp_MaleAdult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleAdult.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleAdult.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleAdult;
            this.Comp_MaleAdult.LabelText = "Adult:";
            this.Comp_MaleAdult.Location = new System.Drawing.Point(3, 104);
            this.Comp_MaleAdult.Name = "Comp_MaleAdult";
            this.Comp_MaleAdult.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleAdult.Size = new System.Drawing.Size(148, 24);
            this.Comp_MaleAdult.TabIndex = 4;
            this.Comp_MaleAdult.ToolTip = "";
            // 
            // Comp_MaleChild
            // 
            this.Comp_MaleChild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleChild.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleChild.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleChild;
            this.Comp_MaleChild.LabelText = "Child:";
            this.Comp_MaleChild.Location = new System.Drawing.Point(3, 74);
            this.Comp_MaleChild.Name = "Comp_MaleChild";
            this.Comp_MaleChild.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleChild.Size = new System.Drawing.Size(148, 24);
            this.Comp_MaleChild.TabIndex = 3;
            this.Comp_MaleChild.ToolTip = "";
            // 
            // Comp_MaleBaby
            // 
            this.Comp_MaleBaby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleBaby.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleBaby.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleBaby;
            this.Comp_MaleBaby.LabelText = "Baby:";
            this.Comp_MaleBaby.Location = new System.Drawing.Point(3, 44);
            this.Comp_MaleBaby.Name = "Comp_MaleBaby";
            this.Comp_MaleBaby.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleBaby.Size = new System.Drawing.Size(148, 24);
            this.Comp_MaleBaby.TabIndex = 2;
            this.Comp_MaleBaby.ToolTip = "";
            // 
            // separator_1
            // 
            this.separator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_1.BackColor = System.Drawing.Color.Transparent;
            this.separator_1.Location = new System.Drawing.Point(3, 33);
            this.separator_1.Name = "separator_1";
            this.separator_1.Size = new System.Drawing.Size(148, 5);
            this.separator_1.TabIndex = 1;
            // 
            // Comp_Male
            // 
            this.Comp_Male.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Male.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Male.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.None;
            this.Comp_Male.LabelText = "Select all male:";
            this.Comp_Male.Location = new System.Drawing.Point(3, 3);
            this.Comp_Male.Name = "Comp_Male";
            this.Comp_Male.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Male.Size = new System.Drawing.Size(148, 24);
            this.Comp_Male.TabIndex = 0;
            this.Comp_Male.ToolTip = "Same as in \'Select all\', just only for males. ";
            // 
            // Comp_All
            // 
            this.Comp_All.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_All.BackColor = System.Drawing.Color.Transparent;
            this.Comp_All.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.None;
            this.Comp_All.LabelText = "Select all:";
            this.Comp_All.Location = new System.Drawing.Point(6, 52);
            this.Comp_All.Name = "Comp_All";
            this.Comp_All.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_All.Size = new System.Drawing.Size(314, 24);
            this.Comp_All.TabIndex = 1;
            this.Comp_All.ToolTip = "Tick this and all checkboxes below will be checked (or unchecked).";
            // 
            // Comp_Category
            // 
            this.Comp_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Category.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Category.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.ReviewCategory;
            this.Comp_Category.LabelText = "Category:";
            this.Comp_Category.Location = new System.Drawing.Point(6, 19);
            this.Comp_Category.Name = "Comp_Category";
            this.Comp_Category.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Category.Size = new System.Drawing.Size(314, 27);
            this.Comp_Category.TabIndex = 0;
            this.Comp_Category.Text_1 = "Alive";
            this.Comp_Category.Text_2 = "Dead";
            this.Comp_Category.ToolTip = "";
            // 
            // Comp_Infected
            // 
            this.Comp_Infected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Infected.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Infected.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.Infected;
            this.Comp_Infected.LabelText = "Infected:";
            this.Comp_Infected.Location = new System.Drawing.Point(6, 248);
            this.Comp_Infected.Name = "Comp_Infected";
            this.Comp_Infected.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Infected.Size = new System.Drawing.Size(314, 24);
            this.Comp_Infected.TabIndex = 4;
            this.Comp_Infected.ToolTip = "Selects all humans being infected.";
            // 
            // Comp_Diseased
            // 
            this.Comp_Diseased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Diseased.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Diseased.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.Diseased;
            this.Comp_Diseased.LabelText = "Diseased:";
            this.Comp_Diseased.Location = new System.Drawing.Point(6, 278);
            this.Comp_Diseased.Name = "Comp_Diseased";
            this.Comp_Diseased.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Diseased.Size = new System.Drawing.Size(314, 24);
            this.Comp_Diseased.TabIndex = 5;
            this.Comp_Diseased.ToolTip = "Selects all humans being diseased.";
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Next);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 429);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(320, 29);
            this.FlowPanel_Bottom.TabIndex = 6;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(242, 3);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 0;
            this.Btn_Next.Text = "Next >";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // ReviewInformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "ReviewInformationPanel";
            this.Size = new System.Drawing.Size(326, 461);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.Panel_Female.ResumeLayout(false);
            this.Panel_Male.ResumeLayout(false);
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private Components.SwitchComponent Comp_Category;
        private Components.BoolComponent Comp_All;
        private System.Windows.Forms.Panel Panel_Female;
        private System.Windows.Forms.Panel Panel_Male;
        private Components.BoolComponent Comp_Female;
        private Components.BoolComponent Comp_Male;
        private Miscellaneous.Separator separator_2;
        private Miscellaneous.Separator separator_1;
        private Components.BoolComponent Comp_MaleBaby;
        private Components.BoolComponent Comp_MaleAdult;
        private Components.BoolComponent Comp_MaleChild;
        private Components.BoolComponent Comp_MaleSenior;
        private Components.BoolComponent Comp_FemaleSenior;
        private Components.BoolComponent Comp_FemaleAdult;
        private Components.BoolComponent Comp_FemaleChild;
        private Components.BoolComponent Comp_FemaleBaby;
        private Components.BoolComponent Comp_Infected;
        private Components.BoolComponent Comp_Diseased;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Next;
    }
}
