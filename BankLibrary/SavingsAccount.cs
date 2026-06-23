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
        public decimal InterestRate { get; internal set;}
        public SavingsAccount(string firstName, string lastName, string accountNumber, decimal balance, int accountId)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = 'S';
            InterestRate = 0.02m;
        }

        public override string ToString()
        {
            return $"Id: {AccountId}, Checking account: {AccountNumber} | Name: {FirstName} {LastName} | Balance: {Balance} | Account Type: {AccountType}";
        }
    }
}
