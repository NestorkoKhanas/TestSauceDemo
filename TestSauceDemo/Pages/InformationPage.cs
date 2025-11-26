using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestSauceDemo.Pages
{
    class InformationPage : BasePage
    {
        public InformationPage(IWebDriver driver) : base(driver) { }

        private IWebElement firstName => Driver.FindElement(By.Id("first-name"));
        private IWebElement lastName => Driver.FindElement(By.Id("last-name"));
        private IWebElement postalCode => Driver.FindElement(By.Id("postal-code"));
        private IWebElement continueInformButton => Driver.FindElement(By.Id("continue"));
        private IWebElement shopButton => Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        private IWebElement checkOutButton => Driver.FindElement(By.Id("checkout"));
        private IWebElement errorMessage => Driver.FindElement(By.XPath("//h3[@data-test='error']"));


        public void ToOrderCards(string first, string last, string postal)
        {
            shopButton.Click();
            checkOutButton.Click();
            firstName.SendKeys(first);
            lastName.SendKeys(last);
            postalCode.SendKeys(postal);
            continueInformButton.Click();
        }
        public string GetErrorMessage() => errorMessage.Text;
    }
}
