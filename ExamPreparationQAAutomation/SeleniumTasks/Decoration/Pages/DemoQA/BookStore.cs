namespace SeleniumTasks.Decoration.Pages.Widget
{

    using global::Exam.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    using SeleniumExtras.WaitHelpers;
    using StabilizeTestsDemos.ThirdVersion;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    namespace Exam
    {
        public class BookStore : BasePage
        {
            public BookStore(WebDriver driver2)
                : base(driver2)
            {
            }

            public WebElement BookStoreSection => Driver.FindElement(By.XPath("//*[normalize-space(text())='Book Store Application']/ancestor::div[contains(@class, 'top-card')]"));

            public WebElement SearchBox => Driver.FindElement(By.XPath("//*[@id='searchBox']"));

            public WebElement FirstResult => Driver.FindElement(By.XPath("//*[@class='rt-tr -odd']"));



        }
    }
}
