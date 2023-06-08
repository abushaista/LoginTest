using LoginTest.Application.Authentication.Commons;
using LoginTest.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LoginTest.Infrastructure.Persistence.Options;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LoginTest.Domain.Repositories;
using LoginTest.Infrastructure.Persistence;

namespace LoginTest.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services,
            ConfigurationManager config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHash, PasswordHash>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });
        var dbOptions = new DbOptions();
        config.Bind(DbOptions.SectionName, dbOptions);
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(dbOptions.ConnectionString, ServerVersion.AutoDetect(dbOptions.ConnectionString)));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("standard", pol => pol.RequireRole("user"));
            options.AddPolicy("admin", p => p.RequireRole("admin"));
        });
        return services;
    }
}

