using LectionCatalog.Data.Static;
using LectionCatalog.Models;

namespace LectionCatalog.Data.ViewModels
{
    public class FilterVM
    {
        public IEnumerable<Lection> Lections { get; set; }
        public LectionDropdownsVM LectionDropdownsVM { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SelectedLector { get; set; }
        public int SelectedYear { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedFilter { get; set; }
        public FilterVM()
        {
            Lections = new List<Lection>();
            PageInfo = new PageInfo();
            LectionDropdownsVM = new LectionDropdownsVM();
        }
    }
}
