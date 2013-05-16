namespace PSC2013.ES.GUI.ReviewSimulation
{
    partial class ReviewSimulationForm
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
            this.components = new System.ComponentModel.Container();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel_grpBox_main = new System.Windows.Forms.GroupBox();
            this.MainPanel_grpBox_bottom = new System.Windows.Forms.GroupBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_targetDirectory = new System.Windows.Forms.Label();
            this.txtBox_targetDirectory = new System.Windows.Forms.TextBox();
            this.txtBox_prefix = new System.Windows.Forms.TextBox();
            this.lbl_prefix = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_palette = new System.Windows.Forms.Label();
            this.cmbBox_palette = new System.Windows.Forms.ComboBox();
            this.lstBox_entries = new System.Windows.Forms.ListBox();
            this.lbl_entries = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.MainPanel_grpBox_main.SuspendLayout();
            this.MainPanel_grpBox_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainPanel_grpBox_main);
            this.MainPanel.Controls.Add(this.MainPanel_grpBox_bottom);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MainPanel.Size = new System.Drawing.Size(284, 262);
            this.MainPanel.TabIndex = 0;
            // 
            // MainPanel_grpBox_main
            // 
            this.MainPanel_grpBox_main.Controls.Add(this.lbl_entries);
            this.MainPanel_grpBox_main.Controls.Add(this.lstBox_entries);
            this.MainPanel_grpBox_main.Controls.Add(this.cmbBox_palette);
            this.MainPanel_grpBox_main.Controls.Add(this.lbl_palette);
            this.MainPanel_grpBox_main.Controls.Add(this.txtBox_prefix);
            this.MainPanel_grpBox_main.Controls.Add(this.lbl_prefix);
            this.MainPanel_grpBox_main.Controls.Add(this.txtBox_targetDirectory);
            this.MainPanel_grpBox_main.Controls.Add(this.lbl_targetDirectory);
            this.MainPanel_grpBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel_grpBox_main.Location = new System.Drawing.Point(3, 3);
            this.MainPanel_grpBox_main.Name = "MainPanel_grpBox_main";
            this.MainPanel_grpBox_main.Size = new System.Drawing.Size(278, 206);
            this.MainPanel_grpBox_main.TabIndex = 1;
            this.MainPanel_grpBox_main.TabStop = false;
            this.MainPanel_grpBox_main.Text = "Settings";
            // 
            // MainPanel_grpBox_bottom
            // 
            this.MainPanel_grpBox_bottom.Controls.Add(this.btn_start);
            this.MainPanel_grpBox_bottom.Controls.Add(this.btn_back);
            this.MainPanel_grpBox_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel_grpBox_bottom.Location = new System.Drawing.Point(3, 209);
            this.MainPanel_grpBox_bottom.Name = "MainPanel_grpBox_bottom";
            this.MainPanel_grpBox_bottom.Size = new System.Drawing.Size(278, 50);
            this.MainPanel_grpBox_bottom.TabIndex = 0;
            this.MainPanel_grpBox_bottom.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(9, 16);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(102, 25);
            this.btn_back.TabIndex = 0;
            this.btn_back.Text = "< Back";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(167, 16);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(102, 25);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_targetDirectory
            // 
            this.lbl_targetDirectory.AutoSize = true;
            this.lbl_targetDirectory.Location = new System.Drawing.Point(9, 25);
            this.lbl_targetDirectory.Name = "lbl_targetDirectory";
            this.lbl_targetDirectory.Size = new System.Drawing.Size(86, 13);
            this.lbl_targetDirectory.TabIndex = 0;
            this.lbl_targetDirectory.Text = "Target Directory:";
            // 
            // txtBox_targetDirectory
            // 
            this.txtBox_targetDirectory.Location = new System.Drawing.Point(101, 22);
            this.txtBox_targetDirectory.Name = "txtBox_targetDirectory";
            this.txtBox_targetDirectory.Size = new System.Drawing.Size(168, 20);
            this.txtBox_targetDirectory.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtBox_targetDirectory, "Directory where the generated images will be saved.");
            this.txtBox_targetDirectory.TextChanged += new System.EventHandler(this.txtBox_targetDirectory_TextChanged);
            // 
            // txtBox_prefix
            // 
            this.txtBox_prefix.Location = new System.Drawing.Point(101, 48);
            this.txtBox_prefix.Name = "txtBox_prefix";
            this.txtBox_prefix.Size = new System.Drawing.Size(168, 20);
            this.txtBox_prefix.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtBox_prefix, "The prefix for the filenames.");
            // 
            // lbl_prefix
            // 
            this.lbl_prefix.AutoSize = true;
            this.lbl_prefix.Location = new System.Drawing.Point(9, 51);
            this.lbl_prefix.Name = "lbl_prefix";
            this.lbl_prefix.Size = new System.Drawing.Size(36, 13);
            this.lbl_prefix.TabIndex = 2;
            this.lbl_prefix.Text = "Prefix:";
            // 
            // lbl_palette
            // 
            this.lbl_palette.AutoSize = true;
            this.lbl_palette.Location = new System.Drawing.Point(9, 77);
            this.lbl_palette.Name = "lbl_palette";
            this.lbl_palette.Size = new System.Drawing.Size(70, 13);
            this.lbl_palette.TabIndex = 4;
            this.lbl_palette.Text = "Color Palette:";
            // 
            // cmbBox_palette
            // 
            this.cmbBox_palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_palette.FormattingEnabled = true;
            this.cmbBox_palette.Location = new System.Drawing.Point(101, 74);
            this.cmbBox_palette.Name = "cmbBox_palette";
            this.cmbBox_palette.Size = new System.Drawing.Size(168, 21);
            this.cmbBox_palette.TabIndex = 5;
            this.toolTip.SetToolTip(this.cmbBox_palette, "Color-palette used for the graphics.");
            // 
            // lstBox_entries
            // 
            this.lstBox_entries.FormattingEnabled = true;
            this.lstBox_entries.IntegralHeight = false;
            this.lstBox_entries.Location = new System.Drawing.Point(101, 105);
            this.lstBox_entries.Name = "lstBox_entries";
            this.lstBox_entries.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBox_entries.Size = new System.Drawing.Size(168, 95);
            this.lstBox_entries.TabIndex = 6;
            // 
            // lbl_entries
            // 
            this.lbl_entries.AutoSize = true;
            this.lbl_entries.Location = new System.Drawing.Point(10, 105);
            this.lbl_entries.Name = "lbl_entries";
            this.lbl_entries.Size = new System.Drawing.Size(42, 13);
            this.lbl_entries.TabIndex = 7;
            this.lbl_entries.Text = "Entries:";
            // 
            // ReviewSimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MainPanel);
            this.Name = "ReviewSimulationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReviewSimulationForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel_grpBox_main.ResumeLayout(false);
            this.MainPanel_grpBox_main.PerformLayout();
            this.MainPanel_grpBox_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox MainPanel_grpBox_bottom;
        private System.Windows.Forms.GroupBox MainPanel_grpBox_main;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txtBox_targetDirectory;
        private System.Windows.Forms.Label lbl_targetDirectory;
        private System.Windows.Forms.TextBox txtBox_prefix;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lbl_prefix;
        private System.Windows.Forms.Label lbl_palette;
        private System.Windows.Forms.ComboBox cmbBox_palette;
        private System.Windows.Forms.Label lbl_entries;
        private System.Windows.Forms.ListBox lstBox_entries;

    }
}