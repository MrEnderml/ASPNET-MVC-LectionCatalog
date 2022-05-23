using LectionCatalog.Data.Enum;
using LectionCatalog.Models;

namespace LectionCatalog.Data
{
    public class LectionDropdownsVM
    {
        public List<Lector> Lectors { get; set; }
        public List<int> Year { get; set; }
        public List<LectionCategory> LectionsCategory { get; set; }
        public LectionDropdownsVM()
        {
            Lectors = new List<Lector>();
            Year = new List<int>();
            LectionsCategory = new List<LectionCategory>();
        }
    }
}
