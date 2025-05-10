using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Models;
using Middleware.Repositories.Base;
using Middleware.Services.Base;


namespace Middleware.Services;

public class HttpLogger : IHttpLogger
{
    private IHttpLogRepository repository;

    public HttpLogger(IHttpLogRepository repository)
    {
        this.repository=repository;
        
    }

    public async Task LogAsync(HttpContext context, string? message = null)
    {
        var log= new HttpLog(){
            RequestId=context.TraceIdentifier,
            Url=context.Request.Path,
            RequestBody=context.Request.Body.ToString(),
            RequestHeaders=context.Request.Headers.ToString(),
            MethodType=context.Request.Method,
            ResponseBody=context.Response.Body.ToString(),
            ResponseHeaders=context.Response.Headers.ToString(),
            StatusCode=context.Response.StatusCode,
            ClientIp=context.Connection.RemoteIpAddress?.ToString(),

        };
        await repository.InsertAsync(log);

    }
}
