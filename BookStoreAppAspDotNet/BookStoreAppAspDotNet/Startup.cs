using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppAspDotNet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // app.UseRouting();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/new", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World form new middleware \n");
            //     });
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Hello im from first middle ware. \n");
            //     await next();
            //     await context.Response.WriteAsync("Hello im from first middle ware response \n");

            // });

            // app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Helllo Im from Second Middleware. \n");
            //    await next();
            //    await context.Response.WriteAsync("Hello im from second middle ware response\n");

            //});
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("im from third middle ware \n");
            //     await next();
            //     await context.Response.WriteAsync("im from third middle ware response \n");
            // });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            
        }
    }
}
