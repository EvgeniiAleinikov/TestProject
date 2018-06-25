using Coop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Coop
{
    public class BaseContext : DbContext
    {
        static BaseContext ()
        {
            Database.SetInitializer<BaseContext>(new DbInitializer());
        }

        public BaseContext() : base("name=BaseContext")
        { }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Roomer> Roomers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<House> Houses { get; set; }

        public DbSet<UserProfile> Users { get; set; }

    }

    public class DbInitializer : DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext db)
        {
            UserProfile user1 = new UserProfile { SurName = "Golovin", FirstName = "ALeks", Email = "Golova@tut.by", Password = "5121977" };
            UserProfile user2 = new UserProfile { SurName = "Gugin", FirstName = "Vania", Email = "Vitia@tut.by", };
            UserProfile user3 = new UserProfile { SurName = "Lozin", FirstName = "serg", Email = "Serg@tut.by", };
            UserProfile user4 = new UserProfile { SurName = "Solin", FirstName = "kst9", Email = "Koleno@tut.by", };
            UserProfile user5 = new UserProfile { SurName = "Adriva", FirstName = "Gena", Email = "ADriva@tut.by", };
            UserProfile user6 = new UserProfile { Id = 1, SurName = "Dariborev", FirstName = "Lena", Email = "Dariib@tut.by", };

            db.Users.AddRange(new List<UserProfile> { user1, user2, user3, user4, user5, user6 });
            db.SaveChanges();

            db.Managers.Add(new Manager { Id = user1.Id });

            db.Roomers.Add(new Roomer { Id = user1.Id } );

            db.Roomers.Add(new Roomer { Id = user2.Id });

            db.Workers.Add(new Worker { Id = user3.Id});
            db.SaveChanges();

            base.Seed(db);
        }

    }
}
