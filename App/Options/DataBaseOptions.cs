using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Options;

public class DataBaseOptions
{
    public string ConnectionString { get; set; }

    public DataBaseOptions(string ConnectionString)
    {
        this.ConnectionString=ConnectionString;
    }
    public DataBaseOptions()
    {
       ConnectionString = string.Empty;
    }
}
