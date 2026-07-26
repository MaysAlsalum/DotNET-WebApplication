using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace DotNET_WebApplication

{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Modify the request or response here
            httpContext.Response.Headers.Add("Custom-Header", "CustomMiddleware Response");
            await _next(httpContext);
        }
    }
}