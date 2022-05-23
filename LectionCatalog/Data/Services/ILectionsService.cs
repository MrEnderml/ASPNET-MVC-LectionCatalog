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
        Task<IEnumerable> GetLectorsFilter(int id);
        Task<IEnumerable> SearchAsync(string name);
        Task<IEnumerable> GetFavoriteLections();
        Task<IEnumerable> GetWatchLaterLections();
        Task<IEnumerable> GetHistoryLections();
    }
}
