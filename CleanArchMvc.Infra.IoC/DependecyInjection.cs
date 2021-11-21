using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region commits
            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            ////optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true");
            //optionsBuilder
            //.UseLoggerFactory(_logger)
            //.EnableSensitiveDataLogging()
            //.UseSqlServer("Data Source=DESKTOP-97V2AS0\\SQLEXPRESS;Initial Catalog=CursoEFCore;Integrated Security=true",
            #endregion 

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //Esse comando permite ao sistema que gere resiliência de conexão com o BD:
            p => p.EnableRetryOnFailure(
                    maxRetryCount: 2,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null)
            .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            .MigrationsHistoryTable("Clean_Architecture_Course")));

            //b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName),

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
