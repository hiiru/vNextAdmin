using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using vNextAdminLib.Components;
using vNextAdminLib.Data;
using System.Linq;

namespace vNextAdminLib.Resources
{
    public class CRUDList<T> : IAdminResource where T : class
    {
        private GenericDbContext<T> _dbContext;
        public CRUDList(GenericDbContext<T> context)
        {
            _dbContext = context;
        }

        public string ResourceName { get { return "list"; } }

        public AdminResourceType Type { get { return AdminResourceType.API; } }


        public object HandleRequest(HttpContext context)
        {
            return _dbContext.Objects.ToList();
        }
    }
}