using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.IO;


namespace TodoAppBe.Database{
    public class ApplicationContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            DbContextOptionsBuilder<ApplicationContext> builder = new DbContextOptionsBuilder<ApplicationContext>().UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                opts => opts.MigrationsAssembly("TodoAppBe"));

            return new ApplicationContext(builder.Options);
        }
    }

}

