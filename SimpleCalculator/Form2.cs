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
            this.Text = rm.GetString("languageMenuItem");
            languageLabel.Text = rm.GetString("languageComboBoxTitle");
            language.AccessibleName = rm.GetString("languageComboBoxTitle");
            language.Sorted = true;
            language.Items.Add(rm.GetString("languageBulgarian"));
            language.Items.Add(rm.GetString("languageEnglish"));
            language.SelectedIndex = 0;
            ok.Text = rm.GetString("okButton");
            cancel.Text = rm.GetString("cancelButton");
            if (Properties.Settings.Default.firstStart)
            {
                ShowWelcomeMessage();
            }
            }

        ResourceManager rm = new ResourceManager("SimpleCalculator.ProjectResource", Assembly.GetExecutingAssembly());

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.firstStart)
            {
                Properties.Settings.Default.appLanguage = SetAppLanguage();
                Properties.Settings.Default.firstStart = false;
                Properties.Settings.Default.Save();
                Application.Restart();
                return;
            }
            Properties.Settings.Default.appLanguage = SetAppLanguage();
            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName != Properties.Settings.Default.appLanguage)
            {
                DialogResult questionResult = ShowQuestionMessage();
                if (questionResult == DialogResult.Yes)
                {
                    ShowInformationMessage();
                    Properties.Settings.Default.Save();
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

        public string SetAppLanguage()
        {
           string lang = string.Empty;
            if (language.SelectedItem.ToString() == rm.GetString("languageEnglish"))
            {
                  lang = "en";
                }
            else
            {
                   lang = "bg";
            }
            return lang;
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

        public void ShowWelcomeMessage()
        {
            string messageStr = rm.GetString("welcomeMessageText");
            string messageTitle = rm.GetString("welcomeMessageTitle");
            MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
