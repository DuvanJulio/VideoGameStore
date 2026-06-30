using FluentValidation;
using MediatR;
using VideoGameStore.Application.Behaviors;
using VideoGameStore.Infrastructure.Utils;

namespace VideoGameStore.Application.Config
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ApplicationConfig).Assembly;

            services.Configure<AppEnvironment>(configuration.GetSection("AppEnvironment"));

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });

            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            return services;
        }
    }
}
