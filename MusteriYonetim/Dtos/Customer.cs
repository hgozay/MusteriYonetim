using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetim.Dtos
{
    public class Customer : BaseDto
    {
        public string Company { get; set; }
        public long TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public string EducationStatus { get; set; }
        public string GSM { get; set; }
        public string Email { get; internal set; }
    }
}
