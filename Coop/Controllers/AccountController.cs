﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Coop.IRepository;
using Coop.Repository;
using Coop.Models;

namespace Coop.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        { }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ClaimsIdentity ClaimCreate(UserProfile user)
        {
            ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "OWIN Provider", ClaimValueTypes.String));
            foreach (var role in user.Roles)
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name, ClaimValueTypes.String));
            return claim;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfileRepository repository = new UserProfileRepository(new BaseContext());
                UserProfile user = repository.getUserProfile(model);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = ClaimCreate(user);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegModel model, string role)
        {
            if (ModelState.IsValid)
            {
                if (new UserProfileRepository(new BaseContext()).IsValidEmail(model) == true)
                {
                    model.RegUser(role);
                    Login(new LoginModel { Email = model.Email, Password = model.Password });
                }
                else
                {
                    ModelState.AddModelError("Email","Данная электронная почта уже занята!");
                }
                
            }
            return View(model);
        }
    }
}