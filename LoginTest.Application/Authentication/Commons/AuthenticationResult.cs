using System;
using LoginTest.Domain.Authentication;

namespace LoginTest.Application.Authentication.Commons;

public sealed record AuthenticationResult(User User, string Token);



