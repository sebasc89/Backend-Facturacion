using AutoMapper;
using DigitalWare.Facturacion.Common.Classes.Base.Repositories;
using DigitalWare.Facturacion.Common.Classes.Cache;
using DigitalWare.Facturacion.Common.Resources;
using DigitalWare.Facturacion.Domain.Services;
using DigitalWare.Facturacion.Infrastructure.Database.Context;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using DigitalWare.Facturacion.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DigitalWare.Facturacion.Config.Dependencies
{
    public class Container
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region Mapper

            services.AddMemoryCache();
            services.AddAutoMapper();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = configMapper.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            #region Conexion Base de datos

            services.AddDbContext<FacturacionContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMemoryCache();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<FacturacionContext, FacturacionContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region BaseRepositories

            services.AddScoped<IBaseCRUDRepository<Category>, CategoryRepository>();
            services.AddScoped<IBaseCRUDRepository<Customer>, CustomerRepository>();
            services.AddScoped<IBaseCRUDRepository<Product>, ProductRepository>();
            services.AddScoped<IBaseCRUDRepository<Order>, OrderRepository>();

            #endregion

            #region InterfaceRepositories

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            #endregion

            #region Services

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            #endregion

            #region Others

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IMemoryCacheManager, MemoryCacheManager>();
            #endregion
        }

        public static void CreateDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<FacturacionContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
