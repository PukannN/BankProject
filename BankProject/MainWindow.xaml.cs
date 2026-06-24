using BankLibrary;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BankProject
{
    public partial class MainWindow : Window
    {
        
        public ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public Collection<TransactionOption> transactionOptions = new Collection<TransactionOption>
        {
            new TransactionOption { DisplayName = "Deposit", ActionCode = 'D' },
            new TransactionOption { DisplayName = "Withdraw", ActionCode = 'W' },
        };

        public MainWindow()
        {
            InitializeComponent();

            LBAllAccs.ItemsSource = accounts;
            CBTransType.ItemsSource = transactionOptions;
            CBTransType.SelectedIndex = 0; //preselect first trancasation option
            LoadAccountsFromDatabase();
        }

        private void LoadAccountsFromDatabase()
        {
            accounts.Clear();
            DataTable dt = DatabaseService.GetAllAccounts();

            foreach (DataRow row in dt.Rows)
            {
                int accountId = Convert.ToInt32(row["Id"]);
                string accNum = row["AccountNumber"].ToString();
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                decimal balance = Convert.ToDecimal(row["Balance"]);
                string type = row["AccountType"].ToString();
                Account accountObj = null;

                if (type == "C")
                {
                    accountObj = new CheckingAccount(firstName, lastName, "placeholder", accNum, balance, accountId);
                }
                else if (type == "S")
                {
                    accountObj = new SavingsAccount(firstName, lastName, "placeholder", accNum, balance, accountId);
                }

                if (accountObj != null)
                {
                    accounts.Add(accountObj); 
                }
            }
        }

        public void Test(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
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

        private void TBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIHelper.FormatDecimalInput(TBAmount);
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

            char accountType;
            if (RBCheckAcc.IsChecked == true)
            {
                accountType = 'C';
            }
            else if (RBSavingAcc.IsChecked == true)
            {
                accountType = 'S';
            }
            else
            {
                MessageBox.Show("Please select an account type.", "Validation Error");
                return;
            }

            string accountNumber = BankService.GenerateAccountNumber();
            if(DatabaseService.InsertAccount(TBFirstName.Text, TBLastName.Text, accountNumber, balance, accountType))
            {
                LoadAccountsFromDatabase();

                MessageBox.Show($"Account successfully created and saved!\nNumber: {accountNumber}", "Success");

                TBFirstName.Clear();
                TBLastName.Clear();
                TBBalance.Clear();
            }

        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            TransactionOption selectedOption = CBTransType.SelectedItem as TransactionOption;        
            Account selectedAccount = LBAllAccs.SelectedItem as Account;    
            
            if (selectedAccount == null)
            {
                MessageBox.Show("Please select an account from the list.", "Transaction Error");
                return;
            }

            if (selectedOption == null)
            {
                MessageBox.Show("Please select a transaction type.", "Transaction Error");
                return;
            }

            if (!decimal.TryParse(TBAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Transaction Error");
                TBAmount.Text = String.Empty;
                return;
            }

            if (selectedAccount.Balance >= 0 && amount > decimal.MaxValue - selectedAccount.Balance) // new account balance cannot exceed 29 digit number
            {
                MessageBox.Show("Your new account balance would exceed the max allowed value!", "Transaction Error");
                TBAmount.Text = String.Empty;
                return;
            }
            if (selectedAccount.Balance < amount && selectedOption.ActionCode=='W')
            {
                MessageBox.Show("Not enough balance!", "Transaction Error");
                TBAmount.Text = String.Empty;
                return;
            }

            BankService.ApplyTransaction(selectedAccount, selectedOption, amount);
            LBAllAccs.Items.Refresh();
            MessageBox.Show($"Transaction successful!\nAccount: {selectedAccount.AccountNumber}\nAction: {selectedOption.DisplayName}\nAmount: {amount}", "Success");
            TBAmount.Clear();
        }

        private void CBTransType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnInterest_Click(object sender, RoutedEventArgs e)
        {
            if (LBAllAccs.SelectedItem is SavingsAccount selectedAcc)
            {
                BankService.AddInterestRate(selectedAcc);
                LBAllAccs.Items.Refresh();
            }
        }

        private void LBAllAccs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBAllAccs.SelectedItem is SavingsAccount selectedAcc)
            {
                TBInterest.Text = (selectedAcc.InterestRate * 100).ToString() + "%";
            }
            else
            {
                TBInterest.Text = String.Empty;
            }

        }

        private void BtnTransLog_Click(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();
            logWindow.Show();
        }
    }
}
