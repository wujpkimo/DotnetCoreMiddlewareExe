using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Web1.Middlewares
{
    public static class JPMiddlewareExt
    {
        public static void UseJP(this IApplicationBuilder app)
        {
            app.UseMiddleware<JPMiddleware>();
        }
    }
    public class JPMiddleware
    {
        private readonly RequestDelegate _next;

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public JPMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("<H1>");
            await _next(context);
            await context.Response.WriteAsync("</H1>");
        }
    }
}
