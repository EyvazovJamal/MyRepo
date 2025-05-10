using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Repositories.Base;

public interface IHttpLogRepository
{
    public Task InsertAsync(HttpLog httpLog);
}
