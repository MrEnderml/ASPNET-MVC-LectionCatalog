using LectionCatalog.Data.Enum;
using LectionCatalog.Data.ViewModels;
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

		public async Task AddNewLectionAsync(NewLectionVM data)
		{
            var newLeciton = new Lection()
            {
                Name = data.Name,
                Description = data.Description,
                Year = data.Year,
                isFavorite = false,
                isWatchLater = false,
                Duration = data.Duration,
                ImageURL = data.ImageURL,
                LinkURL = data.LinkURL,
                Country = data.Country,
                LectionCategory = data.LectionCategory,
            };

            await _context.Lections.AddAsync(newLeciton);
            await _context.SaveChangesAsync();

            foreach(var lectorId in data.LectorIds)
            {
                var newLectorLection = new Lector_Lection()
                {
                    LectionId = newLeciton.Id,
                    LectorId = lectorId
                };
                await _context.Lectors_Lections.AddAsync(newLectorLection);
            }
            await _context.SaveChangesAsync();
		}

		public Task DeleteLectionAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable> GetAllAsync()
        {
            return await _context.Lections.
                Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).
                ToListAsync();
        }

        public async Task<IEnumerable> GetFavoriteLections()
        {
            var lections = await _context.Lections.Where(l => l.isFavorite == true).ToListAsync();

            foreach(var item in lections)
            {
                if(item.Description.Length > 100)
                {
                    item.Description = item.Description.Remove(item.Description.Length - (item.Description.Length - 100));
                    item.Description += "...";
                }
            }

            return lections;
        }

        public Task<IEnumerable> GetHistoryLections()
        {
            throw new NotImplementedException();
        }

        public async Task<Lection> GetLectionByIdAsync(int id)
        {
           var lectionDetails = await _context.Lections.
                Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).
                FirstOrDefaultAsync(n => id == n.Id);
            return lectionDetails;
        }

        public async Task<IEnumerable> SearchAsync(string name)
        {
            var allLections = await _context.Lections.Where(e => e.Name.Contains(name)).ToListAsync();
            return allLections;
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

        public async Task<IEnumerable> GetWatchLaterLections()
        {
            var lections = await _context.Lections.Where(l => l.isWatchLater == true).ToListAsync();

            foreach (var item in lections)
            {
                if (item.Description.Length > 100)
                {
                    item.Description = item.Description.Remove(item.Description.Length - (item.Description.Length - 100));
                    item.Description += "...";
                }
            }

            return lections;
        }

        public async Task<IEnumerable> GetLectorsFilter(int id)
        {
            var lections = await _context.Lections.Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).Where(ll => ll.Lectors_Lections.All(n => n.LectorId == id)).ToListAsync();

            return lections;
        }

        public async Task UpdateLectionAsync(NewLectionVM data)
		{
            var dbLection = await _context.Lections.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbLection != null)
            {
                dbLection.Name = data.Name;
                dbLection.Description = data.Description;
                dbLection.ImageURL = data.ImageURL;
                dbLection.LinkURL = data.LinkURL;
                dbLection.isFavorite = data.isFavorite;
                dbLection.isWatchLater = data.isWatchLater;
                dbLection.Duration = data.Duration;
                dbLection.Year = data.Year;
                dbLection.Country = data.Country;
                dbLection.LectionCategory = data.LectionCategory;

                await _context.SaveChangesAsync();
            }

            var existingLectorsDb = _context.Lectors_Lections.Where(n => n.LectionId == data.Id).ToList();
            _context.Lectors_Lections.RemoveRange(existingLectorsDb);
            await _context.SaveChangesAsync();

            foreach (var lectorId in data.LectorIds)
            {
                var newLectorLection = new Lector_Lection()
                {
                    LectionId = data.Id,
                    LectorId = lectorId
                };
                await _context.Lectors_Lections.AddAsync(newLectorLection);
            }
            await _context.SaveChangesAsync();

        }
	}
}
