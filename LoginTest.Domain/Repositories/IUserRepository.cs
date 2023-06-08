using System;
using LoginTest.Domain.Authentication;

namespace LoginTest.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task Add(User user);
}


