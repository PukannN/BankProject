using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public abstract class Account
    {
        
        public static readonly string BankCode = "1234";
        public int AccountId { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; internal set; }
        public string Password { get; internal set; }
        public decimal Balance { get; internal set; } = 0.00m;
        public char AccountType { get; internal set; }

        public Account(string firstName, string lastName, string password, string accountNumber, decimal balance, int accountId)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false; // Insufficient funds

        }
    }
}
