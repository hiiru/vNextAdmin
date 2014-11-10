using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using System;
using System.Collections.Generic;
using vNextAdminLib.Data;
using vNextAdminLib.Resources;

namespace vNextAdminLib.Modules
{
    public class CRUDModule<T> : IAdminModule where T : class
    {
        private string _moduleName;
        public CRUDModule(string moduleName)
        {
            if (moduleName==null)
                throw new ArgumentNullException("moduleName");
            _moduleName = moduleName;
        }
        public string ModuleName { get { return _moduleName; } }
        
        public IAdminResource GetResource(string resource, HttpContext context)
        {
            if (resource == string.Empty)
                resource = "list";
            //TODO: define ContextFactory or some other central db handling solution
            var dbContext = new GenericDbContext<T>(context.RequestServices, (IOptionsAccessor<DbContextOptions>)context.RequestServices.GetService(typeof(IOptionsAccessor<DbContextOptions>)));
            //var dbContext = new AdminIdentityDbContext(context.RequestServices, (IOptionsAccessor<DbContextOptions>)context.RequestServices.GetService(typeof(IOptionsAccessor<DbContextOptions>)));
            switch (resource)
            {
                case "list":
                    return new CRUDList<T>(dbContext);
                //case "detail":
                //    return new CRUDForm<T>(dbContext);
            }
            return null;
        }
    }
}