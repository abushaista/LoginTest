using System;
namespace LoginTest.Contracts.Authentication;

public record LoginRequest(string Email, string Password);

