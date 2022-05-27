using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Data.ViewModels
{
	public class EditAccountVM 
    {
        [Display(Name = "User name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
    }
}
