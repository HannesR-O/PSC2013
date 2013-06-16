namespace PSC2013.ES.GUI.Review.Panels
{
    partial class ReviewSettingsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewSettingsPanel));
            this.GrpBox_Main = new System.Windows.Forms.GroupBox();
            this.FlowPanel_Bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.Comp_AllDiagram = new PSC2013.ES.GUI.Components.BoolComponent();
            this.Comp_AgeDiagram = new PSC2013.ES.GUI.Components.BoolComponent();
            this.separator_1 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.Comp_Palette = new PSC2013.ES.GUI.Components.ComboBoxComponent();
            this.Comp_Destination = new PSC2013.ES.GUI.Components.PathComponent();
            this.DestinationFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.separator_2 = new PSC2013.ES.GUI.Miscellaneous.Separator();
            this.TextBox_Hint = new System.Windows.Forms.TextBox();
            this.GrpBox_Main.SuspendLayout();
            this.FlowPanel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.TextBox_Hint);
            this.GrpBox_Main.Controls.Add(this.separator_2);
            this.GrpBox_Main.Controls.Add(this.FlowPanel_Bottom);
            this.GrpBox_Main.Controls.Add(this.Comp_AllDiagram);
            this.GrpBox_Main.Controls.Add(this.Comp_AgeDiagram);
            this.GrpBox_Main.Controls.Add(this.separator_1);
            this.GrpBox_Main.Controls.Add(this.Comp_Palette);
            this.GrpBox_Main.Controls.Add(this.Comp_Destination);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(331, 478);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Settings";
            // 
            // FlowPanel_Bottom
            // 
            this.FlowPanel_Bottom.AutoSize = true;
            this.FlowPanel_Bottom.Controls.Add(this.Btn_Next);
            this.FlowPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanel_Bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanel_Bottom.Location = new System.Drawing.Point(3, 446);
            this.FlowPanel_Bottom.Name = "FlowPanel_Bottom";
            this.FlowPanel_Bottom.Size = new System.Drawing.Size(325, 29);
            this.FlowPanel_Bottom.TabIndex = 5;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(247, 3);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 0;
            this.Btn_Next.Text = "Next >";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // Comp_AllDiagram
            // 
            this.Comp_AllDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_AllDiagram.BackColor = System.Drawing.Color.Transparent;
            this.Comp_AllDiagram.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.AllDiagram;
            this.Comp_AllDiagram.LabelText = "Create alternative diagram:";
            this.Comp_AllDiagram.Location = new System.Drawing.Point(6, 147);
            this.Comp_AllDiagram.Name = "Comp_AllDiagram";
            this.Comp_AllDiagram.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_AllDiagram.Size = new System.Drawing.Size(319, 24);
            this.Comp_AllDiagram.TabIndex = 4;
            this.Comp_AllDiagram.ToolTip = "If enabled, a diagram with information about the infected, diseased and overall p" +
    "opulation will be generated.";
            // 
            // Comp_AgeDiagram
            // 
            this.Comp_AgeDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_AgeDiagram.BackColor = System.Drawing.Color.Transparent;
            this.Comp_AgeDiagram.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.AgeDiagram;
            this.Comp_AgeDiagram.LabelText = "Create age-diagram:";
            this.Comp_AgeDiagram.Location = new System.Drawing.Point(6, 117);
            this.Comp_AgeDiagram.Name = "Comp_AgeDiagram";
            this.Comp_AgeDiagram.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_AgeDiagram.Size = new System.Drawing.Size(319, 24);
            this.Comp_AgeDiagram.TabIndex = 3;
            this.Comp_AgeDiagram.ToolTip = "If enabled, a diagram with all age-groups over the simulation-time will be genera" +
    "ted.";
            // 
            // separator_1
            // 
            this.separator_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_1.BackColor = System.Drawing.Color.Transparent;
            this.separator_1.Location = new System.Drawing.Point(6, 106);
            this.separator_1.Name = "separator_1";
            this.separator_1.Size = new System.Drawing.Size(319, 5);
            this.separator_1.TabIndex = 2;
            // 
            // Comp_Palette
            // 
            this.Comp_Palette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Palette.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Palette.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.ColorPalette;
            this.Comp_Palette.LabelText = "Colorpalette:";
            this.Comp_Palette.Location = new System.Drawing.Point(6, 75);
            this.Comp_Palette.Name = "Comp_Palette";
            this.Comp_Palette.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Palette.Size = new System.Drawing.Size(319, 25);
            this.Comp_Palette.TabIndex = 1;
            this.Comp_Palette.ToolTip = "The colors in which the graphics (not diagrams) will be painted.";
            // 
            // Comp_Destination
            // 
            this.Comp_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Destination.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Destination.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.Destination;
            this.Comp_Destination.Dialog = this.DestinationFolderBrowserDialog;
            this.Comp_Destination.LabelText = "Destination:";
            this.Comp_Destination.Location = new System.Drawing.Point(6, 19);
            this.Comp_Destination.Name = "Comp_Destination";
            this.Comp_Destination.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Destination.Size = new System.Drawing.Size(319, 50);
            this.Comp_Destination.TabIndex = 0;
            this.Comp_Destination.ToolTip = "Path to save the graphics.";
            // 
            // DestinationFolderBrowserDialog
            // 
            this.DestinationFolderBrowserDialog.Description = "The folder where to save the graphics, constructed during this process.";
            // 
            // separator_2
            // 
            this.separator_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator_2.BackColor = System.Drawing.Color.Transparent;
            this.separator_2.Location = new System.Drawing.Point(6, 177);
            this.separator_2.Name = "separator_2";
            this.separator_2.Size = new System.Drawing.Size(319, 5);
            this.separator_2.TabIndex = 6;
            // 
            // TextBox_Hint
            // 
            this.TextBox_Hint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Hint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Hint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox_Hint.Enabled = false;
            this.TextBox_Hint.Location = new System.Drawing.Point(10, 188);
            this.TextBox_Hint.Multiline = true;
            this.TextBox_Hint.Name = "TextBox_Hint";
            this.TextBox_Hint.ReadOnly = true;
            this.TextBox_Hint.Size = new System.Drawing.Size(311, 252);
            this.TextBox_Hint.TabIndex = 7;
            this.TextBox_Hint.Text = resources.GetString("TextBox_Hint.Text");
            // 
            // ReviewSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "ReviewSettingsPanel";
            this.Size = new System.Drawing.Size(331, 478);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.FlowPanel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private System.Windows.Forms.FolderBrowserDialog DestinationFolderBrowserDialog;
        private Components.PathComponent Comp_Destination;
        private Components.ComboBoxComponent Comp_Palette;
        private Miscellaneous.Separator separator_1;
        private Components.BoolComponent Comp_AgeDiagram;
        private Components.BoolComponent Comp_AllDiagram;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Bottom;
        private System.Windows.Forms.Button Btn_Next;
        private Miscellaneous.Separator separator_2;
        private System.Windows.Forms.TextBox TextBox_Hint;
    }
}
