using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Navigation;

namespace vNextAdmin.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string module)
        {
            switch (module)
            {
                case "NavTop":
                    return await NavTopMenu();
                case "NavLeft":
                    return await NavLeftMenu();
                default:
                    return Content("NavigationViewComponent: Unknown module: "+module);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(IAdminMenuEntry item)
        {
            if (item == null)
                return Content("");
            return View(item.ViewComponentMethod, item);
        }
        private async Task<IViewComponentResult> NavTopMenu()
        {
            //Replace with reflection or DB query
            var items = vNextAdminLib.StaticExampleData.GetMenu(true);
            return View("NavTop", items);
        }
        private async Task<IViewComponentResult> NavLeftMenu()
        {
            //Replace with reflection or DB query
            var items = vNextAdminLib.StaticExampleData.GetMenu(false);
            return View("NavLeft", items);
        }
    }
}