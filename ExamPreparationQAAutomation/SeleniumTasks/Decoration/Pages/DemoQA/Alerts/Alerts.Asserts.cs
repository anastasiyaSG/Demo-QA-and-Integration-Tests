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
        public partial class Alerts : BasePage
        {

            public void AssertChangedColor(string colorBefore, string colorAfter)
            {
                Assert.AreNotEqual(colorBefore, colorAfter);
            }

            public void AssertTextDisplayed(WebElement element)
            {
                Assert.IsTrue(element.Displayed);
            }

            public void AssertCorrectText(string message, WebElement element)
            {
                Assert.AreEqual(message, element.Text);
            }
        }
    }
}
