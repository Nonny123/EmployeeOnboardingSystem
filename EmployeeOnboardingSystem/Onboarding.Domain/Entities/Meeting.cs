using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.Entities
{
    public class Meeting
    {
		[Required]
		[MaxLength(50, ErrorMessage = "Title cannot be more than 50 characters")]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public DateTime MeetingDate { get; set; }
	}
}
