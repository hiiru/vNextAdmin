using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileSystems;
using System.IO;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using vNextAdminLib.Data;
using Microsoft.Framework.ConfigurationModel;

namespace vNextAdmin
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var configuration = new Configuration();
            configuration.AddJsonFile("config.json");

            app.UseStaticFiles();

            app.UseServices(services =>
            {
                services.AddEntityFramework().AddSqlServer();
                //Configure DbContext
                services.SetupOptions<DbContextOptions>(options =>
                {
                    options.UseSqlServer(configuration.Get("Data:Azure:ConnectionString"));
                });

                // Add Identity services to the services container
                services.AddIdentitySqlServer<AdminIdentityDbContext, IdentityUser>().AddAuthentication();

                services.AddMvc();

            });

            //Microsoft.Framework.DependencyInjection.ActivatorUtilities.GetServiceOrCreateInstance<>
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = ClaimsIdentityOptions.DefaultAuthenticationType,
                LoginPath = new PathString("/Login"),
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "test",
                    template: "Test/{action}/{id?}",
                    defaults: new { controller = "Test", action = "Index" });

                routes.MapRoute(
                    "admin module route",
                    "{module?}/{resource?}/{*urlParams}",
                    new { controller = "Generic", action = "Index", module="Dashboard", resource=string.Empty });

                //routes.MapRoute(
                //    name: "default",
                //    template: "{*url}",
                //    defaults: new { controller = "Generic", action = "Index" });
            });


        }
    }
}
