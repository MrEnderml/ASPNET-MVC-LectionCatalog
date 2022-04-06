using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Display(Name = "Nick Name")]
		public string FullName { get; set; }
	}
}
