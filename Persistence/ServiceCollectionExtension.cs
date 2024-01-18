using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.Context;
using Persistence.DbConfig;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Data.Common;
using System.Reflection;

namespace Persistence
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            // Replace with your connection string.
            var connectionString = configuration.GetSection(nameof(DbConnectionString)).Get<DbConnectionString>()?.ConnectionString;

            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            // Unit of Work


            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion, mySqlOptions =>
                    {
                        mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    })
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableDetailedErrors()
            )
                .AddTransient<ApplicationDbSeeder>();
            return services;
        }

        //public static IServiceCollection AddIdentityServices(this IServiceCollection services) { 
        //}

        public static void AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
