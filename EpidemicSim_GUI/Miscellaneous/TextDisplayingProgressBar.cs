using System;
using System.Drawing;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public class TextDisplayingProgressBar : ProgressBar
    {
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F && Style != ProgressBarStyle.Marquee)
            {
                var flags = TextFormatFlags.VerticalCenter |
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.SingleLine |
                            TextFormatFlags.WordEllipsis;

                TextRenderer.DrawText(CreateGraphics(),
                                      String.Format("{0," + Maximum.ToString().Length + "} / {1}", Value, Maximum),
                                      SystemFonts.DefaultFont,
                                      new Rectangle(0, 0, this.Width, this.Height),
                                      Color.Black,
                                      flags);
            }
        }
    }
}