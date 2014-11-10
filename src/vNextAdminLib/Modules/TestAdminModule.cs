using Microsoft.AspNet.Http;
using System.Collections.Generic;
using vNextAdminLib.Resources;

namespace vNextAdminLib.Modules
{
    public class TestAdminModule : IAdminModule
    {
        public string ModuleName { get { return "blackmarket"; } }

        public IAdminResource GetResource(string resource, HttpContext context)
        {
            return new TestAdminPage();
        }
    }
}