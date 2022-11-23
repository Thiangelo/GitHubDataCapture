using GitHubDataCapture.Tests.Base;
using NUnit.Framework;

namespace GitHubDataCapture.Tests.IntegrationTest
{
    [TestFixture]
    public class GitHubControllerIntegrationTest : BaseSetup
    {
        [Test, Order(1)]
        public void Get_All_Detailed_Repositories_Fail()
        {
            var response = HttpClient.GetAsync($"{BaseUrl}/getalldetailedrepositories").Result;

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("InternalServerError"));
        }

        [Test, Order(2)]
        public void Get_All_Basic_Repositories_Fail()
        {
            var response = HttpClient.GetAsync($"{BaseUrl}/getallbasicrepositories").Result;

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("InternalServerError"));
        }

        [Test, Order(3)]
        public void Search_And_Save_Repositories_Sucess()
        {
            HttpContent httpContent = null;
            var response = HttpClient.PostAsync($"{BaseUrl}/searchandsaverepositories", httpContent).Result;

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
        }

        [Test, Order(4)]
        public void Get_All_Detailed_Repositories_Sucess()
        {
            var response = HttpClient.GetAsync($"{BaseUrl}/getalldetailedrepositories").Result;

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
        }

        [Test, Order(5)]
        public void Get_All_Basic_Repositories_Sucess()
        {
            var response = HttpClient.GetAsync($"{BaseUrl}/getallbasicrepositories").Result;

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
        }
    }
}
