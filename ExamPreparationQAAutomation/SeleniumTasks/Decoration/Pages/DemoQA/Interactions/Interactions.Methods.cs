
using Exam.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public partial class DemoQA : BasePage

    {

        public DemoQA(WebDriver driver2)
            : base(driver2)
        {
        }


        public void DraggableDragAndDrop(WebElement point)
        {
            Builder.DragAndDropToOffset(point.WrappedElement, 100, 100).Perform();

        }

        public void DraggableDragAndDropToTarget(WebElement dragBox, WebElement target)
        {
            Builder.DragAndDrop(dragBox.WrappedElement, target.WrappedElement).Perform();

        }


        public void DropOnTarget(WebElement dragMe, WebElement dropHere)
        {
            Builder.DragAndDrop(dragMe.WrappedElement, dropHere.WrappedElement).Perform();

        }

        public void ResizeOffset(WebElement resizeArrow, int X, int Y)
        {
            this.WaitForLoad();
            Builder.DragAndDropToOffset(resizeArrow.WrappedElement, X, Y).Perform();

        }



    }

}


