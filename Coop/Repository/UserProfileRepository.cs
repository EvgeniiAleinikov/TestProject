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

        public Task<UserProfile> getUserProfile(LoginModel model)
        {
             return DbSet.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        }

        public void Create(UserProfile user,string role)
        {
            base.Create(user);
        }
    }
}