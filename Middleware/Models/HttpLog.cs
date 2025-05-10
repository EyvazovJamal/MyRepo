using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Models;
public class HttpLog
{
    public int Id { get; set; }
    public string? RequestId { get; set; }

    public string? Url { get; set; }

    public string? RequestBody { get; set; }

    public string? RequestHeaders { get; set; }

    
    public string? MethodType { get; set; } 

    public string? ResponseBody { get; set; }

    public string? ResponseHeaders { get; set; }

    
    public int StatusCode { get; set; }

    public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;

    public DateTime? EndDateTime { get; set; }

    public string? ClientIp { get; set; }



   public HttpLog(
    string? requestId, 
    string? url, 
    string? requestBody, 
    string? requestHeaders, 
    string? methodType, 
    string? responseBody, 
    string? responseHeaders, 
    int statusCode, 
    string? clientIp)
    {
        this.RequestId = requestId;
        this.Url = url ?? string.Empty;
        this.RequestBody = requestBody;
        this.RequestHeaders = requestHeaders;
        this.MethodType = methodType;
        this.ResponseBody = responseBody;
        this.ResponseHeaders = responseHeaders;
        this.StatusCode = statusCode;
        this.CreationDateTime = DateTime.UtcNow;
        this.ClientIp = clientIp;
    }

    public HttpLog()
    {
        
    }
   
}
