using System;
using LoginTest.Domain.Authentication;
using LoginTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoginTest.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        _dbContext.Set<User>().Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var data = await _dbContext.Set<User>().Where(x => x.Email == email).FirstOrDefaultAsync();
        return data;
    }
}

