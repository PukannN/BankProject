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

        public static void FormatDecimalInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text) || (textBox.Text.EndsWith(".") && textBox.Text.Count(c => c == '.') == 1)) return;
            
            if (!decimal.TryParse(textBox.Text, out decimal value))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                textBox.Text = "";
                return;
            }
            
            string newText = Math.Round(value, 2).ToString();


            int selectionStart = textBox.SelectionStart;
            int oldLength = textBox.Text.Length;

            if (textBox.Text != newText)
            {
                textBox.Text = newText;
                int lenghtDifference = textBox.Text.Length - oldLength;
                textBox.SelectionStart = Math.Max(0, selectionStart + lenghtDifference);
            }
        }

        public static void FormatUsernameInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text)) return;
            
            int selectionStart = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace(" ", "");
            textBox.SelectionStart = selectionStart;
          
        }
}
}
