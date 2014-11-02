using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vNextAdmin.Controllers
{ 
    public class HomeController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var row = new vNextAdminLib.Components.Common.Row();
            row.Children.Add(new vNextAdminLib.Components.Dashboard.CountPanel
            {
                IconCss = "comments",
                ColorCss = "primary",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new vNextAdminLib.Components.Dashboard.CountPanel
            {
                IconCss = "comments",
                ColorCss = "red",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new vNextAdminLib.Components.Dashboard.CountPanel
            {
                IconCss = "comments",
                ColorCss = "green",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new vNextAdminLib.Components.Dashboard.CountPanel
            {
                IconCss = "comments",
                ColorCss = "default",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });


            return View(row);
        }
    }
}
