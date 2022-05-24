using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectionCatalog.Models
{	
	public class ApplicationUser : IdentityUser
	{
		[Display(Name = "Nick Name")]
		public string FullName { get; set; }
		public string Favorites { get; set; }
		public string WatchLater { get; set; }
		public string History { get; set; }
	}
}
