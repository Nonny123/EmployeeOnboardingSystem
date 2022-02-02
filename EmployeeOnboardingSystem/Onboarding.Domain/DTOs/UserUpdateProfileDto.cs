using Onboarding.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Onboarding.Domain.DTOs
{
    public class UserUpdateProfileDto
    {
        [MaxLength(50, ErrorMessage = "First Name can not be longer than 50 characters")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Middle Name can not be longer than 50 characters")]
        public string MiddleName { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name can not be longer than 50 characters")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber { get; set; }

        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber2 { get; set; }

        [MaxLength(50)]
        public string ResidentialAddress { get; set; }

        [MaxLength(50)]
        public string CityOfResidence { get; set; }

        [MaxLength(50)]
        public string StateofResidence { get; set; }

        [MaxLength(50)]
        public string StateofOrigin { get; set; }

        [MaxLength(50)]
        public string CountryOfOrigin { get; set; }

        public string DateOfBirth { get; set; }

    }
}
