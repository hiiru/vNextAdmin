using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components
{
    public abstract class AAdminPageItemChildren : IAdminPageItem
    {
        public bool AllowsChildren { get { return true; } }
        private List<IAdminPageItem> _children;
        public List<IAdminPageItem> Children { get { return _children; } }

        public AAdminPageItemChildren()
        {
            _children = new List<IAdminPageItem>();
        }

        
        public abstract string ViewComponentIdentifier { get; }
        public abstract string ViewComponentMethod { get; }
    }
}