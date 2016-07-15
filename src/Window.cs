using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.QR_GEN
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void generatebtn_Click(object sender, EventArgs e)
        {
            Generator.getGenerator().generate(this);
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(picture.Image != null)
            {
                Image img = picture.Image;
                img.Save("qr.jpg");
            }
        }
    }
}
