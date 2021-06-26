using MusteriYonetim.Dtos;
using MusteriYonetim.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetim.Managers
{
    class BCompanyManager : ICompanyOperations
    {
        public void GiveScoreToCustomer(Customer customer)
        {
            Helper.Helper.PrintSomething($"Tebrikler. {customer.Name} {customer.Surname} adlı kişiyi kaydettiniz. Bu işlem için kaç puan vereceksiniz?");
            var score = Console.ReadLine();
            Helper.Helper.SaveScore("B", score);
        }

        public bool IsValidCustomer(Customer customer)
        {
            var password = Helper.Helper.GenerateOTP();
            Helper.Helper.PrintSomething("Müşterinizin telefon numarasına tek kullanımlık bir şifre gönderildi. Lütfen kodu giriniz: ");
            Helper.Helper.PrintSomething($"(Mesajla gelen kod:{password})");
            var inputPass = Console.ReadLine();
            if (password == inputPass)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Customer TakeCustomerInfo()
        {
        Ad:
            Helper.Helper.PrintSomething("Ad giriniz:");
            string ad = Console.ReadLine();

            if (!Helper.Helper.isAlphabet(ad))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik karakter veya sembol içeriyor.");
                goto Ad;
            }

        SoyAd:
            Helper.Helper.PrintSomething("Soyad giriniz:");
            string soyad = Console.ReadLine();

            if (!Helper.Helper.isAlphabet(soyad))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik karakter veya sembol içeriyor.");
                goto SoyAd;
            }

        Egitim:
            Helper.Helper.PrintSomething("Eğitim durumu giriniz:");
            string egitim = Console.ReadLine();

            if (!Helper.Helper.isAlphabet(egitim))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik karakter veya sembol içeriyor.");
                goto Egitim;
            }

        GSM:
            Helper.Helper.PrintSomething("GSM numarası giriniz:");
            string gsm = Console.ReadLine();
            if (!Helper.Helper.isLong(gsm))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik olmayan karakterler içeriyor.");
                goto GSM;
            }

            return new Customer()
            {
                EducationStatus = egitim,
                Name = ad,
                Surname = soyad,
                GSM = gsm,
                Company = "B"
            };
        }

        public void Welcome()
        {
            Helper.Helper.PrintSomething("B firması olarak sisteme giriş yaptınız.");
        }
    }
}
