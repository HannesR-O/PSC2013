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
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel_Tick = new System.Windows.Forms.Panel();
            this.GroupBox_TickInfo = new System.Windows.Forms.GroupBox();
            this.TabControl_MapCreator = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CheckBox_S_MaleBaby = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_MaleSenior = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleBaby = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleChild = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleAdult = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_FemaleSenior = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Infected = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Diseased = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Male = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_Female = new System.Windows.Forms.CheckBox();
            this.CheckBox_S_All = new System.Windows.Forms.CheckBox();
            this.Btn_Create_S = new System.Windows.Forms.Button();
            this.GroupBox_Disease.SuspendLayout();
            this.GroupBox_TickSelections.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_Tick.SuspendLayout();
            this.TabControl_MapCreator.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.GroupBox_Disease.Location = new System.Drawing.Point(9, 0);
            this.GroupBox_Disease.Name = "GroupBox_Disease";
            this.GroupBox_Disease.Size = new System.Drawing.Size(237, 329);
            this.GroupBox_Disease.TabIndex = 4;
            this.GroupBox_Disease.TabStop = false;
            this.GroupBox_Disease.Text = "Disease";
            // 
            // GroupBox_TickSelections
            // 
            this.GroupBox_TickSelections.Controls.Add(this.ComboBox_Entries);
            this.GroupBox_TickSelections.Controls.Add(this.Btn_LoadTick);
            this.GroupBox_TickSelections.Location = new System.Drawing.Point(9, 336);
            this.GroupBox_TickSelections.Name = "GroupBox_TickSelections";
            this.GroupBox_TickSelections.Size = new System.Drawing.Size(237, 281);
            this.GroupBox_TickSelections.TabIndex = 5;
            this.GroupBox_TickSelections.TabStop = false;
            this.GroupBox_TickSelections.Text = "Tick Selections";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GroupBox_Disease);
            this.panel1.Controls.Add(this.GroupBox_TickSelections);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 629);
            this.panel1.TabIndex = 6;
            // 
            // Panel_Tick
            // 
            this.Panel_Tick.Controls.Add(this.TabControl_MapCreator);
            this.Panel_Tick.Controls.Add(this.GroupBox_TickInfo);
            this.Panel_Tick.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Tick.Location = new System.Drawing.Point(255, 0);
            this.Panel_Tick.Name = "Panel_Tick";
            this.Panel_Tick.Size = new System.Drawing.Size(880, 216);
            this.Panel_Tick.TabIndex = 7;
            // 
            // GroupBox_TickInfo
            // 
            this.GroupBox_TickInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_TickInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox_TickInfo.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_TickInfo.Name = "GroupBox_TickInfo";
            this.GroupBox_TickInfo.Size = new System.Drawing.Size(504, 216);
            this.GroupBox_TickInfo.TabIndex = 0;
            this.GroupBox_TickInfo.TabStop = false;
            this.GroupBox_TickInfo.Text = "Tick Information";
            // 
            // TabControl_MapCreator
            // 
            this.TabControl_MapCreator.Controls.Add(this.tabPage1);
            this.TabControl_MapCreator.Controls.Add(this.tabPage2);
            this.TabControl_MapCreator.Dock = System.Windows.Forms.DockStyle.Right;
            this.TabControl_MapCreator.Location = new System.Drawing.Point(510, 0);
            this.TabControl_MapCreator.Name = "TabControl_MapCreator";
            this.TabControl_MapCreator.SelectedIndex = 0;
            this.TabControl_MapCreator.Size = new System.Drawing.Size(370, 216);
            this.TabControl_MapCreator.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Btn_Create_S);
            this.tabPage1.Controls.Add(this.CheckBox_S_All);
            this.tabPage1.Controls.Add(this.CheckBox_S_Female);
            this.tabPage1.Controls.Add(this.CheckBox_S_Male);
            this.tabPage1.Controls.Add(this.CheckBox_S_Diseased);
            this.tabPage1.Controls.Add(this.CheckBox_S_Infected);
            this.tabPage1.Controls.Add(this.CheckBox_S_FemaleSenior);
            this.tabPage1.Controls.Add(this.CheckBox_S_FemaleAdult);
            this.tabPage1.Controls.Add(this.CheckBox_S_FemaleChild);
            this.tabPage1.Controls.Add(this.CheckBox_S_FemaleBaby);
            this.tabPage1.Controls.Add(this.CheckBox_S_MaleSenior);
            this.tabPage1.Controls.Add(this.CheckBox_S_MaleAdult);
            this.tabPage1.Controls.Add(this.CheckBox_S_MaleChild);
            this.tabPage1.Controls.Add(this.CheckBox_S_MaleBaby);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(362, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Standard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(362, 159);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Death";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleBaby
            // 
            this.CheckBox_S_MaleBaby.AutoSize = true;
            this.CheckBox_S_MaleBaby.Location = new System.Drawing.Point(6, 50);
            this.CheckBox_S_MaleBaby.Name = "CheckBox_S_MaleBaby";
            this.CheckBox_S_MaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleBaby.TabIndex = 0;
            this.CheckBox_S_MaleBaby.Text = "Baby";
            this.CheckBox_S_MaleBaby.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleChild
            // 
            this.CheckBox_S_MaleChild.AutoSize = true;
            this.CheckBox_S_MaleChild.Location = new System.Drawing.Point(6, 73);
            this.CheckBox_S_MaleChild.Name = "CheckBox_S_MaleChild";
            this.CheckBox_S_MaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_MaleChild.TabIndex = 1;
            this.CheckBox_S_MaleChild.Text = "Child";
            this.CheckBox_S_MaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleAdult
            // 
            this.CheckBox_S_MaleAdult.AutoSize = true;
            this.CheckBox_S_MaleAdult.Location = new System.Drawing.Point(6, 96);
            this.CheckBox_S_MaleAdult.Name = "CheckBox_S_MaleAdult";
            this.CheckBox_S_MaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_MaleAdult.TabIndex = 2;
            this.CheckBox_S_MaleAdult.Text = "Adult";
            this.CheckBox_S_MaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_MaleSenior
            // 
            this.CheckBox_S_MaleSenior.AutoSize = true;
            this.CheckBox_S_MaleSenior.Location = new System.Drawing.Point(6, 119);
            this.CheckBox_S_MaleSenior.Name = "CheckBox_S_MaleSenior";
            this.CheckBox_S_MaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_MaleSenior.TabIndex = 3;
            this.CheckBox_S_MaleSenior.Text = "Senior";
            this.CheckBox_S_MaleSenior.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleBaby
            // 
            this.CheckBox_S_FemaleBaby.AutoSize = true;
            this.CheckBox_S_FemaleBaby.Location = new System.Drawing.Point(101, 50);
            this.CheckBox_S_FemaleBaby.Name = "CheckBox_S_FemaleBaby";
            this.CheckBox_S_FemaleBaby.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleBaby.TabIndex = 4;
            this.CheckBox_S_FemaleBaby.Text = "Baby";
            this.CheckBox_S_FemaleBaby.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleChild
            // 
            this.CheckBox_S_FemaleChild.AutoSize = true;
            this.CheckBox_S_FemaleChild.Location = new System.Drawing.Point(101, 73);
            this.CheckBox_S_FemaleChild.Name = "CheckBox_S_FemaleChild";
            this.CheckBox_S_FemaleChild.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_FemaleChild.TabIndex = 5;
            this.CheckBox_S_FemaleChild.Text = "Child";
            this.CheckBox_S_FemaleChild.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleAdult
            // 
            this.CheckBox_S_FemaleAdult.AutoSize = true;
            this.CheckBox_S_FemaleAdult.Location = new System.Drawing.Point(101, 96);
            this.CheckBox_S_FemaleAdult.Name = "CheckBox_S_FemaleAdult";
            this.CheckBox_S_FemaleAdult.Size = new System.Drawing.Size(50, 17);
            this.CheckBox_S_FemaleAdult.TabIndex = 6;
            this.CheckBox_S_FemaleAdult.Text = "Adult";
            this.CheckBox_S_FemaleAdult.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_FemaleSenior
            // 
            this.CheckBox_S_FemaleSenior.AutoSize = true;
            this.CheckBox_S_FemaleSenior.Location = new System.Drawing.Point(101, 119);
            this.CheckBox_S_FemaleSenior.Name = "CheckBox_S_FemaleSenior";
            this.CheckBox_S_FemaleSenior.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_S_FemaleSenior.TabIndex = 7;
            this.CheckBox_S_FemaleSenior.Text = "Senior";
            this.CheckBox_S_FemaleSenior.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Infected
            // 
            this.CheckBox_S_Infected.AutoSize = true;
            this.CheckBox_S_Infected.Location = new System.Drawing.Point(6, 142);
            this.CheckBox_S_Infected.Name = "CheckBox_S_Infected";
            this.CheckBox_S_Infected.Size = new System.Drawing.Size(65, 17);
            this.CheckBox_S_Infected.TabIndex = 8;
            this.CheckBox_S_Infected.Text = "Infected";
            this.CheckBox_S_Infected.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Diseased
            // 
            this.CheckBox_S_Diseased.AutoSize = true;
            this.CheckBox_S_Diseased.Location = new System.Drawing.Point(6, 160);
            this.CheckBox_S_Diseased.Name = "CheckBox_S_Diseased";
            this.CheckBox_S_Diseased.Size = new System.Drawing.Size(70, 17);
            this.CheckBox_S_Diseased.TabIndex = 9;
            this.CheckBox_S_Diseased.Text = "Diseased";
            this.CheckBox_S_Diseased.UseVisualStyleBackColor = true;
            // 
            // CheckBox_S_Male
            // 
            this.CheckBox_S_Male.AutoSize = true;
            this.CheckBox_S_Male.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_S_Male.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CheckBox_S_Male.Location = new System.Drawing.Point(6, 27);
            this.CheckBox_S_Male.Name = "CheckBox_S_Male";
            this.CheckBox_S_Male.Size = new System.Drawing.Size(49, 17);
            this.CheckBox_S_Male.TabIndex = 10;
            this.CheckBox_S_Male.Text = "Male";
            this.CheckBox_S_Male.UseVisualStyleBackColor = true;
            this.CheckBox_S_Male.CheckedChanged += new System.EventHandler(this.CheckBox_S_Male_CheckedChanged);
            // 
            // CheckBox_S_Female
            // 
            this.CheckBox_S_Female.AutoSize = true;
            this.CheckBox_S_Female.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CheckBox_S_Female.Location = new System.Drawing.Point(101, 27);
            this.CheckBox_S_Female.Name = "CheckBox_S_Female";
            this.CheckBox_S_Female.Size = new System.Drawing.Size(60, 17);
            this.CheckBox_S_Female.TabIndex = 11;
            this.CheckBox_S_Female.Text = "Female";
            this.CheckBox_S_Female.UseVisualStyleBackColor = true;
            this.CheckBox_S_Female.CheckedChanged += new System.EventHandler(this.CheckBox_S_Female_CheckedChanged);
            // 
            // CheckBox_S_All
            // 
            this.CheckBox_S_All.AutoSize = true;
            this.CheckBox_S_All.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CheckBox_S_All.Location = new System.Drawing.Point(6, 4);
            this.CheckBox_S_All.Name = "CheckBox_S_All";
            this.CheckBox_S_All.Size = new System.Drawing.Size(37, 17);
            this.CheckBox_S_All.TabIndex = 12;
            this.CheckBox_S_All.Text = "All";
            this.CheckBox_S_All.UseVisualStyleBackColor = true;
            this.CheckBox_S_All.CheckedChanged += new System.EventHandler(this.CheckBox_S_All_CheckedChanged);
            // 
            // Btn_Create_S
            // 
            this.Btn_Create_S.Location = new System.Drawing.Point(262, 161);
            this.Btn_Create_S.Name = "Btn_Create_S";
            this.Btn_Create_S.Size = new System.Drawing.Size(94, 23);
            this.Btn_Create_S.TabIndex = 13;
            this.Btn_Create_S.Text = "Create!";
            this.Btn_Create_S.UseVisualStyleBackColor = true;
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 629);
            this.Controls.Add(this.Panel_Tick);
            this.Controls.Add(this.panel1);
            this.Name = "ReviewForm";
            this.Text = "ReviewForm";
            this.GroupBox_Disease.ResumeLayout(false);
            this.GroupBox_Disease.PerformLayout();
            this.GroupBox_TickSelections.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Panel_Tick.ResumeLayout(false);
            this.TabControl_MapCreator.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_DiseaseName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox ComboBox_Entries;
        private System.Windows.Forms.Button Btn_LoadTick;
        private System.Windows.Forms.GroupBox GroupBox_Disease;
        private System.Windows.Forms.GroupBox GroupBox_TickSelections;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel Panel_Tick;
        private System.Windows.Forms.GroupBox GroupBox_TickInfo;
        private System.Windows.Forms.TabControl TabControl_MapCreator;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}