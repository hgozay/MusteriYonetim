using MusteriYonetim.DBOperations;
using MusteriYonetim.Dtos;
using MusteriYonetim.Interfaces;
using MusteriYonetim.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MusteriYonetim.Helper
{
    static class Helper
    {
        public static void PrintSomething(string text)
        {
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
        public static string GenerateOTP()
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            return new String(stringChars1);
        }

        internal static void SaveScore(string company, string score)
        {
            CrudOperations operations = new CrudOperations("Companies");

            var companyObject = operations.Get<Company>(company, typeof(Company));
            if (companyObject == null)
            {
                operations.Add<Company>(new Company() { CompanyName = company, Score = score, Id = company });
            }
            else
            {
                operations.Update<Company>(companyObject, typeof(Company));
            }
        }

        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop - 1;

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

        }
        public static bool CheckCompany(object company)
        {
            if ("ABC".Contains(company.ToString()) || "ABC".Contains(company.ToString().ToUpper()))
            {
                return true;
            }
            return false;
        }
        public static ICompanyOperations GetManager(object company)
        {
            switch (company)
            {
                case "A":
                case "a":
                    return new ACompanyManager();
                case "B":
                case "b":
                    return new BCompanyManager();
                case "C":
                case "c":
                    return new CCompanyManager();
                default:
                    return null;
            }
        }

        internal static bool isMail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void SaveCustomer(Customer customer, string DBName)
        {
            CrudOperations operations = new CrudOperations(DBName);

            operations.Add<Customer>(customer);
        }

        public static List<Customer> GetAllCustomers(string DBName)
        {
            CrudOperations operations = new CrudOperations(DBName);

            return operations.GetAll<Customer>(typeof(Customer));
        }

        public static bool isAlphabet(string text)
        {

            if (string.IsNullOrEmpty(text))
                return false;
            foreach (var letter in text)
            {
                if (letter != ' ')
                {
                    if (!char.IsLetter(letter))
                        return false;
                }
            }
            return true;
        }
        public static bool isLong(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            try
            {
                long value = Convert.ToInt64(text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
