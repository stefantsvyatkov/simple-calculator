﻿namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numberLabel = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Subtract = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Button();
            this.numberText = new System.Windows.Forms.TextBox();
            this.percent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            resources.ApplyResources(this.numberLabel, "numberLabel");
            this.numberLabel.Name = "numberLabel";
            // 
            // clear
            // 
            resources.ApplyResources(this.clear, "clear");
            this.clear.Name = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Add
            // 
            resources.ApplyResources(this.Add, "Add");
            this.Add.Name = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Subtract
            // 
            resources.ApplyResources(this.Subtract, "Subtract");
            this.Subtract.Name = "Subtract";
            this.Subtract.UseVisualStyleBackColor = true;
            this.Subtract.Click += new System.EventHandler(this.Subtract_Click);
            // 
            // Multiply
            // 
            resources.ApplyResources(this.Multiply, "Multiply");
            this.Multiply.Name = "Multiply";
            this.Multiply.UseVisualStyleBackColor = true;
            this.Multiply.Click += new System.EventHandler(this.Multiply_Click);
            // 
            // divide
            // 
            resources.ApplyResources(this.divide, "divide");
            this.divide.Name = "divide";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.Divide_Click);
            // 
            // result
            // 
            resources.ApplyResources(this.result, "result");
            this.result.Name = "result";
            this.result.UseVisualStyleBackColor = true;
            this.result.Click += new System.EventHandler(this.Result_Click);
            // 
            // numberText
            // 
            resources.ApplyResources(this.numberText, "numberText");
            this.numberText.Name = "numberText";
            // 
            // percent
            // 
            resources.ApplyResources(this.percent, "percent");
            this.percent.Name = "percent";
            this.percent.UseVisualStyleBackColor = true;
            this.percent.Click += new System.EventHandler(this.Percent_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.result;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.percent);
            this.Controls.Add(this.numberText);
            this.Controls.Add(this.result);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.Multiply);
            this.Controls.Add(this.Subtract);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.numberLabel);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Subtract;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button result;
        private System.Windows.Forms.TextBox numberText;
        private System.Windows.Forms.Button percent;
    }
}

