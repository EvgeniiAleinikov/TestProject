using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Coop.IRepository;
using Coop.Repository;

namespace Coop.Controllers
{
    public class AccountController : Controller
    {
        UserProfileRepository repository;

        public AccountController()
        {
            repository = new UserProfileRepository(new BaseContext());
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ClaimsIdentity ClaimCreate(UserProfile user)
        {
            ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "OWIN Provider", ClaimValueTypes.String));
            if (user.Role != null)
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role, ClaimValueTypes.String));
            return claim;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfile user = await repository.getUserProfile(model);

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

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registr(RegModel model)
        {

            return RedirectToAction("Index", "Home");
        }
    }
}