using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    internal class CheckingAccount : Account
    {
        public string DebitCardNumber { get; set; }
        public decimal OverdraftLimit { get; set; } = 100.00m;

        public override string ToString()
        {
            return $"Checking account: {AccountNumber}, Balance: {Balance}";
        }
    }
}
