using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;  
using System;

namespace DataDrivenSeleniumFramework
{
    internal class Login
    {
        public void login_Execution(IWebDriver driver, string url, string username, string password)
        {
            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => drv.FindElement(By.Id("username")).Displayed);
            driver.FindElement(By.Id("username")).SendKeys(username);

            wait.Until(drv => drv.FindElement(By.Id("password")).Displayed);
            driver.FindElement(By.Id("password")).SendKeys(password);
        }
    }
}
