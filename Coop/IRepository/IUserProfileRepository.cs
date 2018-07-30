using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coop.IRepository
{
    interface IUserProfileRepository: IRepository<UserProfile>
    {
        UserProfile getUserProfile(LoginModel model);
        UserModel GetUserById(int id);
        bool IsValidEmail(string Email);
    }
}