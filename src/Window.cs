﻿using Microsoft.Win32;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_GEN.src
{
    public partial class Window : Form
    {

        private AsciiWindow asciiwindow = new AsciiWindow();

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

                if(googleauthcheckbox.Checked)
                {
                    string text = textbox.Text;
                    textbox.Clear();

                    //first check if it is already a OTP...
                    if (text.StartsWith("otpauth://"))
                    {
                        //when this is true we should update the textbox with the stripped secret again.
                        
                        int start = text.IndexOf('=')+1;
                        string leftside = text.Substring(start);
                        string rightside = leftside.Substring(0, leftside.IndexOf('&'));
                        textbox.Text = rightside;
                        text = rightside;
                    }

                    //first verify if the secret is actually OTP standard.
                    string secret = text;

                    
                    if(!OTP.GetOTP().Verify(secret))
                    {
                        MessageBox.Show("invalid OTP secret given in!");
                        return;
                    }
                    
                    string account = googleuserbox.Text;
                    string domain = googlewebsitetext.Text;

                    //verify if valid domain...
                    if(domain.Contains("."))
                    {
                        int i = domain.LastIndexOf('.');
                        if(domain.Substring(i).Length < 1)
                        {
                            MessageBox.Show("when you type your website make sure it ends like \".domain\"!", "error");
                            return;
                        }
                    } else
                    {
                        MessageBox.Show("when you type your website make sure it ends like \".domain\"!", "error");
                        return;
                    }

                    //strip domain url ;-)
                    string issuer = domain.Substring(0, domain.LastIndexOf('.')).Replace("https://", "").Replace("http://", "").Replace("www.", "");
                
                    string google = "otpauth://totp/" + issuer + ":" + account + "?secret=" + text + "&issuer=" + issuer;

                    //convert password into compatible format for google authenticator
                    textbox.Text = google;
                }

                if (asciicheckbox.Checked)
                {
                    if (this.append.Checked)
                    {
                        if(asciiwindow.QRcode.Length > 0)
                        {
                            string currentqr = asciiwindow.QRcode;
                            string QR = Generator.GetGenerator().GenerateAsciiQR(textbox.Text);
                            asciiwindow.QRcode = currentqr+"\n\n\n\n\n"+QR;
                        } else
                        {
                            asciiwindow.QRcode = null;
                            string QR = Generator.GetGenerator().GenerateAsciiQR(textbox.Text);
                            asciiwindow.QRcode = QR;
                        }
                    }
                    else
                    {
                        asciiwindow.QRcode = null;
                        string QR = Generator.GetGenerator().GenerateAsciiQR(textbox.Text);
                        asciiwindow.QRcode = QR;
                    }
                    asciiwindow.ShowDialog();
                }
                else
                {
                    if (append.Checked)
                    {
                        if (picture.Image == null)
                        {
                            if(logotext.Enabled && File.Exists(logotext.Text))
                            {
                                Image img = new Bitmap(Image.FromFile(logotext.Text));
                                Image qr = Generator.GetGenerator().GenerateQR(textbox.Text);
                                picture.Image = Generator.GetGenerator().AddQRLogo(img, qr);
                            } else
                            {
                                picture.Image = Generator.GetGenerator().GenerateQR(textbox.Text);
                            }
                        }
                        else
                        {
                            if (logotext.Enabled && File.Exists(logotext.Text))
                            {
                                Image img = new Bitmap(Image.FromFile(logotext.Text));
                                Image qr = Generator.GetGenerator().GenerateQR(textbox.Text);
                                picture.Image = Generator.GetGenerator().AddQRLogo(img, qr);
                            }
                            else
                            {
                                picture.Image = Generator.GetGenerator().GenerateAppendedImage(textbox.Text, picture.Image);
                            }
                        }
                    }
                    else
                    {
                        if (logotext.Enabled && File.Exists(logotext.Text))
                        {
                            Image img = new Bitmap(Image.FromFile(logotext.Text));
                            Image qr = Generator.GetGenerator().GenerateQR(textbox.Text);
                            picture.Image = Generator.GetGenerator().AddQRLogo(img, qr);
                        }
                        else
                        {
                            picture.Image = Generator.GetGenerator().GenerateQR(textbox.Text);
                        }
                    }
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
                notifyIcon.BalloonTipText = "in order to close it, right click this icon and click close.\n\nin order to start it just left click ;-)";
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

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                notifyIcon.Visible = false;
            }
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

            Bitmap bit = new Bitmap(picture.Image, (comboBox1.SelectedIndex == 0 ? picture.Image.Width/2 : (picture.Image.Width /2)/2), (comboBox1.SelectedIndex == 0 ? picture.Image.Height/2 : (picture.Image.Height / 2)/2));
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

        private void asciicheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void googleauthcheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void googleauthcheckbox_CheckedChanged_1(object sender, EventArgs e)
        {
            textbox.Clear();
            if(googleauthcheckbox.Checked)
            {
                googleuserlabel.Enabled = true;
                googleuserbox.Enabled = true;
                googlewebsitelabel.Enabled = true;
                googlewebsitetext.Enabled = true;
            } else
            {
                googleuserlabel.Enabled = false;
                googleuserbox.Enabled = false;
                googlewebsitelabel.Enabled = false;
                googlewebsitetext.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = icondialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                if(icondialog.CheckFileExists)
                {
                    logotext.Enabled = true;
                    logotext.Text = icondialog.FileName;
                }
            }
        }

        private void icondialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void logotext_TextChanged(object sender, EventArgs e)
        {
            if(logotext.Text.Length == 0)
            {
                logotext.Enabled = false;
            }
        }
    }
}
