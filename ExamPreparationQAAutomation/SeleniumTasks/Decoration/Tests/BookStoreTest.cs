using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Decoration.Pages.Widget.Exam;
using System.Threading;

namespace Exam.Tests
{
    public class BookStoreTest : BaseTest
    {
        private BookStore _bookStore;
        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/");
            _bookStore = new BookStore(Driver);

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var sceenshot = ((ITakesScreenshot)Driver.WrappedDriver).GetScreenshot();
                sceenshot.SaveAsFile($"{TestContext.CurrentContext.Test.FullName}.png", ScreenshotImageFormat.Png);
            }

            Driver.WrappedDriver.Quit();
        }

        [Test]
        public void CheckBooksWithYou()
        {
            _bookStore.ScrollTo(_bookStore.BookStoreSection).Click();

            Builder.Click(_bookStore.SearchBox.WrappedElement).SendKeys("You"+Keys.Enter).Perform();

            StringAssert.Contains("O'Reilly Media", _bookStore.FirstResult.Text);
        }
    }
}
