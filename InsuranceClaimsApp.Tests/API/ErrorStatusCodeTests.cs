using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceClaimsApp.Tests.API
{
    public class ErrorStatusCodeTests : IClassFixture<CustomWebApplicationFactory<Startup>>

    {
        public HttpClient _client;

        public ErrorStatusCodeTests(CustomWebApplicationFactory<Startup> webApplicationFactory)
        {
            _client = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task NonExistingPage_GETPage_StatusCodeNotFound()
        {
            var httpResponse = await _client.GetAsync("/blah");

            // must be 404.
            Assert.Equal(System.Net.HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

    }
}
