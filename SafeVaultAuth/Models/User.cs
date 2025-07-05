using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeVaultAuth.Models
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Admin, User
    }
}
