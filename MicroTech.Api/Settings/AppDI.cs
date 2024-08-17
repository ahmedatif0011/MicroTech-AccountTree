using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MicroTech.Data;
using MicroTech.Infrastructure;
using MicroTech.Services;
using Serilog;
using System.Globalization;
using MicroTech.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using MicroTech.Infrastructure.Interfaces.Context;

namespace MicroTech.Api.Settings
{
    public static class AppDI
    {
        public static void Services(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Local"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure
                (
                    maxRetryCount: 5, // Number of retry attempts
                    maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                    errorNumbersToAdd: null // SQL error numbers to trigger the retry logic (null will include all transient errors)
                ));
            });

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
            //builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            #endregion


            #region Localization
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                     new CultureInfo("en-US"),
                     new CultureInfo("de-DE"),
                     new CultureInfo("fr-FR"),
                     new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion
        }

    }
}
