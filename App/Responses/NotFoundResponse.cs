using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Responses;

public class NotFoundResponse
{
    public string Message { get; set; }

    public NotFoundResponse(string message)
    {
        this.Message = message;
    }   
}
