using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LoginTest.Domain.Authentication;

namespace LoginTest.Infrastructure.Persistence.Options;

public class UserConfigBuilder : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Role).HasMaxLength(50);
    }
}

