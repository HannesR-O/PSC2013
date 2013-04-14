namespace PSC2013.ES.InputDataParsers.UI
{
    partial class MainFrm
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
            this.tControl = new System.Windows.Forms.TabControl();
            this.tPagePopulation = new System.Windows.Forms.TabPage();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lBoxCities = new System.Windows.Forms.ListBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.txBoxPopulationFile = new System.Windows.Forms.TextBox();
            this.tPageCoordinates = new System.Windows.Forms.TabPage();
            this.btnParseCoord = new System.Windows.Forms.Button();
            this.lBoxDepartments = new System.Windows.Forms.ListBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.txBoxImage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseText = new System.Windows.Forms.Button();
            this.txBoxTextfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tPageMatch = new System.Windows.Forms.TabPage();
            this.btnParseMatch = new System.Windows.Forms.Button();
            this.fileDlg = new System.Windows.Forms.OpenFileDialog();
            this.txBoxMatchResults = new System.Windows.Forms.TextBox();
            this.tControl.SuspendLayout();
            this.tPagePopulation.SuspendLayout();
            this.tPageCoordinates.SuspendLayout();
            this.tPageMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tControl
            // 
            this.tControl.Controls.Add(this.tPagePopulation);
            this.tControl.Controls.Add(this.tPageCoordinates);
            this.tControl.Controls.Add(this.tPageMatch);
            this.tControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tControl.Location = new System.Drawing.Point(0, 0);
            this.tControl.Name = "tControl";
            this.tControl.SelectedIndex = 0;
            this.tControl.Size = new System.Drawing.Size(684, 411);
            this.tControl.TabIndex = 0;
            // 
            // tPagePopulation
            // 
            this.tPagePopulation.Controls.Add(this.btnBrowse);
            this.tPagePopulation.Controls.Add(this.lBoxCities);
            this.tPagePopulation.Controls.Add(this.btnParse);
            this.tPagePopulation.Controls.Add(this.txBoxPopulationFile);
            this.tPagePopulation.Location = new System.Drawing.Point(4, 22);
            this.tPagePopulation.Name = "tPagePopulation";
            this.tPagePopulation.Padding = new System.Windows.Forms.Padding(3);
            this.tPagePopulation.Size = new System.Drawing.Size(676, 385);
            this.tPagePopulation.TabIndex = 0;
            this.tPagePopulation.Text = "Population";
            this.tPagePopulation.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(478, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(93, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse!";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lBoxCities
            // 
            this.lBoxCities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lBoxCities.FormattingEnabled = true;
            this.lBoxCities.Location = new System.Drawing.Point(3, 40);
            this.lBoxCities.Name = "lBoxCities";
            this.lBoxCities.Size = new System.Drawing.Size(670, 342);
            this.lBoxCities.TabIndex = 2;
            // 
            // btnParse
            // 
            this.btnParse.Enabled = false;
            this.btnParse.Location = new System.Drawing.Point(577, 4);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(93, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse!";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txBoxPopulationFile
            // 
            this.txBoxPopulationFile.Location = new System.Drawing.Point(8, 6);
            this.txBoxPopulationFile.Name = "txBoxPopulationFile";
            this.txBoxPopulationFile.Size = new System.Drawing.Size(464, 20);
            this.txBoxPopulationFile.TabIndex = 0;
            this.txBoxPopulationFile.TextChanged += new System.EventHandler(this.txBoxPopulationFile_TextChanged);
            // 
            // tPageCoordinates
            // 
            this.tPageCoordinates.Controls.Add(this.btnParseCoord);
            this.tPageCoordinates.Controls.Add(this.lBoxDepartments);
            this.tPageCoordinates.Controls.Add(this.btnBrowseImage);
            this.tPageCoordinates.Controls.Add(this.txBoxImage);
            this.tPageCoordinates.Controls.Add(this.label2);
            this.tPageCoordinates.Controls.Add(this.btnBrowseText);
            this.tPageCoordinates.Controls.Add(this.txBoxTextfile);
            this.tPageCoordinates.Controls.Add(this.label1);
            this.tPageCoordinates.Location = new System.Drawing.Point(4, 22);
            this.tPageCoordinates.Name = "tPageCoordinates";
            this.tPageCoordinates.Padding = new System.Windows.Forms.Padding(3);
            this.tPageCoordinates.Size = new System.Drawing.Size(676, 385);
            this.tPageCoordinates.TabIndex = 1;
            this.tPageCoordinates.Text = "Coordinates";
            this.tPageCoordinates.UseVisualStyleBackColor = true;
            // 
            // btnParseCoord
            // 
            this.btnParseCoord.Location = new System.Drawing.Point(593, 65);
            this.btnParseCoord.Name = "btnParseCoord";
            this.btnParseCoord.Size = new System.Drawing.Size(75, 23);
            this.btnParseCoord.TabIndex = 7;
            this.btnParseCoord.Text = "Parse";
            this.btnParseCoord.UseVisualStyleBackColor = true;
            this.btnParseCoord.Click += new System.EventHandler(this.btnParseCoord_Click);
            // 
            // lBoxDepartments
            // 
            this.lBoxDepartments.FormattingEnabled = true;
            this.lBoxDepartments.Location = new System.Drawing.Point(9, 90);
            this.lBoxDepartments.Name = "lBoxDepartments";
            this.lBoxDepartments.Size = new System.Drawing.Size(659, 290);
            this.lBoxDepartments.TabIndex = 6;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(593, 36);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImage.TabIndex = 5;
            this.btnBrowseImage.Text = "Browse";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // txBoxImage
            // 
            this.txBoxImage.Location = new System.Drawing.Point(59, 38);
            this.txBoxImage.Name = "txBoxImage";
            this.txBoxImage.Size = new System.Drawing.Size(528, 20);
            this.txBoxImage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image:";
            // 
            // btnBrowseText
            // 
            this.btnBrowseText.Location = new System.Drawing.Point(593, 10);
            this.btnBrowseText.Name = "btnBrowseText";
            this.btnBrowseText.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseText.TabIndex = 2;
            this.btnBrowseText.Text = "Browse";
            this.btnBrowseText.UseVisualStyleBackColor = true;
            this.btnBrowseText.Click += new System.EventHandler(this.btnBrowseText_Click);
            // 
            // txBoxTextfile
            // 
            this.txBoxTextfile.Location = new System.Drawing.Point(59, 12);
            this.txBoxTextfile.Name = "txBoxTextfile";
            this.txBoxTextfile.Size = new System.Drawing.Size(528, 20);
            this.txBoxTextfile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TextFile:";
            // 
            // tPageMatch
            // 
            this.tPageMatch.Controls.Add(this.txBoxMatchResults);
            this.tPageMatch.Controls.Add(this.btnParseMatch);
            this.tPageMatch.Location = new System.Drawing.Point(4, 22);
            this.tPageMatch.Name = "tPageMatch";
            this.tPageMatch.Size = new System.Drawing.Size(676, 385);
            this.tPageMatch.TabIndex = 2;
            this.tPageMatch.Text = "Match RegionInfos";
            this.tPageMatch.UseVisualStyleBackColor = true;
            // 
            // btnParseMatch
            // 
            this.btnParseMatch.Location = new System.Drawing.Point(8, 8);
            this.btnParseMatch.Name = "btnParseMatch";
            this.btnParseMatch.Size = new System.Drawing.Size(660, 23);
            this.btnParseMatch.TabIndex = 1;
            this.btnParseMatch.Text = "Match RegionInfos";
            this.btnParseMatch.UseVisualStyleBackColor = true;
            this.btnParseMatch.Click += new System.EventHandler(this.btnParseMatch_Click);
            // 
            // txBoxMatchResults
            // 
            this.txBoxMatchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txBoxMatchResults.Location = new System.Drawing.Point(8, 37);
            this.txBoxMatchResults.Multiline = true;
            this.txBoxMatchResults.Name = "txBoxMatchResults";
            this.txBoxMatchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBoxMatchResults.Size = new System.Drawing.Size(660, 340);
            this.txBoxMatchResults.TabIndex = 2;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.tControl);
            this.Name = "MainFrm";
            this.Text = "Epidemic Sim - Data Parser";
            this.tControl.ResumeLayout(false);
            this.tPagePopulation.ResumeLayout(false);
            this.tPagePopulation.PerformLayout();
            this.tPageCoordinates.ResumeLayout(false);
            this.tPageCoordinates.PerformLayout();
            this.tPageMatch.ResumeLayout(false);
            this.tPageMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tControl;
        private System.Windows.Forms.TabPage tPagePopulation;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txBoxPopulationFile;
        private System.Windows.Forms.TabPage tPageCoordinates;
        private System.Windows.Forms.ListBox lBoxCities;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog fileDlg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txBoxTextfile;
        private System.Windows.Forms.Button btnBrowseText;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.TextBox txBoxImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lBoxDepartments;
        private System.Windows.Forms.Button btnParseCoord;
        private System.Windows.Forms.TabPage tPageMatch;
        private System.Windows.Forms.Button btnParseMatch;
        private System.Windows.Forms.TextBox txBoxMatchResults;
    }
}

