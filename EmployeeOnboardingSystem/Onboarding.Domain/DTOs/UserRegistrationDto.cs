using Onboarding.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding.Domain.DTOs
{
    public class UserRegistrationDto : UserBase
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
