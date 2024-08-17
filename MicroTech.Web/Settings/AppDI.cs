using Microsoft.EntityFrameworkCore;
using MicroTech.Data;
using MicroTech.Infrastructure;
using MicroTech.Services;
using Serilog;
using MicroTech.Infrastructure.Persistence.Context;
using MicroTech.Infrastructure.Interfaces.Context;
using MicroTech.Web.Services;

namespace MicroTech.Web.Settings
{
    public static class AppDI
    {
        public static void Services(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
            builder.Services.AddScoped<Func<ApplicationDbContext>>((provider) => () => provider.GetService<ApplicationDbContext>());
            builder.Services.AddScoped<ApplicationDbContext>();
            #region Serilog
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .WriteTo.Console()
              .CreateLogger();
            builder.Services.AddSerilog();
            #endregion
            #region Dependency Injections
            builder.Services
                .AddInfrastructureDependencies(builder.Configuration)
                .AddServiceDependencies()
                .AddCoreDependencies()
                .AddServiceRegistration(builder.Configuration);
            #endregion

        }

    }
}
