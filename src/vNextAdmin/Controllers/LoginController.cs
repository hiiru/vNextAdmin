using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using vNextAdmin.Models.Login;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{
    public class LoginController : Controller
    {
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
                //TODO: login
                return null;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult logOut()
        {
            //TODO: logout
            return RedirectToAction("Index", "Home");
        }
    }
}
