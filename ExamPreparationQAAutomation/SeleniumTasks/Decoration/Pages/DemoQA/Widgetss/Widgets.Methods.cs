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
            public Widgets(WebDriver driver2)
                : base(driver2)
            {
            }

            public void WriteColorRed(WebElement banner)
            {
                Builder.Click(banner.WrappedElement).SendKeys("Re" + Keys.Enter).Perform();
            }

            public void WriteColorGreen(WebElement banner)
            {
                Builder.Click(banner.WrappedElement).SendKeys("Re" + Keys.ArrowDown + Keys.Enter).Perform();
            }

            public void WriteColorRedAgain(WebElement banner)
            {
                Builder.Click(banner.WrappedElement).SendKeys("Re" + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter).Perform();
            }

            public void AssertColorOptions(WebElement banner)
            {
                Builder.Click(banner.WrappedElement).SendKeys("Re" + Keys.ArrowDown + Keys.Enter).Perform();
            }

            public void SliderMove(WebElement sliderDot, WebElement referentSlider)
            {
               // Builder.DragAndDrop(sliderDot.WrappedElement,referentSlider.WrappedElement).Perform();
                Builder.ClickAndHold(SliderDot.WrappedElement).MoveByOffset(0, 100).Perform();
            }

            public void PresStartProgress(WebElement startProgress, WebElement progressBar)
            {
                StartButton.Click();
                Thread.Sleep(1500);
                StartButton.Click();
            }

            public void HoverTooltip(WebElement Input)
            {
                Builder.MoveToElement(Input.WrappedElement).Perform();
            }

            public void HoverMenu2(WebElement element)
            {
                Builder.MoveToElement(element.WrappedElement).Perform();
            }

            public void SelectColor()
            {
                SelectElement color = new SelectElement(OldSelectMenu.WrappedElement);
                color.SelectByValue("3");
            }
        }
    }
}
