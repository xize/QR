using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_GEN.src.controls
{
    public class CustomPictureBox : PictureBox
    {

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Image == null)
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.YellowGreen, ButtonBorderStyle.Solid);
            }
        }

    }
}
