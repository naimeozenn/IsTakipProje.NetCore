using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzenProje.ToDo.Business.Concrete;
using OzenProje.ToDo.Business.DiContainer;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.Business.ValidationRules.FluentValidation;
using OzenProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OzenProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OzenProje.ToDo.DataAccess.Interfaces;
using OzenProje.ToDo.DTO.DTOs.AciliyetDtos;
using OzenProje.ToDo.DTO.DTOs.AppUserDtos;
using OzenProje.ToDo.DTO.DTOs.GorevDtos;
using OzenProje.ToDo.DTO.DTOs.RaporDtos;
using OzenProje.ToDo.Entities.Concrete;
using OzenProje.ToDo.Web.CustomCollectionExtensions;
using System;

namespace OzenProje.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();
            services.AddDbContext<ToDoContext>();
            services.AddCustomIdentity();
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomValidator();
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern:"{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute
                (
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
