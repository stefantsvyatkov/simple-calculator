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

namespace SimpleCalculator
{
public partial class Form1: Form
    {

        public string appCurrentLanguage = Properties.Settings.Default.appLanguage;

        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(appCurrentLanguage);
            InitializeComponent();
            if (Properties.Settings.Default.buttonsHidden)
            {
                HideButtons_click(new object(), new EventArgs());
            }
            else
            {
                ShowButtons_click(new object(), new EventArgs());
            }
            CreateContextMenu();
        }

        ContextMenuStrip myMenu = new ContextMenuStrip();

        private void CreateContextMenu()
        {
            CreateLanguageMenuItem();
            myMenu.Opened += new EventHandler(MyMenu_Opened);
            myMenu.Closed += new ToolStripDropDownClosedEventHandler(MyMenu_Closed);
                    this.ContextMenuStrip = myMenu;
                    numberText.ContextMenuStrip = myMenu;
                }

        private void CreateLanguageMenuItem()
        {
            ToolStripMenuItem chooseLanguage = new ToolStripMenuItem(rm.GetString("languageMenuItem"));
            chooseLanguage.Click += new EventHandler(ChooseLanguage_Click);
            myMenu.Items.Add(chooseLanguage);
        }

private void MyMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            myMenu.Items.Clear();
            CreateLanguageMenuItem();
        }

        private void MyMenu_Opened(object sender, EventArgs e)
        {
            if (hideButtonsClicked)
            {
                ToolStripMenuItem showButtons = new ToolStripMenuItem(rm.GetString("showButtonsMenuItem"));
                showButtons.Click += new EventHandler(ShowButtons_click);
                myMenu.Items.Add(showButtons);
            }
            else
            {
                ToolStripMenuItem hideButtons = new ToolStripMenuItem(rm.GetString("hideButtonsMenuItem"));
                hideButtons.Click += new EventHandler(HideButtons_click);
                myMenu.Items.Add(hideButtons);
            }
        }
        
        private void ChooseLanguage_Click(object sender, EventArgs e)
        {
            Form2 languageForm = new Form2();
            languageForm.Show();
        }

        bool hideButtonsClicked = Properties.Settings.Default.buttonsHidden;

        private void HideButtons_click(object sender, EventArgs e)
        {
    add.Visible = false;
                subtract.Visible = false;
                multiply.Visible = false;
                divide.Visible = false;
                percent.Visible = false;
                Properties.Settings.Default.buttonsHidden = true;
                    this.Size = new System.Drawing.Size(300, 125);
                result.Location = new Point(80, 50);
            Properties.Settings.Default.Save();
                }

        private void ShowButtons_click(object sender, EventArgs e)
        {
            add.Visible = true;
                subtract.Visible = true;
                multiply.Visible = true;
                divide.Visible = true;
                percent.Visible = true;
               Properties.Settings.Default.buttonsHidden = false;
    this.Size = new System.Drawing.Size(300, 280);
                result.Location = new Point(80, 200);
            Properties.Settings.Default.Save();
            }
        
      ResourceManager rm = new ResourceManager("SimpleCalculator.ProjectResource", Assembly.GetExecutingAssembly());
        
        private void Form1_Close(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
        }

        decimal currentNum = 0;
        decimal secondNum = 0;
       string operation = string.Empty;
        bool operationMade = false;

        private void GetCurrentNumber()
        {
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
            }
            else
            {
                operationMade = true;
                currentNum = decimal.Parse(numberText.Text);
                }
numberText.Text = string.Empty;
            numberText.Focus();
        }

            private void Clear_Click(object sender, EventArgs e)
        {
            currentNum = 0;
            secondNum = 0;
            operationMade = false;
            operation = string.Empty;
            numberText.Text = string.Empty;
            numberText.Focus();
            }
        
private void Add_Click(object sender, EventArgs e)
        {
            operation = "+";
            GetCurrentNumber();
}
        
        private void Subtract_Click(object sender, EventArgs e)
        {
            operation = "-";
            GetCurrentNumber();
            }

        private void Multiply_Click(object sender, EventArgs e)
        {
            operation = "*";
            GetCurrentNumber();
}

        private void Divide_Click(object sender, EventArgs e)
        {
            operation = "/";
            GetCurrentNumber();
}

        private void Percent_Click(object sender, EventArgs e)
        {
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

        private void ShowResultOutput()
        {
            numberText.Visible = false;
            numberText.Visible = true;
            numberText.Text = currentNum.ToString("0.##");
            numberText.Focus();
}

        

        }
}
                    