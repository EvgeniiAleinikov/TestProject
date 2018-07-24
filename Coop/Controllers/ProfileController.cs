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
            var manager = new ManagerRepository(new BaseContext())
                .CollectionLoadandGetById(User.Identity.GetUserId<int>(),"Companys");                    
            //new ManagerRepository(new BaseContext()).CollectionLoad(manager,"Companys");

            return View(CompanyModel.GetCompanyModelList(manager));
        }

        [HttpGet]
        public ActionResult MyCompany(int id)
        {
            var company = new CompanyRepository(new BaseContext())
                .GetById(id);
            new CompanyRepository(new BaseContext())
                .CollectionLoad(company, "Houses");

            var model = new CompanyModel(company);
            return View(model);
        }

        [HttpGet]
        public ActionResult House(int id)
        {
            House house = new HouseRepository(new BaseContext())
                .GetById(id);
            new HouseRepository(new BaseContext())
                .DataLoad(house, new string[] { "Workers", "Roomers" });
            return View(new HouseModel(house));
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

        [HttpPost]
        public ActionResult NewHouse(HouseModel model)
        {
            if (ModelState.IsValid)
            {
                var ripo = new HouseRepository(new BaseContext());

                if (ripo.IsUniqie(model))
                {
                    var house = new House(model, new CompanyRepository(new BaseContext()).GetById(model.Id));
                    ripo.Create(house);
                }
                else
                { 
                    ModelState.AddModelError("Address", "Данный дом уже управляеться");
                }
            }

            return Redirect("MyCompany/" + model.Id);

        }
    }
}