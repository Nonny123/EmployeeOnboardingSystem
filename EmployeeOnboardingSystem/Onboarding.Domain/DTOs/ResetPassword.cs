using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.DTOs
{
    public class ResetPassword
    {
        [Required]
        public string Token { get; set; }

        [Required(ErrorMessage = "Email Address is required."), MaxLength(50)]
        [EmailAddress(ErrorMessage = "This is not a valid email address.")]
        public string EmailAddress { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
    }
}
