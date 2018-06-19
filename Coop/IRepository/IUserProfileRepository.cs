﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coop.IRepository
{
    interface IUserProfileRepository: IRepository<UserProfile>
    {
        Task<UserProfile> getUserProfile(LoginModel model);
    }
}