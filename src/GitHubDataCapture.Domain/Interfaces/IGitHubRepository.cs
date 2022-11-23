using GitHubDataCapture.Domain.Models;

namespace GitHubDataCapture.Domain.Interfaces
{
    public interface IGitHubRepository
    {
        IEnumerable<Item> GetAllRepositories();
        Task SaveRepositories(IEnumerable<Item> Items);
    }
}
