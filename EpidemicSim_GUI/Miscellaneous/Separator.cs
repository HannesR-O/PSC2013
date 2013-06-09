using System;
using System.Drawing;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public partial class Separator : UserControl
    {
        public Separator()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            RectangleF r = g.VisibleClipBounds;

            float w = r.Width - 10;
            float x = r.X + 5;
            float y = r.Y + r.Height / 2;

            Pen black = new Pen(Color.DarkGray);
            Pen gray = new Pen(Color.LightGray);

            g.DrawRectangle(black, x, y, w, 0.75f);
            g.DrawRectangle(gray, x, y + 0.5f, w, 0.5f);
        }
    }
}