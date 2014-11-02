using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Dashboard;

namespace vNextAdmin.Components
{
    [ViewComponent(Name = "Common")]
    public class CommonComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IAdminPageItem item)
        {
            if (item != null) 
                switch (item.ViewComponentMethod)
                {
                    case "row":
                        return await RenderRow(item);
                }
            return Content("");
        }

        private async Task<IViewComponentResult> RenderRow(IAdminPageItem item)
        {
            if (item==null || item.Children==null || item.Children.Count==0)
                return Content("");
            return View("row", item);
        }
    }
}