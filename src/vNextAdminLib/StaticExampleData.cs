using System.Linq;
using System.Collections.Generic;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Navigation;

namespace vNextAdminLib
{
    public static class StaticExampleData
    {
        private static List<IAdminMenuEntry> _menu;

        public static IEnumerable<IAdminMenuEntry> GetMenu(bool top)
        {
            if (_menu == null)
            {
                var menu = new List<IAdminMenuEntry>();
                var topMenu = new MenuItem
                {
                    Label = "",
                    Target = "#",
                    Icon = "user",
                    IsTopMenu=true
                };
                topMenu.Children.Add(new MenuItem { Label = "Profile", Target = "#", Icon = "user" });
                topMenu.Children.Add(new MenuItem { Label = "Settings", Target = "#", Icon = "gear" });
                topMenu.Children.Add(new MenuItem { Type=MenuItemType.Divider});
                topMenu.Children.Add(new MenuItem { Label = "Logout", Target = "/logout", Icon = "sign-out" });
                menu.Add(topMenu);

                menu.Add(new MenuItem { Label = "Dashboard", Target = "/home/index", Icon = "dashboard" });
                menu.Add(new MenuItem { Label = "Testing", Target = "/home/test" });
                _menu = menu;
            }
            return _menu.Where(x=>x.IsTopMenu==top).ToList();
        }

    }
}