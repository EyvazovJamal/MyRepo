using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Responses;

public class InternalServerErrorResponse
{

    public string Message { get; set; }

    public InternalServerErrorResponse(string message)
    {
        this.Message=message;
    }
    
}
