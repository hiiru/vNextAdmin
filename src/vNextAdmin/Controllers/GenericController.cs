using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{
    public class GenericController : AdminControllerBase
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {



            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            return View("error");
        }
    }
}
