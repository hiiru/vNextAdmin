using System.Collections.Generic;
using vNextAdminLib.Components;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;

namespace vNextAdminLib.Resources
{
    public interface IAdminResource
    {
        string ResourceName { get; }

        AdminResourceType Type { get; }
        
        object HandleRequest(HttpContext context);
    }
}