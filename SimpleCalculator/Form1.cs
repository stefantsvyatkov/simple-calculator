﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;
using DavyKager;
using System.Configuration;
using System.Diagnostics;

namespace SimpleCalculator
{
public partial class Form1: Form
    {
        public Form1()
        {
            InitializeSettings();
            if (GetSettingValue("firstStart") == "false")
            {
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(GetSettingValue("appLanguage"));
            }
            InitializeComponent();
            ManipulateOperationButtonsVisibility();
            CreateContextMenu();
            }

        ContextMenuStrip myMenu = new ContextMenuStrip();
        System.Configuration.Configuration mySettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

private void CreateContextMenu()
        {
            CreateLanguageMenuItem();
            CreateResetSettingsMenuItem();
            CreateOpenHelpMenuItem();
            myMenu.Opened += new EventHandler(MyMenu_Opened);
            myMenu.Closed += new ToolStripDropDownClosedEventHandler(MyMenu_Closed);
                    this.ContextMenuStrip = myMenu;
                    numberText.ContextMenuStrip = myMenu;
                }

        private void CreateLanguageMenuItem()
        {
            ToolStripMenuItem chooseLanguage = new ToolStripMenuItem
            {
                Text = rm.GetString("languageMenuItem"),
                ShortcutKeys = Keys.Control | Keys.L,
            ShowShortcutKeys = true
};
            chooseLanguage.Click += new EventHandler(ChooseLanguage_Click);
            myMenu.Items.Add(chooseLanguage);
        }

        private void CreateResetSettingsMenuItem()
        {
            ToolStripMenuItem resetSettings = new ToolStripMenuItem
            {
                Text = rm.GetString("resetSettingsMenuItem"),
                ShortcutKeys = Keys.Control | Keys.R,
                ShowShortcutKeys = true
            };
        resetSettings.Click += new EventHandler(ResetSettings_Click);
            myMenu.Items.Add(resetSettings);
        }

        private void CreateOpenHelpMenuItem()
        {
            ToolStripMenuItem openHelpFile = new ToolStripMenuItem
            {
                Text = rm.GetString("openHelpFileMenuItem"),
                ShortcutKeys = Keys.Control | Keys.H,
                ShowShortcutKeys = true
            };
            openHelpFile.Click += new EventHandler(OpenHelpFile_Click);
            myMenu.Items.Add(openHelpFile);
        }
        
        private void MyMenu_Opened(object sender, EventArgs e)
        {
            if (GetSettingValue("buttonsHidden") == "true")
            {
                ToolStripMenuItem showButtons = new ToolStripMenuItem
                {
                    Text = rm.GetString("showButtonsMenuItem"),
                    ShortcutKeys = Keys.Control | Keys.B,
                ShowShortcutKeys = true
};
                showButtons.Click += new EventHandler(ShowButtons_click);
                myMenu.Items.Add(showButtons);
            }
            else
            {
                ToolStripMenuItem hideButtons = new ToolStripMenuItem
                {
                    Text = rm.GetString("hideButtonsMenuItem"),
                    ShortcutKeys = Keys.Control | Keys.B,
                ShowShortcutKeys = true
                };
                hideButtons.Click += new EventHandler(HideButtons_click);
                myMenu.Items.Add(hideButtons);
            }
                }

        private void MyMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            myMenu.Items.Clear();
            CreateLanguageMenuItem();
            CreateResetSettingsMenuItem();
            CreateOpenHelpMenuItem();
        }
        
        private void ChooseLanguage_Click(object sender, EventArgs e)
        {
            Form2 languageForm = new Form2();
            languageForm.Show();
        }

        private void HideButtons_click(object sender, EventArgs e)
        {
    add.Visible = false;
                subtract.Visible = false;
                multiply.Visible = false;
                divide.Visible = false;
                percent.Visible = false;
                    this.Size = new System.Drawing.Size(300, 125);
                result.Location = new Point(80, 50);
            UpdateSetting("buttonsHidden", "true");
                }

