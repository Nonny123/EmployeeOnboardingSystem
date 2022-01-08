using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.Entities
{
    public class Annoucement
    {
		[Required]
		[MaxLength(50, ErrorMessage = "Title can not be more than 50 characters")]
		public string Title { get; set; }

		[Required]
		public string Message { get; set; }

		[Required]
		public string Author { get; set; }

		[FileExtensions(Extensions = "jpg,jpeg,png")]
		public IFormFile Attachment { get; set; }

		public bool NotifyEmployee { get; set; }
	}
}
