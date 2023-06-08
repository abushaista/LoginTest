using System;
using LoginTest.Application.Abstraction.Messaging;
using LoginTest.Application.Authentication.Commons;
using LoginTest.Domain.Authentication;
using LoginTest.Domain.Repositories;
using LoginTest.Domain.Shared;

namespace LoginTest.Application.Authentication.Commands;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHash _hash;

    public RegisterCommandHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository, IPasswordHash hash)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _hash = hash;
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Result.Failure<AuthenticationResult>(new Error("401", "Email already in used"));
        }
        var password = _hash.Generate(request.Password);
        var user = new User { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = password };

        await _userRepository.Add(user);

        var token = _tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);

    }
}

