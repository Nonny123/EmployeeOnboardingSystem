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
		public long EmployeeId { get; set; }

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

		[Column(TypeName = "decimal(18,4)")]
		public decimal Salary { get; set; }
		public bool IsActive { get; set; } = true;


	}
}
