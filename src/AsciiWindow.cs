using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_GEN.src
{
    public partial class AsciiWindow : Form
    {
        public AsciiWindow()
        {
            InitializeComponent();
        }

        private void AsciiWindow_Load(object sender, EventArgs e)
        {

        }

        public string QRcode
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value;  }
        }

    }
}
