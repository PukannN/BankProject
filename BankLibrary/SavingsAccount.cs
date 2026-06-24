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
        public decimal InterestRate { get; internal set;} = 0.02m;
        public SavingsAccount(string firstName, string lastName, string password, string accountNumber, decimal balance, int accountId) : base(firstName, lastName, password, accountNumber, balance, accountId)
        {
            AccountType = 'S';
        }

        public override string ToString()
        {
            return $"Id: {AccountId}, Checking account: {AccountNumber} | Name: {FirstName} {LastName} | Balance: {Balance} | Account Type: {AccountType}";
        }
    }
}
