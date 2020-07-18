using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Decoration.Pages.Widget.Exam;
using StabilizeTestsDemos.ThirdVersion;

namespace Exam.Tests
{
    public class WidgetsTests : BaseTest
    {
        private Widgets _widgets;

        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/");
            _widgets = new Widgets(Driver);
            _widgets.ScrollTo(_widgets.Widget).Click();
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
        public void Accordian()
        {
            _widgets.ScrollTo(_widgets.AccordianButton).Click();

            _widgets.ScrollTo(_widgets.section2Heading).Click();

            var text = _widgets.textOnAccordian.WrappedElement.Text;
            StringAssert.Contains("Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a", text);
        }

        [Test]
        public void AutoComplete()
        {
            _widgets.ScrollTo(_widgets.AutoCompleateButton).Click();

            _widgets.WriteColorRed(_widgets.SingleColorName);
            var redColor = _widgets.SelectedColor.WrappedElement.Text;
            _widgets.WriteColorGreen(_widgets.SingleColorName);
            var greenColor = _widgets.SelectedColor.WrappedElement.Text;
            _widgets.WriteColorRedAgain(_widgets.SingleColorName);
            var tirdColor = _widgets.SelectedColor.WrappedElement.Text;

            _widgets.AssertColorsList(redColor, greenColor, tirdColor);
        }

        [Test]
        public void DatePicker()
        {
            _widgets.ScrollTo(_widgets.DatePickerButton).Click();

            _widgets.ScrollTo(_widgets.SelectDate).Click();
            _widgets.CalendarDay.Click();

            var text = _widgets.SelectDate.GetAttribute("value");
            Assert.AreEqual("07/13/2020", text);
        }

        [Test]
        public void DatePickerCheckHeadlineOnCalendar()
        {
            _widgets.ScrollTo(_widgets.DatePickerButton).Click();
            _widgets.ScrollTo(_widgets.SelectDate).Click();

            _widgets.SelectDate.Clear();
            var currentMonthHeader = _widgets.MonthHeaderOnCalendar.WrappedElement.Text;

            _widgets.CalendarDay.Click();
            var text = _widgets.SelectDate.GetAttribute("value");

            Assert.AreEqual("July 2020", currentMonthHeader);
            Assert.AreEqual("07/13/2020", text);
        }

        [Test]
        public void Slider()
        {
            _widgets.ScrollTo(_widgets.SliderButton).Click();
            var reffBefore = _widgets.ReferentSlider.GetProperty("value");

            _widgets.SliderMove(_widgets.SliderDot, _widgets.ReferentSlider);
            var reffAfter = _widgets.ReferentSlider.GetProperty("value");

            Assert.AreNotEqual(reffBefore, reffAfter);
        }

        [Test]
        public void ProgressBar()
        {
            _widgets.ScrollTo(_widgets.ProgressBarButton).Click();
            var before = _widgets.StartButton.Text;

            _widgets.PresStartProgress(_widgets.StartButton, _widgets.ProgressBar);
            var after = _widgets.StartButton.Text;

            Assert.AreNotSame(before, after);
        }

        [Test]
        public void Tabs()
        {
            _widgets.ScrollTo(_widgets.TabsButton).Click();

            _widgets.ScrollTo(_widgets.TabOrigin).Click();

            var text = _widgets.TabOriginText.WrappedElement.Text;
            StringAssert.Contains("Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old", text);
        }

        [Test]
        public void TooltipTest()
        {
            _widgets.ScrollTo(_widgets.TooltipButton).Click();

            _widgets.HoverTooltip(_widgets.Input);

            Assert.IsTrue(_widgets.TooltipDiv.Displayed);
            Assert.AreEqual("You hovered over the text field", _widgets.TooltipDiv.Text);
        }

        [Test]
        public void Menu()
        {
            _widgets.ScrollTo(_widgets.MenuButton).Click();
            _widgets.HoverMenu2(_widgets.Menu2);

            _widgets.AssertSubSectionDisplayed(_widgets.SubSection);
        }

        [Test]
        public void SelectMenu()
        {
            _widgets.ScrollTo(_widgets.SelectMenuButton).Click();
            _widgets.SelectColor();

            string color = "Yellow";
            _widgets.AssertCorectColor(color, _widgets.Color);

            //    _widgets.ScrollTo(_widgets.SelectMenuButton).Click();

            //    _widgets.ChooseFromSelectMenu(_widgets.SelectOneMenu, _widgets.ChooseOption);

            //    Assert.AreEqual("Mrs.", _widgets.MenuBanner.WrappedElement.Text);
        }
    }
}
