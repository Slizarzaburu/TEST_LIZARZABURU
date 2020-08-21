using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_LIZARZABURU.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Identification { get; set; }
        public string DistrictResidence { get; set; }
        public string AddressResidence { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string Occupation { get; set; }
        public DateTime RegisterDate { get; set; }
        public Decimal MonthlyContract { get; set; }
        public Decimal HourlyContract { get; set; }
        public int TypeContract { get; set; }
    }
}
