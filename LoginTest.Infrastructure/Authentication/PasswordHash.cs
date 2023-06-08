using System;
using LoginTest.Application.Authentication.Commons;
using Crypto = BCrypt.Net.BCrypt;

namespace LoginTest.Infrastructure.Authentication;

public class PasswordHash : IPasswordHash
{
	public PasswordHash()
	{
	}

    public string Generate(string value)
    {
        return Crypto.HashPassword(value);
    }

    public bool Verify(string value, string hashedValue)
    {
        return Crypto.Verify(value, hashedValue);
    }
}

