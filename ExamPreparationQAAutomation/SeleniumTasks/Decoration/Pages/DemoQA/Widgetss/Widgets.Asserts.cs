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
        public partial class Widgets : BasePage
        {

            public void AssertColorsList(string redColor, string greenColor, string tirdColor)
            {
                StringAssert.Contains("Red", redColor);
                StringAssert.Contains("Green", greenColor);
                Assert.AreEqual(redColor, tirdColor);
            }

            public void AssertCorectColor(string color, WebElement element)
            {
                Assert.AreEqual(color, element.Text);
            }

            public void AssertSubSectionDisplayed(WebElement element)
            {
                Assert.IsTrue(element.Displayed);
            }
        }
    }
}
