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
            if (window.textbox.Text == "") { return; }
            Image QR = generateQR(window.textbox.Text);
            //FileStream fs = File.Create("qr.jpg");
            Clipboard.SetImage(QR);
            window.picture.Image = QR;
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
