using System;
using LoginTest.Domain.Authentication;

namespace LoginTest.Application.Authentication.Commons;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}


