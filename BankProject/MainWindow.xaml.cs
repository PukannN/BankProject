using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        public void Test(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void UpDownBalance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (UpDownBalance.Text != "")
                {
                    Int64 value = Int64.Parse(UpDownBalance.Text);
                    UpDownBalance.Text = value.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
                UpDownBalance.Text = "";
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number is too large.");
                UpDownBalance.Text = UpDownBalance.Text.Substring(0, UpDownBalance.Text.Length - 1); // Remove last written character
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
                UpDownBalance.Text = "";
            }
    }

        private void TBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TBAmount.Text != "")
                {
                    Int64 value = Int64.Parse(TBAmount.Text);
                    TBAmount.Text = value.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
                TBAmount.Text = "";
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number is too large.");
                TBAmount.Text = TBAmount.Text.Substring(0, TBAmount.Text.Length - 1); // Remove last written character
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
                TBAmount.Text = "";
            }
        }
    }
}
