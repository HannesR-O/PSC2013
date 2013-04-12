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
            this.tPageCoordinates = new System.Windows.Forms.TabPage();
            this.txBoxPopulationFile = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.lBoxCities = new System.Windows.Forms.ListBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fileDlg = new System.Windows.Forms.OpenFileDialog();
            this.tControl.SuspendLayout();
            this.tPagePopulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tControl
            // 
            this.tControl.Controls.Add(this.tPagePopulation);
            this.tControl.Controls.Add(this.tPageCoordinates);
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
            // tPageCoordinates
            // 
            this.tPageCoordinates.Location = new System.Drawing.Point(4, 22);
            this.tPageCoordinates.Name = "tPageCoordinates";
            this.tPageCoordinates.Padding = new System.Windows.Forms.Padding(3);
            this.tPageCoordinates.Size = new System.Drawing.Size(676, 385);
            this.tPageCoordinates.TabIndex = 1;
            this.tPageCoordinates.Text = "Coordinates";
            this.tPageCoordinates.UseVisualStyleBackColor = true;
            // 
            // txBoxPopulationFile
            // 
            this.txBoxPopulationFile.Location = new System.Drawing.Point(8, 6);
            this.txBoxPopulationFile.Name = "txBoxPopulationFile";
            this.txBoxPopulationFile.Size = new System.Drawing.Size(464, 20);
            this.txBoxPopulationFile.TabIndex = 0;
            this.txBoxPopulationFile.TextChanged += new System.EventHandler(this.txBoxPopulationFile_TextChanged);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(577, 4);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(93, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse!";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
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
    }
}

