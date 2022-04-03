namespace LectionCatalog.Models
{
    public class Lector_Lection
    {
        public int LectionId { get; set; }
        public Lection Lection { get; set; }
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
    }
}
