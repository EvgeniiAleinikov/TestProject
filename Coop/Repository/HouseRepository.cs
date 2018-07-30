using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coop.ViewModels;

namespace Coop.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(BaseContext context) : base(context)
        {
        }

        public bool IsUniqie(HouseModel house)
        {
            var address = house.getAddress();
            return this.DbSet.ToList().FirstOrDefault(u => new HouseModel(u).getAddress() == address) == null;
        }

        public UserValidModel UserToHouse(SignInModel signInModel, int id)
        {
            if (signInModel.IsRoomer)
            {
                return AddRoomer(signInModel, id);
            }
            else
            {
                return AddWorker(signInModel, id);
            }
        }

        UserValidModel AddRoomer(SignInModel signInModel, int userId)
        {
            var house = Context.Houses
                .Include("Roomers")
                .Include("Company")
                .FirstOrDefault(u => u.Id == signInModel.HouseId);

            bool validApartament = house.Roomers
                .FirstOrDefault(item => item.Number == signInModel.ApartamentNumber && item.Number <= signInModel.ApartamentNumber) == null;
            bool validUser = house.Roomers.
                FirstOrDefault(item => item.Id == userId) == null;
            bool validPassword = house.Company
                .Password == signInModel.Password;

            var validModel = new UserValidModel
            {
                IsRoomer = true,
                IsApartamentValid = validApartament,
                IsPasswordValid = validPassword,
                IsUserValid = validUser
            };

            if (house != null && validModel.IsApartamentValid && validModel.IsUserValid)
            {
                Context.Roomers.Add(new Roomer { Id = userId, HouseId = signInModel.HouseId, Number = signInModel.ApartamentNumber });
                var user = Context.Users.Find(userId);

                Role role = new Role { Name = "roomer", UserProfile = user };
                Context.Roles.Add(role);
                Context.SaveChanges();
            }
            return validModel;
        }

        UserValidModel AddWorker(SignInModel signInModel, int userId)
        {
            var house = Context.Houses
                .Include("Workers")
                .Include("Company")
                .FirstOrDefault(u => u.Id == signInModel.HouseId);

            bool validUser = house.Workers.
                FirstOrDefault(item => item.Id == userId) == null;
            bool validPassword = house.Company
                .Password == signInModel.Password;

            var validModel = new UserValidModel
            {
                IsRoomer = false,
                IsApartamentValid = true,
                IsPasswordValid = validPassword,
                IsUserValid = validUser
            };

            if (house != null && validModel.IsUserValid)
            {
                Context.Workers.Add(new Worker { Id = userId, HouseId = signInModel.HouseId });
                var user = Context.Users.Find(userId);

                Role role = new Role { Name = "worker", UserProfile = user };
                Context.Roles.Add(role);
                Context.SaveChanges();
            }

            return validModel;
        }
    }
}