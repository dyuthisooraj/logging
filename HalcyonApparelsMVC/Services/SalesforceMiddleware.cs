using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using HalcyonApparelsMVC.Interfaces;

namespace HalcyonApparelsMVC.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SalesforceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticate _authenticate;
        public SalesforceMiddleware(RequestDelegate next, IAuthenticate authenticate)
        {
            _next = next;
            _authenticate = authenticate;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("Acces_token") == null)
            {
                var tempAcessToken = _authenticate.Authenticate();
                httpContext.Session.SetString("Acces_token", tempAcessToken);
            }


            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SalesforceMiddlewareExtensions
    {
        public static IApplicationBuilder UseSalesforceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SalesforceMiddleware>();
        }
    }
}