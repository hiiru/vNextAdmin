using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using vNextAdminLib.Components;
using vNextAdminLib.Data;

namespace vNextAdminLib.Resources
{
    public class CRUDForm<T> : IAdminResource where T : class
    {
        public CRUDForm(AdminIdentityDbContext context)
        {
        }

        public string ResourceName { get { return "form"; } }

        public AdminResourceType Type { get { return AdminResourceType.AdminPage; } }

 
        public object HandleRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}