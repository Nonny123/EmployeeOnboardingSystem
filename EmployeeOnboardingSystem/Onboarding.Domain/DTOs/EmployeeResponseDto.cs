using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.DTOs
{
	public class EmployeeResponseDto
	{
		public string EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string PhoneNumber { get; set; }
		public string DateOfBirth { get; set; }
		public string WorkEmail { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public string EmploymentStatus { get; set; }
		public string EmployeeStartDate { get; set; }
		public decimal Salary { get; set; }
		public string Avatar { get; set; }
	}
}
