using Newtonsoft.Json;

namespace GitHubDataCapture.Domain.Models
{
    public class Repositories
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
