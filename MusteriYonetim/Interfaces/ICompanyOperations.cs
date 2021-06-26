using MusteriYonetim.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetim.Interfaces
{
    interface ICompanyOperations
    {
        public void Welcome();

        public Customer TakeCustomerInfo();

        public bool IsValidCustomer(Customer customer);

        public void GiveScoreToCustomer(Customer customer);
    }
}
