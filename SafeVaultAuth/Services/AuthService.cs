using SafeVaultAuth.Models;

namespace SafeVaultAuth.Services
{
    public class AuthService
    {
        private readonly List<User> _users;

        public AuthService()
        {
            _users = new List<User>
            {
                new User { Username = "admin", PasswordHash = AuthHelper.HashPassword("admin123"), Role = "Admin" },
                new User { Username = "john", PasswordHash = AuthHelper.HashPassword("user123"), Role = "User" }
            };
        }

        public bool Login(string username, string password, out User user)
        {
            user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            return AuthHelper.VerifyPassword(password, user.PasswordHash);
        }
    }
}
