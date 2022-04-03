using LectionCatalog.Data.Enum;

namespace LectionCatalog.Models
{
    public class Lection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Year { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public int Views { get; set; }
        public LectionCategory LectionCategory { get; set; }
        public List<Lector_Lection> Lectors_Lections { get; set; }
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
    }
}
