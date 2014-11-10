using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using System;

namespace vNextAdminLib.Data
{
    public class GenericDbContext<T> : DbContext where T : class
    {
        public DbSet<T> Objects { get; set; }

        private static bool _created = false;

        public GenericDbContext(IServiceProvider serviceProvider, IOptionsAccessor<DbContextOptions> optionsAccessor)
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