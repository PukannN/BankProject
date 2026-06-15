using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public abstract class Account
    {
        public static readonly string IBAN = "1234";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; internal set; } //TODO: generate new random acc number + IBAN prefix
        public decimal Balance { get; internal set; }

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
