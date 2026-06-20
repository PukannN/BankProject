using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Transaction
    {
        public int Id { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Amount { get; private set; }
        public char TransactionType { get; private set; }

        public Transaction(int id, string accountNumber, decimal amount, char transactionType) 
        {
            Id = id;
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;

        }
        public override string ToString()
        {
            return $"Id: {Id}, Account number: {AccountNumber}, Amount: {Amount}, Transaction type: {TransactionType}";

        }
    }
}
