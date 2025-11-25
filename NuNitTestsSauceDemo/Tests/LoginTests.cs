using NUnit.Framework;
using OpenQA.Selenium;
using TestSauceDemo.Pages;
using TestSauceDemo;

namespace TestSauceDemo.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            loginPage.Open();
        }

        [Test]
        public void SuccessfulLogin_StandardUser_RedirectsToInventory()
        {
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        public void EmptyUsername_ShowsError()
        {
            loginPage.Login("", "secret_sauce");
            Assert.That(loginPage.GetErrorMessage(), Does.Contain("Username is required"));
        }

        [Test]
        public void EmptyPassword_ShowsError()
        {
            loginPage.Login("standard_user", "");
            Assert.That(loginPage.GetErrorMessage(), Does.Contain("Password is required"));
        }

        [Test]
        public void LockedOutUser_ShowsError()
        {
            loginPage.Login("locked_out_user", "secret_sauce");
            Assert.That(loginPage.GetErrorMessage(), Does.Contain("Sorry, this user has been locked out"));
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }
    }
}