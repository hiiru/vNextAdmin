using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components.Dashboard
{
    public class CountPanel : IAdminPageItem
    {
        public string ViewComponentIdentifier { get { return "CountPanel"; } }
        public string ViewComponentMethod { get { return null; } }
        public bool AllowsChildren { get { return false; } }
        public List<IAdminPageItem> Children { get { return null; } }

        public int Count { get; set; }
        public string Message { get; set; }
        public string LinkText { get; set; }
        public string LinkTarget { get; set; }
        public string IconCss { get; set; }
        public string ColorCss { get; set; }


    }
}