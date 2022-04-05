using LectionCatalog.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Models
{
    public class Lection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isFavorite { get; set; }
        public bool isWatchLater { get; set; }
        public int Year { get; set; }
        public string ImageURL { get; set; } 
        public string LinkURL { get; set; }
        public int Duration { get; set; }
        public CountriesCategory Country { get; set; }
        public int Views { get; set; }
        public LectionCategory LectionCategory { get; set; }
        public List<Lector_Lection> Lectors_Lections { get; set; }
    }
}
