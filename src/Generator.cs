using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

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
