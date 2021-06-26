using MusteriYonetim.Dtos;
using MusteriYonetim.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetim.Managers
{
    class CCompanyManager : ICompanyOperations
    {
        public void GiveScoreToCustomer(Customer customer)
        {
            Helper.Helper.PrintSomething($"Tebrikler. {customer.Name} {customer.Surname} adlı kişiyi kaydettiniz. Bu işlem için kaç puan vereceksiniz?");
            var score = Console.ReadLine();
            Helper.Helper.SaveScore("C", score);
        }

        public bool IsValidCustomer(Customer customer)
        {
            string password = Helper.Helper.GenerateOTP();
            
            Helper.Helper.PrintSomething("Müşterinizin email adresine tek kullanımlık bir şifre gönderildi. Lütfen şifreyi giriniz: ");
            Helper.Helper.PrintSomething($"(Emaile gelen kod:{password})");
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

        Email:
            Helper.Helper.PrintSomething("Email giriniz:");
            string email = Console.ReadLine();
            if (!Helper.Helper.isMail(email))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer bir email olamaz.");
                goto Email;
            }

            return new Customer()
            {
                EducationStatus = egitim,
                Name = ad,
                Surname = soyad,
                Email = email,
                Company = "C"
            };
        }

        public void Welcome()
        {
            Helper.Helper.PrintSomething("C firması olarak sisteme giriş yaptınız.");

        }
    }
}
