using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components
{
    /// <summary>
    /// This item contains the shared Properties for Items on an Admin Page
    /// </summary>
    public interface IAdminPageItem : IAdminComponent
    {
        bool AllowsChildren { get; }

        List<IAdminPageItem> Children { get; }
    }
}