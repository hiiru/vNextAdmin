using System;
using System.Collections.Generic;
using vNextAdminLib.Resources;

namespace vNextAdminLib.Modules
{
    public interface IAdminModule
    {
        List<IAdminResource> Resources { get; }
    }
}