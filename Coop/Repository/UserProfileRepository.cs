using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;

namespace Coop.Repository
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(BaseContext context) : base(context)
        {}

        public UserProfile getUserProfile(LoginModel model)
        {
            UserProfile user = DbSet.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            return user;
        }

    }
}