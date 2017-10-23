using System;
using System.Collections.Generic;
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

        public Image GenerateQR(string text)
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
            //TODO: check if we want to implement this.
            Bitmap img = new Bitmap(image);
            BarcodeReader reader = new BarcodeReader();

            Result result = reader.Decode(img);

            return result.ToString().Trim();
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
