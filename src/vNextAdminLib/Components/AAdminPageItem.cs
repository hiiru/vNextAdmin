using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components
{
    public abstract class AAdminPageItem : IAdminPageItem
    {
        public bool AllowsChildren { get { return false; } }
        public List<IAdminPageItem> Children { get { return null; } }

        public abstract string ViewComponentIdentifier { get; }
        public abstract string ViewComponentMethod { get; }
    }
}