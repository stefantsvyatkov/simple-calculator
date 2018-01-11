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
        
        private void Form1_KeyShortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                add.PerformClick();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                subtract.PerformClick();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.M)
            {
                e.SuppressKeyPress = true;
                multiply.PerformClick();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.D)
            {
                e.SuppressKeyPress = true;
                divide.PerformClick();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.P)
            {
                e.SuppressKeyPress = true;
                percent.PerformClick();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.C)
            {
                e.SuppressKeyPress = true;
                clear.PerformClick();
            }
            }
        
        double currentNum = double.MinValue;
        double resultNum = 0;
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
                currentNum = double.Parse(numberText.Text);
            }
numberText.Text = string.Empty;
            numberText.Focus();
        }

            private void Clear_Click(object sender, EventArgs e)
        {
            currentNum = double.MinValue;
            resultNum = double.MinValue;
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
            if (currentNum == double.MinValue || operation == string.Empty || (resultPressCount > 1 && !invalidNumberEntered))
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
                    resultNum = double.Parse(numberText.Text);
                    invalidNumberEntered = false;
                }
               currentNum = MakeCalculation(operation, currentNum, resultNum);
numberText.Visible = false;
                numberText.Visible = true;
numberText.Text = currentNum.ToString("0.##");
                numberText.Focus();
            }
}

        private double MakeCalculation(string operation, double currentNum, double resultNum)
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
                    currentNum /= 100.0;
                    currentNum *= resultNum;
                    break;
            }
            return currentNum;
        }

        private bool CheckInputValidation(string str)
        {
            double num;
            bool checker = double.TryParse(str, out num);
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
                    