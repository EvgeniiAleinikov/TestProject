using Coop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Coop
{
    public class BaseContext : DbContext
    {
        public BaseContext():base("name=BaseContext")
        { }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Roomer> Roomers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<House> Houses { get; set; }

        public DbSet<UserProfile> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Roomer>().ToTable("Roomers");
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.Entity<House>().ToTable("Hauses");

            modelBuilder.Entity<UserProfile>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DbInitializer : DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext db)
        {
            db.Managers.Add(new Manager { Id = 1, SurName = "Golovin", FirstName = "ALeks", Email = "Golova@tut.by", Password = "5121977" });
            db.Managers.Add(new Manager { Id = 1, SurName = "Gugin", FirstName = "Vania", Email = "Vitia@tut.by", });
            db.Managers.Add(new Manager { Id = 1, SurName = "Lozin", FirstName = "serg", Email = "Serg@tut.by", });

            db.Workers.Add(new Worker { Id = 1, SurName = "Solin", FirstName = "kst9", Email = "Koleno@tut.by", });
            db.Workers.Add(new Worker { Id = 1, SurName = "Adriva", FirstName = "Gena", Email = "ADriva@tut.by", });
            db.Workers.Add(new Worker { Id = 1, SurName = "Dariborev", FirstName = "Lena", Email = "Dariib@tut.by", });

            db.Roomers.Add(new Roomer { Id = 1, SurName = "Lok9", FirstName = "che9", Email = "Lok9@tut.by", });
            db.Roomers.Add(new Roomer { Id = 1, SurName = "Dul9", FirstName = "cveta", Email = "Diuch@tut.by", });
            db.Roomers.Add(new Roomer { Id = 1, SurName = "Kuka", FirstName = "sonia", Email = "Switch@tut.by", });

            base.Seed(db);
        }

    }
}
