using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components.Navigation
{
    public class MenuItem : IAdminMenuEntry
    {
        public MenuItem()
        {
            _children = new List<IAdminMenuEntry>();
        }
        public string ViewComponentIdentifier { get { return "Navigation"; } }
        public string ViewComponentMethod { get { return "MenuItem"; } }
        private List<IAdminMenuEntry> _children;
        public List<IAdminMenuEntry> Children { get { return _children; } }

        public bool HasChildren { get { return _children.Count > 0; } }

        public bool IsTopMenu { get; set; }

        public string Label { get; set; }

        public string Target { get; set; }

        public string Icon { get; set; }

        public MenuItemType Type { get; set; }

        
    }
    public enum MenuItemType
    {
        Link,
        Divider
    }
}