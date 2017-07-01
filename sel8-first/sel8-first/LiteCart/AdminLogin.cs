using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace sel8_first
{
    [TestFixture]
    public class AdminLogin
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            InternetExplorerOptions IeCapabilities = new InternetExplorerOptions();
            IeCapabilities.IgnoreZoomLevel = true;
            IeCapabilities.EnableNativeEvents = false;
            IeCapabilities.EnablePersistentHover = true;
            driver = new InternetExplorerDriver(IeCapabilities);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            wait.Until(ExpectedConditions.TitleContains("My Store"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username"))).SendKeys("admin");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password"))).SendKeys("admin");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("login"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[title=\"Logout\"]")));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
