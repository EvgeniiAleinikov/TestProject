using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coop.Models;
using Coop.Repository;
using Coop.ViewModels;

namespace Coop.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult UserProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserProfileRepository repo = new UserProfileRepository(new BaseContext());
                UserModel model = repo.GetUserById(User.Identity.GetUserId<int>());
                return View(model);
            }
            return RedirectToAction("Register", "Account");
        }
    }
}