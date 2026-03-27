using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Entities
{
    public class User
    {
         public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // later hash this
        public string? Role { get; set; }
        
    }
}