using GitHubDataCapture.Domain.Interfaces;
using GitHubDataCapture.Domain.Models;
using GitHubDataCapture.Infra.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GitHubDataCapture.Service.Service
{
    public class GitHubService : IGitHubService
    {
        private IGitHubRepository _gitHubRepository;

        private static string Url => GitHubConfig.Url;
        private static string Token => GitHubConfig.Token;
        private static IEnumerable<string> Languages => GitHubConfig.Languages;
        private static string NameSystem => GitHubConfig.NameSystem;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public IEnumerable<Item> GetAllRepositories()
        {
            var result = _gitHubRepository.GetAllRepositories();

            if (!result.Any())
                throw new Exception("Empty database");

            return result;
        }

        public async Task<string> SearchAndSaveRepositories()
        {
            var message = "Repositories saved in memory";

            var repositories = await SearchRepositoriesAsync();

             await _gitHubRepository.SaveRepositories(repositories);

            return message;
        }

        private static async Task<IEnumerable<Item>> SearchRepositoriesAsync()
        {
            HttpClient client = new HttpClient();
            var respositories = new List<Item>();

            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", Token); ;
            client.DefaultRequestHeaders.Add("User-Agent", NameSystem);

            foreach (var language in Languages)
            {
                var urlComplete = Url.Replace("languageReplace", language);
                var response = await client.GetAsync(urlComplete);

                var repositoriesJson = await response.Content.ReadAsStringAsync();
                var repositories = JsonConvert.DeserializeObject<Repositories>(repositoriesJson);
                var item = repositories.Items.FirstOrDefault();

                respositories.Add(item);
            }

            return respositories;
        }
    }
}
