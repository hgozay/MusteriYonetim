using MernisWebService;
using MusteriYonetim.Dtos;
using MusteriYonetim.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static MernisWebService.KPSPublicSoapClient;

namespace MusteriYonetim.Managers
{
    class ACompanyManager : ICompanyOperations
    {
        public void GiveScoreToCustomer(Customer customer)
        {
            Helper.Helper.PrintSomething($"Tebrikler. {customer.Name} {customer.Surname} adlı kişiyi kaydettiniz. Bu işlem için kaç puan vereceksiniz?");
            var score = Console.ReadLine();
            Helper.Helper.SaveScore("A", score);
        }

        public bool IsValidCustomer(Customer customer)
        {
            EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
            KPSPublicSoapClient mernisClient = new KPSPublicSoapClient(endpointConfiguration);

            return mernisClient.TCKimlikNoDogrula(customer.TcNo, customer.Name, customer.Surname, customer.BirthYear);
        }

        public Customer TakeCustomerInfo()
        {
        TCNo:
            Helper.Helper.PrintSomething("TC kimlik no giriniz:");
            string tcNoInput = Console.ReadLine();

            if (!Helper.Helper.isLong(tcNoInput))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik olmayan karakterler içeriyor.");
                goto TCNo;

            }

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

        DogumYili:
            Helper.Helper.PrintSomething("Doğum yılı giriniz:");
            string yilInput = Console.ReadLine();

            if (!Helper.Helper.isLong(yilInput))
            {
                Helper.Helper.PrintSomething("Girdiğiniz değer numerik olmayan karakterler içeriyor.");
                goto DogumYili;

            }

            return new Customer()
            {
                TcNo = Convert.ToInt64(tcNoInput),
                Name = ad,
                Surname = soyad,
                BirthYear = Convert.ToInt32(yilInput),
                Company = "A"
            };
        }

        public void Welcome()
        {
            Helper.Helper.PrintSomething("A firması olarak sisteme giriş yaptınız.");
        }

    }
}
