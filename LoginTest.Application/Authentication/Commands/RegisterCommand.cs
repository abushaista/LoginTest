using System;
using LoginTest.Application.Abstraction.Messaging;
using LoginTest.Application.Authentication.Commons;

namespace LoginTest.Application.Authentication.Commands;

public record RegisterCommand(string FirstName,
    string LastName,
    string Email,
    string Password) : ICommand<AuthenticationResult>;


