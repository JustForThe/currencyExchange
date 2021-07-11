using AutoMapper;
using currencyExchangeService.Application.Common.Behaviours;
using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Application.CurrencyRates;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace currencyExchangeService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            services.AddSingleton<ICurrncyExchangeMarkupManager, CurrncyExchangeMarkupManager>();
            services.AddSingleton<ICurrencyExchangeRateManager, CurrencyExchangeRateManager>();

            return services;
        }
    }
}
