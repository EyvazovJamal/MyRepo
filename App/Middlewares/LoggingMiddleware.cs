using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Base;


namespace App.Middlewares;

public class LoggingMiddleware
{
    private RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next)
    {
        this.next=next;
    }

    public async Task InvokeAsync(HttpContext httpContext,IHttpLogger logger){
        await next.Invoke(httpContext);

        var message= httpContext.Items["exception"];

        await logger.LogAsync(httpContext,message?.ToString());
        
    }
}
