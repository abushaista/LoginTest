using System;
namespace LoginTest.Application.Authentication.Commons;

public interface IPasswordHash
{
    string Generate(string value);
    bool Verify(string value, string hashedValue);
}


