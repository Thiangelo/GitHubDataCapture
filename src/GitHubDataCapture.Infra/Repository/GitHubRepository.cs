
using GitHubDataCapture.Domain.Interfaces;
using GitHubDataCapture.Domain.Models;

namespace GitHubDataCapture.Infra.Repository
{
    public class GitHubRepository : Repository<Item>, IGitHubRepository
    {
        public GitHubRepository(GitHubContext gitHubContext) : base(gitHubContext)
        {
        }

        public IEnumerable<Item> GetAllRepositories()
        {
            return GetAll();
        }

        public async Task SaveRepositories(IEnumerable<Item> Items)
        {
            await AddRangerAsync(Items);
        }
    }
}
