using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TestSauceDemo
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--guest");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-cache");

            ChromeDriver driver = new ChromeDriver(options);

            return driver;

        }
    }
}
