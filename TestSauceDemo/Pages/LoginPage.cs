using OpenQA.Selenium;
using TestSauceDemo.Pages;

namespace TestSauceDemo.Pages
{
    public class LoginPage : BasePage
    {
        private const string WebURL= "https://www.saucedemo.com";

        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement UsernameInput => Driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => Driver.FindElement(By.CssSelector("h3[data-test='error']"));

        public void Open() => Driver.Navigate().GoToUrl(WebURL);

        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }

        public string GetErrorMessage() => ErrorMessage.Text;
    }
}