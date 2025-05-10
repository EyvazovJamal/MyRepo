using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Middleware.Models;

namespace Middleware.Repositories.Base;

public interface IHttpLogRepository
{
    public Task InsertAsync(HttpLog httpLog);
}
