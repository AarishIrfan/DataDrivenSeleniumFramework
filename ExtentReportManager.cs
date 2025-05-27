using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.Extensions;

namespace DataDrivenSeleniumFramework
{
    public class ExtentReport
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();

            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }

        public void inti()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new EdgeDriver(options);

        }
        public void TakeScreenshot(Status status, string stepDetail)
        {

            string path = @"D:\DataDrivenSeleniumFramework\bin\Debug\Screenshots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());


        }

        public void Write(By by, string data, string detail)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Entry Failed" + ex);
            }
        }

        public void Click(By by, string detail)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed" + ex);
            }
        }
    }
}
        
    