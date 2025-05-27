using AventStack.ExtentReports;
using DataDrivenSeleniumFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DataDrivenSeleniumTests
{
    [TestClass]
    public class SeleniumTests : ExtentReport
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {

            inti();
            LogReport("Testing");
            driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Cleanup()
        {

            Thread.Sleep(3000);
            extentReports.Flush();
            driver.Close();

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        public void TestCase_DataDriven_CSV_001()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            IWebDriver driver = new ChromeDriver();
            Login login = new Login();
            login.login_Execution(driver,url, username, password);
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginButton = wait.Until(Driver =>
            {
                var element = driver.FindElement(By.CssSelector("#login > button"));
                return (element.Displayed && element.Enabled) ? element : null;
            });
            // Scroll into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);

            // --- UPDATED: pause + JS click instead of normal click ---
            System.Threading.Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", loginButton);
            driver.Quit();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        public void TestCase_DataDriven_CSV_002()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Write(By.Id("username"), username, "Enter your username");
            Write(By.Id("password"), password, "Enter your password");
            //driver.FindElement(By.Id("username")).SendKeys(username);
            //driver.FindElement(By.Id("password")).SendKeys(password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginButton = wait.Until(Driver =>
            {
                var element = driver.FindElement(By.CssSelector("#login > button"));
                return (element.Displayed && element.Enabled) ? element : null;
            });

            // Scroll into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);

            // --- UPDATED: pause + JS click instead of normal click ---
            System.Threading.Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", loginButton);
            driver.Quit();
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        public void TestCase_DataDriven_CSV_003()
        {
            exParentTest = extentReports.CreateTest("Project Test");

            exChildTest = exParentTest.CreateNode("Login");
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            //EdgeOptions options = new EdgeOptions();
            //options.AddArguments("start-maximized", "incognito");
            //IWebDriver driver = new EdgeDriver(options);
            driver.Navigate().GoToUrl(url);
            //driver.FindElement(By.Id("username")).SendKeys(username);
            //driver.FindElement(By.Id("password")).SendKeys(password);
            

            Write(By.Id("username"), username, "Enter your username");

            Write(By.Id("password"), password, "Enter your password");
            //Click(By.CssSelector("#login > button"), "Click on submit button");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginButton = wait.Until(Driver =>
            {
                var element = driver.FindElement(By.CssSelector("#login > button"));
                return (element.Displayed && element.Enabled) ? element : null;
                Thread.Sleep(4000);
                TakeScreenshot(Status.Pass,"Click on button");
            });

            // Scroll into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);

            // --- UPDATED: pause + JS click instead of normal click ---
            System.Threading.Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", loginButton);
            driver.Quit();
        }
        }
    }


