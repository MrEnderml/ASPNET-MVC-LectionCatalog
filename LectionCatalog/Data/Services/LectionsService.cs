using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LectionCatalog.Data.Services
{
    public class LectionsService : ILectionsService
    {
        private readonly AppDbContext _context;
        public LectionsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable> GetAllAsync()
        {
            return await _context.Lections.ToListAsync();
        }
    }
}
