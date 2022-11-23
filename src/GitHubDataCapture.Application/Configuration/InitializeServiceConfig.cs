using GitHubDataCapture.Domain.Interfaces;
using GitHubDataCapture.Infra.Configuration;
using GitHubDataCapture.Infra.Repository;
using GitHubDataCapture.Service.Service;
using Microsoft.EntityFrameworkCore;

namespace GitHubDataCapture.Application.Configuration
{
    public static class InitializeServiceConfig
    {
        public static void InitDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGitHubService, GitHubService>();
            services.AddTransient<IGitHubRepository, GitHubRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<GitHubContext>(options => options.UseInMemoryDatabase(databaseName: "Repositories"));
            services.GitHubConfigInitialize(configuration);
            services.AddAutoMapper(typeof(AutoMapperProfileConfig));
        }
    }
}
