using System;
using System.Collections.Generic;
using vNextAdminLib.Resources;

namespace vNextAdminLib.Modules
{
    public class CRUDModule<T> : IAdminModule
    {
        public List<IAdminResource> Resources
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}