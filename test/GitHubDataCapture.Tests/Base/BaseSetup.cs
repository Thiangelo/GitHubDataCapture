using GitHubDataCapture.Tests.Configuration;
using Microsoft.AspNetCore.Authentication;

namespace GitHubDataCapture.Tests.Base
{
    public class BaseSetup
    {
        public static string BaseUrl = "/api/GitHub";
        public static HttpClient HttpClient => new InicializeApplicationConfig().CreateDefaultClient();
    }
}
