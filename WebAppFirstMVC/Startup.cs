using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAppFirstMVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddMvc()//enable ous to use MVC
                .AddRazorRuntimeCompilation();//needed if you want to use and use Browserlink & one more line of code in the Configure method below.
                                              // also need to install two NuGet packages
                                              // 1: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
                                              //    controll its the right version 3.1.10 for a Core 3.1 MVC project.
                                              // 2: Microsoft.VisualStudio.Web.BrowserLink
                                              //    controll its the right version 2.2.0 for a Core 3.1 MVC project.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();//needed if you want to use and use Browserlink & one more line of code in the ConfigureServices method above.
            }

            app.UseStaticFiles();//opens up access to the wwwroot folder so we can use our files there like css/javascript/images...
            app.UseDefaultFiles();//enables cliants to access html files in the wwwroot folder.

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "myCarsList",
                    pattern: "Car-Listings/{action=Index}/{id?}",//compers vs url request from user({id?} is a optinal parameter and is therefore not requierd).
                    defaults: new { controller = "Cars", action = "Index" });//set what controller and action to be used.

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");// {name of varibale} {name? the ? indecates that this veribale is optinal and dose not need to be pressent}
            });
            // more information at https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1
        }
    }
}
