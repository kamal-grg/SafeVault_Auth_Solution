using SafeVaultAuth.Models;
using SafeVaultAuth.Services;

var authService = new AuthService();
var authzService = new AuthorizationService();

Console.Write("Username: ");
var username = Console.ReadLine();

Console.Write("Password: ");
var password = Console.ReadLine();

if (authService.Login(username, password, out User user))
{
    Console.WriteLine($"Welcome, {user.Username}! Role: {user.Role}");

    if (authzService.HasAccess(user, "Admin"))
    {
        Console.WriteLine("Access granted to Admin Dashboard.");
    }
    else
    {
        Console.WriteLine("Access restricted to Admin only.");
    }
}
else
{
    Console.WriteLine("Invalid login.");
}
