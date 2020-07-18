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
            public WebElement Alert => Driver.FindElement(By.XPath("//*[normalize-space(text())='Alerts, Frame & Windows']/ancestor::div[contains(@class, 'top-card')]"));

            public WebElement BrowserWindows => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Browser Windows']"));

            public WebElement AlertsSection => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Alerts']"));

            public WebElement Frames => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Frames']"));

            public WebElement ModalDialogs => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Modal Dialogs']"));

            // Browsers
            public WebElement NewTab => Driver.FindElement(By.Id("tabButton"));

            public WebElement NewTabMessage => Driver.FindElement(By.Id("sampleHeading"));

            // Alerts
            public WebElement AllertButton => Driver.FindElement(By.XPath("//*[@id='alertButton']"));

            public WebElement TimerAlertButton => Driver.FindElement(By.Id("timerAlertButton"));

            public WebElement ConfirmButton => Driver.FindElement(By.Id("confirmButton"));

            public WebElement PromtButton => Driver.FindElement(By.Id("promtButton"));

            public WebElement CanceledText => Driver.FindElement(By.XPath("//span[text()='Cancel']"));

            // Modal Dialogs
            public WebElement SmallModalButton => Driver.FindElement(By.XPath("//*[@id='showSmallModal']"));

            public WebElement SmallModalText => Driver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > div.modal-body"));
        }
    }
    }
