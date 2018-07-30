using Coop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

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
        public DbSet<Role> Roles { get; set; }
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
            UserProfile user6 = new UserProfile { SurName = "Dariborev", FirstName = "Lena", Email = "Dariib@tut.by", };

            db.Users.AddRange(new List<UserProfile> { user1, user2, user3, user4, user5, user6 });
            db.SaveChanges();

            db.Managers.Add(new Manager { Id = user1.Id });

            Role role1 = new Role { Name = "manager", UserProfile = user1 };
            db.Roles.Add(role1);
            db.SaveChanges();

            var house = new House()
            {
                Country = "Беларусь",
                City = "Минск",
                Street = "Октября",
                HouseNumber = 12,
                NumberOfApartments = 120,
                Age = 10
            };

            db.Companys.Add(new Company
            {
                Date = DateTime.Now,
                Name = "Lol",
                Password = "123",
                ManagerId = user1.Id,
                Houses = new List<House>
                {
                    house
                }
            });

            db.Managers.Add(new Manager { Id = user2.Id });
            Role role2 = new Role { Name = "manager", UserProfile = user2 };
            db.Roles.Add(role2);
            db.SaveChanges();
            db.Companys.Add(new Company
            {

                Date = DateTime.Now,
                Name = "Lol",
                Password = "123",
                ManagerId = user2.Id,
                Houses = new List<House>
                {
                    new House()
                    {
                        Country = "Беларусь",
                        City = "Витебск",
                        Street = "Ленина",
                        HouseNumber = 3,
                        NumberOfApartments = 120,
                        Age = 10
                    }
                }
            });
            db.SaveChanges();

            db.Workers.Add(new Worker {
                HouseId = house.Id,
                Id = user1.Id,
                Profession = "Электрик"
            });
            db.SaveChanges();

            base.Seed(db);
        }

    }
}
