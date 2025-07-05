using NUnit.Framework;
using SafeVaultAuth.Models;
using SafeVaultAuth.Services;

namespace SafeVaultAuth.Tests
{
    public class AuthTests
    {
        private AuthService auth;
        private AuthorizationService authz;

        [SetUp]
        public void Setup()
        {
            auth = new AuthService();
            authz = new AuthorizationService();
        }

        [Test]
        public void TestInvalidLogin()
        {
            var result = auth.Login("wrong", "wrong", out var user);
            Assert.IsFalse(result);
            Assert.IsNull(user);
        }

        [Test]
        public void TestValidAdminLogin()
        {
            var result = auth.Login("admin", "admin123", out var user);
            Assert.IsTrue(result);
            Assert.AreEqual("Admin", user.Role);
        }

        [Test]
        public void TestAccessControl_UserCannotAccessAdmin()
        {
            auth.Login("john", "user123", out var user);
            var access = authz.HasAccess(user, "Admin");
            Assert.IsFalse(access);
        }

        [Test]
        public void TestAccessControl_AdminAccessGranted()
        {
            auth.Login("admin", "admin123", out var user);
            var access = authz.HasAccess(user, "Admin");
            Assert.IsTrue(access);
        }
    }
}
