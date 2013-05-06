namespace PSC2013.ES.GUI
{
    partial class MainForm
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeOpenedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSidePanel = new System.Windows.Forms.Panel();
            this.MainSidePanel_disease = new System.Windows.Forms.GroupBox();
            this.MainSidePanel_bottom = new System.Windows.Forms.GroupBox();
            this.MainSidePanel_general = new System.Windows.Forms.GroupBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel_pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbl_simduration = new System.Windows.Forms.Label();
            this.numField_simduration = new System.Windows.Forms.NumericUpDown();
            this.numField_realtimetick = new System.Windows.Forms.NumericUpDown();
            this.lbl_realtimetick = new System.Windows.Forms.Label();
            this.numField_snapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.lbl_snapshotInterval = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenuStrip.SuspendLayout();
            this.MainSidePanel.SuspendLayout();
            this.MainSidePanel_general.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_simduration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_realtimetick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_snapshotInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.reviewToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(634, 24);
            this.MainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeOpenedDataToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.openFileToolStripMenuItem.Text = "Open .dep...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenDepMap_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.importToolStripMenuItem.Text = "Open .sim...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // closeOpenedDataToolStripMenuItem
            // 
            this.closeOpenedDataToolStripMenuItem.Name = "closeOpenedDataToolStripMenuItem";
            this.closeOpenedDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeOpenedDataToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.closeOpenedDataToolStripMenuItem.Text = "Close opened data";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewSimulationToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // createNewSimulationToolStripMenuItem
            // 
            this.createNewSimulationToolStripMenuItem.Name = "createNewSimulationToolStripMenuItem";
            this.createNewSimulationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.createNewSimulationToolStripMenuItem.Text = "Create new simulation...";
            this.createNewSimulationToolStripMenuItem.Click += new System.EventHandler(this.OpenDepMap_Click);
            // 
            // reviewToolStripMenuItem
            // 
            this.reviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSnapshotsToolStripMenuItem});
            this.reviewToolStripMenuItem.Name = "reviewToolStripMenuItem";
            this.reviewToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.reviewToolStripMenuItem.Text = "Review";
            // 
            // openSnapshotsToolStripMenuItem
            // 
            this.openSnapshotsToolStripMenuItem.Name = "openSnapshotsToolStripMenuItem";
            this.openSnapshotsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openSnapshotsToolStripMenuItem.Text = "Open snapshots...";
            // 
            // MainSidePanel
            // 
            this.MainSidePanel.Controls.Add(this.MainSidePanel_disease);
            this.MainSidePanel.Controls.Add(this.MainSidePanel_bottom);
            this.MainSidePanel.Controls.Add(this.MainSidePanel_general);
            this.MainSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainSidePanel.Location = new System.Drawing.Point(384, 24);
            this.MainSidePanel.Name = "MainSidePanel";
            this.MainSidePanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainSidePanel.Size = new System.Drawing.Size(250, 538);
            this.MainSidePanel.TabIndex = 1;
            // 
            // MainSidePanel_disease
            // 
            this.MainSidePanel_disease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSidePanel_disease.Location = new System.Drawing.Point(5, 115);
            this.MainSidePanel_disease.Name = "MainSidePanel_disease";
            this.MainSidePanel_disease.Size = new System.Drawing.Size(240, 365);
            this.MainSidePanel_disease.TabIndex = 3;
            this.MainSidePanel_disease.TabStop = false;
            this.MainSidePanel_disease.Text = "Disease";
            // 
            // MainSidePanel_bottom
            // 
            this.MainSidePanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainSidePanel_bottom.Location = new System.Drawing.Point(5, 480);
            this.MainSidePanel_bottom.Name = "MainSidePanel_bottom";
            this.MainSidePanel_bottom.Size = new System.Drawing.Size(240, 53);
            this.MainSidePanel_bottom.TabIndex = 2;
            this.MainSidePanel_bottom.TabStop = false;
            // 
            // MainSidePanel_general
            // 
            this.MainSidePanel_general.Controls.Add(this.lbl_snapshotInterval);
            this.MainSidePanel_general.Controls.Add(this.numField_snapshotInterval);
            this.MainSidePanel_general.Controls.Add(this.lbl_realtimetick);
            this.MainSidePanel_general.Controls.Add(this.numField_realtimetick);
            this.MainSidePanel_general.Controls.Add(this.numField_simduration);
            this.MainSidePanel_general.Controls.Add(this.lbl_simduration);
            this.MainSidePanel_general.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainSidePanel_general.Location = new System.Drawing.Point(5, 5);
            this.MainSidePanel_general.Name = "MainSidePanel_general";
            this.MainSidePanel_general.Size = new System.Drawing.Size(240, 110);
            this.MainSidePanel_general.TabIndex = 0;
            this.MainSidePanel_general.TabStop = false;
            this.MainSidePanel_general.Text = "General";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainPanel_pictureBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(384, 538);
            this.MainPanel.TabIndex = 2;
            // 
            // MainPanel_pictureBox
            // 
            this.MainPanel_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel_pictureBox.Location = new System.Drawing.Point(5, 5);
            this.MainPanel_pictureBox.Name = "MainPanel_pictureBox";
            this.MainPanel_pictureBox.Size = new System.Drawing.Size(374, 528);
            this.MainPanel_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainPanel_pictureBox.TabIndex = 0;
            this.MainPanel_pictureBox.TabStop = false;
            this.MainPanel_pictureBox.WaitOnLoad = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // lbl_simduration
            // 
            this.lbl_simduration.AutoSize = true;
            this.lbl_simduration.Location = new System.Drawing.Point(6, 25);
            this.lbl_simduration.Name = "lbl_simduration";
            this.lbl_simduration.Size = new System.Drawing.Size(99, 13);
            this.lbl_simduration.TabIndex = 0;
            this.lbl_simduration.Text = "Simulation duration:";
            // 
            // numField_simduration
            // 
            this.numField_simduration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_simduration.Location = new System.Drawing.Point(113, 23);
            this.numField_simduration.Maximum = new decimal(new int[] {
            0,
            -2147483648,
            0,
            0});
            this.numField_simduration.Name = "numField_simduration";
            this.numField_simduration.Size = new System.Drawing.Size(120, 20);
            this.numField_simduration.TabIndex = 1;
            this.numField_simduration.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_simduration, "The overall number of ticks, this simulation shall run.\r\n0 means infinite.");
            this.numField_simduration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numField_realtimetick
            // 
            this.numField_realtimetick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_realtimetick.Location = new System.Drawing.Point(113, 49);
            this.numField_realtimetick.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_realtimetick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numField_realtimetick.Name = "numField_realtimetick";
            this.numField_realtimetick.Size = new System.Drawing.Size(120, 20);
            this.numField_realtimetick.TabIndex = 2;
            this.numField_realtimetick.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_realtimetick, "The (realtime) duration a tick shall emulate.");
            this.numField_realtimetick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_realtimetick
            // 
            this.lbl_realtimetick.AutoSize = true;
            this.lbl_realtimetick.Location = new System.Drawing.Point(6, 51);
            this.lbl_realtimetick.Name = "lbl_realtimetick";
            this.lbl_realtimetick.Size = new System.Drawing.Size(88, 13);
            this.lbl_realtimetick.TabIndex = 3;
            this.lbl_realtimetick.Text = "Duration per tick:";
            // 
            // numField_snapshotInterval
            // 
            this.numField_snapshotInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_snapshotInterval.Location = new System.Drawing.Point(113, 75);
            this.numField_snapshotInterval.Maximum = new decimal(new int[] {
            0,
            -2147483648,
            0,
            0});
            this.numField_snapshotInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numField_snapshotInterval.Name = "numField_snapshotInterval";
            this.numField_snapshotInterval.Size = new System.Drawing.Size(120, 20);
            this.numField_snapshotInterval.TabIndex = 4;
            this.numField_snapshotInterval.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_snapshotInterval, "The interval of taking a snapshot (in ticks)");
            this.numField_snapshotInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_snapshotInterval
            // 
            this.lbl_snapshotInterval.AutoSize = true;
            this.lbl_snapshotInterval.Location = new System.Drawing.Point(6, 77);
            this.lbl_snapshotInterval.Name = "lbl_snapshotInterval";
            this.lbl_snapshotInterval.Size = new System.Drawing.Size(89, 13);
            this.lbl_snapshotInterval.TabIndex = 5;
            this.lbl_snapshotInterval.Text = "Snapshot interval";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainSidePanel);
            this.Controls.Add(this.MainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epidemic Simulator";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainSidePanel.ResumeLayout(false);
            this.MainSidePanel_general.ResumeLayout(false);
            this.MainSidePanel_general.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_simduration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_realtimetick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_snapshotInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeOpenedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSnapshotsToolStripMenuItem;
        private System.Windows.Forms.Panel MainSidePanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox MainPanel_pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox MainSidePanel_general;
        private System.Windows.Forms.GroupBox MainSidePanel_bottom;
        private System.Windows.Forms.GroupBox MainSidePanel_disease;
        private System.Windows.Forms.NumericUpDown numField_simduration;
        private System.Windows.Forms.Label lbl_simduration;
        private System.Windows.Forms.Label lbl_realtimetick;
        private System.Windows.Forms.NumericUpDown numField_realtimetick;
        private System.Windows.Forms.Label lbl_snapshotInterval;
        private System.Windows.Forms.NumericUpDown numField_snapshotInterval;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

