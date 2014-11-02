using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using vNextAdmin.Models.Login;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public UserManager<IdentityUser> UserManager { get; private set; }
        public SignInManager<IdentityUser> SignInManager { get; private set; }

        [HttpGet("/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {  
            return View();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var signInStatus = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                switch (signInStatus)
                {
                    case SignInStatus.Success:
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid username or password.");
                        return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult logOut()
        {
            SignInManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
