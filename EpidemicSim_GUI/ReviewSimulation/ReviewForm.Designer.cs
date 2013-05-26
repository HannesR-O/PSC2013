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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ComboBox_Entries = new System.Windows.Forms.ComboBox();
            this.Btn_LoadTick = new System.Windows.Forms.Button();
            this.Label_DiseaseName = new System.Windows.Forms.Label();
            this.GroupBox_Disease = new System.Windows.Forms.GroupBox();
            this.GroupBox_TickSelections = new System.Windows.Forms.GroupBox();
            this.Panel_leftside = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel_Tick = new System.Windows.Forms.Panel();
            this.TabControl_MapCreator = new System.Windows.Forms.TabControl();
            this.Page_Standard = new System.Windows.Forms.TabPage();
            this.TextBox_S_Prefix = new System.Windows.Forms.TextBox();
            this.CheckBox_S_IndPredix = new System.Windows.Forms.CheckBox();
            this.Btn_Create_S = new System.Windows.Forms.Button();
            this.CheckBox_S_All = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Female = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Male = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Diseased = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Infected = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleSenior = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleBaby = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleSenior = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleBaby = new System.Windows.Forms.CheckBox();
            this.Page_Death = new System.Windows.Forms.TabPage();
            this.GroupBox_TickInfo = new System.Windows.Forms.GroupBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.Panel_fieldSelectionContainer = new System.Windows.Forms.Panel();
            this.GroupBox_Disease.SuspendLayout();
            this.GroupBox_TickSelections.SuspendLayout();
            this.Panel_leftside.SuspendLayout();
            this.Panel_Tick.SuspendLayout();
            this.TabControl_MapCreator.SuspendLayout();
            this.Page_Standard.SuspendLayout();
            this.Panel_fieldSelectionContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ComboBox_Entries
            // 
            this.ComboBox_Entries.FormattingEnabled = true;
            this.ComboBox_Entries.Location = new System.Drawing.Point(10, 35);
            this.ComboBox_Entries.Name = "ComboBox_Entries";
            this.ComboBox_Entries.Size = new System.Drawing.Size(208, 21);
            this.ComboBox_Entries.TabIndex = 1;
            // 
            // Btn_LoadTick
            // 
            this.Btn_LoadTick.Location = new System.Drawing.Point(143, 62);
            this.Btn_LoadTick.Name = "Btn_LoadTick";
            this.Btn_LoadTick.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadTick.TabIndex = 2;
            this.Btn_LoadTick.Text = "Load";
            this.Btn_LoadTick.UseVisualStyleBackColor = true;
            // 
            // Label_DiseaseName
            // 
            this.Label_DiseaseName.AutoSize = true;
            this.Label_DiseaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DiseaseName.Location = new System.Drawing.Point(6, 16);
            this.Label_DiseaseName.Name = "Label_DiseaseName";
            this.Label_DiseaseName.Size = new System.Drawing.Size(113, 20);
            this.Label_DiseaseName.TabIndex = 0;
            this.Label_DiseaseName.Text = "Disease Name";
            // 
            // GroupBox_Disease
            // 
            this.GroupBox_Disease.Controls.Add(this.Label_DiseaseName);
            this.GroupBox_Disease.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox_Disease.Location = new System.Drawing.Point(10, 0);
            this.GroupBox_Disease.Name = "GroupBox_Disease";
            this.GroupBox_Disease.Size = new System.Drawing.Size(235, 329);
            this.GroupBox_Disease.TabIndex = 4;
            this.GroupBox_Disease.TabStop = false;
            this.GroupBox_Disease.Text = "Disease";
            // 
            // GroupBox_TickSelections
            // 
            this.GroupBox_TickSelections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox_TickSelections.Controls.Add(this.ComboBox_Entries);
            this.GroupBox_TickSelections.Controls.Add(this.Btn_LoadTick);
            this.GroupBox_TickSelections.Location = new System.Drawing.Point(10, 335);
            this.GroupBox_TickSelections.Name = "GroupBox_TickSelections";
            this.GroupBox_TickSelections.Size = new System.Drawing.Size(235, 321);
            this.GroupBox_TickSelections.TabIndex = 5;
            this.GroupBox_TickSelections.TabStop = false;
            this.GroupBox_TickSelections.Text = "Tick Selections";
            // 
            // Panel_leftside
            // 
            this.Panel_leftside.Controls.Add(this.GroupBox_Disease);
            this.Panel_leftside.Controls.Add(this.GroupBox_TickSelections);
            this.Panel_leftside.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_leftside.Location = new System.Drawing.Point(0, 0);
            this.Panel_leftside.Name = "Panel_leftside";
            this.Panel_leftside.Padding = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.Panel_leftside.Size = new System.Drawing.Size(255, 662);
            this.Panel_leftside.TabIndex = 6;
            // 
            // Panel_Tick
            // 
            this.Panel_Tick.Controls.Add(this.Panel_fieldSelectionContainer);
            this.Panel_Tick.Controls.Add(this.GroupBox_TickInfo);
            this.Panel_Tick.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Tick.Location = new System.Drawing.Point(255, 0);
            this.Panel_Tick.Name = "Panel_Tick";
            this.Panel_Tick.Size = new System.Drawing.Size(679, 216);
            this.Panel_Tick.TabIndex = 7;
            // 
            // TabControl_MapCreator
            // 
            this.TabControl_MapCreator.Controls.Add(this.Page_Standard);
            this.TabControl_MapCreator.Controls.Add(this.Page_Death);
            this.TabControl_MapCreator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_MapCreator.Location = new System.Drawing.Point(5, 5);
            this.TabControl_MapCreator.Name = "TabControl_MapCreator";
            this.TabControl_MapCreator.SelectedIndex = 0;
            this.TabControl_MapCreator.Size = new System.Drawing.Size(360, 211);
            this.TabControl_MapCreator.TabIndex = 1;
            // 
            // Page_Standard
            // 
            this.Page_Standard.BackColor = System.Drawing.Color.Transparent;
            this.Page_Standard.Controls.Add(this.TextBox_S_Prefix);
            this.Page_Standard.Controls.Add(this.CheckBox_S_IndPredix);
            this.Page_Standard.Controls.Add(this.Btn_Create_S);
            this.Page_Standard.Controls.Add(this.CheckBox_S_All);
            this.Page_Standard.Controls.Add(this.CheckBox_S_Female);
            this.Page_Standard.Controls.Add(this.CheckBox_S_Male);
            this.Page_Standard.Controls.Add(this.CheckBox_S_Diseased);
            this.Page_Standard.Controls.Add(this.CheckBox_S_Infected);
            this.Page_Standard.Controls.Add(this.CheckBox_S_FemaleSenior);
            this.Page_Standard.Controls.Add(this.CheckBox_S_FemaleAdult);
            this.Page_Standard.Controls.Add(this.CheckBox_S_FemaleChild);
            this.Page_Standard.Controls.Add(this.CheckBox_S_FemaleBaby);
            this.Page_Standard.Controls.Add(this.CheckBox_S_MaleSenior);
            this.Page_Standard.Controls.Add(this.CheckBox_S_MaleAdult);
            this.Page_Standard.Controls.Add(this.CheckBox_S_MaleChild);
            this.Page_Standard.Controls.Add(this.CheckBox_S_MaleBaby);
            this.Page_Standard.Location = new System.Drawing.Point(4, 22);
            this.Page_Standard.Name = "Page_Standard";
            this.Page_Standard.Padding = new System.Windows.Forms.Padding(3);
            this.Page_Standard.Size = new System.Drawing.Size(352, 185);
            this.Page_Standard.TabIndex = 0;
            this.Page_Standard.Text = "Standard";
            // 
            // TextBox_S_Prefix
            // 
            this.TextBox_S_Prefix.Enabled = false;
            this.TextBox_S_Prefix.Location = new System.Drawing.Point(202, 130);
            this.TextBox_S_Prefix.Name = "TextBox_S_Prefix";
            this.TextBox_S_Prefix.Size = new System.Drawing.Size(146, 20);
            this.TextBox_S_Prefix.TabIndex = 15;
            // 
            // CheckBox_S_IndPredix
            // 
            this.CheckBox_S_IndPredix.AutoSize = true;
            this.CheckBox_S_IndPredix.Location = new System.Drawing.Point(202, 107);
            this.CheckBox_S_IndPredix.Name = "CheckBox_S_IndPredix";
            this.CheckBox_S_IndPredix.Size = new System.Drawing.Size(122, 17);
            this.CheckBox_S_IndPredix.TabIndex = 14;
            this.CheckBox_S_IndPredix.Text = "Use Individual Prefix";
            this.CheckBox_S_IndPredix.UseVisualStyleBackColor = true;
            this.CheckBox_S_IndPredix.CheckedChanged += new System.EventHandler(this.CheckBox_S_IndPredix_CheckedChanged);
            // 
            // Btn_Create_S
            // 
            this.Btn_Create_S.Location = new System.Drawing.Point(254, 156);
            this.Btn_Create_S.Name = "Btn_Create_S";
            this.Btn_Create_S.Size = new System.Drawing.Size(94, 23);
            this.Btn_Create_S.TabIndex = 13;
            this.Btn_Create_S.Text = "Create!";
            this.Btn_Create_S.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_All
            // 
            this.CheckBox_S_All.AutoSize = true;
            this.CheckBox_S_All.Location = new System.Drawing.Point(6, 4);
            this.CheckBox_S_All.Name = "CheckBox_S_All";
            this.CheckBox_S_All.Size = new System.Drawing.Size(37, 17);
            this.CheckBox_S_All.TabIndex = 12;
            this.CheckBox_S_All.Text = "All";
            this.CheckBox_S_All.UseVisualStyleBackColor = true;
            this.CheckBox_S_All.CheckedChanged += new System.EventHandler(this.CheckBox_S_All_CheckedChanged);
            // 
            // CheckBox_S_Female
            // 
            this.CheckBox_S_Female.AutoSize = true;
            this.CheckBox_S_Female.Location = new System.Drawing.Point(101, 31);
            this.CheckBox_S_Female.Name = "CheckBox_S_Female";
            this.CheckBox_S_Female.Size = new System.Drawing.Size(60, 17);
            this.CheckBox_S_Female.TabIndex = 11;
            this.CheckBox_S_Female.Text = "Female";
            this.CheckBox_S_Female.UseVisualStyleBackColor = true;
            this.CheckBox_S_Female.CheckedChanged += new System.EventHandler(this.CheckBox_S_Female_CheckedChanged);
            // 
            // CheckBox_S_Male
            // 
            this.CheckBox_S_Male.AutoSize = true;
            this.CheckBox_S_Male.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_S_Male.Location = new System.Drawing.Point(6, 31);
            this.CheckBox_S_Male.Name = "CheckBox_S_Male";
            this.CheckBox_S_Male.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_Male.TabIndex = 10;
            this.CheckBox_S_Male.Text = "Male";
            this.CheckBox_S_Male.UseVisualStyleBackColor = true;
            this.CheckBox_S_Male.CheckedChanged += new System.EventHandler(this.CheckBox_S_Male_CheckedChanged);
            // 
            // CheckBox_S_Diseased
            // 
            this.CheckBox_S_Diseased.AutoSize = true;
            this.CheckBox_S_Diseased.Location = new System.Drawing.Point(101, 4);
            this.CheckBox_S_Diseased.Name = "CheckBox_S_Diseased";
            this.CheckBox_S_Diseased.Size = new System.Drawing.Size(70, 17);
            this.CheckBox_S_Diseased.TabIndex = 9;
            this.CheckBox_S_Diseased.Text = "Diseased";
            this.CheckBox_S_Diseased.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Infected
            // 
            this.CheckBox_S_Infected.AutoSize = true;
            this.CheckBox_S_Infected.Location = new System.Drawing.Point(193, 4);
            this.CheckBox_S_Infected.Name = "CheckBox_S_Infected";
            this.CheckBox_S_Infected.Size = new System.Drawing.Size(65, 17);
            this.CheckBox_S_Infected.TabIndex = 8;
            this.CheckBox_S_Infected.Text = "Infected";
            this.CheckBox_S_Infected.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleSenior
            // 
            this.CheckBox_S_FemaleSenior.AutoSize = true;
            this.CheckBox_S_FemaleSenior.Location = new System.Drawing.Point(101, 132);
            this.CheckBox_S_FemaleSenior.Name = "CheckBox_S_FemaleSenior";
            this.CheckBox_S_FemaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_FemaleSenior.TabIndex = 7;
            this.CheckBox_S_FemaleSenior.Text = "Senior";
            this.CheckBox_S_FemaleSenior.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleAdult
            // 
            this.CheckBox_S_FemaleAdult.AutoSize = true;
            this.CheckBox_S_FemaleAdult.Location = new System.Drawing.Point(101, 109);
            this.CheckBox_S_FemaleAdult.Name = "CheckBox_S_FemaleAdult";
            this.CheckBox_S_FemaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleAdult.TabIndex = 6;
            this.CheckBox_S_FemaleAdult.Text = "Adult";
            this.CheckBox_S_FemaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleChild
            // 
            this.CheckBox_S_FemaleChild.AutoSize = true;
            this.CheckBox_S_FemaleChild.Location = new System.Drawing.Point(101, 86);
            this.CheckBox_S_FemaleChild.Name = "CheckBox_S_FemaleChild";
            this.CheckBox_S_FemaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_FemaleChild.TabIndex = 5;
            this.CheckBox_S_FemaleChild.Text = "Child";
            this.CheckBox_S_FemaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleBaby
            // 
            this.CheckBox_S_FemaleBaby.AutoSize = true;
            this.CheckBox_S_FemaleBaby.Location = new System.Drawing.Point(101, 63);
            this.CheckBox_S_FemaleBaby.Name = "CheckBox_S_FemaleBaby";
            this.CheckBox_S_FemaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleBaby.TabIndex = 4;
            this.CheckBox_S_FemaleBaby.Text = "Baby";
            this.CheckBox_S_FemaleBaby.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleSenior
            // 
            this.CheckBox_S_MaleSenior.AutoSize = true;
            this.CheckBox_S_MaleSenior.Location = new System.Drawing.Point(6, 132);
            this.CheckBox_S_MaleSenior.Name = "CheckBox_S_MaleSenior";
            this.CheckBox_S_MaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_MaleSenior.TabIndex = 3;
            this.CheckBox_S_MaleSenior.Text = "Senior";
            this.CheckBox_S_MaleSenior.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleAdult
            // 
            this.CheckBox_S_MaleAdult.AutoSize = true;
            this.CheckBox_S_MaleAdult.Location = new System.Drawing.Point(6, 109);
            this.CheckBox_S_MaleAdult.Name = "CheckBox_S_MaleAdult";
            this.CheckBox_S_MaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleAdult.TabIndex = 2;
            this.CheckBox_S_MaleAdult.Text = "Adult";
            this.CheckBox_S_MaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleChild
            // 
            this.CheckBox_S_MaleChild.AutoSize = true;
            this.CheckBox_S_MaleChild.Location = new System.Drawing.Point(6, 86);
            this.CheckBox_S_MaleChild.Name = "CheckBox_S_MaleChild";
            this.CheckBox_S_MaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_MaleChild.TabIndex = 1;
            this.CheckBox_S_MaleChild.Text = "Child";
            this.CheckBox_S_MaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleBaby
            // 
            this.CheckBox_S_MaleBaby.AutoSize = true;
            this.CheckBox_S_MaleBaby.Location = new System.Drawing.Point(6, 63);
            this.CheckBox_S_MaleBaby.Name = "CheckBox_S_MaleBaby";
            this.CheckBox_S_MaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleBaby.TabIndex = 0;
            this.CheckBox_S_MaleBaby.Text = "Baby";
            this.CheckBox_S_MaleBaby.UseVisualStyleBackColor = true;
            // 
            // Page_Death
            // 
            this.Page_Death.Location = new System.Drawing.Point(4, 22);
            this.Page_Death.Name = "Page_Death";
            this.Page_Death.Padding = new System.Windows.Forms.Padding(3);
            this.Page_Death.Size = new System.Drawing.Size(362, 190);
            this.Page_Death.TabIndex = 1;
            this.Page_Death.Text = "Death";
            this.Page_Death.UseVisualStyleBackColor = true;
            // 
            // GroupBox_TickInfo
            // 
            this.GroupBox_TickInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_TickInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_TickInfo.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_TickInfo.Name = "GroupBox_TickInfo";
            this.GroupBox_TickInfo.Size = new System.Drawing.Size(306, 216);
            this.GroupBox_TickInfo.TabIndex = 0;
            this.GroupBox_TickInfo.TabStop = false;
            this.GroupBox_TickInfo.Text = "Tick Information";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // Panel_fieldSelectionContainer
            // 
            this.Panel_fieldSelectionContainer.Controls.Add(this.TabControl_MapCreator);
            this.Panel_fieldSelectionContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_fieldSelectionContainer.Location = new System.Drawing.Point(309, 0);
            this.Panel_fieldSelectionContainer.Name = "Panel_fieldSelectionContainer";
            this.Panel_fieldSelectionContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Panel_fieldSelectionContainer.Size = new System.Drawing.Size(370, 216);
            this.Panel_fieldSelectionContainer.TabIndex = 8;
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 662);
            this.Controls.Add(this.Panel_Tick);
            this.Controls.Add(this.Panel_leftside);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReviewForm";
            this.GroupBox_Disease.ResumeLayout(false);
            this.GroupBox_Disease.PerformLayout();
            this.GroupBox_TickSelections.ResumeLayout(false);
            this.Panel_leftside.ResumeLayout(false);
            this.Panel_Tick.ResumeLayout(false);
            this.TabControl_MapCreator.ResumeLayout(false);
            this.Page_Standard.ResumeLayout(false);
            this.Page_Standard.PerformLayout();
            this.Panel_fieldSelectionContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_DiseaseName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox ComboBox_Entries;
        private System.Windows.Forms.Button Btn_LoadTick;
        private System.Windows.Forms.GroupBox GroupBox_Disease;
        private System.Windows.Forms.GroupBox GroupBox_TickSelections;
        private System.Windows.Forms.Panel Panel_leftside;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
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
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox TextBox_S_Prefix;
        private System.Windows.Forms.Panel Panel_fieldSelectionContainer;
    }
}