using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App_web_Tatry.Entities
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Szlak> Szlaki { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Szlak>().HasData(
                new Szlak
                {
                    Id = 1,
                    Nazwa = "Morskie Oko z Palenicy Białczańskiej",
                    Opis = "Najpopularniejszy szlak w Tatrach...",
                    Dlugosc = 7.8,
                    PoziomTrudnosci = "Łatwy",
                    KolorSzlakow = "Czerwony",
                    CzasPrzejscia = 2.5
                }
            );
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TatryDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
