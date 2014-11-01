using System;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace vNextAdmin.Components.Navigation
{
    [ViewComponent(Name = "NavTopDropdown")]
    public class NavTopDropdownComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}