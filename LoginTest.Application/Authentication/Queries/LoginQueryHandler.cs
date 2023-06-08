using System;
using LoginTest.Application.Abstraction.Messaging;
using LoginTest.Application.Authentication.Commons;
using LoginTest.Domain.Repositories;
using LoginTest.Domain.Shared;

namespace LoginTest.Application.Authentication.Queries;

public class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IPasswordHash _hash;
    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator, IPasswordHash hash)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _hash = hash;
    }
    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        if (user == null || !_hash.Verify(request.Password, user.Password))
        {
            return Result.Failure<AuthenticationResult>(new Error("401", "Invalid Credential"));
        }
        var token = _tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}

