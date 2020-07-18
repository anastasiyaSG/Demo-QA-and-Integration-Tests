

using Exam.Pages;
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

namespace Exam
{
    public partial class Elements : BasePage
    {
        public WebElement ElementsSection => Driver.FindElement(By.XPath("//*[normalize-space(text())='Elements']/ancestor::div[contains(@class, 'top-card')]"));

        // Text Box
        public WebElement TextBox => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Text Box']"));

        public WebElement UserName => Driver.FindElement(By.XPath(".//*[@id='userName']"));

        public WebElement UserEmail => Driver.FindElement(By.XPath(".//*[@id='userEmail']"));

        public WebElement CurrentAddress => Driver.FindElement(By.XPath(".//*[@id='currentAddress']"));

        public WebElement TextBoxSubmit => Driver.FindElement(By.XPath(".//*[@id='submit']"));

        public WebElement OutPutText => Driver.FindElement(By.XPath(".//*[@id='output']"));

        // Check Box
        public WebElement CheckBox => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Check Box']"));

        public WebElement CheckBoxButton => Driver.FindElement(By.CssSelector("#tree-node > ol > li > span > label > span:nth-child(2) > svg > path"));

        public WebElement CheckBoxResult => Driver.FindElement(By.XPath(".//*[@id='result']"));

        // Radio Button
        public WebElement RadioButton => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Radio Button']"));

        public WebElement YesRadioButton => Driver.FindElement(By.XPath(".//*[@id='yesRadio']"));

        public WebElement OutputRadio => Driver.FindElement(By.CssSelector("#app > div > div > div.row > div.col-12.mt-4.col-md-6 > div:nth-child(1) > p"));

        // Web Tables
        public WebElement WebTables => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Web Tables']"));

        public WebElement Table => Driver.FindElement(By.XPath(".//*[@class='ReactTable -striped -highlight']"));

        public WebElement DeleteRow => Driver.FindElement(By.XPath($".//*[@id='delete-record-1']"));

        public WebElement DeleteRow2 => Driver.FindElement(By.XPath($".//*[@id='delete-record-2']"));

        public WebElement DeleteRow3 => Driver.FindElement(By.XPath($".//*[@id='delete-record-3']"));

        // Buttons
        public WebElement Buttons => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Buttons']"));

        public WebElement DoubleClickButton => Driver.FindElement(By.XPath(".//*[@id ='doubleClickBtn']"));

        public WebElement DoubleClickMsg => Driver.FindElement(By.XPath(".//*[@id ='doubleClickMessage']"));

        // Links
        public WebElement Links => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Links']"));

        public WebElement LinkHomePage => Driver.FindElement(By.XPath(".//*[@id ='simpleLink']"));

        public WebElement HeaderOfNewTab => Driver.FindElement(By.CssSelector("#app > header > a"));

        // Upload and Download
        public WebElement UploadAndDownload => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Upload and Download']"));

        // Dynamic Properties
        public WebElement DynamicProperties => Driver.FindElement(By.XPath(".//*[normalize-space(text())='Dynamic Properties']"));

        public WebElement ColorChangeButton => Driver.FindElement(By.XPath(".//*[@id ='colorChange']"));

    }
}

