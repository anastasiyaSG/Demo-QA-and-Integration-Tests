
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.IO;
using System.Reflection;

namespace Exam.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected WebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("-headless");
            //var uri = new Uri("http://192.168.0.215:2323/wd/hub");

            //Driver = new RemoteWebDriver(uri, options)
            //Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Driver = new WebDriver();

            Driver.Start(Browser.Chrome);

            Builder = new Actions(Driver.WrappedDriver);
        }
    }
}
