using Assigment3WebApiDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace Assigment3WebApiDatabase.Persistence
{
    
    public class PersonDBContext: DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Persons.db");
        }
    }
}