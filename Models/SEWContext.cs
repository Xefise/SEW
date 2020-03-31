using Microsoft.EntityFrameworkCore;

namespace SEW.Models
{
    public class SEWContext : DbContext
    {
        public SEWContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SEWdatabase.db");
        }
    }
}
