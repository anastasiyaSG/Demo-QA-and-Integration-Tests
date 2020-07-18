
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;
using System.Threading;

namespace Exam.Tests
{
    public class ElementTests : BaseTest
    {
        private Elements _elements;

        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/");
            _elements = new Elements(Driver);
            _elements.ScrollTo(_elements.ElementsSection).Click();
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
        public void TextBox()
        {
            _elements.TextBox.Click();

            _elements.FillTextBox(_elements.UserName, _elements.UserEmail, _elements.CurrentAddress);
            _elements.ScrollTo(_elements.TextBoxSubmit).Click();

            StringAssert.Contains("Kuku Buki", _elements.OutPutText.Text);
        }

        [Test]
        public void CheckBox()
        {
            _elements.CheckBox.Click();

            _elements.CheckCheckButton(_elements.CheckBoxButton);

            StringAssert.Contains("You have selected", _elements.CheckBoxResult.Text);
        }

        [Test]
        public void RadioButton()
        {
            _elements.RadioButton.Click();

            _elements.ClickOnRadioButton(_elements.YesRadioButton);

            StringAssert.Contains("You have selected Yes", _elements.OutputRadio.Text);
        }

        [Test]
        public void WebTables()
        {
            _elements.WebTables.Click();

            _elements.DeleteNumberOfRows(_elements.DeleteRow, _elements.DeleteRow2, _elements.DeleteRow3);

            StringAssert.Contains("No rows found", _elements.Table.Text);
        }

        [Test]
        public void Buttons()
        {
            _elements.ScrollTo(_elements.Buttons).Click();

            _elements.DoubleClick(_elements.DoubleClickButton);

            StringAssert.Contains("You have done a double click", _elements.DoubleClickMsg.Text);
        }

        [Test]
        public void Links()
        {
            _elements.ScrollTo(_elements.Links).Click();

            _elements.LinkHomePage.Click();
            Driver.WrappedDriver.SwitchTo().ActiveElement();

            Assert.IsTrue(_elements.HeaderOfNewTab.Displayed);
        }

        [Test]
        public void UploadAndDownload()
        {
            _elements.ScrollTo(_elements.UploadAndDownload).Click();
        }

        [Test]
        public void DynamicProperties()
        {
            _elements.ScrollTo(_elements.DynamicProperties).Click();

            var colorButtonLetterBefore = _elements.ColorChangeButton.GetCssValue("color");
            Thread.Sleep(10000);

            var colorButtonLetterAfter= _elements.ColorChangeButton.GetCssValue("color");
            Assert.AreNotEqual(colorButtonLetterAfter, colorButtonLetterBefore);
        }
    }
}