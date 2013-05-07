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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importDiseaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDiseaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSidePanel = new System.Windows.Forms.Panel();
            this.MainSidePanel_disease = new System.Windows.Forms.GroupBox();
            this.btn_disease_export = new System.Windows.Forms.Button();
            this.btn_disease_import = new System.Windows.Forms.Button();
            this.lbl_resistance = new System.Windows.Forms.Label();
            this.btn_resistance = new System.Windows.Forms.Button();
            this.lbl_healing = new System.Windows.Forms.Label();
            this.btn_healing = new System.Windows.Forms.Button();
            this.lbl_mortality = new System.Windows.Forms.Label();
            this.btn_mortality = new System.Windows.Forms.Button();
            this.lbl_transferability = new System.Windows.Forms.Label();
            this.numField_transferability = new System.Windows.Forms.NumericUpDown();
            this.lbl_spreading = new System.Windows.Forms.Label();
            this.numField_spreading = new System.Windows.Forms.NumericUpDown();
            this.lbl_idle = new System.Windows.Forms.Label();
            this.numField_idle = new System.Windows.Forms.NumericUpDown();
            this.lbl_incubationperiod = new System.Windows.Forms.Label();
            this.numField_incubationperiod = new System.Windows.Forms.NumericUpDown();
            this.txBox_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.MainSidePanel_bottom = new System.Windows.Forms.GroupBox();
            this.btn_start_sim = new System.Windows.Forms.Button();
            this.MainSidePanel_general = new System.Windows.Forms.GroupBox();
            this.lbl_snapshotInterval = new System.Windows.Forms.Label();
            this.numField_snapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.lbl_realtimetick = new System.Windows.Forms.Label();
            this.numField_realtimetick = new System.Windows.Forms.NumericUpDown();
            this.numField_simduration = new System.Windows.Forms.NumericUpDown();
            this.lbl_simduration = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel_pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenuStrip.SuspendLayout();
            this.MainSidePanel.SuspendLayout();
            this.MainSidePanel_disease.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_transferability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_spreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_idle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_incubationperiod)).BeginInit();
            this.MainSidePanel_bottom.SuspendLayout();
            this.MainSidePanel_general.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_snapshotInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_realtimetick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_simduration)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel_pictureBox)).BeginInit();
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
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.openFileToolStripMenuItem.Text = "Open .dep...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenDepMap_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
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
            this.createNewSimulationToolStripMenuItem,
            this.toolStripSeparator3,
            this.importDiseaseToolStripMenuItem,
            this.exportDiseaseToolStripMenuItem});
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // importDiseaseToolStripMenuItem
            // 
            this.importDiseaseToolStripMenuItem.Name = "importDiseaseToolStripMenuItem";
            this.importDiseaseToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.importDiseaseToolStripMenuItem.Text = "Import disease...";
            // 
            // exportDiseaseToolStripMenuItem
            // 
            this.exportDiseaseToolStripMenuItem.Name = "exportDiseaseToolStripMenuItem";
            this.exportDiseaseToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exportDiseaseToolStripMenuItem.Text = "Export disease...";
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
            this.MainSidePanel_disease.Controls.Add(this.btn_disease_export);
            this.MainSidePanel_disease.Controls.Add(this.btn_disease_import);
            this.MainSidePanel_disease.Controls.Add(this.lbl_resistance);
            this.MainSidePanel_disease.Controls.Add(this.btn_resistance);
            this.MainSidePanel_disease.Controls.Add(this.lbl_healing);
            this.MainSidePanel_disease.Controls.Add(this.btn_healing);
            this.MainSidePanel_disease.Controls.Add(this.lbl_mortality);
            this.MainSidePanel_disease.Controls.Add(this.btn_mortality);
            this.MainSidePanel_disease.Controls.Add(this.lbl_transferability);
            this.MainSidePanel_disease.Controls.Add(this.numField_transferability);
            this.MainSidePanel_disease.Controls.Add(this.lbl_spreading);
            this.MainSidePanel_disease.Controls.Add(this.numField_spreading);
            this.MainSidePanel_disease.Controls.Add(this.lbl_idle);
            this.MainSidePanel_disease.Controls.Add(this.numField_idle);
            this.MainSidePanel_disease.Controls.Add(this.lbl_incubationperiod);
            this.MainSidePanel_disease.Controls.Add(this.numField_incubationperiod);
            this.MainSidePanel_disease.Controls.Add(this.txBox_name);
            this.MainSidePanel_disease.Controls.Add(this.lbl_name);
            this.MainSidePanel_disease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSidePanel_disease.Location = new System.Drawing.Point(5, 115);
            this.MainSidePanel_disease.Name = "MainSidePanel_disease";
            this.MainSidePanel_disease.Size = new System.Drawing.Size(240, 368);
            this.MainSidePanel_disease.TabIndex = 3;
            this.MainSidePanel_disease.TabStop = false;
            this.MainSidePanel_disease.Text = "Disease";
            // 
            // btn_disease_export
            // 
            this.btn_disease_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disease_export.Location = new System.Drawing.Point(131, 339);
            this.btn_disease_export.Name = "btn_disease_export";
            this.btn_disease_export.Size = new System.Drawing.Size(102, 23);
            this.btn_disease_export.TabIndex = 19;
            this.btn_disease_export.Text = "Export disease...";
            this.toolTip.SetToolTip(this.btn_disease_export, "Export the current disease to use it several\r\ntimes by importing it later again.");
            this.btn_disease_export.UseVisualStyleBackColor = true;
            // 
            // btn_disease_import
            // 
            this.btn_disease_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_disease_import.Location = new System.Drawing.Point(9, 339);
            this.btn_disease_import.Name = "btn_disease_import";
            this.btn_disease_import.Size = new System.Drawing.Size(102, 23);
            this.btn_disease_import.TabIndex = 0;
            this.btn_disease_import.Text = "Import disease...";
            this.toolTip.SetToolTip(this.btn_disease_import, "Import an existing disease.");
            this.btn_disease_import.UseVisualStyleBackColor = true;
            // 
            // lbl_resistance
            // 
            this.lbl_resistance.AutoSize = true;
            this.lbl_resistance.Location = new System.Drawing.Point(6, 208);
            this.lbl_resistance.Name = "lbl_resistance";
            this.lbl_resistance.Size = new System.Drawing.Size(98, 13);
            this.lbl_resistance.TabIndex = 18;
            this.lbl_resistance.Text = "Resistance factors:";
            this.toolTip.SetToolTip(this.lbl_resistance, "The hours the disease is spreading after the subject got infected.");
            // 
            // btn_resistance
            // 
            this.btn_resistance.Location = new System.Drawing.Point(113, 204);
            this.btn_resistance.Name = "btn_resistance";
            this.btn_resistance.Size = new System.Drawing.Size(120, 20);
            this.btn_resistance.TabIndex = 17;
            this.btn_resistance.Text = "Set data...";
            this.toolTip.SetToolTip(this.btn_resistance, "Specify the rate of resistance for each age- and gender-group.");
            this.btn_resistance.UseVisualStyleBackColor = true;
            // 
            // lbl_healing
            // 
            this.lbl_healing.AutoSize = true;
            this.lbl_healing.Location = new System.Drawing.Point(6, 182);
            this.lbl_healing.Name = "lbl_healing";
            this.lbl_healing.Size = new System.Drawing.Size(81, 13);
            this.lbl_healing.TabIndex = 16;
            this.lbl_healing.Text = "Healing factors:";
            this.toolTip.SetToolTip(this.lbl_healing, "The hours the disease is spreading after the subject got infected.\r\nThis might in" +
        "fluence the resistance factor (over time).");
            // 
            // btn_healing
            // 
            this.btn_healing.Location = new System.Drawing.Point(113, 178);
            this.btn_healing.Name = "btn_healing";
            this.btn_healing.Size = new System.Drawing.Size(120, 20);
            this.btn_healing.TabIndex = 15;
            this.btn_healing.Text = "Set data...";
            this.toolTip.SetToolTip(this.btn_healing, "Specify the rate of healing for each age- and gender-group.");
            this.btn_healing.UseVisualStyleBackColor = true;
            // 
            // lbl_mortality
            // 
            this.lbl_mortality.AutoSize = true;
            this.lbl_mortality.Location = new System.Drawing.Point(6, 156);
            this.lbl_mortality.Name = "lbl_mortality";
            this.lbl_mortality.Size = new System.Drawing.Size(84, 13);
            this.lbl_mortality.TabIndex = 14;
            this.lbl_mortality.Text = "Mortality factors:";
            this.toolTip.SetToolTip(this.lbl_mortality, "The hours the disease is spreading after the subject got infected.");
            // 
            // btn_mortality
            // 
            this.btn_mortality.Location = new System.Drawing.Point(113, 152);
            this.btn_mortality.Name = "btn_mortality";
            this.btn_mortality.Size = new System.Drawing.Size(120, 20);
            this.btn_mortality.TabIndex = 13;
            this.btn_mortality.Text = "Set data...";
            this.toolTip.SetToolTip(this.btn_mortality, "Specify the rate of mortality for each age- and gender-group.");
            this.btn_mortality.UseVisualStyleBackColor = true;
            this.btn_mortality.Click += new System.EventHandler(this.btn_mortality_Click);
            // 
            // lbl_transferability
            // 
            this.lbl_transferability.AutoSize = true;
            this.lbl_transferability.Location = new System.Drawing.Point(6, 128);
            this.lbl_transferability.Name = "lbl_transferability";
            this.lbl_transferability.Size = new System.Drawing.Size(105, 13);
            this.lbl_transferability.TabIndex = 12;
            this.lbl_transferability.Text = "Transferability factor:";
            this.toolTip.SetToolTip(this.lbl_transferability, "The hours the disease is spreading after the subject got infected.");
            // 
            // numField_transferability
            // 
            this.numField_transferability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_transferability.Location = new System.Drawing.Point(113, 126);
            this.numField_transferability.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_transferability.Name = "numField_transferability";
            this.numField_transferability.Size = new System.Drawing.Size(120, 20);
            this.numField_transferability.TabIndex = 11;
            this.numField_transferability.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_transferability, "The percentage of the disease infecting someone.\r\n(e.g.: per air will be a greate" +
        "r value than per direct contact.)");
            // 
            // lbl_spreading
            // 
            this.lbl_spreading.AutoSize = true;
            this.lbl_spreading.Location = new System.Drawing.Point(6, 102);
            this.lbl_spreading.Name = "lbl_spreading";
            this.lbl_spreading.Size = new System.Drawing.Size(90, 13);
            this.lbl_spreading.TabIndex = 10;
            this.lbl_spreading.Text = "Spreading period:";
            this.toolTip.SetToolTip(this.lbl_spreading, "The hours the disease is spreading after the subject got infected.");
            // 
            // numField_spreading
            // 
            this.numField_spreading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_spreading.Location = new System.Drawing.Point(113, 100);
            this.numField_spreading.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_spreading.Name = "numField_spreading";
            this.numField_spreading.Size = new System.Drawing.Size(120, 20);
            this.numField_spreading.TabIndex = 9;
            this.numField_spreading.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_spreading, "The hours the subject spreads the disease.\r\nThis effect will start when the idle-" +
        "time is over.");
            // 
            // lbl_idle
            // 
            this.lbl_idle.AutoSize = true;
            this.lbl_idle.Location = new System.Drawing.Point(6, 76);
            this.lbl_idle.Name = "lbl_idle";
            this.lbl_idle.Size = new System.Drawing.Size(59, 13);
            this.lbl_idle.TabIndex = 8;
            this.lbl_idle.Text = "Idle period:";
            this.toolTip.SetToolTip(this.lbl_idle, "The hours the disease is spreading after the subject got infected.");
            // 
            // numField_idle
            // 
            this.numField_idle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_idle.Location = new System.Drawing.Point(113, 74);
            this.numField_idle.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_idle.Name = "numField_idle";
            this.numField_idle.Size = new System.Drawing.Size(120, 20);
            this.numField_idle.TabIndex = 7;
            this.numField_idle.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_idle, "The hours the incubation lasts.");
            // 
            // lbl_incubationperiod
            // 
            this.lbl_incubationperiod.AutoSize = true;
            this.lbl_incubationperiod.Location = new System.Drawing.Point(6, 50);
            this.lbl_incubationperiod.Name = "lbl_incubationperiod";
            this.lbl_incubationperiod.Size = new System.Drawing.Size(92, 13);
            this.lbl_incubationperiod.TabIndex = 6;
            this.lbl_incubationperiod.Text = "Incubation period:";
            // 
            // numField_incubationperiod
            // 
            this.numField_incubationperiod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numField_incubationperiod.Location = new System.Drawing.Point(113, 48);
            this.numField_incubationperiod.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_incubationperiod.Name = "numField_incubationperiod";
            this.numField_incubationperiod.Size = new System.Drawing.Size(120, 20);
            this.numField_incubationperiod.TabIndex = 5;
            this.numField_incubationperiod.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.numField_incubationperiod, "The hours the incubation lasts.");
            // 
            // txBox_name
            // 
            this.txBox_name.Location = new System.Drawing.Point(113, 22);
            this.txBox_name.Name = "txBox_name";
            this.txBox_name.Size = new System.Drawing.Size(120, 20);
            this.txBox_name.TabIndex = 1;
            this.toolTip.SetToolTip(this.txBox_name, "The disease\'s name.");
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(6, 25);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // MainSidePanel_bottom
            // 
            this.MainSidePanel_bottom.Controls.Add(this.btn_start_sim);
            this.MainSidePanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainSidePanel_bottom.Location = new System.Drawing.Point(5, 483);
            this.MainSidePanel_bottom.Name = "MainSidePanel_bottom";
            this.MainSidePanel_bottom.Size = new System.Drawing.Size(240, 50);
            this.MainSidePanel_bottom.TabIndex = 2;
            this.MainSidePanel_bottom.TabStop = false;
            // 
            // btn_start_sim
            // 
            this.btn_start_sim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start_sim.Location = new System.Drawing.Point(9, 16);
            this.btn_start_sim.Name = "btn_start_sim";
            this.btn_start_sim.Size = new System.Drawing.Size(224, 25);
            this.btn_start_sim.TabIndex = 0;
            this.btn_start_sim.Text = "Start simulation...";
            this.toolTip.SetToolTip(this.btn_start_sim, "Start the simulation.\r\nThis might consume time, RAM, CPU and memory-capacities.");
            this.btn_start_sim.UseVisualStyleBackColor = true;
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
            // lbl_snapshotInterval
            // 
            this.lbl_snapshotInterval.AutoSize = true;
            this.lbl_snapshotInterval.Location = new System.Drawing.Point(6, 77);
            this.lbl_snapshotInterval.Name = "lbl_snapshotInterval";
            this.lbl_snapshotInterval.Size = new System.Drawing.Size(89, 13);
            this.lbl_snapshotInterval.TabIndex = 5;
            this.lbl_snapshotInterval.Text = "Snapshot interval";
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
            24,
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainSidePanel);
            this.Controls.Add(this.MainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epidemic Simulator";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainSidePanel.ResumeLayout(false);
            this.MainSidePanel_disease.ResumeLayout(false);
            this.MainSidePanel_disease.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_transferability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_spreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_idle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_incubationperiod)).EndInit();
            this.MainSidePanel_bottom.ResumeLayout(false);
            this.MainSidePanel_general.ResumeLayout(false);
            this.MainSidePanel_general.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_snapshotInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_realtimetick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_simduration)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel_pictureBox)).EndInit();
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
        private System.Windows.Forms.Label lbl_incubationperiod;
        private System.Windows.Forms.NumericUpDown numField_incubationperiod;
        private System.Windows.Forms.TextBox txBox_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_idle;
        private System.Windows.Forms.NumericUpDown numField_idle;
        private System.Windows.Forms.Label lbl_spreading;
        private System.Windows.Forms.NumericUpDown numField_spreading;
        private System.Windows.Forms.Label lbl_transferability;
        private System.Windows.Forms.NumericUpDown numField_transferability;
        private System.Windows.Forms.Button btn_mortality;
        private System.Windows.Forms.Label lbl_mortality;
        private System.Windows.Forms.Label lbl_resistance;
        private System.Windows.Forms.Button btn_resistance;
        private System.Windows.Forms.Label lbl_healing;
        private System.Windows.Forms.Button btn_healing;
        private System.Windows.Forms.Button btn_disease_import;
        private System.Windows.Forms.Button btn_disease_export;
        private System.Windows.Forms.Button btn_start_sim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importDiseaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDiseaseToolStripMenuItem;
    }
}

