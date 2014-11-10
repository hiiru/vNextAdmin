using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{
    public class GenericController : AdminControllerBase
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {



            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index(string module, string resource)
        {
            if (module == "Dashboard")
                return View("Index");

            //TODO: change this to a dynamic object which is injected
            var modules = vNextAdminLib.StaticExampleData.GetModules();
            var match = modules.FirstOrDefault(m => m.ModuleName == module);
            if (match != null)
            {
                var admResource = match.GetResource(resource, Context);
                if (admResource != null)
                {
                    switch (admResource.Type)
                    {
                        case vNextAdminLib.Resources.AdminResourceType.AdminPage:
                            return View("Page", admResource.HandleRequest(Context));

                        case vNextAdminLib.Resources.AdminResourceType.API:
                            return Json(admResource.HandleRequest(Context));
                    }
                }
            }
            return View("error");
        }
    }
}
