using SafeVaultAuth.Models;

namespace SafeVaultAuth.Services
{
    public class AuthorizationService
    {
        public bool HasAccess(User user, string requiredRole)
        {
            return user != null && user.Role == requiredRole;
        }
    }
}
