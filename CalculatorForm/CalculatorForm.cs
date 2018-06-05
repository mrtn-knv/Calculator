using System;
using System.Windows.Forms;

namespace Calc_NewNewNew
{
    public partial class CalculatorForm : Form
    {
        const string OPERATOR_MULTIPLICATION = "*";
        const string OPERATOR_DIVISION = "/";
        const string OPERATOR_PLUS = "+";
        const string OPERATOR_MINUS = "-";

        const string DECIMAL_SIGN = ".";

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button CalcButton = (Button)sender;
            var value = CalcButton.Text;

            if(result.Text.StartsWith("0") && !result.Text.Contains(DECIMAL_SIGN))
            {
                result.Text = value;
            }
            else
            {
                result.Text += value;
            }
            
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button CalcOperationButton = (Button)sender;
            var operation = CalcOperationButton.Text;
            if (string.IsNullOrWhiteSpace(result.Text))
                return;

            CleanupInput();
            
            //Calculate the temp result
            if(!string.IsNullOrWhiteSpace(magic.Text))
            {
                var previousOperation = magic.Text[magic.Text.Length - 1].ToString();
                var previousValue = double.Parse(magic.Text.Substring(0, magic.Text.Length - 1));
                var currentValue = double.Parse(result.Text);
                magic.Text = CalculateResult(previousValue, currentValue, previousOperation).ToString() + operation;
            }
            else
            {
                magic.Text = double.Parse(result.Text).ToString() + operation;
            }

            result.Text = string.Empty;
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            CleanupInput();

            //Calculate the temp result
            if (!string.IsNullOrWhiteSpace(magic.Text))
            {
                var previousOperation = magic.Text[magic.Text.Length - 1].ToString();
                var previousValue = double.Parse(magic.Text.Substring(0, magic.Text.Length - 1));
                var currentValue = double.Parse(result.Text);
                result.Text = CalculateResult(previousValue, currentValue, previousOperation).ToString();
            }

            magic.Text = string.Empty;
        }

        private void CleanupInput()
        {
            if (result.Text.EndsWith(DECIMAL_SIGN))
                result.Text += "0";

            if (string.IsNullOrWhiteSpace(result.Text))
                result.Text = "0";
        }

        private double CalculateResult(double leftSide, double rightSide, string operation)
        {
            switch(operation)
            {
                case OPERATOR_MULTIPLICATION:
                    return leftSide * rightSide;

                case OPERATOR_DIVISION:
                    return leftSide / rightSide;

                case OPERATOR_PLUS:
                    return leftSide + rightSide;

                case OPERATOR_MINUS:
                    return leftSide - rightSide;

                default:
                    throw new Exception("PROBLEM!");
            }
        }

        private void ClearEquasion_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(result.Text))
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(result.Text) && !result.Text.Contains(DECIMAL_SIGN))
                result.Text += DECIMAL_SIGN;
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            result.Text = string.Empty;
            magic.Text = string.Empty;
        }
    }
}
