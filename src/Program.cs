using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.QR_GEN
{
    static class Program
    {

        private static Mutex mutex = new Mutex(false, "35b778e7-1b7d-4494-823f-c15f476729d7");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(!mutex.WaitOne(0, false))
            {
                MessageBox.Show("can only run a single instance of this program!", "error");
                return;
            }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Window());
        }
    }
}
