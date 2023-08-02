using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.EF
{
    public class SeafoodDbcontextFactory : IDesignTimeDbContextFactory<SeafoodDbcontext>
    {
        public SeafoodDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("seafoodDb");

            var optionsBuilder = new DbContextOptionsBuilder<SeafoodDbcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SeafoodDbcontext(optionsBuilder.Options);
        }
    }
}
