using NUnit.Framework;
using Rendeleskezelo;
using System.ComponentModel;
using System.Configuration;

namespace Rendeleskezelo.Tests
{
    [TestFixture]
    public class LoginFormTests
    {
        private LoginForm loginForm;

        [SetUp]
        public void SetUp()
        {
            // Set up a new instance of the form before each test
            loginForm = new LoginForm();
        }

        [Test]
        [TestCase("admin", "admin", DialogResult.OK)]  // Correct credentials
        [TestCase("admin", "wrongpassword", DialogResult.Cancel)]  // Incorrect password
        public void TestLoginForm(string username, string password, DialogResult expectedDialogResult)
        {
            // Arrange: Set the username and password
            loginForm.txtUsername.Text = username;
            loginForm.txtPassword.Text = password;

            // Act: Simulate button click
            loginForm.buttonLogin.PerformClick();

            // Assert: Check if the dialog result matches the expected result
            Assert.AreEqual(expectedDialogResult, loginForm.DialogResult);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            loginForm.Dispose();
        }
    }
}
