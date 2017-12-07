using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
namespace QR_GEN.src
{
    class Generator
    {

        public static Generator gen;
        
        private Generator(){} /*do not instance it outside of this class*/

        public Image GenerateQR(string text)
        {
            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData data = gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            return new Bitmap(code.GetGraphic(20), 260, 260);
        }

        public Image AddQRLogo(Image img, Image qr)
        {
            if(img.Width != 45 && img.Height != 45)
            {
                //resize image and make a error aswell.
                MessageBox.Show("the correct size is 45*45 however we try to resize it", "warning");
                Bitmap b = new Bitmap(img, 45, 45);
                img = b;
            }
            
            //create new bitmap on base of QR
            Bitmap a = new Bitmap(qr, 260, 260);
            Graphics g = Graphics.FromImage(a);
            g.DrawImage(img, new Point(a.Height/2-img.Height+22, a.Width/2-img.Width+22));
            g.Save();

            return a;
        }

        public string GenerateAsciiQR(string text)
        {
            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData data = gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            AsciiQRCode ascii = new AsciiQRCode(data);
            return ascii.GetGraphic(1);
        }

        public Image GenerateAppendedImage(string text, Image orginal)
        {

            Image img = this.GenerateQR(text);

            int marginheight = 20;

            Bitmap newimage = new Bitmap(orginal.Width, orginal.Height+marginheight+img.Height);

            using (Graphics gfx = Graphics.FromImage(newimage))
            {
                gfx.DrawImage(orginal, 0, 0);
                gfx.DrawImage(img, 0, marginheight+orginal.Height);
            }
            return newimage;
        }

        [Obsolete]
        public string ReadQR(Image image)
        {       
            return null;
        }

        public static Generator GetGenerator()
        {
            if(gen == null)
            {
                gen = new Generator();
            }
            return gen;
        }

    }
}
