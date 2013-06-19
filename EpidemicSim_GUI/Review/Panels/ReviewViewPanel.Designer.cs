namespace PSC2013.ES.GUI.Review.Panels
{
    partial class ReviewViewPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabPage_Graphics = new System.Windows.Forms.TabPage();
            this.GrpBox_Graphic = new System.Windows.Forms.GroupBox();
            this.PictureBox_Graphic = new System.Windows.Forms.PictureBox();
            this.GrpBox_Caption = new System.Windows.Forms.GroupBox();
            this.TextBox_Caption = new System.Windows.Forms.TextBox();
            this.GrpBox_Selection = new System.Windows.Forms.GroupBox();
            this.ListBox_Selection = new System.Windows.Forms.ListBox();
            this.TabPage_AgeDiagram = new System.Windows.Forms.TabPage();
            this.Chart_Age = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel_BottomAgeDiagram = new System.Windows.Forms.Panel();
            this.TextBox_SaveAgeDiagram = new System.Windows.Forms.TextBox();
            this.Btn_SaveAgeDiagram = new System.Windows.Forms.Button();
            this.TabPage_AlternativeDiagram = new System.Windows.Forms.TabPage();
            this.Chart_Alternative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel_BottomAlternativeDiagram = new System.Windows.Forms.Panel();
            this.TextBox_SaveAlternativeDiagram = new System.Windows.Forms.TextBox();
            this.Btn_SaveAlternativeDiagram = new System.Windows.Forms.Button();
            this.saveChartFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Graphics.SuspendLayout();
            this.GrpBox_Graphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graphic)).BeginInit();
            this.GrpBox_Caption.SuspendLayout();
            this.GrpBox_Selection.SuspendLayout();
            this.TabPage_AgeDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Age)).BeginInit();
            this.Panel_BottomAgeDiagram.SuspendLayout();
            this.TabPage_AlternativeDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Alternative)).BeginInit();
            this.Panel_BottomAlternativeDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Controls.Add(this.TabPage_Graphics);
            this.TabControl_Main.Controls.Add(this.TabPage_AgeDiagram);
            this.TabControl_Main.Controls.Add(this.TabPage_AlternativeDiagram);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Main.Multiline = true;
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(537, 466);
            this.TabControl_Main.TabIndex = 0;
            // 
            // TabPage_Graphics
            // 
            this.TabPage_Graphics.Controls.Add(this.GrpBox_Graphic);
            this.TabPage_Graphics.Controls.Add(this.GrpBox_Caption);
            this.TabPage_Graphics.Controls.Add(this.GrpBox_Selection);
            this.TabPage_Graphics.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Graphics.Name = "TabPage_Graphics";
            this.TabPage_Graphics.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Graphics.Size = new System.Drawing.Size(529, 440);
            this.TabPage_Graphics.TabIndex = 0;
            this.TabPage_Graphics.Text = "Graphics";
            this.TabPage_Graphics.UseVisualStyleBackColor = true;
            // 
            // GrpBox_Graphic
            // 
            this.GrpBox_Graphic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBox_Graphic.Controls.Add(this.PictureBox_Graphic);
            this.GrpBox_Graphic.Location = new System.Drawing.Point(212, 3);
            this.GrpBox_Graphic.Name = "GrpBox_Graphic";
            this.GrpBox_Graphic.Padding = new System.Windows.Forms.Padding(7);
            this.GrpBox_Graphic.Size = new System.Drawing.Size(311, 431);
            this.GrpBox_Graphic.TabIndex = 2;
            this.GrpBox_Graphic.TabStop = false;
            this.GrpBox_Graphic.Text = "Graphic";
            // 
            // PictureBox_Graphic
            // 
            this.PictureBox_Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox_Graphic.Location = new System.Drawing.Point(7, 20);
            this.PictureBox_Graphic.Name = "PictureBox_Graphic";
            this.PictureBox_Graphic.Size = new System.Drawing.Size(297, 404);
            this.PictureBox_Graphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Graphic.TabIndex = 0;
            this.PictureBox_Graphic.TabStop = false;
            // 
            // GrpBox_Caption
            // 
            this.GrpBox_Caption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GrpBox_Caption.BackColor = System.Drawing.Color.Transparent;
            this.GrpBox_Caption.Controls.Add(this.TextBox_Caption);
            this.GrpBox_Caption.Location = new System.Drawing.Point(6, 234);
            this.GrpBox_Caption.Name = "GrpBox_Caption";
            this.GrpBox_Caption.Padding = new System.Windows.Forms.Padding(7);
            this.GrpBox_Caption.Size = new System.Drawing.Size(200, 200);
            this.GrpBox_Caption.TabIndex = 0;
            this.GrpBox_Caption.TabStop = false;
            this.GrpBox_Caption.Text = "Caption";
            // 
            // TextBox_Caption
            // 
            this.TextBox_Caption.BackColor = System.Drawing.Color.White;
            this.TextBox_Caption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Caption.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox_Caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Caption.Enabled = false;
            this.TextBox_Caption.HideSelection = false;
            this.TextBox_Caption.Location = new System.Drawing.Point(7, 20);
            this.TextBox_Caption.Multiline = true;
            this.TextBox_Caption.Name = "TextBox_Caption";
            this.TextBox_Caption.ReadOnly = true;
            this.TextBox_Caption.Size = new System.Drawing.Size(186, 173);
            this.TextBox_Caption.TabIndex = 0;
            // 
            // GrpBox_Selection
            // 
            this.GrpBox_Selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GrpBox_Selection.Controls.Add(this.ListBox_Selection);
            this.GrpBox_Selection.Location = new System.Drawing.Point(6, 3);
            this.GrpBox_Selection.Name = "GrpBox_Selection";
            this.GrpBox_Selection.Padding = new System.Windows.Forms.Padding(7);
            this.GrpBox_Selection.Size = new System.Drawing.Size(200, 225);
            this.GrpBox_Selection.TabIndex = 1;
            this.GrpBox_Selection.TabStop = false;
            this.GrpBox_Selection.Text = "Selection";
            // 
            // ListBox_Selection
            // 
            this.ListBox_Selection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox_Selection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Selection.FormattingEnabled = true;
            this.ListBox_Selection.Location = new System.Drawing.Point(7, 20);
            this.ListBox_Selection.Name = "ListBox_Selection";
            this.ListBox_Selection.Size = new System.Drawing.Size(186, 198);
            this.ListBox_Selection.TabIndex = 0;
            // 
            // TabPage_AgeDiagram
            // 
            this.TabPage_AgeDiagram.Controls.Add(this.Chart_Age);
            this.TabPage_AgeDiagram.Controls.Add(this.Panel_BottomAgeDiagram);
            this.TabPage_AgeDiagram.Location = new System.Drawing.Point(4, 22);
            this.TabPage_AgeDiagram.Name = "TabPage_AgeDiagram";
            this.TabPage_AgeDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_AgeDiagram.Size = new System.Drawing.Size(529, 440);
            this.TabPage_AgeDiagram.TabIndex = 1;
            this.TabPage_AgeDiagram.Text = "Age-Diagram";
            this.TabPage_AgeDiagram.UseVisualStyleBackColor = true;
            // 
            // Chart_Age
            // 
            chartArea1.Name = "ChartAreaAge";
            this.Chart_Age.ChartAreas.Add(chartArea1);
            this.Chart_Age.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "LegendAge";
            this.Chart_Age.Legends.Add(legend1);
            this.Chart_Age.Location = new System.Drawing.Point(3, 3);
            this.Chart_Age.Name = "Chart_Age";
            this.Chart_Age.Size = new System.Drawing.Size(523, 404);
            this.Chart_Age.TabIndex = 1;
            this.Chart_Age.Text = "AgeDiagram";
            // 
            // Panel_BottomAgeDiagram
            // 
            this.Panel_BottomAgeDiagram.Controls.Add(this.TextBox_SaveAgeDiagram);
            this.Panel_BottomAgeDiagram.Controls.Add(this.Btn_SaveAgeDiagram);
            this.Panel_BottomAgeDiagram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_BottomAgeDiagram.Location = new System.Drawing.Point(3, 407);
            this.Panel_BottomAgeDiagram.Name = "Panel_BottomAgeDiagram";
            this.Panel_BottomAgeDiagram.Size = new System.Drawing.Size(523, 30);
            this.Panel_BottomAgeDiagram.TabIndex = 0;
            // 
            // TextBox_SaveAgeDiagram
            // 
            this.TextBox_SaveAgeDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_SaveAgeDiagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextBox_SaveAgeDiagram.Location = new System.Drawing.Point(239, 6);
            this.TextBox_SaveAgeDiagram.Name = "TextBox_SaveAgeDiagram";
            this.TextBox_SaveAgeDiagram.ReadOnly = true;
            this.TextBox_SaveAgeDiagram.Size = new System.Drawing.Size(200, 20);
            this.TextBox_SaveAgeDiagram.TabIndex = 1;
            this.TextBox_SaveAgeDiagram.Click += new System.EventHandler(this.OnSaveBoxClick);
            // 
            // Btn_SaveAgeDiagram
            // 
            this.Btn_SaveAgeDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SaveAgeDiagram.Location = new System.Drawing.Point(445, 4);
            this.Btn_SaveAgeDiagram.Name = "Btn_SaveAgeDiagram";
            this.Btn_SaveAgeDiagram.Size = new System.Drawing.Size(75, 23);
            this.Btn_SaveAgeDiagram.TabIndex = 0;
            this.Btn_SaveAgeDiagram.Text = "Save";
            this.Btn_SaveAgeDiagram.UseVisualStyleBackColor = true;
            this.Btn_SaveAgeDiagram.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // TabPage_AlternativeDiagram
            // 
            this.TabPage_AlternativeDiagram.Controls.Add(this.Chart_Alternative);
            this.TabPage_AlternativeDiagram.Controls.Add(this.Panel_BottomAlternativeDiagram);
            this.TabPage_AlternativeDiagram.Location = new System.Drawing.Point(4, 22);
            this.TabPage_AlternativeDiagram.Name = "TabPage_AlternativeDiagram";
            this.TabPage_AlternativeDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_AlternativeDiagram.Size = new System.Drawing.Size(529, 440);
            this.TabPage_AlternativeDiagram.TabIndex = 2;
            this.TabPage_AlternativeDiagram.Text = "AlternativeDiagram";
            this.TabPage_AlternativeDiagram.UseVisualStyleBackColor = true;
            // 
            // Chart_Alternative
            // 
            chartArea2.Name = "ChartAreaAlternative";
            this.Chart_Alternative.ChartAreas.Add(chartArea2);
            this.Chart_Alternative.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "LegendAlternative";
            this.Chart_Alternative.Legends.Add(legend2);
            this.Chart_Alternative.Location = new System.Drawing.Point(3, 3);
            this.Chart_Alternative.Name = "Chart_Alternative";
            this.Chart_Alternative.Size = new System.Drawing.Size(523, 404);
            this.Chart_Alternative.TabIndex = 1;
            this.Chart_Alternative.Text = "AlternativeDiagram";
            // 
            // Panel_BottomAlternativeDiagram
            // 
            this.Panel_BottomAlternativeDiagram.Controls.Add(this.TextBox_SaveAlternativeDiagram);
            this.Panel_BottomAlternativeDiagram.Controls.Add(this.Btn_SaveAlternativeDiagram);
            this.Panel_BottomAlternativeDiagram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_BottomAlternativeDiagram.Location = new System.Drawing.Point(3, 407);
            this.Panel_BottomAlternativeDiagram.Name = "Panel_BottomAlternativeDiagram";
            this.Panel_BottomAlternativeDiagram.Size = new System.Drawing.Size(523, 30);
            this.Panel_BottomAlternativeDiagram.TabIndex = 0;
            // 
            // TextBox_SaveAlternativeDiagram
            // 
            this.TextBox_SaveAlternativeDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_SaveAlternativeDiagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextBox_SaveAlternativeDiagram.Location = new System.Drawing.Point(239, 6);
            this.TextBox_SaveAlternativeDiagram.Name = "TextBox_SaveAlternativeDiagram";
            this.TextBox_SaveAlternativeDiagram.ReadOnly = true;
            this.TextBox_SaveAlternativeDiagram.Size = new System.Drawing.Size(200, 20);
            this.TextBox_SaveAlternativeDiagram.TabIndex = 1;
            this.TextBox_SaveAlternativeDiagram.Click += new System.EventHandler(this.OnSaveBoxClick);
            // 
            // Btn_SaveAlternativeDiagram
            // 
            this.Btn_SaveAlternativeDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SaveAlternativeDiagram.Location = new System.Drawing.Point(445, 4);
            this.Btn_SaveAlternativeDiagram.Name = "Btn_SaveAlternativeDiagram";
            this.Btn_SaveAlternativeDiagram.Size = new System.Drawing.Size(75, 23);
            this.Btn_SaveAlternativeDiagram.TabIndex = 0;
            this.Btn_SaveAlternativeDiagram.Text = "Save";
            this.Btn_SaveAlternativeDiagram.UseVisualStyleBackColor = true;
            this.Btn_SaveAlternativeDiagram.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // saveChartFileDialog
            // 
            this.saveChartFileDialog.DefaultExt = "png";
            this.saveChartFileDialog.Filter = "Portable Network Graphics (*.png)|*.png|All files (*.*)|*.*";
            this.saveChartFileDialog.Title = "Save chart at...";
            // 
            // ReviewViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TabControl_Main);
            this.Name = "ReviewViewPanel";
            this.Size = new System.Drawing.Size(537, 466);
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Graphics.ResumeLayout(false);
            this.GrpBox_Graphic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graphic)).EndInit();
            this.GrpBox_Caption.ResumeLayout(false);
            this.GrpBox_Caption.PerformLayout();
            this.GrpBox_Selection.ResumeLayout(false);
            this.TabPage_AgeDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Age)).EndInit();
            this.Panel_BottomAgeDiagram.ResumeLayout(false);
            this.Panel_BottomAgeDiagram.PerformLayout();
            this.TabPage_AlternativeDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Alternative)).EndInit();
            this.Panel_BottomAlternativeDiagram.ResumeLayout(false);
            this.Panel_BottomAlternativeDiagram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Graphics;
        private System.Windows.Forms.GroupBox GrpBox_Caption;
        private System.Windows.Forms.GroupBox GrpBox_Selection;
        private System.Windows.Forms.GroupBox GrpBox_Graphic;
        private System.Windows.Forms.ListBox ListBox_Selection;
        private System.Windows.Forms.TextBox TextBox_Caption;
        private System.Windows.Forms.PictureBox PictureBox_Graphic;
        private System.Windows.Forms.TabPage TabPage_AgeDiagram;
        private System.Windows.Forms.Panel Panel_BottomAgeDiagram;
        private System.Windows.Forms.Button Btn_SaveAgeDiagram;
        private System.Windows.Forms.TextBox TextBox_SaveAgeDiagram;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Age;
        private System.Windows.Forms.TabPage TabPage_AlternativeDiagram;
        private System.Windows.Forms.Panel Panel_BottomAlternativeDiagram;
        private System.Windows.Forms.Button Btn_SaveAlternativeDiagram;
        private System.Windows.Forms.TextBox TextBox_SaveAlternativeDiagram;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Alternative;
        private System.Windows.Forms.SaveFileDialog saveChartFileDialog;
    }
}
