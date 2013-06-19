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
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.MenuStrip_Main_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Main_File_NewSim = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStrip_Main_File_OpenSim = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStrip_Main_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Main_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Main_About = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDepFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenSimFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._workPanel = new System.Windows.Forms.Panel();
            this.MenuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_Main_File,
            this.MenuStrip_Main_Tools,
            this.MenuStrip_Main_About});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip_Main.Size = new System.Drawing.Size(834, 24);
            this.MenuStrip_Main.TabIndex = 0;
            // 
            // MenuStrip_Main_File
            // 
            this.MenuStrip_Main_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_Main_File_NewSim,
            this.toolStripSeparator1,
            this.MenuStrip_Main_File_OpenSim,
            this.toolStripSeparator2,
            this.MenuStrip_Main_File_Exit});
            this.MenuStrip_Main_File.Name = "MenuStrip_Main_File";
            this.MenuStrip_Main_File.Size = new System.Drawing.Size(37, 20);
            this.MenuStrip_Main_File.Text = "&File";
            // 
            // MenuStrip_Main_File_NewSim
            // 
            this.MenuStrip_Main_File_NewSim.Name = "MenuStrip_Main_File_NewSim";
            this.MenuStrip_Main_File_NewSim.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuStrip_Main_File_NewSim.Size = new System.Drawing.Size(215, 22);
            this.MenuStrip_Main_File_NewSim.Text = "&New Simulation...";
            this.MenuStrip_Main_File_NewSim.Click += new System.EventHandler(this.MenuStrip_Main_File_NewSim_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // MenuStrip_Main_File_OpenSim
            // 
            this.MenuStrip_Main_File_OpenSim.Name = "MenuStrip_Main_File_OpenSim";
            this.MenuStrip_Main_File_OpenSim.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuStrip_Main_File_OpenSim.Size = new System.Drawing.Size(215, 22);
            this.MenuStrip_Main_File_OpenSim.Text = "&Open Simulation...";
            this.MenuStrip_Main_File_OpenSim.Click += new System.EventHandler(this.MenuStrip_Main_File_OpenSim_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // MenuStrip_Main_File_Exit
            // 
            this.MenuStrip_Main_File_Exit.Name = "MenuStrip_Main_File_Exit";
            this.MenuStrip_Main_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MenuStrip_Main_File_Exit.Size = new System.Drawing.Size(215, 22);
            this.MenuStrip_Main_File_Exit.Text = "Exit";
            this.MenuStrip_Main_File_Exit.Click += new System.EventHandler(this.MenuStrip_Main_File_Exit_Click);
            // 
            // MenuStrip_Main_Tools
            // 
            this.MenuStrip_Main_Tools.Name = "MenuStrip_Main_Tools";
            this.MenuStrip_Main_Tools.Size = new System.Drawing.Size(48, 20);
            this.MenuStrip_Main_Tools.Text = "&Tools";
            this.MenuStrip_Main_Tools.Visible = false;
            // 
            // MenuStrip_Main_About
            // 
            this.MenuStrip_Main_About.Name = "MenuStrip_Main_About";
            this.MenuStrip_Main_About.Size = new System.Drawing.Size(52, 20);
            this.MenuStrip_Main_About.Text = "&About";
            // 
            // OpenDepFileDialog
            // 
            this.OpenDepFileDialog.Filter = "Department File (*.dep)|*.dep|All Files (*.*)|*.*";
            this.OpenDepFileDialog.Title = "Open Department file (.dep)";
            // 
            // OpenSimFileDialog
            // 
            this.OpenSimFileDialog.Filter = "Simulation File (*.sim)|*.sim|All files (*.*)|*.*";
            this.OpenSimFileDialog.Title = "Open Simulation file (.sim)";
            // 
            // _workPanel
            // 
            this._workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._workPanel.Location = new System.Drawing.Point(0, 24);
            this._workPanel.Margin = new System.Windows.Forms.Padding(0);
            this._workPanel.Name = "_workPanel";
            this._workPanel.Size = new System.Drawing.Size(834, 538);
            this._workPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 562);
            this.Controls.Add(this._workPanel);
            this.Controls.Add(this.MenuStrip_Main);
            this.MainMenuStrip = this.MenuStrip_Main;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epidemic Simulator";
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_File;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_File_NewSim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_File_OpenSim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_Tools;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Main_About;
        private System.Windows.Forms.OpenFileDialog OpenDepFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenSimFileDialog;
        private System.Windows.Forms.Panel _workPanel;
    }
}

