using Microsoft.AspNetCore.Builder;

namespace AccountOwnerServer.Extensions
{
    /// <summary>
    /// ExceptionMiddlewareExtensions class
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// ConfigureCustomExceptionMiddleware method
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        { 
            app.UseMiddleware<ExceptionMiddleware>(); 
        }
    }
}
