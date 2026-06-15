using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class SavingsAccount : Account
    {
        //private int withdrawalLimit = 3;
        private decimal interestRate = 0.02m; // 2% interest rate
        public SavingsAccount(string firstName, string lastName, string accountNumber, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void AddInterestRate()
        {
            Balance += Balance * interestRate;
        }

        public override string ToString()
        {
            return $"Savings account: {AccountNumber}, Balance: {Balance}";
        }
    }
}
