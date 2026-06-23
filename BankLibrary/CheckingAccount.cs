using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class CheckingAccount : Account
    {
        public string DebitCardNumber { get; set; }
        public decimal OverdraftLimit { get; set; } = 100.00m;
        

        public CheckingAccount(string firstName, string lastName, string accountNumber, decimal balance, int accountId)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = 'C';
        }

        public override string ToString()
        {
            return $"Id: {AccountId}, Checking account: {AccountNumber} | Name: {FirstName} {LastName} | Balance: {Balance} | Account Type: {AccountType}";
        }
    }
}
