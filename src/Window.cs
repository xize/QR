using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.QR_GEN
{
    public partial class Window : Form
    {

        public Window()
        {
            hookDLL();
            InitializeComponent();
            updateTitle();
        }

        private void updateTitle()
        {
            this.Text = String.Format("QR Code Creator v{0}", Application.ProductVersion);
        }

        private void hookDLL()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void generatebtn_Click(object sender, EventArgs e)
        {
            if(textbox.Text.Length > 0)
            {
                if(append.Checked)
                {
                    if(picture.Image == null)
                    {
                        picture.Image = Generator.GetGenerator().GenerateQR(textbox.Text);
                    } else
                    {
                        picture.Image = Generator.GetGenerator().GenerateAppendedImage(textbox.Text, picture.Image);
                    }
                } else
                {
                    picture.Image = Generator.GetGenerator().GenerateQR(textbox.Text);
                }
            } else
            {
                MessageBox.Show("please make sure you have something in the textbox !");
            }
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void savefile_FileOk(object sender, CancelEventArgs e)
        {
            //generate the image again for better useability.
            bool disabled = false;
            if (!picture.Enabled)
            {
                picture.Enabled = true;
                disabled = !disabled;
            }
            picture.Image.Save(savefile.FileName);
            if(disabled)
            {
                picture.Enabled = false;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(textbox.Text.Length > 0)
            {
                savefile.Filter = "JPEG image|*.jpg|GIF Image|*.gif|BMP image|*.bmp|PNG image|*.png|TIF image|*.tif";
                savefile.ShowDialog();
            } else
            {
                MessageBox.Show("please make sure you have something in the textbox !");
            }
        }

        private void Window_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form1_Close;
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }

            if(e.CloseReason == CloseReason.UserClosing)
            {
                picture.Image = null;
                textbox.Clear();
                e.Cancel = true;
                this.Visible = false;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "QR Code Creator has been minimized";
                notifyIcon.BalloonTipText = "in order to close it, right click this icon and click close.\n\nin order to start it just double click ;-)";
                notifyIcon.ShowBalloonTip(400);
            }

        }

        private void dialog_FileOk(object sender, CancelEventArgs e)
        {
            if(dialog.SafeFileName.Split('.')[1].ToLower() == "jpg" || dialog.SafeFileName.Split('.')[1].ToLower() == "bmp" || dialog.SafeFileName.Split('.')[1].ToLower() == "png" || dialog.SafeFileName.Split('.')[1].ToLower() == "gif")
            {
                Stream stream = dialog.OpenFile();
                Image img = Image.FromStream(stream);
                string text = Generator.GetGenerator().ReadQR(img);
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
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menustrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                this.Visible = true;
                notifyIcon.Visible = false;
        }

        private void passwdcheck_CheckedChanged(object sender, EventArgs e)
        {
            if(passwdcheck.Checked)
            {
                textbox.PasswordChar = '*';
            } else
            {
                textbox.PasswordChar = '\0';
            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            if(picture.Image == null)
            {
                MessageBox.Show("No image has been generated!");
                return;
            }
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += printhandle;
            pd.Print();
        }

        private void printhandle(object sender, PrintPageEventArgs e)
        {
            if(picture.Image == null)
            {
                MessageBox.Show("Error: cannot print because the image is not generated", "error");
                return;
            }
            Bitmap bit = new Bitmap(picture.Image, (picture.Image.Width/2), (picture.Image.Height/2));
            e.Graphics.DrawImage(bit, 0, 0);
            bit.Dispose();
        }

        private void append_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void qrhide_CheckedChanged(object sender, EventArgs e)
        {
            if(qrhide.Checked)
            {
                picture.Visible = false;
            } else
            {
                picture.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture.Image = null;
        }
    }
}
