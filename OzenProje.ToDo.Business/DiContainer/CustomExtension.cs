using Microsoft.Extensions.DependencyInjection;
using OzenProje.ToDo.Business.Concrete;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OzenProje.ToDo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.Business.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGorevService, GorevManager>();
            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IBildirimService, BildirimManager>();

            services.AddScoped<IGorevDal, EfGorevRepository>();
            services.AddScoped<IAciliyetDal, EfAciliyetRepository>();
            services.AddScoped<IRaporDal, EfRaporRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirimDal, EfBildirimRepository>();

 
        }
    }
}
