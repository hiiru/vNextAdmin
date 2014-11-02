using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.SqlServer;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;

namespace vNextAdminLib.Data
{
    public class AdminIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        private static bool _created = false;

        public AdminIdentityDbContext(IServiceProvider serviceProvider, IOptionsAccessor<DbContextOptions> optionsAccessor)
            : base(serviceProvider, optionsAccessor.Options)
        {
            
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET vNext
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }
    }
}