using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroTech.Data.Helper;
using MicroTech.Infrastructure.Interfaces.Repository;
using MicroTech.Infrastructure.Persistence.UnitOfWork;
using MicroTech.Infrastructure.Reposiotries.Configuration;
using MicroTech.Infrastructure.Interfaces.Dapper;
using MicroTech.Infrastructure.Persistence.DapperConfiguration;
using Microsoft.AspNetCore.Http;
using MicroTech.Infrastructure.Interfaces.Context;
using MicroTech.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;

namespace MicroTech.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Func<ApplicationDbContext>>((provider) => () => provider.GetService<ApplicationDbContext>());
            services.AddScoped<Func<SqlConnection>>((provider) => () => provider.GetService<SqlConnection>());
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<SqlConnection>();
            services.AddTransient<IApplicationSqlDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped(typeof(IRepositoryQuery<>), typeof(RepositoryQuery<>));
            services.AddScoped(typeof(IRepositoryCommand<>), typeof(RepositoryCommand<>));
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
            services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();
            return services;
        }
    }

}
