using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using vNextAdminLib.Resources;

namespace vNextAdminLib.Modules
{
    public interface IAdminModule
    {
        string ModuleName { get; }
        IAdminResource GetResource(string resource, HttpContext context);
    }
}