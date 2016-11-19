using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace src.QR_GEN
{
    class Generator
    {

        public static Generator gen;

        private Generator(){} /*do not instance it outside of this class*/

        private Image appended_img;

        private Image generateQR(string text)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 260,
                    Width = 260,
                    Margin = 0
                }
            };

            return writer.Write(text);
        }

        public string readQR(Image image)
        {
            Bitmap img = new Bitmap(image);
            BarcodeReader reader = new BarcodeReader();

            Result result = reader.Decode(img);

            return result.ToString().Trim();
        }

        public void generate(Window window)
        {
            if(window.textbox.Text == "")
            {
                return;
            }

            //generate a new QR code by using the text.
            Image QR = generateQR(window.textbox.Text);

            if(window.qrhide.Checked && this.appended_img != null)
            {
                Image currentImage = this.appended_img;
                    
                int margin = 60;
                int width = QR.Width;
                int height = currentImage.Height+QR.Height+margin;

                Image bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);
                g.Clear(Color.White);

                g.DrawImage(currentImage, new Point(0,0));
                g.DrawImage(QR, new Point(0, height));

                this.appended_img = bitmap;
                currentImage.Dispose();
            } else if(window.append.Checked && window.picture.Image != null)
            {
                Image currentImage = appended_img;
                Image img = window.picture.Image;

                int margin = 60;
                int width = currentImage.Width;
                int height = currentImage.Height + img.Height + margin;

                Image bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);

                g.Clear(Color.White);

                g.DrawImage(currentImage, new Point(0, 0));
                g.DrawImage(img, new Point(0, currentImage.Height + margin));

                this.appended_img = bitmap;
                currentImage.Dispose();
            } else
            {
                this.appended_img = QR;
            }
            window.picture.Image = QR;
        }

        public Image getAppendedImage() {
            return this.appended_img;
        }

        public static Generator getGenerator()
        {
            if(gen == null)
            {
                gen = new Generator();
            }
            return gen;
        }

    }
}
