using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VideoGameStore.Domain.Contracts.General;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Infrastructure.Database;
using VideoGameStore.Infrastructure.Handler;
using VideoGameStore.Infrastructure.Repository;
using VideoGameStore.Infrastructure.Utils;
using VideoGameStore.Application.Interfaces;
using VideoGameStore.Infrastructure.Security;
using VideoGameStore.Presentation.Config.Jwt;


namespace VideoGameStore.Infrastructure.Config
{
    public static class InfrastrutureConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Settings
            services.Configure<AppEnvironment>(configuration.GetSection("AppEnvironment"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppEnvironment>>().Value);

            services.AddJwtAuthentication(configuration);

            services.AddHttpContextAccessor().AddHttpClient();

            // ExceptionHandler registrado como open-generic
            services.AddSingleton(typeof(IExceptionHandler<>), typeof(ExceptionHandler<>));

            // Base de datos
            services.AddDbContext<DatabaseContext>();

            // Repositorios y Unit of Work
            services.AddScoped<IDeliveryTypeRepository, DeliveryTypeRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            
            //JWT
            services.AddScoped<ITokenService, TokenService>();
            
            return services;
        }
    }
}
