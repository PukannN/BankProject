using BankLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Shapes;

namespace BankProject
{
    public partial class LogWindow : Window
    {
        //Transaction class - e.g. Transaction.Withdrawl and Transaction.Deposit
        //Transaction.Id, Transaction.Amount etc.
        //Merge it with the TransactionOptions, makes more sense

        public ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

        public LogWindow()
        {
            InitializeComponent();
            LBTransLog.ItemsSource = transactions;
            LoadTransactionsFromDatabase();

        }

        private void LoadTransactionsFromDatabase()
        {
            transactions.Clear();
            DataTable dt = DatabaseService.GetAllTransactions();
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string accountNumber = row["AccountNumber"].ToString();
                decimal amount = Convert.ToDecimal(row["Amount"]);
                char transactionType = Convert.ToChar(row["TransactionType"]);

                Transaction newTransaction = new Transaction(id, accountNumber, amount, transactionType);
                transactions.Add(newTransaction);
            }
        }
    }
}
