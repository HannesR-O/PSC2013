using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public partial class Seperator : UserControl
    {
        public Seperator()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            RectangleF r = g.VisibleClipBounds;

            float w = r.Width - 10;
            float x = r.X + 5;

            Pen black = new Pen(Color.DarkGray);
            Pen gray = new Pen(Color.LightGray);

            g.DrawRectangle(black, x, r.Y, w, 0.75f);
            g.DrawRectangle(gray, x, r.Y + 0.75f, w, 0.75f);
        }
    }
}
