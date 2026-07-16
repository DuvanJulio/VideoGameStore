using Microsoft.OpenApi;
using System.Runtime.CompilerServices;
using VideoGameStore.Infrastructure.Utils;
using VideoGameStore.Infrastructure.Utils.Attributes;
using VideoGameStore.Presentation.OptionsSetup;

namespace VideoGameStore.Presentation.Config
{
    public static class PresentationConfig
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<AppEnvironmentSetup>();

            var appEnv = new AppEnvironment();
            configuration.GetSection(nameof(AppEnvironment)).Bind(appEnv);

            services.AddCORS();

            services.AddOpenAPIConfigurationService();

            return services;
        }

        private static IServiceCollection AddOpenAPIConfigurationService(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info.Version = "v1.0.0";
                    document.Info.Title = "Video Game Store";
                    document.Info.Description = "Este servicio expone las funcionalidades de una tienda virtual para la compra de video juegos de multiples plataformas.";
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Video Game Store Support",
                        Email = "duvanxjulio@gmail.com",
                    };

                    return Task.CompletedTask;
                });
            });

            services.AddMvc(mvc =>
            {
                mvc.Conventions.Add(new ControllerNameAttributeConvention());
            });

            return services;
        }

        private static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .WithMethods("GET", "POST", "PUT","DELETE")
                           .WithHeaders("uuId", "timestamp", "systemId");
                });
            });

            return services;
        }
    }
}
