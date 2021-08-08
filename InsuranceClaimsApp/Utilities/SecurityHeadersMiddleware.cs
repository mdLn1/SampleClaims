using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Utilities
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            AddHttpHeader(ref httpContext, "X-Content-Type-Options", "nosniff");
            AddHttpHeader(ref httpContext, "X-Frame-Options", "deny");
            AddHttpHeader(ref httpContext, "X-XSS-Protection", "1; mode=block");
            AddHttpHeader(ref httpContext, "Content-Security-Policy", "default-src 'self'");
            AddHttpHeader(ref httpContext, "Referrer-Policy", "same-origin");

            await _next(httpContext);
        }

        private void AddHttpHeader(ref HttpContext httpContext, string headerName, string headerValue)
        {
            if (httpContext.Response.Headers.ContainsKey(headerName))
            {
                httpContext.Response.Headers.Remove(headerName);
            }
            httpContext.Response.Headers.Add(headerName, headerValue);

        }
    }
}
