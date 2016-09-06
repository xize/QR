using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.QR_GEN
{
    public partial class Window : Form
    {
        public Window()
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
            InitializeComponent();
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void generatebtn_Click(object sender, EventArgs e)
        {
            if(textbox.Text.Length > 0)
            {
                Generator.getGenerator().generate(this);
            } else
            {
                MessageBox.Show("please make sure you have something in the textbox !");
            }
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textbox.Text.Length > 0)
            {

                //generate the image again for better useability.
                Generator.getGenerator().generate(this);

                if (append.Checked)
                {
                    if(File.Exists("qr.jpg"))
                    {
                        Image currentImage = Image.FromFile("qr.jpg");
                        Image img = picture.Image;

                        int margin = 60;
                        int width = currentImage.Width;
                        int height = currentImage.Height + img.Height + margin;

                        Image bitmap = new Bitmap(width, height);
                        Graphics g = Graphics.FromImage(bitmap);

                        g.Clear(Color.White);

                        g.DrawImage(currentImage, new Point(0, 0));
                        g.DrawImage(img, new Point(0, currentImage.Height + margin));

                        currentImage.Dispose();

                        bitmap.Save("qr.jpg");
                    } else
                    {
                        Image img = picture.Image;
                        img.Save("qr.jpg");
                    }
                } else
                {
                    Image img = picture.Image;
                    img.Save("qr.jpg");
                }
            } else
            {
                MessageBox.Show("please make sure you have something in the textbox !");
            }
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
