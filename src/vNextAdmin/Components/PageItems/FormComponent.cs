using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Dashboard;

namespace vNextAdmin.Components
{
    [ViewComponent(Name = "Form")]
    public class FormComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IAdminPageItem item)
        {
            if (item != null)
                return View(item.ViewComponentMethod, item);
            return Content("");
        }
    }
}