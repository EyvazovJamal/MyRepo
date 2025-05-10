using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using App.Services.Base;

namespace App.Services;

public class TestService : ITestService
{
    public void DontPutNull(string? text)
    {
        ArgumentNullException.ThrowIfNull(text);
    }

    public void FindBook()
    {
       throw new KeyNotFoundException();
    }

    public void NeverCrashes()
    {
        throw new Exception("I crashed!!!");
    }
}
