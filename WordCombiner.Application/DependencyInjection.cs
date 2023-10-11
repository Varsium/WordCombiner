using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace WordCombiner.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            services
                .AddLogging()
                .AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(DependencyInjection)),includeInternalTypes: true)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddMediatR(config =>
            {
                config.AsTransient();
            }, Assembly.GetAssembly(typeof(DependencyInjection)));
            return services;
        }
    }
}