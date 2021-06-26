using System;
using MusteriYonetim.Helper;
using MusteriYonetim.Interfaces;

namespace MusteriYonetim
{
    class Program
    {
        static void Main(string[] args)
        {
        ReStart:

            Helper.Helper.PrintSomething("Müşteri yönetim sistemine hoşgeldiniz...");

            object company;
            bool checkResult = false;

            do
            {
                Helper.Helper.PrintSomething("Lütfen giriş yapmak istediğiniz firmayı seçiniz.");
                Helper.Helper.PrintSomething("A    B    C");
                company = Console.ReadLine();
                checkResult = Helper.Helper.CheckCompany(company);
                if (!checkResult)
                {
                    Helper.Helper.PrintSomething("Sistemimizde böyle bir firma bulunmamaktadır.");
                }
                if (checkResult)
                {
                    Helper.Helper.ClearLine();
                }

            } while (!checkResult);

            ICompanyOperations manager = Helper.Helper.GetManager(company);

            manager.Welcome();
            var customer = manager.TakeCustomerInfo();
            var isValidCustomer = manager.IsValidCustomer(customer);

            if (isValidCustomer)
            {
                Helper.Helper.PrintSomething("Müşteri doğrulandı!");
            }
            else
            {
                Helper.Helper.PrintSomething("Müşteri doğrulanamadı.");
            }

            Helper.Helper.PrintSomething("Müşterinizi kaydetmek istediğiniz veri tabanının ismini giriniz.");
            var dbName = Console.ReadLine();

            Helper.Helper.SaveCustomer(customer, dbName);
            manager.GiveScoreToCustomer(customer);

            Helper.Helper.PrintSomething("İşlemleriniz tamamlandı. Uygulamayı yenden başlatmak için 'e' tuşuna basınız:");

            if (Console.ReadKey(true).Key == ConsoleKey.E)
            {
                goto ReStart;
            }

        }
    }
}
