using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace BankConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount acc1 = new SavingsAccount();
            acc1.Name = "John";
            acc1.LastName = "Doe";
            acc1.AccountNumber = "123456789";
            acc1.Deposit(1000);
            Console.WriteLine(acc1.Balance);

        }
    }
}
