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
            public WebElement Widget => Driver.FindElement(By.XPath("//*[normalize-space(text())='Widgets']/ancestor::div[contains(@class, 'top-card')]"));

            public WebElement AutoCompleateButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Auto Complete']"));

            public WebElement DatePickerButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Date Picker']"));

            public WebElement AccordianButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Accordian']"));

            public WebElement SliderButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Slider']"));

            public WebElement ProgressBarButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Progress Bar']"));

            public WebElement TabsButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Tabs']"));

            public WebElement TooltipButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Tool Tips']"));

            public WebElement MenuButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Menu']"));

            public WebElement SelectMenuButton => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Select Menu']"));

            // Accordian
            public WebElement section2Heading => Driver.FindElement(By.Id("section2Heading"));

            public WebElement textOnAccordian => Driver.FindElement(By.CssSelector("#section2Content > p:nth-child(1)"));

            // AutoCompleate
            public WebElement SingleColorName => Driver.FindElement(By.XPath("//input[@id='autoCompleteSingleInput']"));

            public WebElement SelectedColor => Driver.FindElement(By.CssSelector("#autoCompleteSingleContainer > div > div.auto-complete__value-container.auto-complete__value-container--has-value.css-1hwfws3"));

            // DatePicker
            public WebElement SelectDate => Driver.FindElement(By.Id("datePickerMonthYearInput"));

            public WebElement CalendarDay => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div[3]/div[2]"));

            public WebElement MonthHeaderOnCalendar => Driver.FindElement(By.CssSelector("#datePickerMonthYear > div.react-datepicker__tab-loop > div.react-datepicker-popper > div > div > div.react-datepicker__month-container > div.react-datepicker__header > div.react-datepicker__current-month.react-datepicker__current-month--hasYearDropdown.react-datepicker__current-month--hasMonthDropdown"));

            // Slider
            public WebElement SliderDot => Driver.FindElement(By.XPath("//input[@class='range-slider range-slider--primary']"));

            public WebElement ReferentSlider => Driver.FindElement(By.Id("sliderValue"));

            // ProgressBar
            public WebElement StartButton => Driver.FindElement(By.Id("startStopButton"));

            public WebElement ProgressBar => Driver.FindElement(By.XPath("//div[@role='progressbar']"));

            // Tabs
            public WebElement TabOrigin => Driver.FindElement(By.Id("demo-tab-origin"));

            public WebElement TabOriginText => Driver.FindElement(By.CssSelector("#demo-tabpane-origin > p.mt-3"));

            // ToolTip
            public WebElement Input => Driver.FindElement(By.Id("toolTipTextField"));

            public WebElement TooltipDiv => Driver.FindElement(By.Id("textFieldToolTip"));

            // Menu
            public WebElement Menu2 => Driver.FindElement(By.XPath("//a[text()='Main Item 2']"));

            public WebElement SubSection => Driver.FindElement(By.XPath("//a[text()='SUB SUB LIST »']"));

            // SubMenu
            public WebElement OldSelectMenu => Driver.FindElement(By.Id("oldSelectMenu"));

            public WebElement Color => Driver.FindElement(By.XPath("//option[text()='Yellow']"));
        }
    }
}


//public IWebElement RedColorSelection => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='react-select-3-option-0\']")));

//public IWebElement GreenColorSelection => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='react-select-3-option-1\']")));