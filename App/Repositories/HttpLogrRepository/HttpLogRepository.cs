using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using App.Models;
using App.Options;
using App.Repositories.Base;

namespace App.Repositories;

public class HttpLogRepository : IHttpLogRepository
{
    private string connectionString;
    

    public HttpLogRepository(IOptionsSnapshot<DataBaseOptions> options)
    {
        this.connectionString=options.Value.ConnectionString;
    }


    public async Task InsertAsync(HttpLog httpLog)
    {
        using (var connection = new SqlConnection(this.connectionString)){
            await connection.OpenAsync();

             await connection.ExecuteAsync(
                sql: @"INSERT INTO HttpLog 
                        (RequestId, Url, RequestBody, RequestHeaders, MethodType, 
                         ResponseBody, ResponseHeaders, StatusCode, CreationDateTime, EndDateTime, ClientIp) 
                      VALUES 
                        (@RequestId, @Url, @RequestBody, @RequestHeaders, @MethodType, 
                         @ResponseBody, @ResponseHeaders, @StatusCode, @CreationDateTime, @EndDateTime, @ClientIp);",
                param: httpLog);
        }
    }
}
