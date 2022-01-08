using Onboarding.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.Entities
{
    public class User : UserBase
	{
		[Key]
		public long UserId { get; set; }

		[Required]
		public DateTime DateRegistered { get; set; }

		public DateTime LastModified { get; set; }
		public bool IsActive { get; set; }

		//Identity
		//public ApplicationUser AppUser { get; set; }

	}
}
