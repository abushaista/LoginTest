using LoginTest.Application.Authentication.Commons;
using LoginTest.Application.Abstraction.Messaging;

namespace LoginTest.Application.Authentication.Queries;

public sealed record LoginQuery(string Email, string Password) : IQuery<AuthenticationResult>;


