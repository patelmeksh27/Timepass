using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Infrastructure.Entities;

namespace Project.Infrastructure.Contracts
{
    public interface IUserRepository
    {
         Task<User> GetByUsernameAsync(string username);
    Task<User> GetByUsernamePasswordAsync(string username, string password);
    Task AddAsync(User user);
    
    }
}