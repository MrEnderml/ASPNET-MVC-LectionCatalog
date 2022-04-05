using LectionCatalog.Models;
using System.Collections;

namespace LectionCatalog.Data.Services
{
    public interface ILectionsService
    {
        Task<IEnumerable> GetAllAsync();
        Task<Lection> GetLectionByIdAsync(int id);
        Task<LectionDropdownsVM> GetLectionDropdownsValues();
    }
}
