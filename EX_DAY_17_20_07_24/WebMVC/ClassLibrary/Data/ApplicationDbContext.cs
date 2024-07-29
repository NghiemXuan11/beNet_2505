using System.Data.Entity;

namespace ClassLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=ConnString")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
