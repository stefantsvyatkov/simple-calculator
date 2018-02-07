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

            Form1 mainForm = new Form1();
            Form2 languageForm = new Form2();
            
            if (mainForm.GetSettingValue("firstStart") == "true")
            {
                Application.Run(languageForm);
            }
            else
            {
                Application.Run(mainForm);
            }
                }
        }
}
