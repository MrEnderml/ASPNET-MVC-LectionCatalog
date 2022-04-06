using LectionCatalog.Models;
using LectionCatalog.Data.Enum;
using Microsoft.AspNetCore.Identity;
using LectionCatalog.Data.Static;

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
                            Year = 2003,
                            ImageURL = "https://i.ytimg.com/vi/pJUttqlDEHw/maxresdefault.jpg",
                            isFavorite = false,
                            isWatchLater = false,
                            Duration = 21,
                            LinkURL = "https://www.youtube.com/embed/pJUttqlDEHw",
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
                            Year = 2017,
                            ImageURL = "",
                            Duration = 33,
                            LinkURL = "",
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
                            Year = 2007,
                            ImageURL = "",
                            Duration = 54,
                            LinkURL = "",
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
                            Year = 2014,
                            ImageURL = "",
                            Duration = 43,
                            LinkURL = "",
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
                            Year = 2007,
                            ImageURL = "",
                            Duration = 55,
                            LinkURL = "",
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
                            LectorId = 3,
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
                            LectorId = 5,
                            LectionId = 5
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@lCatalog.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Text@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@lCatalog.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-User",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Text@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
