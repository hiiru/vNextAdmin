using System;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace vNextAdmin.Components.Navigation
{
    [ViewComponent(Name = "NavTopMenu")]
    public class NavTopMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}