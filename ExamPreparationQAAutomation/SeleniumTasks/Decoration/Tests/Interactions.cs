
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Interfaces;

namespace Exam.Tests
{
    public class Interactions : BaseTest
    {
        private DemoQA _demoQA;

        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/");
            _demoQA = new DemoQA(Driver);
            _demoQA.ScrollTo(_demoQA.InteractionsButton).Click();
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
        public void ElementYIsSame_When_DragAndDropOnlyXDiagonally()
        {
            _demoQA.ScrollTo(_demoQA.Draggable).Click();
            _demoQA.AxisRestrictedTab.Click();
            int yBefore = _demoQA.OnlyXBox.Location.Y;

            _demoQA.DraggableDragAndDrop(_demoQA.OnlyXBox);
            int yAfter = _demoQA.OnlyXBox.Location.Y;

            _demoQA.ElementYIsSame(yBefore, yAfter);
        }

        [Test]
        public void ElementXIsSame_When_DragAndDropOnlyYDiagonally()
        {
            _demoQA.ScrollTo(_demoQA.Draggable).Click();
            _demoQA.AxisRestrictedTab.Click();
            int yBefore = _demoQA.OnlyYBox.Location.X;

            _demoQA.DraggableDragAndDrop(_demoQA.OnlyYBox);
            int yAfter = _demoQA.OnlyYBox.Location.X;

            _demoQA.ElementYIsSame(yBefore, yAfter);
        }

        [Test]
        public void dragToCenterLogo()
        {
            _demoQA.ScrollTo(_demoQA.Draggable).Click();
            int dragBoxXbefore = _demoQA.DragBox.Location.X;

            _demoQA.DraggableDragAndDropToTarget(_demoQA.DragBox, _demoQA.CenterTarget);
            int dragBoxXAfter = _demoQA.DragBox.Location.X;

            _demoQA.ElementIsNotOnSamePlace(dragBoxXbefore, dragBoxXAfter);
        }

        [Test]
        public void DropElementWriteCorrectMsgOfTarget_When_DragAndDropDragMe()
        {
            _demoQA.ScrollTo(_demoQA.Dropable).Click();
            _demoQA.WaitForLoad(55);
            _demoQA.DropOnTarget(_demoQA.DragMe, _demoQA.DropHere);
            _demoQA.WaitForLoad();

            string msg = "Dropped!";
            _demoQA.DroppedOnTarget(_demoQA.DropHere, msg);
        }

        [Test]
        public void DropHereElementChangeColorOfTarget_When_DragAndDropDragMe()
        {
            _demoQA.ScrollTo(_demoQA.Dropable).Click();
            var colorBefore = _demoQA.DropHere.GetCssValue("background-color");

            _demoQA.DropOnTarget(_demoQA.DragMe, _demoQA.DropHere);
            _demoQA.WaitForLoad();
            var colorAfter = _demoQA.DropHere.GetCssValue("background-color");

            _demoQA.DroppedOnTargetColorCheck(colorBefore, colorAfter);
        }

        [Test]
        public void DropedElementChangeColorOfTarget_When_DragAndDropDragMe()
        {
            _demoQA.ScrollTo(_demoQA.Dropable).Click();
            var colorBefore = _demoQA.DragMe.GetCssValue("background-color");

            _demoQA.DropOnTarget(_demoQA.DragMe, _demoQA.DropHere);
            _demoQA.WaitForLoad();
            var colorAfter = _demoQA.DragMe.GetCssValue("background-color");

            _demoQA.DragBoxBackgroundColorIsSame(colorBefore, colorAfter);
        }

        [Test]
        public void ElementSizeIsMaximum()
        {
            _demoQA.ScrollTo(_demoQA.Resizable).Click();
            _demoQA.ResizeOffset(_demoQA.ResizeArrow, 300, 150);
            int resizedX = _demoQA.ResizableBox.Size.Width;
            int resizedY = _demoQA.ResizableBox.Size.Height;
            _demoQA.CheckDimensionsOfResizing(500, resizedX, 300, resizedY);
        }

        [Test]
        public void ResizeUnlimited()
        {
            _demoQA.ScrollTo(_demoQA.Resizable).Click();
            int expectedWidth = _demoQA.Box.Size.Width + 100;
            int expectedHeight = _demoQA.Box.Size.Height + 100;

            _demoQA.Scroll(Driver);
            _demoQA.ResizeOffset(_demoQA.ResizeUnlimitedArrow, 100, 100);

            int actualWidth = _demoQA.Box.Size.Width;
            int actualHeight = _demoQA.Box.Size.Height;
            _demoQA.CheckDimensionsOfResizing(expectedWidth, actualWidth, expectedHeight, actualHeight);
        }

        [Test]
        public void selectableClickOnList()
        {
            _demoQA.ScrollTo(_demoQA.Selectable).Click();
            var colorBefore = _demoQA.FirstBox.GetCssValue("color");

            _demoQA.FirstBox.Click();
            var colorAfter = _demoQA.FirstBox.GetCssValue("color");

            _demoQA.DroppedOnTargetColorCheck(colorBefore, colorAfter);
        }

        [Test]
        public void selectableDoubleClickOnList()
        {
            _demoQA.ScrollTo(_demoQA.Selectable).Click();
            var colorBefore = _demoQA.FirstBox.GetCssValue("color");

            Builder.DoubleClick().Perform();
            var colorAfter = _demoQA.FirstBox.GetCssValue("color");

            _demoQA.DragBoxBackgroundColorIsSame(colorBefore, colorAfter);
        }

        [Test]
        public void sortableFirstGoToEnd()
        {
            _demoQA.ScrollTo(_demoQA.Sortable).Click();
            _demoQA.DropOnTarget(_demoQA.FirstListElement, _demoQA.SortableBanner);
            string msg = "Two";

            _demoQA.WaitForLoad();
            _demoQA.DroppedOnTarget(_demoQA.FirstListElement, msg);
        }

        [Test]
        public void sortableFiveGoFirst()
        {
            _demoQA.ScrollTo(_demoQA.Sortable).Click();
            _demoQA.Scroll(Driver);
            _demoQA.DropOnTarget(_demoQA.FiveListElement, _demoQA.SortableHeadline);
            _demoQA.WaitForLoad();

            string msg = "Five";
            _demoQA.DroppedOnTarget(_demoQA.FirstListElement, msg);
        }
    }
}