using OpenQA.Selenium;
using TestSauceDemo;
using TestSauceDemo.Pages;

namespace NuNitTestsSauceDemo.Tests
{
    [TestFixture]
    public class InformationTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;
        private InformationPage informationPage;
        List<object> testData = ["John","Doe",12345];
        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            informationPage = new InformationPage(driver);
            loginPage.Open();
            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            inventoryPage.AddToCartByName("Sauce Labs Bolt T-Shirt");
            inventoryPage.GoToCart();
        }
        [Test]
        public void Successful_Fill_Information() => informationPage.ToOrderCards("John", "Doe", "12345");
        
        [Test]
        public void EmptyFirstName_ShowsError()
        {
            informationPage.ToOrderCards("", "Doe", "12345");
            Assert.That(informationPage.GetErrorMessage(), Does.Contain("First Name is required"));
        }

        [Test]
        public void EmptyLastName_ShowsError()
        {
            informationPage.ToOrderCards("John", "", "12345");
            Assert.That(informationPage.GetErrorMessage(), Does.Contain("Last Name is required"));
        }

        [Test]
        public void EmptyPostalCode_ShowsError()
        {
            informationPage.ToOrderCards("John", "Doe", "");
            Assert.That(informationPage.GetErrorMessage(), Does.Contain("Postal Code is required"));
        }

        [TearDown]
        public void TearDown() => driver?.Dispose();


    }
}
