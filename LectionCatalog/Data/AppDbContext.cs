using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LectionCatalog.Models;

namespace LectionCatalog.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lector_Lection>().HasKey(am => new
            {
                am.LectorId,
                am.LectionId
            });

            modelBuilder.Entity<Lector_Lection>().HasOne(m => m.Lection).WithMany(am => am.Lectors_Lections).HasForeignKey(m => m.LectionId);
            modelBuilder.Entity<Lector_Lection>().HasOne(m => m.Lector).WithMany(am => am.Lectors_Lections).HasForeignKey(m => m.LectorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<Lector_Lection> Lectors_Lections { get; set; }
    }
}