        private void ShowButtons_click(object sender, EventArgs e)
        {
            add.Visible = true;
                subtract.Visible = true;
                multiply.Visible = true;
                divide.Visible = true;
                percent.Visible = true;
    this.Size = new System.Drawing.Size(300, 280);
                result.Location = new Point(80, 200);
            UpdateSetting("buttonsHidden", "false");
            }

        private void ResetSettings_Click(object sender, EventArgs e)
        {
            Form2 languageForm = new Form2();
            languageForm.ResetDefaultSettings();
        }

        private void OpenHelpFile_Click(object sender, EventArgs e)
        {
            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                Process.Start(@"Docs\User Guide EN.html");
            }
            else
            {
                Process.Start(@"Docs\User Guide BG.html");
            }
        }

ResourceManager rm = new ResourceManager("SimpleCalculator.ProjectResource", Assembly.GetExecutingAssembly());
        
        private void Form1_Shortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Environment.Exit(1);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.B)
            {
                e.SuppressKeyPress = true;
                if (GetSettingValue("buttonsHidden") == "true")
                {
                    UpdateSetting("buttonsHidden", "false");
                    ManipulateOperationButtonsVisibility();
                    TalkString(rm.GetString("buttonsShownMessage"));
                }
                else
                {
                    UpdateSetting("buttonsHidden", "true");
ManipulateOperationButtonsVisibility();
                    TalkString(rm.GetString("buttonsHiddenMessage"));
                }
                }
        }

        decimal currentNum = 0;
        decimal secondNum = 0;
       string operation = string.Empty;
        bool operationMade = false;
        bool operationButtonPressed = false;

        private void GetCurrentNumber()
        {
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
            }
            else
            {
                operationMade = true;
                operationButtonPressed = true;
                currentNum = decimal.Parse(numberText.Text);
                }
numberText.Text = string.Empty;
            numberText.Focus();
        }

            private void Clear_Click(object sender, EventArgs e)
        {
            if (!clear.Focused)
            {
            TalkString(rm.GetString("clearButton"));
            }
            currentNum = 0;
            secondNum = 0;
            operationMade = false;
            operationButtonPressed = true;
            operation = string.Empty;
            numberText.Text = string.Empty;
            numberText.Focus();
            }
        
