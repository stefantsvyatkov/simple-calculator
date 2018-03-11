using System;
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
using System.Media;

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
            if (GetSettingValue("buttonsHidden") == "true")
            {
                HideButtons_click(new object(), new EventArgs());
                }
            CreateContextMenu();
            numberText.KeyPress += new KeyPressEventHandler(NumberText_KeyPress);
            this.FormClosing += new FormClosingEventHandler(Form1_Closing);
            }

        ContextMenuStrip myMenu = new ContextMenuStrip();
        Configuration mySettings;

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
            if (add.Visible == false)
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
                Clear_Click(new object(), new EventArgs());
                }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.B)
            {
                e.SuppressKeyPress = true;
                if (add.Visible == false)
                {
                    ShowButtons_click(new object(), new EventArgs());
                    TalkString(rm.GetString("buttonsShownMessage"));
                }
                else
                {
                    HideButtons_click(new object(), new EventArgs());
                    TalkString(rm.GetString("buttonsHiddenMessage"));
                }
                }
        }

        decimal currentNum = 0;
        decimal secondNum = 0;
       string operation = string.Empty;
        bool operationMade = false;
        bool operationButtonPressed = false;
        string previousOperation = string.Empty;

        private void ProcessCurrentNumber()
        {
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
                ClearNumberTextField();
                return;
            }
                operationMade = true;
                operationButtonPressed = true;
                if (!resultPressed)
                {
                if (currentNum == 0)
                {
                    currentNum = decimal.Parse(numberText.Text);
                }
                else
                {
                    secondNum = decimal.Parse(numberText.Text);
                    currentNum = MakeCalculation(previousOperation, currentNum, secondNum);
                    }
            }
                else
                {
                    resultPressed = false;
                }
            previousOperation = operation;
            ClearNumberTextField();
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
            operationButtonPressed = false;
            resultPressed = false;
            operation = string.Empty;
            ClearNumberTextField();
            }
        
private void Add_Click(object sender, EventArgs e)
        {
            if (!add.Focused)
            {
            TalkString(rm.GetString("addButton"));
            }
            operation = "+";
            ProcessCurrentNumber();
                }
        
        private void Subtract_Click(object sender, EventArgs e)
        {
            if (!subtract.Focused)
            {
            TalkString(rm.GetString("subtractButton"));
            }
            operation = "-";
            ProcessCurrentNumber();
            }

        private void Multiply_Click(object sender, EventArgs e)
        {
            if (!multiply.Focused)
            {
            TalkString(rm.GetString("multiplyButton"));
            }
            operation = "*";
            ProcessCurrentNumber();
}

        private void Divide_Click(object sender, EventArgs e)
        {
            if (!divide.Focused)
            {
            TalkString(rm.GetString("divideButton"));
            }
            operation = "/";
            ProcessCurrentNumber();
}

        private void Percent_Click(object sender, EventArgs e)
        {
            if (!percent.Focused)
            {
            TalkString(rm.GetString("percentButton"));
            }
            operation = "%";
            ProcessCurrentNumber();
}

        bool resultPressed = false;

        private void Result_Click(object sender, EventArgs e)
        {
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
                ClearNumberTextField();
                return;
            }
            if (operationButtonPressed)
            {
                secondNum = decimal.Parse(numberText.Text);
                currentNum = MakeCalculation(operation, currentNum, secondNum);
                ShowResultOutput();
                resultPressed = true;
                operationButtonPressed = false;
                operationMade = false;
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
                }
                }

        private decimal MakeCalculation(string operation, decimal currentNum, decimal secondNum)
        {
            switch (operation)
            {
                case "+":
                    currentNum += secondNum;
                    break;
                case "-":
                    currentNum -= secondNum;
                    break;
                case "*":
                    currentNum *= secondNum;
                    break;
                case "/":
                    currentNum /= secondNum;
                    break;
                case "%":
                    currentNum /= 100.0m;
                    currentNum *= secondNum;
                    break;
            }
            return currentNum;
        }

        private bool CheckInputValidation(string text)
        {
            bool checker = true;
            char[] operators = new char[] { '+', '-', '*', '/', '%' };
            int operatorsCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (operators.Contains(text[i]))
                {
                    operatorsCount++;
                }
            }
            bool checkForNegativeNumber = (operatorsCount > 1 && numberText.Text[0] != '-');
            bool checkForInvalidFirstNumber = (currentNum == 0 && !char.IsDigit(numberText.Text[0]));
            if (text == string.Empty || checkForInvalidFirstNumber || checkForNegativeNumber)
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
        
        private void ShowResultOutput()
        {
            numberText.Text = currentNum.ToString("G29");
numberText.SelectionStart = numberText.Text.Length;
            TalkString(numberText.Text);
            Clipboard.SetText(numberText.Text);
            numberText.Focus();
            }

        private void TalkString(string text)
        {
            Tolk.Load();
            Tolk.Output(text, true);
            Tolk.Unload();
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

        private void NumberText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            char[] allowedSymbols = new char[] { '+', '-', '*', '/', '%', separator};
            if (!char.IsDigit(e.KeyChar) && !allowedSymbols.Contains(e.KeyChar) && e.KeyChar != 8)
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (add.Visible == false && GetSettingValue("buttonsHidden") != "true")
            {
                UpdateSetting("buttonsHidden", "true");
            }
            else if (add.Visible == true && GetSettingValue("buttonsHidden") != "false")
            {
                UpdateSetting("buttonsHidden", "false");
            }
}

        private void ClearNumberTextField()
        {
            numberText.Focus();
            numberText.Text = string.Empty;
}

    }
}
                    