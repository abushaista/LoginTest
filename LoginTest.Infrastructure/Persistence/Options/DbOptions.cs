using System;
namespace LoginTest.Infrastructure.Persistence.Options;

public class DbOptions
{
    public const string SectionName = "DbSettings";
    public string ConnectionString { get; set; } = string.Empty;
}

