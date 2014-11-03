using System;
using System.Collections.Generic;
using vNextAdminLib.Components;

namespace vNextAdminLib.Resources
{
    public interface IAdminResource
    {
        string Url { get; }
        AdminResourceType Type { get; }

        List<IAdminPageItem> PageItems { get; }
    }
}