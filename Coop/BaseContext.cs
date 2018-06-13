using Coop.Models;
using System.Data.Entity;

namespace Coop
{
    public class BaseContext : DbContext
    {
        public BaseContext() 
                : base("DefaultConnection")
        { }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Roomer> Roomers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<House> Houses { get; set; }


        
    }
}
