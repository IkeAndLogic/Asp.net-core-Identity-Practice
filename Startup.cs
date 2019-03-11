using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
//using WebApplication1.Configuration;

namespace WebApplication1
{
    public class Startup
    {

        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<TransportDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc();

            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<TransportDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            ////to configure customized path
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Employee/Login";

            //});


        }

        ////This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        ////public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        ////{
        ////    if (env.IsDevelopment())
        ////    {
        ////        app.UseDeveloperExceptionPage();

        ////        app.UseStaticFiles();

        ////        app.UseAuthentication();
        ////        app.UseMvc(routes =>
        ////        {
        ////            routes.MapRoute(
        ////            name: "default",
        ////            template: "{controller=Home}/{action=Index}/{id?}");
        ////        });
        ////    }

        ////}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}