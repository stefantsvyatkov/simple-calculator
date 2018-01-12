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
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.GetCultureInfo("en");
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

        decimal currentNum = decimal.MinValue;
        decimal resultNum = 0m;
       string operation = string.Empty;
        int resultPressCount = 0;

        private void GetCurrentNumber()
        {
            resultPressCount = 0;
            if (!CheckInputValidation(numberText.Text))
            {
                ShowInvalidNumberMessage();
            }
            else
            {
                currentNum = decimal.Parse(numberText.Text);
            }
numberText.Text = string.Empty;
            numberText.Focus();
        }

            private void Clear_Click(object sender, EventArgs e)
        {
            currentNum = decimal.MinValue;
            resultNum = decimal.MinValue;
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

        bool invalidNumberEntered = false;

        private void Result_Click(object sender, EventArgs e)
        {
            resultPressCount++;
            if (currentNum == decimal.MinValue || operation == string.Empty || (resultPressCount > 1 && !invalidNumberEntered))
            {
                ShowMakeOperationMessage();
                numberText.Focus();
            }
            else
            {
                if (!CheckInputValidation(numberText.Text))
                {
                    ShowInvalidNumberMessage();
                    invalidNumberEntered = true;
                    numberText.Focus();
                    numberText.Text = string.Empty;
                    return;
                }
                else
                {
                    resultNum = decimal.Parse(numberText.Text);
                    invalidNumberEntered = false;
                }
               currentNum = MakeCalculation(operation, currentNum, resultNum);
numberText.Visible = false;
                numberText.Visible = true;
numberText.Text = currentNum.ToString("0.##");
                numberText.Focus();
                }
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

        private bool CheckInputValidation(string str)
        {
            decimal num;
            bool checker = decimal.TryParse(str, out num);
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
}
}
                    