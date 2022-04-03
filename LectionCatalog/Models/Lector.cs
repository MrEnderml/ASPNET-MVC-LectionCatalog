using System.ComponentModel.DataAnnotations;

namespace LectionCatalog.Models
{
    public class Lector
    {
        [Key]
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string LectorPictureURL { get; set; }
        public string Bio { get; set; }
        public List<Lector_Lection> Lectors_Lections { get; set; }
    }
}
