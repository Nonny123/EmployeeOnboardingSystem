using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.DTOs
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PersonalEmail { get; set; }
        public string ResidentialAddress { get; set; }
        public string CityOfResidence { get; set; }
        public string StateofResidence { get; set; }
        public string Avatar { get; set; }
    }
}
