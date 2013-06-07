namespace PSC2013.ES.GUI.Simulation
{
    partial class FactorContainerForm
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
            this.FlowPanel_BottomButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Accept = new System.Windows.Forms.Button();
            this.GrpBox_Male = new System.Windows.Forms.GroupBox();
            this.GrpBox_Female = new System.Windows.Forms.GroupBox();
            this.Comp_MaleSenior = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_MaleAdult = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_MaleChild = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_MaleBaby = new PSC2013.ES.GUI.Components.IntComponent();
            this.FlowPanel_BottomButtons.SuspendLayout();
            this.GrpBox_Male.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowPanel_BottomButtons
            // 
            this.FlowPanel_BottomButtons.Controls.Add(this.Btn_Cancel);
            this.FlowPanel_BottomButtons.Controls.Add(this.Accept);
            this.FlowPanel_BottomButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_BottomButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_BottomButtons.Location = new System.Drawing.Point(0, 182);
            this.FlowPanel_BottomButtons.Name = "FlowPanel_BottomButtons";
            this.FlowPanel_BottomButtons.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.FlowPanel_BottomButtons.Size = new System.Drawing.Size(384, 30);
            this.FlowPanel_BottomButtons.TabIndex = 0;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(301, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Accept
            // 
            this.Accept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Accept.Location = new System.Drawing.Point(220, 3);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(75, 23);
            this.Accept.TabIndex = 0;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            // 
            // GrpBox_Male
            // 
            this.GrpBox_Male.Controls.Add(this.Comp_MaleSenior);
            this.GrpBox_Male.Controls.Add(this.Comp_MaleAdult);
            this.GrpBox_Male.Controls.Add(this.Comp_MaleChild);
            this.GrpBox_Male.Controls.Add(this.Comp_MaleBaby);
            this.GrpBox_Male.Location = new System.Drawing.Point(5, 2);
            this.GrpBox_Male.Name = "GrpBox_Male";
            this.GrpBox_Male.Size = new System.Drawing.Size(185, 174);
            this.GrpBox_Male.TabIndex = 0;
            this.GrpBox_Male.TabStop = false;
            this.GrpBox_Male.Text = "Male";
            // 
            // GrpBox_Female
            // 
            this.GrpBox_Female.Location = new System.Drawing.Point(195, 2);
            this.GrpBox_Female.Name = "GrpBox_Female";
            this.GrpBox_Female.Size = new System.Drawing.Size(185, 174);
            this.GrpBox_Female.TabIndex = 1;
            this.GrpBox_Female.TabStop = false;
            this.GrpBox_Female.Text = "Female";
            // 
            // Comp_MaleSenior
            // 
            this.Comp_MaleSenior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleSenior.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleSenior.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleSenior;
            this.Comp_MaleSenior.LabelText = "Senior:";
            this.Comp_MaleSenior.Location = new System.Drawing.Point(6, 109);
            this.Comp_MaleSenior.Name = "Comp_MaleSenior";
            this.Comp_MaleSenior.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleSenior.Size = new System.Drawing.Size(173, 24);
            this.Comp_MaleSenior.TabIndex = 3;
            this.Comp_MaleSenior.ToolTip = "";
            // 
            // Comp_MaleAdult
            // 
            this.Comp_MaleAdult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleAdult.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleAdult.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleAdult;
            this.Comp_MaleAdult.LabelText = "Adult:";
            this.Comp_MaleAdult.Location = new System.Drawing.Point(6, 79);
            this.Comp_MaleAdult.Name = "Comp_MaleAdult";
            this.Comp_MaleAdult.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleAdult.Size = new System.Drawing.Size(173, 24);
            this.Comp_MaleAdult.TabIndex = 2;
            this.Comp_MaleAdult.ToolTip = "";
            // 
            // Comp_MaleChild
            // 
            this.Comp_MaleChild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleChild.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleChild.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleChild;
            this.Comp_MaleChild.LabelText = "Child:";
            this.Comp_MaleChild.Location = new System.Drawing.Point(6, 49);
            this.Comp_MaleChild.Name = "Comp_MaleChild";
            this.Comp_MaleChild.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleChild.Size = new System.Drawing.Size(173, 24);
            this.Comp_MaleChild.TabIndex = 1;
            this.Comp_MaleChild.ToolTip = "";
            // 
            // Comp_MaleBaby
            // 
            this.Comp_MaleBaby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MaleBaby.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MaleBaby.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MaleBaby;
            this.Comp_MaleBaby.LabelText = "Baby:";
            this.Comp_MaleBaby.Location = new System.Drawing.Point(6, 19);
            this.Comp_MaleBaby.Name = "Comp_MaleBaby";
            this.Comp_MaleBaby.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MaleBaby.Size = new System.Drawing.Size(173, 24);
            this.Comp_MaleBaby.TabIndex = 0;
            this.Comp_MaleBaby.ToolTip = "";
            // 
            // FactorContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Controls.Add(this.GrpBox_Female);
            this.Controls.Add(this.FlowPanel_BottomButtons);
            this.Controls.Add(this.GrpBox_Male);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FactorContainerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FactorContainerForm";
            this.FlowPanel_BottomButtons.ResumeLayout(false);
            this.GrpBox_Male.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowPanel_BottomButtons;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.GroupBox GrpBox_Male;
        private System.Windows.Forms.GroupBox GrpBox_Female;
        private Components.IntComponent Comp_MaleBaby;
        private Components.IntComponent Comp_MaleSenior;
        private Components.IntComponent Comp_MaleAdult;
        private Components.IntComponent Comp_MaleChild;




    }
}