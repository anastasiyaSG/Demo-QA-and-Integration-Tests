
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
    public partial class Elements : BasePage

    {

        public void ElementYIsSame(int yBefore, int yAfter)
        {
            this.WaitForLoad();
            Assert.AreEqual(yBefore, yAfter);
        }

    }

}
