using LectionCatalog.Models;
using LectionCatalog.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace LectionCatalog.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Lectors.Any())
                {
                    context.Lectors.AddRange(new List<Lector>()
                    {
                        new Lector()
                        {
                            FullName = "Grigoriy Leps",
                            LectorPictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Bio = "Grigoriy Leps was born in 1987."
                        },
                        new Lector()
                        {
                            FullName = "Mr Don Stone",
                            LectorPictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",
                            Bio = "Grigoriy Leps was born in 1957. He has a great state of playing piano."
                        },
                        new Lector()
                        {
                            FullName = "Mark Wolter",
                            LectorPictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg",
                            Bio = "A greate psysic of our world!"
                        },
                        new Lector()
                        {
                            FullName = "Mark Twen ml",
                            LectorPictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg",
                            Bio = "Mark Twen ml was born in 1977. He is a good person."
                        },
                        new Lector()
                        {
                            FullName = "Adam Wolter",
                            LectorPictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            Bio = "He has 3 statement of math category"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Lections.Any())
                {
                    context.Lections.AddRange(new List<Lection>()
                    {
                        new Lection()
                        {
                            Name = "Based Story",
                            Description = "This is a story about based story",
                            Year = DateTime.Now.AddYears(-12),
                            ImageURL = "",
                            isFavorite = false,
                            isWatchLater = false,
                            Country = CountriesCategory.USA,
                            Views = 25000,
                            LectionCategory = LectionCategory.Physics,
                        },
                        new Lection()
                        {
                            Name = "Main math in life",
                            Description = "What is the math and what should you do about it?",
                            isFavorite = false,
                            isWatchLater = false,
                            Year = DateTime.Now.AddYears(-14),
                            ImageURL = "",
                            Country = CountriesCategory.USA,
                            Views = 225000,
                            LectionCategory = LectionCategory.Math,
                        },
                        new Lection()
                        {
                            Name = "History of Russia",
                            Description = "This is a story about based story",
                            isFavorite = false,
                            isWatchLater = false,
                            Year = DateTime.Now.AddYears(-3),
                            ImageURL = "",
                            Country = CountriesCategory.Russia,
                            Views = 53000,
                            LectionCategory = LectionCategory.History,
                        },
                        new Lection()
                        {
                            Name = "Fundamental theory of phusical",
                            Description = "This is a story about physical based story",
                            isFavorite = false,
                            isWatchLater = false,
                            Year = DateTime.Now.AddYears(-5),
                            ImageURL = "",
                            Country = CountriesCategory.China,
                            Views = 415000,
                            LectionCategory = LectionCategory.Physics,
                        },
                        new Lection()
                        {
                            Name = "What if a life?",
                            Description = "To be or not to be",
                            isFavorite = false,
                            isWatchLater = false,
                            Year = DateTime.Now.AddYears(-2),
                            ImageURL = "",
                            Country = CountriesCategory.Russia,
                            Views = 13000,
                            LectionCategory = LectionCategory.Philosophy,
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Lectors_Lections.Any())
                {
                    context.Lectors_Lections.AddRange(new List<Lector_Lection>()
                    {
                        new Lector_Lection()
                        {
                            LectorId= 1,
                            LectionId = 1
                        },
                        new Lector_Lection()
                        {
                            LectorId = 3,
                            LectionId = 1
                        },

                         new Lector_Lection()
                        {
                            LectorId = 1,
                            LectionId = 2
                        },
                         new Lector_Lection()
                        {
                            LectorId = 4,
                            LectionId = 2
                        },

                        new Lector_Lection()
                        {
                            LectorId = 1,
                            LectionId = 3
                        },
                        new Lector_Lection()
                        {
                            LectorId = 2,
                            LectionId = 3
                        },
                        new Lector_Lection()
                        {
                            LectorId = 5,
                            LectionId = 3
                        },


                        new Lector_Lection()
                        {
                            LectorId = 2,
                            LectionId = 4
                        },
                        new Lector_Lection()
                        {
                            LectorId = 3,
                            LectionId = 4
                        },
                        new Lector_Lection()
                        {
                            LectorId = 4,
                            LectionId = 4
                        },


                        new Lector_Lection()
                        {
                            LectorId = 2,
                            LectionId = 5
                        },
                        new Lector_Lection()
                        {
                            LectorId = 3,
                            LectionId = 5
                        },
                        new Lector_Lection()
                        {
                            LectorId = 4,
                            LectionId = 5
                        },
                        new Lector_Lection()
                        {
                            LectorId = 5,
                            LectionId = 5
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
