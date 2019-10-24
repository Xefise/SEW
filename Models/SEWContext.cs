using System.Data.Entity;

namespace SEW.Models
{
    public class SEWContext : DbContext
    {
        public SEWContext() : base("DBConnection") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
