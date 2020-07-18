using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using StabilizeTestsDemos.ThirdVersion;
using System;

namespace Exam.Pages
{
    public class BasePage
    {
        public BasePage(WebDriver driver)
        {
            Driver = driver;
            Driver.WrappedDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Builder = new Actions(Driver.WrappedDriver);
        }

        public virtual string Url { get; }

        public WebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        public Actions Builder { get; set; }

        public void NaviteTo()
        {
            Driver.Navigate(Url);
        }

        public void WaitForLoad(int timeoutSec = 25)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WrappedDriver;
            WebDriverWait wait = new WebDriverWait(Driver.WrappedDriver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public WebElement ScrollTo(WebElement element)
        {
            ((IJavaScriptExecutor)Driver.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
            return element;
        }

        public void Scroll(WebDriver Driver)
        {
            IJavaScriptExecutor js = Driver.WrappedDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
        }

        public void ScrollUp(int offset)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.scrollBy(0, -{offset});");
        }

        public void MoveToNextTab()
        {
            Builder.SendKeys(Keys.Control + Keys.Tab);
        }

    }
}
