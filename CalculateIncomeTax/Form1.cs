using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateIncomeTax
{
    public partial class Form1 : Form
    {
        private const int NECESSARY_EXPENSE = 380000;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int income = 0;
            int deduction = 0;
            int taxableIncome = 0;
            double taxRate = 0.0;
            int taxDeduction = 0;
            double taxIncome = 0.0;

            if (CheckTextBox(ref income, ref deduction) == false)
            {
                return;
            }

            taxableIncome = CalculateTaxableIncome(income, deduction);

            CalculateTaxRateAndTaxDeduction(income, ref taxRate, ref taxDeduction);

            taxIncome = CalculateTaxIncome(taxableIncome, taxRate, taxDeduction);

            label7.Text = taxIncome.ToString();
        }

        #region 内部関数

        private bool CheckTextBox(ref int income, ref int deduction)
        {
            if (int.TryParse(GetIncome, out income) == false
                || int.TryParse(GetDeduction, out deduction) == false)
            {
                return false;
            }

            return true;
        }

        private int CalculateTaxableIncome(int income, int deduction)
        {
            return income - deduction;
        }

        private void CalculateTaxRateAndTaxDeduction(int income, ref double taxRate, ref int taxDeduction)
        {
            if (income <= 1950000)
            {
                taxRate = 0.05;
                taxDeduction = 0;
            }
            else if (income <= 3300000)
            {
                taxRate = 0.1;
                taxDeduction = 97500;
            }
            else if (income <= 6950000)
            {
                taxRate = 0.2;
                taxDeduction = 427500;
            }
            else if (income <= 9000000)
            {
                taxRate = 0.23;
                taxDeduction = 636000;
            }
            else if (income <= 18000000)
            {
                taxRate = 0.33;
                taxDeduction = 1536000;
            }
            else if (income <= 40000000)
            {
                taxRate = 0.4;
                taxDeduction = 2796000;
            }
            else
            {
                taxRate = 0.45;
                taxDeduction = 4796000;
            }
        }

        private double CalculateTaxIncome(int taxableIncome, double taxRate, int taxDeduction)
        {
            return taxableIncome * taxRate - taxDeduction;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// テキストボックスに入力された収入を値に代入するプロパティ
        /// </summary>
        public string GetIncome
        {
            get { return textBox1.Text; }
        }

        /// <summary>
        /// テキストボックスに入力された控除額を値に代入するプロパティ
        /// </summary>
        public string GetDeduction
        {
            get { return textBox2.Text; }
        }

        #endregion
    }
}
