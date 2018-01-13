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

namespace SimpleCalculator
{
public partial class Form1: Form
    {
        public Form1()
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture =
            //    System.Globalization.CultureInfo.GetCultureInfo("en");
            InitializeComponent();
        }

        private void Form1_Close(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
        }

        decimal currentNum = 0;
        decimal resultNum = 0;
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
            resultNum = 0;
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
                resultNum = decimal.Parse(numberText.Text.Substring(GetOperatorIndex(numberText.Text) + 1, (numberText.Text.Length - 1) - GetOperatorIndex(numberText.Text)));
                if (GetOperatorIndex(numberText.Text) > 0)
                {
                    currentNum = decimal.Parse(numberText.Text.Substring(0, GetOperatorIndex(numberText.Text)));
                }
                currentNum = MakeCalculation(operation, currentNum, resultNum);
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
                resultNum = decimal.Parse(numberText.Text);
                currentNum = MakeCalculation(operation, currentNum, resultNum);
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
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsNumber(text[i]) && text[i] != separator && !operators.Contains(text[i]))
                {
                    checker = false;
                    break;
                }
            }
            if (text == string.Empty)
            {
                checker = false;
            }
            return checker;
}

private void ShowInvalidNumberMessage()
        {
                string messageStr = "Please enter a valid number!";
            string messageTitle = "Error";
                if (CultureInfo.CurrentUICulture.Name == "bg-BG")
                {
                    messageStr = "Моля въведете валидно число!";
                messageTitle = "Грешка";
                }
                MessageBox.Show(messageStr, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        private void ShowMakeOperationMessage()
        {
            string messageStr = "Please make an operation!";
            string messageTitle = "Error";
            if (CultureInfo.CurrentUICulture.Name == "bg-BG")
            {
                messageStr = "Моля извършете операция!";
                messageTitle = "Грешка";
            }
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
            int operatorCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '+' || text[i] == '-' || text[i] == '*' || text[i] == '/' || text[i] == '%')
                {
                    operatorCount++;
                }
            }
            if (operatorCount == 1 && GetOperatorIndex(text) != text.Length - 1)
            {
                checker = true;
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
                    