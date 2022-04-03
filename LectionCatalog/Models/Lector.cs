namespace LectionCatalog.Models
{
    public class Lector
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Lector_Lection> Lectors_Lections { get; set; }
    }
}
