using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.Base
{
    public class UserBase
    {
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50, ErrorMessage = "First Name can not be longer than 50 characters")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Middle Name can not be longer than 50 characters")]
        public string MiddleName { get; set; }


        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50, ErrorMessage = "Last Name can not be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is Required")]
        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber1 { get; set; }

        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(50)]
        [EmailAddress]
        public string PersonalEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string ResidentialAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string CityOfResidence { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateofResidence { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateofOrigin { get; set; }

        [Required]
        [MaxLength(50)]
        public string CountryOfOrigin { get; set; }


        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Avatar { get; set; }
    }
}
