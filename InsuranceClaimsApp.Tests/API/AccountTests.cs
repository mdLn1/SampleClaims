using InsuranceClaimsApp.Tests.Helpers;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceClaimsApp.Tests.API
{
    public class AccountTests : IClassFixture<CustomWebApplicationFactory<Startup>>

    {
        public HttpClient _client;
        public CustomWebApplicationFactory<Startup> _webApplicationFactory;

        public AccountTests(CustomWebApplicationFactory<Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _client = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task LoginPage_GETPage_StatusCodeOK()
        {
            // act
            var httpResponse = await _client.GetAsync("/Account/Login");
            httpResponse.EnsureSuccessStatusCode();

            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task LoginPage_POSTLogin_StatusCodeOK()
        {
            // arrange
            var httpGETResponse = await _client.GetAsync("/Account/Login");
            httpGETResponse.EnsureSuccessStatusCode();

            string content = await httpGETResponse.Content.ReadAsStringAsync();
            var antiforgeryToken = RequestHelper.GetAntiforgeryTokenValue(content);
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Account/Login");
            postRequest.Headers.Add("Cookie", new CookieHeaderValue(RequestHelper.AntiForgeryCookieName, RequestHelper.GetAntiforgeryCookieValue(httpGETResponse)).ToString());
            var formModel = new Dictionary<string, string>
                {
                    {RequestHelper.AntiForgeryTokenName,antiforgeryToken },
                    { "Username", "gemmela" },
                    { "Password", "Archie" }
                };
            postRequest.Content = new FormUrlEncodedContent(formModel);

            //act
            var httpResponse = await _client.SendAsync(postRequest);

            httpResponse.EnsureSuccessStatusCode();

            // assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponse.StatusCode);
        }

      

    }
}