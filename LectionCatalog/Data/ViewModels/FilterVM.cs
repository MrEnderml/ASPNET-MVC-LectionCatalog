using LectionCatalog.Models;

namespace LectionCatalog.Data.ViewModels
{
    public class FilterVM
    {
        public List<Lection> Lections { get; set; }
        public LectionDropdownsVM LectionDropdownsVM { get; set; }
        public string SelectedLector { get; set; }
        public int SelectedYear { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedFilter { get; set; }
        public FilterVM()
        {
            Lections = new List<Lection>();
            LectionDropdownsVM = new LectionDropdownsVM();
        }
    }
}
