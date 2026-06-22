using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public static class BankService
    {
        // for future transaction logs
        public static void ApplyTransaction(Account account, TransactionOption transOption, decimal amount)
        {
            if (transOption.ActionCode == 'W')
            {
                account.Withdraw(amount);
            }
            else if (transOption.ActionCode == 'D')
            {
                account.Deposit(amount);
            }
            DatabaseService.UpdateAccountBalance(account.AccountNumber, account.Balance);
            DatabaseService.InsertTransactionLog(account.AccountNumber, amount, transOption.ActionCode);
        }
        public static void AddInterestRate(SavingsAccount account)
        {
            account.Balance += Math.Round(account.Balance * account.InterestRate,2);
            
            DatabaseService.UpdateAccountBalance(account.AccountNumber, account.Balance);
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

