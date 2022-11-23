using GitHubDataCapture.Domain.Models;

namespace GitHubDataCapture.Domain.Interfaces
{
    public interface IGitHubService
    {
        IEnumerable<Item> GetAllRepositories();
        Task<string> SearchAndSaveRepositories();
    }
}
