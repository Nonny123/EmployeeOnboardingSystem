using Onboarding.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding.Domain.DTOs
{
    public class EmployeeDto : UserBase
    {
		[Required]
		[EmailAddress(ErrorMessage = "Enter valid email")]
		public string UserEmail { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Enter valid email")]
		public string WorkEmail { get; set; }

		[Required]
		public string Designation { get; set; }

		[Required]
		public string Department { get; set; }

		[Required]
		public string EmploymentStatus { get; set; }
		public DateTime EmployeeStartDate { get; set; }
		public decimal Salary { get; set; }
	}
}
