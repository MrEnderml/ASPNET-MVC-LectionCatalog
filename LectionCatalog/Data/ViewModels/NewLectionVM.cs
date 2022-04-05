using LectionCatalog.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Data.ViewModels
{
	public class NewLectionVM
	{   
        public int Id { get; set; }

        [Display(Name = "Lection name")]
        [Required(ErrorMessage = "Lection name is required")]
        public string Name { get; set; }

        [Display(Name = "Lection description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool isFavorite { get; set; }
        public bool isWatchLater { get; set; }

        [Display(Name = "Lection year")]
        [Required(ErrorMessage = "Description is required")]
        public DateTime Year { get; set; }

        [Display(Name = "Lection preview URL")]
        [Required(ErrorMessage = "Lection preview URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Lection link")]
        [Required(ErrorMessage = "Lection link is required")]
        public string LinkURL { get; set; }

        [Display(Name = "Lection duration")]
        [Required(ErrorMessage = "Lection duration is required")]
        public int Duration { get; set; }

        [Display(Name = "Select a country")]
        [Required(ErrorMessage = "Lection country is required")]
        public CountriesCategory Country { get; set; }

        [Display(Name = "Lection views")]
        [Required(ErrorMessage = "Lection views is required")]
        public int Views { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Lection category is required")]
        public LectionCategory LectionCategory { get; set; }

        [Display(Name = "Select lector(s)")]
        [Required(ErrorMessage = "Lection lector(s) is required")]
        public List<int> Lectors { get; set; }
    }
}
