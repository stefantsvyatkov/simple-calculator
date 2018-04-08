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
            if (GetSettingValue("autoCopying") == "true")
            {
                autoCopyingChecker = true;
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
        
    private void CreateAutoCopyingMenuItem()
    {
        ToolStripMenuItem autoCopying = new ToolStripMenuItem
        {
            Text = rm.GetString("autoCopyingMenuItem"),
            ShortcutKeys = Keys.Control | Keys.Shift | Keys.C,
            ShowShortcutKeys = true
        };
            if (autoCopyingChecker)
            {
                autoCopying.Checked = true;
            }
        autoCopying.Click += new EventHandler(AutoCopying_Click);
        myMenu.Items.Add(autoCopying);
    }

    private void MyMenu_Opened(object sender, EventArgs e)
        {
            CreateAutoCopyingMenuItem();
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
                    this.Size = new System.Drawing.Size(240, 130);
                result.Location = new Point(60, 60);
                }

        private void ShowButtons_click(object sender, EventArgs e)
        {
            add.Visible = true;
                subtract.Visible = true;
                multiply.Visible = true;
                divide.Visible = true;
                percent.Visible = true;
    this.Size = new System.Drawing.Size(240, 280);
                result.Location = new Point(60, 210);
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

        bool autoCopyingChecker = false;

        private void AutoCopying_Click(object sender, EventArgs e)
        {
            if (!autoCopyingChecker)
            {
                autoCopyingChecker = true;
            }
            else
            {
                autoCopyingChecker = false;
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
            if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.C)
            {
                    e.SuppressKeyPress = true;
                if (!autoCopyingChecker)
                {
                    TalkString(rm.GetString("autoCopyingOnMessage"));
                    AutoCopying_Click(new object(), new EventArgs());
                }
                else
                {
                    TalkString(rm.GetString("autoCopyingOffMessage"));
                    AutoCopying_Click(new object(), new EventArgs());
}
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                if (numberText.Text != string.Empty)
                {
                    e.SuppressKeyPress = true;
                    numberText.SelectAll();
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                numberText.Text += Clipboard.GetText();
                TalkString(numberText.Text);
                numberText.SelectionStart = numberText.Text.Length;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                if (numberText.Text != string.Empty)
                {
                    e.SuppressKeyPress = true;
                    Clipboard.SetText(numberText.SelectedText);
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                if (numberText.Text != string.Empty)
                {
                    e.SuppressKeyPress = true;
                    Clipboard.SetText(numberText.SelectedText);
                    numberText.Text = numberText.Text.Replace(numberText.SelectedText, string.Empty);
                    numberText.SelectionStart = numberText.Text.Length;
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
            operationButtonPressed = true;
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
                ClearNumberTextField();
                operationButtonPressed = false;
                return;
            }
                operationMade = true;
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
                List<decimal> numbers = TakeExpressionNumbers(numberText.Text);
                List<string> operatorsList = TakeExpressionOperators(numberText.Text);
                CalculateExpression(numbers, operatorsList);
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
            if (currentNum == 0 && (operation == "*" || operation == "/" || operation == "%"))
            {
                currentNum = 0;
                return currentNum;
            }
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

        char[] operators = new char[] { '+', '-', '*', '/', '%' };
        char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        private bool CheckInputValidation(string text)
        {
            bool checker = true;
            if (text == string.Empty)
            {
                checker = false;
                return checker;
            }
            if (text[0] == separator)
            {
                checker = false;
                return checker;
}
            if (operationButtonPressed && !decimal.TryParse(numberText.Text, out decimal num))
            {
                checker = false;
                return checker;
            }
                    for (int i = 0; i < text.Length - 1; i++)
            {
                bool checkCurrentAndNextSymbol = (operators.Contains(text[i]) || (text[i] == separator)) && (operators.Contains(text[i + 1]) || (text[i + 1] == separator));
if (checkCurrentAndNextSymbol)
                {
                    checker = false;
                    return checker;
                    }
            }
            if (!char.IsDigit(text[text.Length - 1]))
            {
                checker = false;
            }
            return checker;
}

        private bool CheckFirstSymbolForOperator()
        {
            return operators.Contains(numberText.Text[0]);
            }

private List<decimal> TakeExpressionNumbers(string text)
        {
            List<decimal> numbers = new List<decimal>();
            if (CheckFirstSymbolForOperator())
            {
                text = text.Substring(1, text.Length - 1);
            }
                numbers = text.Split(operators)
                .Select(decimal.Parse)
                .ToList();
return numbers;
}

        private List<string> TakeExpressionOperators(string text)
        {
            List<string> operatorsList = new List<string>();
            foreach (char symbol in text)
            {
                if (operators.Contains(symbol))
                {
                    operatorsList.Add(symbol.ToString());
                }
            }
            return operatorsList;
}

        private void CalculateExpression(List<decimal> numbers, List<string> operatorsList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int operatorIndex = i - 1;
                bool currentNumIsNegative = (currentNum < 0 && (numberText.Text[0] == '-'));
                if ((i == 0) && (numbers.Count > 1) && currentNumIsNegative)
                {
                    continue;
                }
                if (i == 0)
                {
if (CheckFirstSymbolForOperator())
                    {
                            currentNum = MakeCalculation(operatorsList[0], currentNum, numbers[i]);
                        operatorsList.RemoveAt(0);
                        continue;
                    }
                    currentNum = numbers[0];
                }
                else
                {
                    if ((operatorIndex != operatorsList.Count - 1) && (operatorsList[operatorIndex + 1] == "%"))
                    {
                        decimal percentValue = MakeCalculation("%", numbers[i], numbers[i + 1]);
                        currentNum = MakeCalculation(operatorsList[operatorIndex], currentNum, percentValue);
                        operatorsList.RemoveAt(operatorIndex + 1);
                        numbers.RemoveAt(i + 1);
                        continue;
                    }
                    currentNum = MakeCalculation(operatorsList[operatorIndex], currentNum, numbers[i]);
                }
            }
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

        private bool CheckTextForOperator(string text)
        {
            bool checker = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (operators.Contains(text[i]))
                {
                    checker = true;
                    break;
                }
            }
            return checker;
        }
        
        private void ShowResultOutput()
        {
            numberText.Text = currentNum.ToString("G29");
numberText.SelectionStart = numberText.Text.Length;
            TalkString(numberText.Text);
            if (autoCopyingChecker)
            {
                Clipboard.SetText(numberText.Text);
            }
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
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = true;
                numberText.Text += separator;
                numberText.SelectionStart = numberText.Text.Length;
                return;
            }
if (!char.IsDigit(e.KeyChar) && !operators.Contains(e.KeyChar) && e.KeyChar != separator && e.KeyChar != 8)
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
                if (autoCopyingChecker && GetSettingValue("autoCopying") != "true")
                {
                    UpdateSetting("autoCopying", "true");
                }
                else if (!autoCopyingChecker && GetSettingValue("autoCopying") != "false")
                {
                    UpdateSetting("autoCopying", "false");
                }
            }

        private void ClearNumberTextField()
        {
            numberText.Focus();
            numberText.Text = string.Empty;
}

    }
}
                    