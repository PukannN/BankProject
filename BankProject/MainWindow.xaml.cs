using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TBBalance_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatDecimalInput(TBBalance);
        }

        private void TBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatDecimalInput(TBAmount);
        }


        private void TBFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatUsernameInput(TBFirstName);
        }

        private void TBLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatUsernameInput(TBLastName);
        }
    }
}
