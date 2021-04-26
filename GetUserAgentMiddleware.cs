using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace zad6Middleware
{
    public class GetUserAgentMiddleware
    {
        private RequestDelegate _next;
        public GetUserAgentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            string coll;

            // Load Header collection into NameValueCollection object.
            coll = context.Request.Headers["User-Agent"];
            context.Response.WriteAsync(coll);
            return _next(context);
        }


    }

    public static class  GetUserAgentMiddlewareExtensions
    {
        public static IApplicationBuilder UseGetUserAgentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GetUserAgentMiddleware>();
        }
    }
}
