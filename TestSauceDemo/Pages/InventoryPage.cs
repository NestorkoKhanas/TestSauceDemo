using OpenQA.Selenium;

namespace TestSauceDemo.Pages
{
    public class InventoryPage : BasePage
    {
        private IWebElement cartButton => Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));

        public InventoryPage(IWebDriver driver) : base(driver) { }
        public void AddToCartByName(string productName)
        {
            IWebElement button = Driver.FindElement(By.XPath($"//div[text()='{productName}']/following::button[text()='Add to cart']"));
            button.Click();
        }
        public void GoToCart() => cartButton.Click();

    }
}