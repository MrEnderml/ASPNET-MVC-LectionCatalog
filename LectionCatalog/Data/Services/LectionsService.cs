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
                Views = data.Views,
                ImageURL = getYouTubeThumbnail(data.LinkURL),
                LinkURL = getCorrectYoutubeLink(data.LinkURL),
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

        public async Task UpdateLectionAsync(NewLectionVM data)
        {
            var dbLection = await _context.Lections.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbLection != null)
            {
                dbLection.Name = data.Name;
                dbLection.Description = data.Description;
                dbLection.ImageURL = getYouTubeThumbnail(data.LinkURL);
                dbLection.LinkURL = data.LinkURL;
                dbLection.Views = data.Views;
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

        public async Task DeleteLectionAsync(int id)
		{
            var lection = await _context.Lections.FirstOrDefaultAsync(n => n.Id == id);
            if(lection != null)
            {
                _context.Lections.Remove(lection);
                await _context.SaveChangesAsync();
            }
		}

		public async Task<List<Lection>> GetAllAsync()
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
                Year = Enumerable.Range(2000, 22).ToList(),
                LectionsCategory = LectionCategory.GetValues(typeof(LectionCategory)).Cast<LectionCategory>().ToList()
            };
            return response;
        }

        public async Task<IEnumerable> GetLectionsByList(string list)
        {
            List<string> filterList = list.Split(' ').ToList();
            var lections = await _context.Lections.Where(l => filterList.Any(i => i == l.Id.ToString())).ToListAsync();

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
 
        public async Task<IEnumerable> GetLectorsFilter(string name)
        {
            var lector = await _context.Lectors.FirstOrDefaultAsync(l => l.FullName.Contains(name));

            var lections = await _context.Lections.Include(ll => ll.Lectors_Lections).
                ThenInclude(l => l.Lector).Where(ll => ll.Lectors_Lections.All(n => n.LectorId == lector.Id)).ToListAsync();

            return lections;
        }

        public IEnumerable GetYearFilter(List<Lection> lect, int value)
        { 

            var lections = lect.Where(l => l.Year == value).ToList();

            return lections;
        }

        public IEnumerable GetCategoryFilter(List<Lection> lect, string value)
        {
            var lections = lect.Where(l => l.LectionCategory.ToString().Equals(value)).ToList();

            return lections;
        }

        public IEnumerable GetFilterTypes(List<Lection> lect, string value)
        {
            switch (value)
            {
                case "Views up": return lect.OrderBy(n => n.Views).ToList();
                case "Views down": return lect.OrderByDescending(n => n.Views).ToList();
                case "Released up": return lect.OrderBy(n => n.Year).ToList();
                case "Released down": return lect.OrderByDescending(n => n.Year).ToList();
            }

            return lect;
        }
        public string getYouTubeThumbnail(string YoutubeUrl)
        {
            YoutubeUrl = getUncorrectYoutubeLink(YoutubeUrl);
            string youTubeThumb = string.Empty;
            if (YoutubeUrl == "")
                return "";

            if (YoutubeUrl.IndexOf("=") > 0)
            {
                youTubeThumb = YoutubeUrl.Split('=')[1];
            }
            else if (YoutubeUrl.IndexOf("/v/") > 0)
            {
                string strVideoCode = YoutubeUrl.Substring(YoutubeUrl.IndexOf("/v/") + 3);
                int ind = strVideoCode.IndexOf("?");
                youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
            }
            else if (YoutubeUrl.IndexOf('/') < 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[3];
            }
            else if (YoutubeUrl.IndexOf('/') > 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[1];
            }

            return "http://img.youtube.com/vi/" + youTubeThumb + "/mqdefault.jpg";
        }     
        public string getCorrectYoutubeLink(string YoutubeUrl)
        {
            return YoutubeUrl.Replace("watch?v=", "embed/");
        }

        public string getUncorrectYoutubeLink(string YoutubeUrl)
        {
            if (YoutubeUrl.Contains("embed/"))
            {
                return YoutubeUrl.Replace("embed/", "watch?v=");
            }
            return YoutubeUrl;
        }
    }
}
