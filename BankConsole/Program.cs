using BankLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    internal class Program
    {
        static void Main()
        {

            string password = "123";
            string tryPassword = "123";
            byte[] hash = ComputeSHA256Hash(password);
            byte[] tryHash = ComputeSHA256Hash(tryPassword);
            string hashString = BitConverter.ToString(hash);
            string tryHashString = BitConverter.ToString(tryHash);
            Console.WriteLine(hashString);
            Console.WriteLine(tryHashString);
            if (hashString==tryHashString)
            {

                Console.WriteLine("match");
            }
            else
            {
                Console.WriteLine("not a match");
            }
        }
        static byte[] ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
    }
}


