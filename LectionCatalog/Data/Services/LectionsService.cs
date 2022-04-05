using LectionCatalog.Data.Enum;
using LectionCatalog.Models;
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
            return await _context.Lections.
                Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).
                ToListAsync();
        }

        public async Task<Lection> GetLectionByIdAsync(int id)
        {
           var lectionDetails = await _context.Lections.
                Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).
                FirstOrDefaultAsync(n => id == n.Id);
            return lectionDetails;
        }

        public async Task<LectionDropdownsVM> GetLectionDropdownsValues()
        {
            var response = new LectionDropdownsVM()
            {
                Lectors = await _context.Lectors.OrderBy(n => n.FullName).ToListAsync(),
                LectionsCategory = LectionCategory.GetValues(typeof(LectionCategory)).Cast<LectionCategory>().ToList()
            };
            return response;
        }
    }
}
