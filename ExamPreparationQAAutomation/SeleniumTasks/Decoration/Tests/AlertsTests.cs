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
    public class AlertsTests : BaseTest
    {
        private Alerts _alerts;

        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/");
            _alerts = new Alerts(Driver);
            _alerts.ScrollTo(_alerts.Alert).Click();
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
        public void CheckAlertMessage()
        {
            _alerts.ScrollTo(_alerts.AlertsSection).Click();
            string colorBefore = _alerts.AllertButton.GetCssValue("back-ground");

            _alerts.AllertButton.Click();
            var alert = Driver.WrappedDriver.SwitchTo().Alert().Text;

            Assert.AreEqual("You clicked a button", alert);
        }

        [Test]
        public void TimerAlertAcceptSuccessfully_When_ClickTimerAlertButton()
        {
            _alerts.ScrollTo(_alerts.AlertsSection).Click();
            string colorBefore = _alerts.TimerAlertButton.GetCssValue("back-ground");

            _alerts.TimerAlertButton.Click();
            Thread.Sleep(5500);
            var alert = Driver.WrappedDriver.SwitchTo().Alert();
            alert.Accept();

            string colorAfter = _alerts.TimerAlertButton.GetCssValue("back-ground");
            _alerts.AssertChangedColor(colorBefore, colorAfter);
        }

        [Test]
        public void DismissAlertSuccessfully_When_ClickCancelButton()
        {
            _alerts.ScrollTo(_alerts.AlertsSection).Click();
            _alerts.ConfirmButton.Click();

            var alert = Driver.WrappedDriver.SwitchTo().Alert();
            alert.Dismiss();

            _alerts.AssertTextDisplayed(_alerts.CanceledText);
            string message = "You selected Cancel";
            _alerts.AssertCorrectText(message, _alerts.CanceledText);
        }

        [Test]
        public void Browsers()
        {
            _alerts.ScrollTo(_alerts.BrowserWindows).Click();

            _alerts.NewTab.Click();
            Thread.Sleep(1000);
            var textInNewTab = Driver.WrappedDriver.SwitchTo().ActiveElement().Text;

            Assert.AreEqual("New Tab", textInNewTab);
        }

        [Test]
        public void Frame()
        {
            _alerts.ScrollTo(_alerts.Frames).Click();

        }

        [Test]
        public void ModalDialogs()
        {
            _alerts.ScrollTo(_alerts.ModalDialogs).Click();
            _alerts.SmallModalButton.Click();

            Driver.WrappedDriver.SwitchTo().ActiveElement();

            Assert.AreEqual("This is a small modal. It has very less content", _alerts.SmallModalText.Text);
        }
    }
}
