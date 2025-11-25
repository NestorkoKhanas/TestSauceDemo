using OpenQA.Selenium;
using TestSauceDemo;
using TestSauceDemo.Pages;
namespace SaucedemoTests.Tests
{
    [TestFixture]
    public class InventoryTests
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
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        public void AddTwoItems_UpdatesCartBadge()
        {
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }
    }
}