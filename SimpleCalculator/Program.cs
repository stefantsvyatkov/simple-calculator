using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace SimpleCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.firstStart)
            {
                Application.Run(new Form2());
            }
            else
            {

            Application.Run(new Form1());
            }
        }
    }
}
