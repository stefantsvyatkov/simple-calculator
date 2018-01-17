using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace SimpleCalculator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = rm.GetString("languageFormTitle");
            language.AccessibleName = rm.GetString("languageFormTitle");
            language.Items.Add(rm.GetString("languageBulgarian"));
            language.Items.Add(rm.GetString("languageEnglish"));
            language.SelectedIndex = 0;
            ok.Text = rm.GetString("okButton");
            cancel.Text = rm.GetString("cancelButton");
        }

        ResourceManager rm = new ResourceManager("SimpleCalculator.ProjectResource", Assembly.GetExecutingAssembly());

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (language.SelectedItem.ToString() == rm.GetString("languageEnglish"))
            {
                Properties.Settings.Default.appLanguage = "en";
                }
            else
            {
                Properties.Settings.Default.appLanguage = "bg";
                }
            Properties.Settings.Default.Save();
            Application.Restart();
        }

    }
}
