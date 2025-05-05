using NUnit.Framework;
using Rendeleskezeles;
using Rendeleskezelo;

namespace Rendeleskezelo.Tests
{
    [TestFixture]
    public class LoginFormTestFixture
    {
        // Teszt a felhasználónév érvényességére
        [Test, TestCase("admi", false), TestCase("adm", false), TestCase("ADMIN", false), TestCase("admin", true)]
        public void TestValidateUsername(string username, bool expectedResult)
        {
            // Arrange
            var authService = new AuthService("admin", "admin");

            // Act
            var actualResult = authService.Authenticate(username, "admin");

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Teszt a jelszó érvényességére
        [Test, TestCase("admi", false), TestCase("ADMIN", false), TestCase("admi1", false), TestCase("adMin", false), TestCase("AdmIn", false), TestCase("admin", true)]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var authService = new AuthService("admin", "admin");

            // Act
            var actualResult = authService.Authenticate("admin", password);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Teszt a sikeres regisztrációra (a példádhoz hasonlóan)
        [Test, TestCase("admin", "admin"), TestCase("irf@uni-corvinus.hu", "Abcd1234567")]
        public void TestRegisterHappyPath(string username, string password)
        {
            // Arrange
            var authService = new AuthService("admin", "admin");

            // Act
            var result = authService.Authenticate(username, password);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
