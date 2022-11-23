using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubDataCapture.Infra.Configuration
{
    public static class GitHubConfig
    {
        private static IConfiguration _configuration;

        public static string Url => _configuration["GitHub:Url"];

        public static string Token => _configuration["GitHub:Token"]; 

        public static List<string> Languages => _configuration.GetSection("GitHub:Languages").Get<List<string>>();

        public static string NameSystem => _configuration["GitHub:NameSystem"];

        public static IServiceCollection GitHubConfigInitialize(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;
            
            return services;
        }
    }
}
