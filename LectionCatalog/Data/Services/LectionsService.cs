﻿using LectionCatalog.Data.Enum;
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

		public Task AddNewLectionAsync(NewLectionVM data)
		{
			throw new NotImplementedException();
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
