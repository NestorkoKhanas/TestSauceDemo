using OpenQA.Selenium;

namespace TestSauceDemo.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver) { }
        public void AddToCartByName(string productName)
        {
            IWebElement button = Driver.FindElement(By.XPath($"//div[text()='{productName}']/following::button[text()='Add to cart']"));
            button.Click();
        }

    }
}