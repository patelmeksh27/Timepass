using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Application.DTOs;

namespace Project.Application.Contract
{
    public interface IAuthService
    {
      Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDtos dto);
      string GenerateToken(string userId, string username, string role);  
    }
}