using System.Net.Http;
using Marvel.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Marvel.Api.Tests
{
    public class BaseTest
    {
        protected readonly HttpClient _client;
        protected readonly string _baseUrl = "/v1/public";

        public BaseTest()
        {
            var host = new WebHostBuilder()
              .UseEnvironment("Development")
              .UseStartup<Startup>();

            var server = new TestServer(host);
            _client = server.CreateClient();

            DataGenerator.InitializeCharacters(server.Host);
        }
    }
}
