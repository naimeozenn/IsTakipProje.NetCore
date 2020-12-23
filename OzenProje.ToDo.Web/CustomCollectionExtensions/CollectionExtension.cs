using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OzenProje.ToDo.Business.Concrete;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt => {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;


            })
             .AddEntityFrameworkStores<ToDoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipcookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }
      
        public static void AddCustomValidator(this IServiceCollection services)
        {

            services.AddTransient<IValidator<AciliyetAddDto>, AciliyetAddValidator>();
            services.AddTransient<IValidator<AciliyetUpdateDto>, AciliyetUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<GorevAddDto>, GorevAddValidator>();
            services.AddTransient<IValidator<GorevUpdateDto>, GorevUpdateValidator>();
            services.AddTransient<IValidator<RaporAddDto>, RaporAddValidator>();
            services.AddTransient<IValidator<RaporUpdateDto>, RaporUpdateValidator>();
        }
    }
}
