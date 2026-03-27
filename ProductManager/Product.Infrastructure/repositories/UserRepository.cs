using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Contracts;
using Project.Infrastructure.Data;
using Project.Infrastructure.Entities;

namespace Project.Infrastructure.repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ProductDbContext _context;
        public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User> GetByUsernamePasswordAsync(string username, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    }
}