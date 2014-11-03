using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.ModelBinding;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{
    public class GenericController : AdminControllerBase
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {



            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index()
        {
            if (Context.Request.Path.StartsWithSegments(new Microsoft.AspNet.Http.PathString("/blackmarket")))
            {
                var page = new vNextAdminLib.Resources.TestAdminPage();
                if (Context.Request.Method == "POST")
                {
                    await TryUpdateModelAsync(page.Model);
                    var form=Context.Request.GetFormAsync();
                    return View("Page", page.Post(Context.Request.QueryString, await form));
                }
                else
                {
                    return View("Page", page.Get(Context.Request.QueryString));
                }
            }

            return View("error");
        }
    }
}
