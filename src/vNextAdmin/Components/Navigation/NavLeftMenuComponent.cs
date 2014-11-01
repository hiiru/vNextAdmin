using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;

namespace vNextAdmin.Components.Navigation
{
    [ViewComponent(Name = "NavLeftMenu")]
    public class NavLeftMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}