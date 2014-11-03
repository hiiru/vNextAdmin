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

namespace vNextAdmin
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseServices(services =>
            {
                services.AddEntityFramework().AddSqlServer();
                //Configure DbContext
                services.SetupOptions<DbContextOptions>(options =>
                {
                    options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Code\Admin\vNextAdmin\db.mdf;Integrated Security=True;Connect Timeout=30");
                });

                // Add Identity services to the services container
                services.AddIdentitySqlServer<AdminIdentityDbContext, IdentityUser>().AddAuthentication();

                services.AddMvc();
            });

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
                    name: "default",
                    template: "{*url}",
                    defaults: new { controller = "Generic", action = "Index" });
            });


        }
    }
}
