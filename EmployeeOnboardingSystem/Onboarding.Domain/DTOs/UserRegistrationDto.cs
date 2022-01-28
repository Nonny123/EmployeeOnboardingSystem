using Onboarding.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding.Domain.DTOs
{
    public class UserRegistrationDto
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

        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Phone number can not be less than 50 characters")]
        public string Password { get; set; }

        [Required]
        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber { get; set; }

        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber2 { get; set; }

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
        public string DateOfBirth { get; set; }


    }
}
