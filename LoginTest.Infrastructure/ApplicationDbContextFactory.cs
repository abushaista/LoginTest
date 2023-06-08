using System;
using LoginTest.Infrastructure.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LoginTest.Infrastructure;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private IConfiguration Configuration { get; set; }

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        Configuration = builder.Build();

        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();
        var dbOptions = new DbOptions();
        Configuration.Bind(DbOptions.SectionName, dbOptions);
        optionsBuilder.UseMySql(connectionString: dbOptions.ConnectionString,serverVersion: ServerVersion.AutoDetect(dbOptions.ConnectionString));
        return new ApplicationDbContext(options: optionsBuilder.Options);
    }
}

