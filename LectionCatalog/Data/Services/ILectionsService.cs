using System.Collections;

namespace LectionCatalog.Data.Services
{
    public interface ILectionsService
    {
        Task<IEnumerable> GetAllAsync();
    }
}
