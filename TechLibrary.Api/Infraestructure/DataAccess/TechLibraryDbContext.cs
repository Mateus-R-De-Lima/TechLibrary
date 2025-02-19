using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain;

namespace TechLibrary.Api.Infraestructure.DataAccess
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Rocketseat\\Nlw Connect\\TechLibrary\\DB\\TechLibraryDb.db");
        }
    }
}