private void Add_Click(object sender, EventArgs e)
        {
            if (!add.Focused)
            {
            TalkString(rm.GetString("addButton"));
            }
            operation = "+";
            GetCurrentNumber();
                }
        
        private void Subtract_Click(object sender, EventArgs e)
        {
            if (!subtract.Focused)
            {
            TalkString(rm.GetString("subtractButton"));
            }
            operation = "-";
            GetCurrentNumber();
            }

        private void Multiply_Click(object sender, EventArgs e)
        {
            if (!multiply.Focused)
            {
            TalkString(rm.GetString("multiplyButton"));
            }
            operation = "*";
            GetCurrentNumber();
}

        private void Divide_Click(object sender, EventArgs e)
        {
            if (!divide.Focused)
            {
            TalkString(rm.GetString("divideButton"));
            }
            operation = "/";
            GetCurrentNumber();
}

        private void Percent_Click(object sender, EventArgs e)
        {
            if (!percent.Focused)
            {
            TalkString(rm.GetString("percentButton"));
            }
            operation = "%";
            GetCurrentNumber();
}
        
        private void Result_Click(object sender, EventArgs e)
        {
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
                numberText.Focus();
                numberText.Text = string.Empty;
                return;
            }
            if (CheckTextForOperator(numberText.Text))
            {
                operationMade = true;
                operation = numberText.Text[GetOperatorIndex(numberText.Text)].ToString();
                secondNum = decimal.Parse(numberText.Text.Substring(GetOperatorIndex(numberText.Text) + 1, (numberText.Text.Length - 1) - GetOperatorIndex(numberText.Text)));
                if (GetOperatorIndex(numberText.Text) > 0)
                {
                    currentNum = decimal.Parse(numberText.Text.Substring(0, GetOperatorIndex(numberText.Text)));
                }
                currentNum = MakeCalculation(operation, currentNum, secondNum);
                ShowResultOutput();
                operationMade = false;
                return;
            }
            if (currentNum == 0 || operation == string.Empty || !operationMade)
            {
                ShowMakeOperationMessage();
                numberText.Focus();
                return;
            }
                secondNum = decimal.Parse(numberText.Text);
                currentNum = MakeCalculation(operation, currentNum, secondNum);
                ShowResultOutput();
            operationMade = false;
            operationButtonPressed = false;
                }

        private decimal MakeCalculation(string operation, decimal currentNum, decimal resultNum)
        {
            switch (operation)
            {
                case "+":
                    currentNum += resultNum;
                    break;
                case "-":
                    currentNum -= resultNum;
                    break;
                case "*":
                    currentNum *= resultNum;
                    break;
                case "/":
                    currentNum /= resultNum;
                    break;
                case "%":
                    currentNum /= 100.0m;
                    currentNum *= resultNum;
                    break;
            }
            return currentNum;
        }

        private bool CheckInputValidation(string text)
        {
            bool checker = true;
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            char[] operators = new char[] { '+', '-', '*', '/', '%' };
            int operatorsCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsNumber(text[i]) && text[i] != separator && !operators.Contains(text[i]))
                {
                    checker = false;
                    break;
                }
                if (operators.Contains(text[i]))
                {
                    operatorsCount++;
                }
            }
            if (text == string.Empty || operatorsCount > 1)
            {
                checker = false;
            }
            return checker;
}

private void ShowInvalidNumberMessage()
        {
                string messageStr = rm.GetString("invalidNumberMessageText");
            string messageTitle = rm.GetString("errorTitle");
                MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        private void ShowMakeOperationMessage()
        {
            string messageStr = rm.GetString("makeOperationMessageText");
            string messageTitle = rm.GetString("errorTitle");
            MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
}

        private int GetOperatorIndex(string text)
        {
            int index = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                       index = i;
                        break;
                        }
            }
            return index;
}

        private bool CheckTextForOperator(string text)
        {
            bool checker = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '+' || text[i] == '-' || text[i] == '*' || text[i] == '/' || text[i] == '%')
                {
                    checker = true;
                    break;
                }
            }
            if (GetOperatorIndex(text) == text.Length - 1)
            {
                checker = false;
            }
            return checker;
        }

        bool resultPressed = false;
        
        private void ShowResultOutput()
        {
            numberText.Text = currentNum.ToString();
numberText.SelectionStart = numberText.Text.Length;
            TalkString(numberText.Text);
            Clipboard.SetText(numberText.Text);
            numberText.Focus();
            resultPressed = true;
        }

        private void TalkString(string text)
        {
            Tolk.Load();
            Tolk.Output(text, true);
            Tolk.Unload();
}

        private void NumberText_TextChanged(object sender, EventArgs e)
        {
            if (resultPressed && !operationButtonPressed)
            {
            numberText.Text = numberText.Text[numberText.Text.Length - 1].ToString();
                numberText.SelectionStart = numberText.Text.Length;
                resultPressed = false;
                }
        }

        private void ManipulateOperationButtonsVisibility()
        {
            if (GetSettingValue("buttonsHidden") == "true")
            {
                HideButtons_click(new object(), new EventArgs());
            }
            else
            {
                ShowButtons_click(new object(), new EventArgs());
            }
        }

        public void UpdateSetting(string key, string value)
        {
            mySettings.AppSettings.Settings[key].Value = value;
            mySettings.Save();
            }

        public string GetSettingValue(string key)
        {
            return mySettings.AppSettings.Settings[key].Value;
}
        
        public void InitializeSettings()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "Settings.config"
            };
            mySettings = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None) as Configuration;
}

}
}
                    