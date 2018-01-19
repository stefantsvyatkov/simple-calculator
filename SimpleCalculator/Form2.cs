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
            language.Sorted = true;
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
                if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "bg")
                {
                Properties.Settings.Default.appLanguage = CultureInfo.CreateSpecificCulture("en");
                }
            }
            else
            {
                if (Properties.Settings.Default.appLanguage.TwoLetterISOLanguageName != "bg")
                {
                Properties.Settings.Default.appLanguage = CultureInfo.CreateSpecificCulture("bg");
                }
            }
            Properties.Settings.Default.Save();
            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName != Properties.Settings.Default.appLanguage.TwoLetterISOLanguageName)
            {
                DialogResult questionResult = ShowQuestionMessage();
                if (questionResult == DialogResult.Yes)
                {
                    ShowInformationMessage();
Application.Restart();
}
                if (questionResult == DialogResult.No)
                {
                    cancel.PerformClick();
                }
            }
            else
            {
                cancel.PerformClick();
            }
            }

        public DialogResult ShowQuestionMessage()
        {
            string messageStr = rm.GetString("questionText");
            string messageTitle = rm.GetString("questionTitle");
          DialogResult result = MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
}

       public void ShowInformationMessage()
        {
            string messageStr = rm.GetString("informationMessageText");
            string messageTitle = rm.GetString("informationMessageTitle");
            MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
}

    }
}
