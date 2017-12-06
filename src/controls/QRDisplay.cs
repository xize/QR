using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_GEN.src.controls
{
    public partial class QRDisplay : UserControl
    {
        public QRDisplay()
        {
            InitializeComponent();
        }

        private void QRDisplay_Load(object sender, EventArgs e)
        {
            
        }

        public void SetQRCode(Image img)
        {
            customPictureBox1.Image = img;
        }

        public Image GetQRCode()
        {
            return customPictureBox1.Image;
        }

        public void SetAsciiQR(string text)
        {
            if(!richTextBox1.Visible)
            {
                richTextBox1.Show();
            }
            richTextBox1.Text = text;
        }

        public string GetAsciiQR()
        {
            return richTextBox1.Text;
        }

        public void Clear()
        {
            if(customPictureBox1.Image != null)
            {
                customPictureBox1.Image = null;
            }
            if(richTextBox1.Visible)
            {
                richTextBox1.Clear();
                richTextBox1.Hide();
            }
        }
        
    }
}
