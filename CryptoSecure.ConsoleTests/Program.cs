using CryptoSecure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSecure.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

            Console.WriteLine();
            Console.WriteLine("Please enter an option number : ");
            string option = Console.ReadLine();
            Console.WriteLine();

            while (option != "2")
            {
                switch (option)
                {
                    case "1":
                        EncryptDecryptPassword();
                        break;
                    case "2":
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Please enter an option number : ");
                option = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("Select an option from menu:");
            Console.WriteLine("1: Encrypt / decrypt string");
            Console.WriteLine("2: Exit");
        }

        private static void EncryptDecryptPassword()
        {
            Console.WriteLine("---- Encrypt password ----");
            Console.WriteLine();

            Console.WriteLine("Please enter a password to use:");
            string password = Console.ReadLine();

            string salt = PasswordAuthentication.GenerateSalt();

            string hash = PasswordAuthentication.GenerateHash(salt, password);

            Console.WriteLine("Your encrypted password : {0}", hash);

            Console.WriteLine();
            Console.WriteLine("---- Decrypt password ----");
            Console.WriteLine();

            Console.WriteLine("Please enter your password:");
            string newPassword = Console.ReadLine();

            string newHash = PasswordAuthentication.GenerateHash(salt, newPassword);

            Console.WriteLine(string.Format("New password hash: {0}", newHash));

            bool passwordsMatch = PasswordAuthentication.CompareHashes(hash, newHash);

            if (passwordsMatch)
            {
                Console.WriteLine("Given password matches the original.");
            }
            else
            {
                Console.WriteLine("Given password does not match the original.");
            }

            Console.ReadKey();
        }
    }
}
