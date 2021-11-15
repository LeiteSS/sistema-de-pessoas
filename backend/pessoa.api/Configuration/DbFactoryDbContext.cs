using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using pessoa.api.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Configuration
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<PessoaDbContext>
    {
        public PessoaDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                     .AddJsonFile("appsettings.json")
                                     .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PessoaDbContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(10, 3, 29)));
            PessoaDbContext contexto = new PessoaDbContext(optionsBuilder.Options);
            return contexto;
        }
    }
}
