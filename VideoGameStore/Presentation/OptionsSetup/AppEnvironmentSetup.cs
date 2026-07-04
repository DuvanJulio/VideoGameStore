using Microsoft.Extensions.Options;
using VideoGameStore.Infrastructure.Utils;

namespace VideoGameStore.Presentation.OptionsSetup
{
    public class AppEnvironmentSetup : IConfigureOptions<AppEnvironment>
    {
        private readonly IConfiguration _configuration;

        public AppEnvironmentSetup(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public void Configure(AppEnvironment options)
        {
            _configuration.GetSection(typeof(AppEnvironment).Name).Bind(options);
        }
    }
}