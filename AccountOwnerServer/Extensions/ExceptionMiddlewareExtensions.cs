using Microsoft.AspNetCore.Builder;

namespace AccountOwnerServer.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        { app.UseMiddleware<ExceptionMiddleware>(); }
    }
}
