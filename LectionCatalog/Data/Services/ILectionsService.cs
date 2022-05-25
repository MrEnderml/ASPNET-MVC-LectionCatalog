using LectionCatalog.Data.ViewModels;
using LectionCatalog.Models;
using System.Collections;

namespace LectionCatalog.Data.Services
{
    public interface ILectionsService
    {
        Task<IEnumerable> GetAllAsync();
        Task<Lection> GetLectionByIdAsync(int id);
        Task<LectionDropdownsVM> GetLectionDropdownsValues();
        Task AddNewLectionAsync(NewLectionVM data);
        Task UpdateLectionAsync(NewLectionVM data);
        Task DeleteLectionAsync(int id);
        Task<IEnumerable> GetLectorsFilter(string name);
        IEnumerable GetYearFilter(List<Lection> lect, int value);
        IEnumerable GetCategoryFilter(List<Lection> lect, string value);
        IEnumerable GetFilterTypes(List<Lection> lect, string value);
        Task<IEnumerable> SearchAsync(string name);
        Task<IEnumerable> GetLectionsByList(string list);
        string getYouTubeThumbnail(string YoutubeUrl);
        string getCorrectYoutubeLink(string YoutubeUrl);
    }
}
