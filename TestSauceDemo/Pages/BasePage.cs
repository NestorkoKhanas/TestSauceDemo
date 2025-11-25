using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSauceDemo.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
