namespace PSC2013.ES.GUI.Simulation.Panels
{
    partial class SimulationOutputPanel
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
            this.GrpBox_Main = new System.Windows.Forms.GroupBox();
            this.Panel_Bottom = new System.Windows.Forms.Panel();
            this.ProgressBar_Main = new System.Windows.Forms.ProgressBar();
            this.Btn_Abort = new System.Windows.Forms.Button();
            this.ListBox_Output = new System.Windows.Forms.ListBox();
            this.GrpBox_Main.SuspendLayout();
            this.Panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.Panel_Bottom);
            this.GrpBox_Main.Controls.Add(this.ListBox_Output);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(443, 452);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Output";
            // 
            // Panel_Bottom
            // 
            this.Panel_Bottom.AutoSize = true;
            this.Panel_Bottom.Controls.Add(this.ProgressBar_Main);
            this.Panel_Bottom.Controls.Add(this.Btn_Abort);
            this.Panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Bottom.Location = new System.Drawing.Point(3, 420);
            this.Panel_Bottom.Name = "Panel_Bottom";
            this.Panel_Bottom.Size = new System.Drawing.Size(437, 29);
            this.Panel_Bottom.TabIndex = 1;
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_Main.Location = new System.Drawing.Point(7, 3);
            this.ProgressBar_Main.MarqueeAnimationSpeed = 50;
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(342, 23);
            this.ProgressBar_Main.Step = 1;
            this.ProgressBar_Main.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar_Main.TabIndex = 1;
            // 
            // Btn_Abort
            // 
            this.Btn_Abort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Abort.Location = new System.Drawing.Point(355, 3);
            this.Btn_Abort.Name = "Btn_Abort";
            this.Btn_Abort.Size = new System.Drawing.Size(75, 23);
            this.Btn_Abort.TabIndex = 0;
            this.Btn_Abort.Text = "Abort";
            this.Btn_Abort.UseVisualStyleBackColor = true;
            // 
            // ListBox_Output
            // 
            this.ListBox_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox_Output.FormattingEnabled = true;
            this.ListBox_Output.IntegralHeight = false;
            this.ListBox_Output.Location = new System.Drawing.Point(10, 19);
            this.ListBox_Output.Name = "ListBox_Output";
            this.ListBox_Output.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox_Output.Size = new System.Drawing.Size(423, 395);
            this.ListBox_Output.TabIndex = 0;
            // 
            // SimulationOutputPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationOutputPanel";
            this.Size = new System.Drawing.Size(443, 452);
            this.GrpBox_Main.ResumeLayout(false);
            this.GrpBox_Main.PerformLayout();
            this.Panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private System.Windows.Forms.ListBox ListBox_Output;
        private System.Windows.Forms.Panel Panel_Bottom;
        private System.Windows.Forms.ProgressBar ProgressBar_Main;
        private System.Windows.Forms.Button Btn_Abort;
    }
}
