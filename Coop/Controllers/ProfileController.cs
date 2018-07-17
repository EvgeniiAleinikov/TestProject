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
        public ProfileController()
        {   }

        [HttpGet]
        public ActionResult MyCompanys()
        {
            User.Identity.GetUserId<int>();
            int id = new UserProfileRepository(new BaseContext()).GetById(User.Identity.GetUserId<int>()).Manager.Id;
            List<Company> companys = new CompanyRepository(new BaseContext()).GetAll().Where(c => c.ManagerId == id).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult MyCompany(string Name)
        {
            return View(new CompanyRepository(new BaseContext()).GetAll().FirstOrDefault(item => item.Name == Name));
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserModel model = new UserProfileRepository(new BaseContext()).GetUserById(User.Identity.GetUserId<int>());
                return View(model);
            }
            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        public ActionResult UserProfile(UserModel newData)
        {
            new UserProfileRepository(new BaseContext()).UpdateById(new UserProfileRepository(new BaseContext())
                .GetById(User.Identity.GetUserId<int>()).Update(newData),User.Identity.GetUserId<int>());
            return View(newData);
        }
    }
}