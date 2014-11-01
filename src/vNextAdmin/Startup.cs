using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileSystems;
using System.IO;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;

namespace vNextAdmin
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            InitStaticContent(app);

            app.UseServices(services =>
            {
                services.AddMvc();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute(
                //    name: "api",
                //    template: "{controller}/{id?}");
            });
        }

        private void InitStaticContent(IApplicationBuilder app)
        {
            var staticContent = Path.Combine(AppContext.BaseDirectory, "wwwroot", "static");
            app.UseStaticFiles(new StaticFileOptions {
                FileSystem = new PhysicalFileSystem(staticContent),
                RequestPath = new PathString("/static")
            });
        }
    }
}
