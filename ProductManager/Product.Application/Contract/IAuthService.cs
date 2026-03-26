using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Contract
{
    public interface IAuthService
    {
      string GenerateToken(string userId, string username, string role);  
    }
}