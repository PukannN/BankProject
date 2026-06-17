using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public static class BankService
    {
        public static void ApplyTransaction(Account account, TransactionOption transOption, decimal amount)
        {
            if (transOption.ActionCode == "W")
            {
                account.Balance -= amount;
            }
            else if (transOption.ActionCode == "D")
            {
                account.Balance += amount;
            }
        }

        public static string GenerateAccountNumber()
        {
            
            Random random = new Random();
            string accountNumber;
            do
            {
                accountNumber = random.Next(10000000, 99999999).ToString() + "/" + Account.BankCode;
            } while (DatabaseService.AccountNumberExists(accountNumber));
            return accountNumber;

        }

    }
}

