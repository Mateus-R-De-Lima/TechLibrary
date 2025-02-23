using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace TechLibrary.Api.Infraestructure.DataAccess
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Rocketseat\\Nlw Connect\\TechLibrary\\DB\\TechLibraryDb.db");
        }
    }
}
