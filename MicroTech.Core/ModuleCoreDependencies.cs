using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MicroTech.Core.Bahaviors;
using MicroTech.Core.Filters;
using System.Reflection;

namespace MicroTech.Data
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Mediator Config.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<AuthAttribute>();

            //validators 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
