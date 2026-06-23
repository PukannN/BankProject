using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankProject
{
    public static class UIHelper
    {
        // realtime decimal input check
        public static void FormatDecimalInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text)) return;

            // get the current culture's decimal separator
            string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if (textBox.Text.EndsWith(decimalSeparator) && textBox.Text.Count(c => c.ToString() == decimalSeparator) == 1) return;

            if (!decimal.TryParse(textBox.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal value))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                textBox.Text = string.Empty;
                return;
            }

            value = Math.Abs(value);
            string newText = Math.Round(value, 2).ToString(System.Globalization.CultureInfo.CurrentCulture);
            int selectionStart = textBox.SelectionStart;
            int oldLength = textBox.Text.Length;

            if (textBox.Text != newText)
            {
                textBox.Text = newText;
                int lenghtDifference = textBox.Text.Length - oldLength;
                textBox.SelectionStart = Math.Max(0, selectionStart + lenghtDifference);
                return;
            }
        }

        // realtime username input check
        public static void FormatUsernameInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text)) return;
            
            int selectionStart = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace(" ", "");
            textBox.SelectionStart = selectionStart;
          
        }


        public static void PasswordInput(TextBox textBox)
        {
           
        }

    }
}
