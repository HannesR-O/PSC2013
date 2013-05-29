namespace PSC2013.ES.GUI.ReviewSimulation
{
    partial class ReviewForm
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
            this.ComboBox_Entries = new System.Windows.Forms.ComboBox();
            this.Btn_LoadTick = new System.Windows.Forms.Button();
            this.Label_DiseaseName = new System.Windows.Forms.Label();
            this.GroupBox_Disease = new System.Windows.Forms.GroupBox();
            this.Label_Transfer = new System.Windows.Forms.Label();
            this.Label_Spreading = new System.Windows.Forms.Label();
            this.Label_Idle = new System.Windows.Forms.Label();
            this.Label_Incubation = new System.Windows.Forms.Label();
            this.Transferability = new System.Windows.Forms.Label();
            this.Idle = new System.Windows.Forms.Label();
            this.Spreading = new System.Windows.Forms.Label();
            this.Incubation = new System.Windows.Forms.Label();
            this.GroupBox_TickSelections = new System.Windows.Forms.GroupBox();
            this.Panel_leftside = new System.Windows.Forms.Panel();
            this.Panel_Tick = new System.Windows.Forms.Panel();
            this.Panel_fieldSelectionContainer = new System.Windows.Forms.Panel();
            this.TabControl_MapCreator = new System.Windows.Forms.TabControl();
            this.Page_Standard = new System.Windows.Forms.TabPage();
            this.GroupBox_S_Create = new System.Windows.Forms.GroupBox();
            this.ComboBox_S_IndPalette = new System.Windows.Forms.ComboBox();
            this.CheckBox_S_Male = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_IndPalette = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleSenior = new System.Windows.Forms.CheckBox();
            this.TextBox_S_Prefix = new System.Windows.Forms.TextBox();
            this.CheckBox_S_FemaleBaby = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Infected = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_IndPredix = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleSenior = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Diseased = new System.Windows.Forms.CheckBox();
            this.Btn_Create_S = new System.Windows.Forms.Button();
            this.CheckBox_S_MaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_All = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleBaby = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Female = new System.Windows.Forms.CheckBox();
            this.Page_Death = new System.Windows.Forms.TabPage();
            this.Page_Defaults = new System.Windows.Forms.TabPage();
            this.TextBox_SaveTo = new System.Windows.Forms.TextBox();
            this.LabelSaveTo = new System.Windows.Forms.Label();
            this.Btn_SaveTo_Browse = new System.Windows.Forms.Button();
            this.Label_Palette = new System.Windows.Forms.Label();
            this.ComboBox_DefaultPalette = new System.Windows.Forms.ComboBox();
            this.TextBox_DefaultPrefix = new System.Windows.Forms.TextBox();
            this.Label_Prefix = new System.Windows.Forms.Label();
            this.GroupBox_TickInfo = new System.Windows.Forms.GroupBox();
            this.Label_DeathInformation = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileChooser = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox_Settings = new System.Windows.Forms.GroupBox();
            this.Btn_ApplySettings = new System.Windows.Forms.Button();
            this.GroupBox_Disease.SuspendLayout();
            this.GroupBox_TickSelections.SuspendLayout();
            this.Panel_leftside.SuspendLayout();
            this.Panel_Tick.SuspendLayout();
            this.Panel_fieldSelectionContainer.SuspendLayout();
            this.TabControl_MapCreator.SuspendLayout();
            this.Page_Standard.SuspendLayout();
            this.GroupBox_S_Create.SuspendLayout();
            this.Page_Defaults.SuspendLayout();
            this.GroupBox_TickInfo.SuspendLayout();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBox_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBox_Entries
            // 
            this.ComboBox_Entries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Entries.Enabled = false;
            this.ComboBox_Entries.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboBox_Entries.Location = new System.Drawing.Point(10, 35);
            this.ComboBox_Entries.Name = "ComboBox_Entries";
            this.ComboBox_Entries.Size = new System.Drawing.Size(208, 21);
            this.ComboBox_Entries.Sorted = true;
            this.ComboBox_Entries.TabIndex = 1;
            // 
            // Btn_LoadTick
            // 
            this.Btn_LoadTick.Enabled = false;
            this.Btn_LoadTick.Location = new System.Drawing.Point(143, 62);
            this.Btn_LoadTick.Name = "Btn_LoadTick";
            this.Btn_LoadTick.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadTick.TabIndex = 2;
            this.Btn_LoadTick.Text = "Load";
            this.Btn_LoadTick.UseVisualStyleBackColor = true;
            this.Btn_LoadTick.Click += new System.EventHandler(this.Btn_LoadTick_Click);
            // 
            // Label_DiseaseName
            // 
            this.Label_DiseaseName.AutoSize = true;
            this.Label_DiseaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DiseaseName.Location = new System.Drawing.Point(6, 22);
            this.Label_DiseaseName.Name = "Label_DiseaseName";
            this.Label_DiseaseName.Size = new System.Drawing.Size(51, 20);
            this.Label_DiseaseName.TabIndex = 0;
            this.Label_DiseaseName.Text = "Name";
            // 
            // GroupBox_Disease
            // 
            this.GroupBox_Disease.Controls.Add(this.Label_Transfer);
            this.GroupBox_Disease.Controls.Add(this.Label_Spreading);
            this.GroupBox_Disease.Controls.Add(this.Label_Idle);
            this.GroupBox_Disease.Controls.Add(this.Label_Incubation);
            this.GroupBox_Disease.Controls.Add(this.Transferability);
            this.GroupBox_Disease.Controls.Add(this.Label_DiseaseName);
            this.GroupBox_Disease.Controls.Add(this.Idle);
            this.GroupBox_Disease.Controls.Add(this.Spreading);
            this.GroupBox_Disease.Controls.Add(this.Incubation);
            this.GroupBox_Disease.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox_Disease.Location = new System.Drawing.Point(10, 0);
            this.GroupBox_Disease.Name = "GroupBox_Disease";
            this.GroupBox_Disease.Size = new System.Drawing.Size(235, 329);
            this.GroupBox_Disease.TabIndex = 4;
            this.GroupBox_Disease.TabStop = false;
            this.GroupBox_Disease.Text = "Disease";
            // 
            // Label_Transfer
            // 
            this.Label_Transfer.Location = new System.Drawing.Point(123, 82);
            this.Label_Transfer.Name = "Label_Transfer";
            this.Label_Transfer.Size = new System.Drawing.Size(95, 13);
            this.Label_Transfer.TabIndex = 8;
            this.Label_Transfer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Label_Spreading
            // 
            this.Label_Spreading.Location = new System.Drawing.Point(123, 69);
            this.Label_Spreading.Name = "Label_Spreading";
            this.Label_Spreading.Size = new System.Drawing.Size(95, 13);
            this.Label_Spreading.TabIndex = 7;
            this.Label_Spreading.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Label_Idle
            // 
            this.Label_Idle.Location = new System.Drawing.Point(123, 56);
            this.Label_Idle.Name = "Label_Idle";
            this.Label_Idle.Size = new System.Drawing.Size(95, 13);
            this.Label_Idle.TabIndex = 6;
            this.Label_Idle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Label_Incubation
            // 
            this.Label_Incubation.Location = new System.Drawing.Point(120, 44);
            this.Label_Incubation.Name = "Label_Incubation";
            this.Label_Incubation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_Incubation.Size = new System.Drawing.Size(98, 13);
            this.Label_Incubation.TabIndex = 5;
            this.Label_Incubation.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Transferability
            // 
            this.Transferability.AutoSize = true;
            this.Transferability.Location = new System.Drawing.Point(7, 83);
            this.Transferability.Name = "Transferability";
            this.Transferability.Size = new System.Drawing.Size(72, 13);
            this.Transferability.TabIndex = 4;
            this.Transferability.Text = "Transferability";
            // 
            // Idle
            // 
            this.Idle.AutoSize = true;
            this.Idle.Location = new System.Drawing.Point(7, 57);
            this.Idle.Name = "Idle";
            this.Idle.Size = new System.Drawing.Size(50, 13);
            this.Idle.TabIndex = 2;
            this.Idle.Text = "Idle Time";
            // 
            // Spreading
            // 
            this.Spreading.AutoSize = true;
            this.Spreading.Location = new System.Drawing.Point(7, 70);
            this.Spreading.Name = "Spreading";
            this.Spreading.Size = new System.Drawing.Size(81, 13);
            this.Spreading.TabIndex = 3;
            this.Spreading.Text = "Spreading Time";
            // 
            // Incubation
            // 
            this.Incubation.AutoSize = true;
            this.Incubation.Location = new System.Drawing.Point(7, 44);
            this.Incubation.Name = "Incubation";
            this.Incubation.Size = new System.Drawing.Size(83, 13);
            this.Incubation.TabIndex = 1;
            this.Incubation.Text = "Incubation Time";
            // 
            // GroupBox_TickSelections
            // 
            this.GroupBox_TickSelections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox_TickSelections.Controls.Add(this.ComboBox_Entries);
            this.GroupBox_TickSelections.Controls.Add(this.Btn_LoadTick);
            this.GroupBox_TickSelections.Location = new System.Drawing.Point(10, 335);
            this.GroupBox_TickSelections.Name = "GroupBox_TickSelections";
            this.GroupBox_TickSelections.Size = new System.Drawing.Size(235, 297);
            this.GroupBox_TickSelections.TabIndex = 5;
            this.GroupBox_TickSelections.TabStop = false;
            this.GroupBox_TickSelections.Text = "Tick Selections";
            // 
            // Panel_leftside
            // 
            this.Panel_leftside.Controls.Add(this.GroupBox_Disease);
            this.Panel_leftside.Controls.Add(this.GroupBox_TickSelections);
            this.Panel_leftside.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_leftside.Location = new System.Drawing.Point(0, 24);
            this.Panel_leftside.Name = "Panel_leftside";
            this.Panel_leftside.Padding = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.Panel_leftside.Size = new System.Drawing.Size(255, 638);
            this.Panel_leftside.TabIndex = 6;
            // 
            // Panel_Tick
            // 
            this.Panel_Tick.Controls.Add(this.Panel_fieldSelectionContainer);
            this.Panel_Tick.Controls.Add(this.GroupBox_TickInfo);
            this.Panel_Tick.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Tick.Location = new System.Drawing.Point(255, 24);
            this.Panel_Tick.Name = "Panel_Tick";
            this.Panel_Tick.Size = new System.Drawing.Size(702, 235);
            this.Panel_Tick.TabIndex = 7;
            // 
            // Panel_fieldSelectionContainer
            // 
            this.Panel_fieldSelectionContainer.Controls.Add(this.TabControl_MapCreator);
            this.Panel_fieldSelectionContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_fieldSelectionContainer.Location = new System.Drawing.Point(320, 0);
            this.Panel_fieldSelectionContainer.Name = "Panel_fieldSelectionContainer";
            this.Panel_fieldSelectionContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Panel_fieldSelectionContainer.Size = new System.Drawing.Size(382, 235);
            this.Panel_fieldSelectionContainer.TabIndex = 8;
            // 
            // TabControl_MapCreator
            // 
            this.TabControl_MapCreator.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl_MapCreator.Controls.Add(this.Page_Standard);
            this.TabControl_MapCreator.Controls.Add(this.Page_Death);
            this.TabControl_MapCreator.Controls.Add(this.Page_Defaults);
            this.TabControl_MapCreator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_MapCreator.Enabled = false;
            this.TabControl_MapCreator.Location = new System.Drawing.Point(5, 5);
            this.TabControl_MapCreator.Name = "TabControl_MapCreator";
            this.TabControl_MapCreator.SelectedIndex = 0;
            this.TabControl_MapCreator.Size = new System.Drawing.Size(372, 230);
            this.TabControl_MapCreator.TabIndex = 1;
            // 
            // Page_Standard
            // 
            this.Page_Standard.BackColor = System.Drawing.Color.Transparent;
            this.Page_Standard.Controls.Add(this.GroupBox_S_Create);
            this.Page_Standard.Location = new System.Drawing.Point(4, 25);
            this.Page_Standard.Name = "Page_Standard";
            this.Page_Standard.Padding = new System.Windows.Forms.Padding(3);
            this.Page_Standard.Size = new System.Drawing.Size(364, 201);
            this.Page_Standard.TabIndex = 0;
            this.Page_Standard.Text = "Standard";
            // 
            // GroupBox_S_Create
            // 
            this.GroupBox_S_Create.Controls.Add(this.ComboBox_S_IndPalette);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_Male);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_FemaleAdult);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_IndPalette);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_FemaleChild);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_FemaleSenior);
            this.GroupBox_S_Create.Controls.Add(this.TextBox_S_Prefix);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_FemaleBaby);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_Infected);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_IndPredix);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_MaleSenior);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_Diseased);
            this.GroupBox_S_Create.Controls.Add(this.Btn_Create_S);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_MaleAdult);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_All);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_MaleChild);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_MaleBaby);
            this.GroupBox_S_Create.Controls.Add(this.CheckBox_S_Female);
            this.GroupBox_S_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_S_Create.Location = new System.Drawing.Point(3, 3);
            this.GroupBox_S_Create.Name = "GroupBox_S_Create";
            this.GroupBox_S_Create.Size = new System.Drawing.Size(358, 195);
            this.GroupBox_S_Create.TabIndex = 0;
            this.GroupBox_S_Create.TabStop = false;
            this.GroupBox_S_Create.Text = "Create";
            // 
            // ComboBox_S_IndPalette
            // 
            this.ComboBox_S_IndPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_S_IndPalette.Enabled = false;
            this.ComboBox_S_IndPalette.FormattingEnabled = true;
            this.ComboBox_S_IndPalette.Location = new System.Drawing.Point(203, 91);
            this.ComboBox_S_IndPalette.Name = "ComboBox_S_IndPalette";
            this.ComboBox_S_IndPalette.Size = new System.Drawing.Size(146, 21);
            this.ComboBox_S_IndPalette.TabIndex = 17;
            // 
            // CheckBox_S_Male
            // 
            this.CheckBox_S_Male.AutoSize = true;
            this.CheckBox_S_Male.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_S_Male.Location = new System.Drawing.Point(6, 42);
            this.CheckBox_S_Male.Name = "CheckBox_S_Male";
            this.CheckBox_S_Male.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_Male.TabIndex = 10;
            this.CheckBox_S_Male.Text = "Male";
            this.CheckBox_S_Male.UseVisualStyleBackColor = true;
            this.CheckBox_S_Male.CheckedChanged += new System.EventHandler(this.CheckBox_S_Male_CheckedChanged);
            // 
            // CheckBox_S_FemaleAdult
            // 
            this.CheckBox_S_FemaleAdult.AutoSize = true;
            this.CheckBox_S_FemaleAdult.Location = new System.Drawing.Point(101, 111);
            this.CheckBox_S_FemaleAdult.Name = "CheckBox_S_FemaleAdult";
            this.CheckBox_S_FemaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleAdult.TabIndex = 6;
            this.CheckBox_S_FemaleAdult.Text = "Adult";
            this.CheckBox_S_FemaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_IndPalette
            // 
            this.CheckBox_S_IndPalette.AutoSize = true;
            this.CheckBox_S_IndPalette.Location = new System.Drawing.Point(203, 67);
            this.CheckBox_S_IndPalette.Name = "CheckBox_S_IndPalette";
            this.CheckBox_S_IndPalette.Size = new System.Drawing.Size(129, 17);
            this.CheckBox_S_IndPalette.TabIndex = 16;
            this.CheckBox_S_IndPalette.Text = "Use Individual Palette";
            this.CheckBox_S_IndPalette.UseVisualStyleBackColor = true;
            this.CheckBox_S_IndPalette.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CheckBox_S_FemaleChild
            // 
            this.CheckBox_S_FemaleChild.AutoSize = true;
            this.CheckBox_S_FemaleChild.Location = new System.Drawing.Point(101, 88);
            this.CheckBox_S_FemaleChild.Name = "CheckBox_S_FemaleChild";
            this.CheckBox_S_FemaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_FemaleChild.TabIndex = 5;
            this.CheckBox_S_FemaleChild.Text = "Child";
            this.CheckBox_S_FemaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleSenior
            // 
            this.CheckBox_S_FemaleSenior.AutoSize = true;
            this.CheckBox_S_FemaleSenior.Location = new System.Drawing.Point(101, 134);
            this.CheckBox_S_FemaleSenior.Name = "CheckBox_S_FemaleSenior";
            this.CheckBox_S_FemaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_FemaleSenior.TabIndex = 7;
            this.CheckBox_S_FemaleSenior.Text = "Senior";
            this.CheckBox_S_FemaleSenior.UseVisualStyleBackColor = true;
            // 
            // TextBox_S_Prefix
            // 
            this.TextBox_S_Prefix.Enabled = false;
            this.TextBox_S_Prefix.Location = new System.Drawing.Point(203, 41);
            this.TextBox_S_Prefix.Name = "TextBox_S_Prefix";
            this.TextBox_S_Prefix.Size = new System.Drawing.Size(146, 20);
            this.TextBox_S_Prefix.TabIndex = 15;
            // 
            // CheckBox_S_FemaleBaby
            // 
            this.CheckBox_S_FemaleBaby.AutoSize = true;
            this.CheckBox_S_FemaleBaby.Location = new System.Drawing.Point(101, 65);
            this.CheckBox_S_FemaleBaby.Name = "CheckBox_S_FemaleBaby";
            this.CheckBox_S_FemaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleBaby.TabIndex = 4;
            this.CheckBox_S_FemaleBaby.Text = "Baby";
            this.CheckBox_S_FemaleBaby.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Infected
            // 
            this.CheckBox_S_Infected.AutoSize = true;
            this.CheckBox_S_Infected.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_S_Infected.Location = new System.Drawing.Point(6, 174);
            this.CheckBox_S_Infected.Name = "CheckBox_S_Infected";
            this.CheckBox_S_Infected.Size = new System.Drawing.Size(65, 17);
            this.CheckBox_S_Infected.TabIndex = 8;
            this.CheckBox_S_Infected.Text = "Infected";
            this.CheckBox_S_Infected.UseVisualStyleBackColor = false;
            // 
            // CheckBox_S_IndPredix
            // 
            this.CheckBox_S_IndPredix.AutoSize = true;
            this.CheckBox_S_IndPredix.Location = new System.Drawing.Point(203, 18);
            this.CheckBox_S_IndPredix.Name = "CheckBox_S_IndPredix";
            this.CheckBox_S_IndPredix.Size = new System.Drawing.Size(122, 17);
            this.CheckBox_S_IndPredix.TabIndex = 14;
            this.CheckBox_S_IndPredix.Text = "Use Individual Prefix";
            this.CheckBox_S_IndPredix.UseVisualStyleBackColor = true;
            this.CheckBox_S_IndPredix.CheckedChanged += new System.EventHandler(this.CheckBox_S_IndPredix_CheckedChanged);
            // 
            // CheckBox_S_MaleSenior
            // 
            this.CheckBox_S_MaleSenior.AutoSize = true;
            this.CheckBox_S_MaleSenior.Location = new System.Drawing.Point(6, 134);
            this.CheckBox_S_MaleSenior.Name = "CheckBox_S_MaleSenior";
            this.CheckBox_S_MaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_MaleSenior.TabIndex = 3;
            this.CheckBox_S_MaleSenior.Text = "Senior";
            this.CheckBox_S_MaleSenior.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Diseased
            // 
            this.CheckBox_S_Diseased.AutoSize = true;
            this.CheckBox_S_Diseased.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_S_Diseased.Location = new System.Drawing.Point(6, 157);
            this.CheckBox_S_Diseased.Name = "CheckBox_S_Diseased";
            this.CheckBox_S_Diseased.Size = new System.Drawing.Size(70, 17);
            this.CheckBox_S_Diseased.TabIndex = 9;
            this.CheckBox_S_Diseased.Text = "Diseased";
            this.CheckBox_S_Diseased.UseVisualStyleBackColor = false;
            // 
            // Btn_Create_S
            // 
            this.Btn_Create_S.Enabled = false;
            this.Btn_Create_S.Location = new System.Drawing.Point(255, 163);
            this.Btn_Create_S.Name = "Btn_Create_S";
            this.Btn_Create_S.Size = new System.Drawing.Size(94, 23);
            this.Btn_Create_S.TabIndex = 13;
            this.Btn_Create_S.Text = "Create!";
            this.Btn_Create_S.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleAdult
            // 
            this.CheckBox_S_MaleAdult.AutoSize = true;
            this.CheckBox_S_MaleAdult.Location = new System.Drawing.Point(6, 111);
            this.CheckBox_S_MaleAdult.Name = "CheckBox_S_MaleAdult";
            this.CheckBox_S_MaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleAdult.TabIndex = 2;
            this.CheckBox_S_MaleAdult.Text = "Adult";
            this.CheckBox_S_MaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_All
            // 
            this.CheckBox_S_All.AutoSize = true;
            this.CheckBox_S_All.Location = new System.Drawing.Point(6, 19);
            this.CheckBox_S_All.Name = "CheckBox_S_All";
            this.CheckBox_S_All.Size = new System.Drawing.Size(37, 17);
            this.CheckBox_S_All.TabIndex = 12;
            this.CheckBox_S_All.Text = "All";
            this.CheckBox_S_All.UseVisualStyleBackColor = true;
            this.CheckBox_S_All.CheckedChanged += new System.EventHandler(this.CheckBox_S_All_CheckedChanged);
            // 
            // CheckBox_S_MaleChild
            // 
            this.CheckBox_S_MaleChild.AutoSize = true;
            this.CheckBox_S_MaleChild.Location = new System.Drawing.Point(6, 88);
            this.CheckBox_S_MaleChild.Name = "CheckBox_S_MaleChild";
            this.CheckBox_S_MaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_MaleChild.TabIndex = 1;
            this.CheckBox_S_MaleChild.Text = "Child";
            this.CheckBox_S_MaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleBaby
            // 
            this.CheckBox_S_MaleBaby.AutoSize = true;
            this.CheckBox_S_MaleBaby.Location = new System.Drawing.Point(6, 65);
            this.CheckBox_S_MaleBaby.Name = "CheckBox_S_MaleBaby";
            this.CheckBox_S_MaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleBaby.TabIndex = 0;
            this.CheckBox_S_MaleBaby.Text = "Baby";
            this.CheckBox_S_MaleBaby.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Female
            // 
            this.CheckBox_S_Female.AutoSize = true;
            this.CheckBox_S_Female.Location = new System.Drawing.Point(101, 42);
            this.CheckBox_S_Female.Name = "CheckBox_S_Female";
            this.CheckBox_S_Female.Size = new System.Drawing.Size(60, 17);
            this.CheckBox_S_Female.TabIndex = 11;
            this.CheckBox_S_Female.Text = "Female";
            this.CheckBox_S_Female.UseVisualStyleBackColor = true;
            this.CheckBox_S_Female.CheckedChanged += new System.EventHandler(this.CheckBox_S_Female_CheckedChanged);
            // 
            // Page_Death
            // 
            this.Page_Death.BackColor = System.Drawing.Color.Transparent;
            this.Page_Death.Location = new System.Drawing.Point(4, 25);
            this.Page_Death.Name = "Page_Death";
            this.Page_Death.Padding = new System.Windows.Forms.Padding(3);
            this.Page_Death.Size = new System.Drawing.Size(364, 201);
            this.Page_Death.TabIndex = 1;
            this.Page_Death.Text = "Death";
            // 
            // Page_Defaults
            // 
            this.Page_Defaults.BackColor = System.Drawing.Color.Transparent;
            this.Page_Defaults.Controls.Add(this.GroupBox_Settings);
            this.Page_Defaults.Location = new System.Drawing.Point(4, 25);
            this.Page_Defaults.Name = "Page_Defaults";
            this.Page_Defaults.Padding = new System.Windows.Forms.Padding(3);
            this.Page_Defaults.Size = new System.Drawing.Size(364, 201);
            this.Page_Defaults.TabIndex = 2;
            this.Page_Defaults.Text = "Defaults";
            // 
            // TextBox_SaveTo
            // 
            this.TextBox_SaveTo.Enabled = false;
            this.TextBox_SaveTo.Location = new System.Drawing.Point(55, 82);
            this.TextBox_SaveTo.Name = "TextBox_SaveTo";
            this.TextBox_SaveTo.Size = new System.Drawing.Size(142, 20);
            this.TextBox_SaveTo.TabIndex = 6;
            this.TextBox_SaveTo.TextChanged += new System.EventHandler(this.TextBox_SaveTo_TextChanged);
            // 
            // LabelSaveTo
            // 
            this.LabelSaveTo.AutoSize = true;
            this.LabelSaveTo.Location = new System.Drawing.Point(5, 85);
            this.LabelSaveTo.Name = "LabelSaveTo";
            this.LabelSaveTo.Size = new System.Drawing.Size(44, 13);
            this.LabelSaveTo.TabIndex = 5;
            this.LabelSaveTo.Text = "Save to";
            // 
            // Btn_SaveTo_Browse
            // 
            this.Btn_SaveTo_Browse.Location = new System.Drawing.Point(203, 82);
            this.Btn_SaveTo_Browse.Name = "Btn_SaveTo_Browse";
            this.Btn_SaveTo_Browse.Size = new System.Drawing.Size(31, 20);
            this.Btn_SaveTo_Browse.TabIndex = 4;
            this.Btn_SaveTo_Browse.Text = "->";
            this.Btn_SaveTo_Browse.UseVisualStyleBackColor = true;
            this.Btn_SaveTo_Browse.Click += new System.EventHandler(this.Btn_SaveTo_Browse_Click);
            // 
            // Label_Palette
            // 
            this.Label_Palette.AutoSize = true;
            this.Label_Palette.Location = new System.Drawing.Point(5, 53);
            this.Label_Palette.Name = "Label_Palette";
            this.Label_Palette.Size = new System.Drawing.Size(40, 13);
            this.Label_Palette.TabIndex = 3;
            this.Label_Palette.Text = "Palette";
            // 
            // ComboBox_DefaultPalette
            // 
            this.ComboBox_DefaultPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_DefaultPalette.FormattingEnabled = true;
            this.ComboBox_DefaultPalette.Location = new System.Drawing.Point(55, 50);
            this.ComboBox_DefaultPalette.Name = "ComboBox_DefaultPalette";
            this.ComboBox_DefaultPalette.Size = new System.Drawing.Size(142, 21);
            this.ComboBox_DefaultPalette.TabIndex = 2;
            this.ComboBox_DefaultPalette.SelectedValueChanged += new System.EventHandler(this.ComboBox_DefaultPalette_SelectedValueChanged);
            // 
            // TextBox_DefaultPrefix
            // 
            this.TextBox_DefaultPrefix.Location = new System.Drawing.Point(55, 19);
            this.TextBox_DefaultPrefix.Name = "TextBox_DefaultPrefix";
            this.TextBox_DefaultPrefix.Size = new System.Drawing.Size(142, 20);
            this.TextBox_DefaultPrefix.TabIndex = 1;
            this.TextBox_DefaultPrefix.Text = "Map";
            this.TextBox_DefaultPrefix.TextChanged += new System.EventHandler(this.TextBox_DefaultPrefix_TextChanged);
            // 
            // Label_Prefix
            // 
            this.Label_Prefix.AutoSize = true;
            this.Label_Prefix.Location = new System.Drawing.Point(6, 22);
            this.Label_Prefix.Name = "Label_Prefix";
            this.Label_Prefix.Size = new System.Drawing.Size(33, 13);
            this.Label_Prefix.TabIndex = 0;
            this.Label_Prefix.Text = "Prefix";
            // 
            // GroupBox_TickInfo
            // 
            this.GroupBox_TickInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_TickInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_TickInfo.Controls.Add(this.Label_DeathInformation);
            this.GroupBox_TickInfo.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_TickInfo.Name = "GroupBox_TickInfo";
            this.GroupBox_TickInfo.Size = new System.Drawing.Size(314, 228);
            this.GroupBox_TickInfo.TabIndex = 0;
            this.GroupBox_TickInfo.TabStop = false;
            this.GroupBox_TickInfo.Text = "Tick Information";
            // 
            // Label_DeathInformation
            // 
            this.Label_DeathInformation.AutoSize = true;
            this.Label_DeathInformation.Location = new System.Drawing.Point(7, 22);
            this.Label_DeathInformation.Name = "Label_DeathInformation";
            this.Label_DeathInformation.Size = new System.Drawing.Size(91, 13);
            this.Label_DeathInformation.TabIndex = 0;
            this.Label_DeathInformation.Text = "Death Information";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(957, 24);
            this.Menu.TabIndex = 8;
            this.Menu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ToolStripOpen_Click);
            // 
            // FileChooser
            // 
            this.FileChooser.FileName = "FileChooser";
            this.FileChooser.Filter = "\"Simulation-Files (*.sim)|*.sim|All files (*.*)|*.*\"";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(573, 265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 385);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // GroupBox_Settings
            // 
            this.GroupBox_Settings.Controls.Add(this.Btn_ApplySettings);
            this.GroupBox_Settings.Controls.Add(this.TextBox_SaveTo);
            this.GroupBox_Settings.Controls.Add(this.Label_Prefix);
            this.GroupBox_Settings.Controls.Add(this.TextBox_DefaultPrefix);
            this.GroupBox_Settings.Controls.Add(this.LabelSaveTo);
            this.GroupBox_Settings.Controls.Add(this.ComboBox_DefaultPalette);
            this.GroupBox_Settings.Controls.Add(this.Label_Palette);
            this.GroupBox_Settings.Controls.Add(this.Btn_SaveTo_Browse);
            this.GroupBox_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Settings.Location = new System.Drawing.Point(3, 3);
            this.GroupBox_Settings.Name = "GroupBox_Settings";
            this.GroupBox_Settings.Size = new System.Drawing.Size(358, 195);
            this.GroupBox_Settings.TabIndex = 0;
            this.GroupBox_Settings.TabStop = false;
            this.GroupBox_Settings.Text = "Settings";
            // 
            // Btn_ApplySettings
            // 
            this.Btn_ApplySettings.Enabled = false;
            this.Btn_ApplySettings.Location = new System.Drawing.Point(277, 166);
            this.Btn_ApplySettings.Name = "Btn_ApplySettings";
            this.Btn_ApplySettings.Size = new System.Drawing.Size(75, 23);
            this.Btn_ApplySettings.TabIndex = 7;
            this.Btn_ApplySettings.Text = "Apply";
            this.Btn_ApplySettings.UseVisualStyleBackColor = true;
            this.Btn_ApplySettings.Click += new System.EventHandler(this.Btn_ApplySettings_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 662);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Panel_Tick);
            this.Controls.Add(this.Panel_leftside);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReviewForm";
            this.GroupBox_Disease.ResumeLayout(false);
            this.GroupBox_Disease.PerformLayout();
            this.GroupBox_TickSelections.ResumeLayout(false);
            this.Panel_leftside.ResumeLayout(false);
            this.Panel_Tick.ResumeLayout(false);
            this.Panel_fieldSelectionContainer.ResumeLayout(false);
            this.TabControl_MapCreator.ResumeLayout(false);
            this.Page_Standard.ResumeLayout(false);
            this.GroupBox_S_Create.ResumeLayout(false);
            this.GroupBox_S_Create.PerformLayout();
            this.Page_Defaults.ResumeLayout(false);
            this.GroupBox_TickInfo.ResumeLayout(false);
            this.GroupBox_TickInfo.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBox_Settings.ResumeLayout(false);
            this.GroupBox_Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_DiseaseName;
        private System.Windows.Forms.ComboBox ComboBox_Entries;
        private System.Windows.Forms.Button Btn_LoadTick;
        private System.Windows.Forms.GroupBox GroupBox_Disease;
        private System.Windows.Forms.GroupBox GroupBox_TickSelections;
        private System.Windows.Forms.Panel Panel_leftside;
        private System.Windows.Forms.Panel Panel_Tick;
        private System.Windows.Forms.GroupBox GroupBox_TickInfo;
        private System.Windows.Forms.TabControl TabControl_MapCreator;
        private System.Windows.Forms.TabPage Page_Standard;
        private System.Windows.Forms.TabPage Page_Death;
        private System.Windows.Forms.CheckBox CheckBox_S_Diseased;
        private System.Windows.Forms.CheckBox CheckBox_S_Infected;
        private System.Windows.Forms.CheckBox CheckBox_S_FemaleSenior;
        private System.Windows.Forms.CheckBox CheckBox_S_FemaleAdult;
        private System.Windows.Forms.CheckBox CheckBox_S_FemaleChild;
        private System.Windows.Forms.CheckBox CheckBox_S_FemaleBaby;
        private System.Windows.Forms.CheckBox CheckBox_S_MaleSenior;
        private System.Windows.Forms.CheckBox CheckBox_S_MaleAdult;
        private System.Windows.Forms.CheckBox CheckBox_S_MaleChild;
        private System.Windows.Forms.CheckBox CheckBox_S_MaleBaby;
        private System.Windows.Forms.CheckBox CheckBox_S_Female;
        private System.Windows.Forms.CheckBox CheckBox_S_Male;
        private System.Windows.Forms.CheckBox CheckBox_S_All;
        private System.Windows.Forms.Button Btn_Create_S;
        private System.Windows.Forms.CheckBox CheckBox_S_IndPredix;
        private System.Windows.Forms.TextBox TextBox_S_Prefix;
        private System.Windows.Forms.Panel Panel_fieldSelectionContainer;
        private System.Windows.Forms.TabPage Page_Defaults;
        private System.Windows.Forms.TextBox TextBox_DefaultPrefix;
        private System.Windows.Forms.Label Label_Prefix;
        private System.Windows.Forms.ComboBox ComboBox_DefaultPalette;
        private System.Windows.Forms.Label Label_Palette;
        private System.Windows.Forms.ComboBox ComboBox_S_IndPalette;
        private System.Windows.Forms.CheckBox CheckBox_S_IndPalette;
        private System.Windows.Forms.Button Btn_SaveTo_Browse;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label LabelSaveTo;
        private System.Windows.Forms.TextBox TextBox_SaveTo;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileChooser;
        private System.Windows.Forms.Label Label_DeathInformation;
        private System.Windows.Forms.Label Incubation;
        private System.Windows.Forms.Label Idle;
        private System.Windows.Forms.Label Transferability;
        private System.Windows.Forms.Label Spreading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox GroupBox_S_Create;
        private System.Windows.Forms.Label Label_Incubation;
        private System.Windows.Forms.Label Label_Transfer;
        private System.Windows.Forms.Label Label_Spreading;
        private System.Windows.Forms.Label Label_Idle;
        private System.Windows.Forms.GroupBox GroupBox_Settings;
        private System.Windows.Forms.Button Btn_ApplySettings;
    }
}