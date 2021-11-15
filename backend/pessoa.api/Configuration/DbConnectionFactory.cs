using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Configuration
{
    static class DbConnectionFactory
    {
        public static OdbcConnection CreateConnection()
        {
            var configuration = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json")
                                   .Build();

            String connectionString = configuration.GetConnectionString("OdbcConnString");

            return new OdbcConnection(connectionString);
        }
    }
}
