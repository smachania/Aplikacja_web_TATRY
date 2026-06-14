using Microsoft.EntityFrameworkCore;

namespace App_web_Tatry.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <Szlak> Szlaki { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TatryDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
