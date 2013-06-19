using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewViewPanel : UserControl
    {
        private const SeriesChartType DEFAULT_CHARTTYPE = SeriesChartType.Spline;

        public ReviewViewPanel()
        {
            InitializeComponent();
        }

        public ListBox TheListBox
        {
            get { return ListBox_Selection; }
        }

        public void SetTabs(bool[] bools)
        {
            if (!bools[0])
                TabControl_Main.TabPages.Remove(TabPage_AgeDiagram);
            if (!bools[1])
                TabControl_Main.TabPages.Remove(TabPage_AlternativeDiagram);
        }

        /// <summary>
        /// just put 8 int[] in here (in correct order)!
        /// </summary>
        public void SetAgeChart(params int[][] ints)
        {
            if (ints.Length != 8)
                throw new ArgumentOutOfRangeException("I told you...");

            string[] names = new string[] { "Baby", "Child", "Adult", "Senior" };

            for (int i = 0; i < 8; ++i)
            {
                string name = (i < 4 ? "Male " : "Female ") + names[i % 4];
                var series = new Series(name);
                series.ChartType = DEFAULT_CHARTTYPE;
                AddToSeries(series.Points, ints[i]);
                Chart_Age.Series.Add(series);
            }
        }

        public void SetAlternativeChart(int[] all, int[] infected, int[] diseased)
        {
            var serA = new Series("All humans");
            serA.ChartType = DEFAULT_CHARTTYPE;
            AddToSeries(serA.Points, all);
            Chart_Alternative.Series.Add(serA);

            var serI = new Series("All infected");
            serI.ChartType = DEFAULT_CHARTTYPE;
            AddToSeries(serI.Points, infected);
            Chart_Alternative.Series.Add(serI);

            var serD = new Series("All diseased");
            serD.ChartType = DEFAULT_CHARTTYPE;
            AddToSeries(serD.Points, diseased);
            Chart_Alternative.Series.Add(serD);
        }

        private void AddToSeries(DataPointCollection points, int[] values)
        {
            for (int i = 0; i < values.Length; ++i)
                points.AddXY(i, values[i]);
        }

        public void SetImage(Image image)
        {
            PictureBox_Graphic.Image = image;
        }

        public void SetCaption(string text)
        {
            TextBox_Caption.Text = text;
        }

        public void SetSavePathAge(string path)
        {
            TextBox_SaveAgeDiagram.Text = path;
        }

        public void SetSavePathAlternative(string path)
        {
            TextBox_SaveAlternativeDiagram.Text = path;
        }

        private void OnSaveBoxClick(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;

            if (txb != null)
            {
                DialogResult dr = saveChartFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                    txb.Text = saveChartFileDialog.FileName;
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            if (sender == Btn_SaveAgeDiagram &&
                !String.IsNullOrEmpty(TextBox_SaveAlternativeDiagram.Text))
            {
                Chart_Age.SaveImage(TextBox_SaveAgeDiagram.Text, ChartImageFormat.Png);
                CallMessageBoxSaved("AgeChart", TextBox_SaveAgeDiagram.Text);
            }
            else if (sender == Btn_SaveAlternativeDiagram &&
                !String.IsNullOrEmpty(TextBox_SaveAlternativeDiagram.Text))
            {
                Chart_Alternative.SaveImage(TextBox_SaveAlternativeDiagram.Text,
                    ChartImageFormat.Png);
                CallMessageBoxSaved("AlternativeChart", TextBox_SaveAlternativeDiagram.Text);
            }
        }

        private void CallMessageBoxSaved(string title, string path)
        {
            MessageBox.Show("The " + title + " has been saved to " + Environment.NewLine +
                path, "Saved " + title);
        }
    }
}