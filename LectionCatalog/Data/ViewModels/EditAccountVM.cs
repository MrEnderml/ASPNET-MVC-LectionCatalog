using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Data.ViewModels
{
	public class EditAccountVM 
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
    }
}
