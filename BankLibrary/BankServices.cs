using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public static class BankServices
    {
        public static void ApplyTransaction(Account account, string actionCode, decimal amount)
        {
            if (actionCode == "W")
            {
                account.Balance -= amount;
            }
            else if (actionCode == "D")
            {
                account.Balance += amount;
            }
        }

        public static string GenerateAccountNumber()
        {
            Random random = new Random();
            string accountNumber = Account.IBAN + random.Next(100_000_000, 999_999_999).ToString();
            return accountNumber;
        }
}
}

