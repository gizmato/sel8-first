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
    public class CSharpSeleniumTest
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://www.google.com/";
            wait.Until(ExpectedConditions.TitleContains("Google"));
            driver.FindElement(By.CssSelector("div.logo-subtext"));
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.logocont > h1 > a > img")));
            driver.FindElement(By.CssSelector("button.sbico-c")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - Поиск в Google"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
