using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Dashboard;

namespace vNextAdmin.Components
{
    [ViewComponent(Name = "CountPanel")]
    public class CountPanelComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IAdminPageItem item)
        {
            var countItem = item as CountPanel;

            return View(countItem);
        }
    }
}