
using Exam.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumTasks.Decoration.Pages.DemoQA.Elements.Model;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Exam
{
    public partial class Elements : BasePage
            {
        public Elements(WebDriver driver2)
            : base(driver2)
        {
        }

        public void FillOne(WebElement element, TextBoxModel user, string panel)
        {
            Builder.Click(element.WrappedElement).SendKeys(user.userEmail).Perform();
        }

        public void FillTextBox(WebElement UserName, WebElement UserEmail, WebElement CurrentAddress,TextBoxModel user)
        {
            UserName.SetText(user.userName);
            UserEmail.SetText(user.userEmail);
            CurrentAddress.SetText(user.currentAddress);
        }

        public void CheckCheckButton(WebElement element)
        {
            Builder.MoveToElement(element.WrappedElement).Click().Perform();
        }

        public void ClickOnRadioButton(WebElement element)
        {
            Builder.MoveToElement(element.WrappedElement).Click().Perform();
        }

        public void DeleteNumberOfRows(WebElement first, WebElement second, WebElement tird)
        {
            first.Click();
            Thread.Sleep(1000);
            second.Click();
            Thread.Sleep(1000);
                        tird.Click();
            Thread.Sleep(1000);

        }

        public void DoubleClick(WebElement button)
        {
            Builder.DoubleClick(button.WrappedElement).Perform();
        }
    }
    }