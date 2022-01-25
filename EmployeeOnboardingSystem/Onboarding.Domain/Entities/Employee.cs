using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.Domain.Base;

namespace Onboarding.Domain.Entities
{
    public class Employee : UserBase
	{
		[Key]
		public string EmployeeId { get; set; } = Guid.NewGuid().ToString();

		[Required]
		[EmailAddress(ErrorMessage = "Enter valid email address")]
		public string WorkEmail { get; set; }

		[Required]
		public string Designation { get; set; }

		[Required]
		public string Department { get; set; }

		[Required]
		public string EmploymentStatus { get; set; }
		public DateTime EmployeeStartDate { get; set; }
		public DateTime LastModified { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Salary { get; set; }
		public bool IsActive { get; set; } = true;
		public string Avatar { get; set; }

		public User User { get; set; }

	}
}
