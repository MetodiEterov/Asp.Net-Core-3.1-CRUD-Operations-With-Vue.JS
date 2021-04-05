using AutoMapper;

using Entities.Contracts;
using Entities.DbContext;

using LoggerService;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Repository.Layer;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServicesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(configuration["mysqlconnection:connectionString"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IOwnerMemoryCache, OwnerMemoryCache>();

            services.Configure<IISOptions>(options =>
            {
                // Not implemented
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
