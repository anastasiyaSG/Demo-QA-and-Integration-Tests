
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

        public void ElementYIsSame(int yBefore, int yAfter)
        {
            this.WaitForLoad();
            Assert.AreEqual(yBefore, yAfter);
        }

        public void ElementIsNotOnSamePlace(int before, int after)
        {

            Assert.AreNotEqual(before, after);
        }
        public void DroppedOnTarget(WebElement targetBox, string msg)
        {
            Assert.AreEqual(msg, targetBox.Text);


        }
        public void DroppedOnTargetColorCheck(string before, string after)
        {
            this.WaitForLoad();
            Assert.AreNotEqual(before, after);

        }

        public void DragBoxBackgroundColorIsSame(string before, string after)
        {
            Assert.AreEqual(before, after);

        }

        public void CheckDimensionsOfResizing(int X, int resizableBoxX, int Y, int resizableBoxY)
        {

            this.WaitForLoad();
            Assert.AreEqual(X, resizableBoxX, 2);
            Assert.AreEqual(Y, resizableBoxY, 2);


        }

    }

}
