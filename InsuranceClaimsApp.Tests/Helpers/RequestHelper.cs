using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace InsuranceClaimsApp.Tests.Helpers
{
    public static class RequestHelper
    {
        public const string AntiForgeryTokenName = "__RequestVerificationToken";
        public const string AntiForgeryCookieName = ".AspNetCore.Antiforgery.3O3bdg2xaZw";

        public static string GetAntiforgeryTokenValue(string htmlContent)
        {
            if (!htmlContent.Contains(AntiForgeryTokenName)) throw new System.ArgumentException("Failed retrieving antiforgery token");

            var antiforgeryTokenMatches = Regex.Match(htmlContent, $@"name=""{AntiForgeryTokenName}"" type=""hidden"" value=""([^""]+)"" \/\>");
            if (antiforgeryTokenMatches.Success)
            {
                return antiforgeryTokenMatches.Groups[1].Captures[0].Value;
            }

            throw new System.ArgumentException("Failed retrieving antiforgery token");
        }

        public static string GetAntiforgeryCookieValue(HttpResponseMessage response)
        {
            string antiForgeryCookie = response.Headers.GetValues("Set-Cookie")
                .FirstOrDefault(x => x.Contains(AntiForgeryCookieName));
            if (antiForgeryCookie is null)
            {
                throw new ArgumentException($"Cookie {AntiForgeryCookieName} not found in HTTP response", nameof(response));
            }
            string antiForgeryCookieValue = SetCookieHeaderValue.Parse(antiForgeryCookie).Value.ToString();
            return antiForgeryCookieValue;
        }
    }
}
