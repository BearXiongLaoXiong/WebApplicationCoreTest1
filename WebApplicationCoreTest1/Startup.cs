using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplicationCoreTest1.Common.Filter;
using WebApplicationCoreTest1.Common.Middleware;

namespace WebApplicationCoreTest1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                //options.Filters.Add(typeof(CustomGlobaFilterAttribute));
            });
            //services.AddTransient<CustomExceptionFilterAttribute>();
            //services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RefuseStealMiddleware>();
            //app.Use(next => async context =>
            //{
            //    //await context.Response.WriteAsync("111 START<br>  ");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync($"111 END <br>{context.Response.StatusCode}   ");
            //});
            //app.Use(next => async context =>
            //{
            //    //await context.Response.WriteAsync("222 START</br>   ");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync($"222 END</br>{context.Response.StatusCode}   ");
            //});
            //app.Use(next => async context =>
            //{
            //    //await context.Response.WriteAsync("333 START</br>   ");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync($"333 END</br>{context.Response.StatusCode}   ");
            //});
            app.UseResponseCaching();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
