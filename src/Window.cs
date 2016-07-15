using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(picture.Image != null)
            {
                Image img = picture.Image;
                img.Save("qr.jpg");
            }
        }

        private void dialog_FileOk(object sender, CancelEventArgs e)
        {
            if(dialog.SafeFileName.Split('.')[1].ToLower() == "jpg" || dialog.SafeFileName.Split('.')[1].ToLower() == "bmp" || dialog.SafeFileName.Split('.')[1].ToLower() == "png" || dialog.SafeFileName.Split('.')[1].ToLower() == "gif")
            {
                Stream stream = dialog.OpenFile();
                Image img = Image.FromStream(stream);
                string text = Generator.getGenerator().readQR(img);
                picture.Image = img;
                textbox.Text = text;
            } else
            {
                MessageBox.Show("this file cannot be accepted!, only jpg, bmp, png, gif");
            }
        }

        private void openbtn_Click_1(object sender, EventArgs e)
        {
            dialog.ShowDialog();
        }
    }
}
