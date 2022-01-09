using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.DTOs
{
    public class EmployeeResponseDto
    {
		public long EmployeeId { get; set; }
		public string WorkEmail { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public string EmploymentStatus { get; set; }
		public DateTime EmployeeStartDate { get; set; }
		public DateTime LastModified { get; set; }
		public decimal Salary { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
