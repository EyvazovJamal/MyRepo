using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Middleware.Responses;

namespace Middleware.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next=next;
    }   
    public async Task InvokeAsync (HttpContext httpContext)
    {
        try
        {
            await next.Invoke(httpContext);
        }
        catch (ArgumentNullException ex)
        {
            httpContext.Response.StatusCode=(int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new BadRequestResponse (message: ex.Message){
                Parameter=ex.ParamName
            });
            httpContext.Items["exception"]=ex.ToString();
        
        } 
        catch (KeyNotFoundException ex)
        {
           httpContext.Response.StatusCode=(int)HttpStatusCode.NotFound;
           await httpContext.Response.WriteAsJsonAsync(new NotFoundResponse(message: "Not Found") );

           httpContext.Items["exception"] = ex.ToString();

        }
        catch(Exception ex) 
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new InternalServerErrorResponse(message: "Internal server error"));
            
            httpContext.Items["exception"] = ex.ToString();
        }
       
    }
}
