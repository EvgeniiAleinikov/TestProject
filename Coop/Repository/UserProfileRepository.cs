using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Coop.ViewModels;

namespace Coop.Repository
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(BaseContext context) : base(context)
        { }

        public UserProfile getUserProfile(LoginModel model)
        {
            UserProfile user = Context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            user.Roles = Context.Roles.Where(r => r.UserProfileId == user.Id).ToList();
            return user;
        }

        public UserModel GetUserById(int id)
        {
            UserModel user = new UserModel(Context.Users.Find(id));
            user.SetRoles(Context.Roles.Where(p => p.UserProfileId == id).ToList<Role>());
            return user;
        }

        public void Create(UserProfile user, string role)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            Context.Roles.Add(new Role { Name = "manager", UserProfile = user });
            Context.SaveChanges();
        }

        public bool IsValidEmail(RegModel regModel)
        {
            return this.DbSet.FirstOrDefault(p => p.Email == regModel.Email)==null;
        }
    }
}