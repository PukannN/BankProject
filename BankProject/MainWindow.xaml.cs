using BankLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
        public ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public MainWindow()
        {
            InitializeComponent();
            LBAllAccs.ItemsSource = accounts;
            
        }

        public void Test(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Test");
        }
            
        private void TBUsernameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                UIHelper.FormatUsernameInput(textBox);
            }
        }

        private void TBBalance_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatDecimalInput(TBBalance);
        }
        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBFirstName.Text) || string.IsNullOrEmpty(TBLastName.Text))
            {
                MessageBox.Show("Please enter both first name and last name.", "Validation Error");
                return;
            }

            if (!decimal.TryParse(TBBalance.Text, out decimal balance))
            {
                MessageBox.Show("Please enter a valid initial balance.", "Validation Error");

                return;
            }

            string accountNumber = BankServices.GenerateAccountNumber();

            if (RBCheckAcc.IsChecked == true)
            {
                CheckingAccount newAccount = new CheckingAccount(TBFirstName.Text, TBLastName.Text, accountNumber, balance);
                accounts.Add(newAccount);
                MessageBox.Show($"Checking account created successfully!\nAccount Number: {newAccount.AccountNumber}\nOwner: {newAccount.FirstName} {newAccount.LastName}\nBalance: {newAccount.Balance}");
            }
            else if (RBSavingAcc.IsChecked == true)
            {
                SavingsAccount newAccount = new SavingsAccount(TBFirstName.Text, TBLastName.Text, accountNumber, balance);
                accounts.Add(newAccount);
                MessageBox.Show($"Savings account created successfully!\nAccount Number: {newAccount.AccountNumber}\nOwner: {newAccount.FirstName} {newAccount.LastName}\nBalance: {newAccount.Balance}");

            }
            else
            {
                MessageBox.Show("Please select an account type.", "Validation Error");
            }
        }

        private void TBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
        }


        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
