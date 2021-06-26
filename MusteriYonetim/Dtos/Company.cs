using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetim.Dtos
{
    public class Company : BaseDto
    {
        public string CompanyName { get; set; }
        public string Score { get; set; }
        public String GetId() { return CompanyName; }
        
    }
}
