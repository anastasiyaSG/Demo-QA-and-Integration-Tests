

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
    public partial class DemoQA : BasePage

    {//draggable
        public WebElement AxisRestrictedTab => Driver.FindElement(By.Id("draggableExample-tab-axisRestriction"));

        public WebElement OnlyXBox => Driver.FindElement(By.Id("restrictedX"));
        public WebElement OnlyYBox => Driver.FindElement(By.Id("restrictedY"));
        public WebElement Container => Driver.FindElement(By.Id("containmentWrapper"));
        public WebElement DraggableBox => Driver.FindElement(By.XPath("//div[@id='containmentWrapper']/div"));
        public WebElement DragBox => Driver.FindElement(By.Id("dragBox"));
        public WebElement CenterTarget => Driver.FindElement(By.XPath("//*[@id='app']/header/a/img"));


        //droppable

        public WebElement DragMe => Driver.FindElement(By.Id("draggable"));
        public WebElement DropHere => Driver.FindElement(By.Id("droppable"));


        //resizable
        public WebElement ContainerResize => Driver.FindElement(By.ClassName("constraint-area"));
        public WebElement ResizableBox => Driver.FindElement(By.Id("resizableBoxWithRestriction"));
        public WebElement ResizeArrow => Driver.FindElement(By.XPath("//span[contains(@class, 'react-resizable-handle')]"));
        public WebElement Box => Driver.FindElement(By.Id("resizable"));
        public WebElement ResizeUnlimitedArrow => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div/span"));

        //selectable
        public WebElement FirstBox => Driver.FindElement(By.XPath("//*[@id='verticalListContainer']/li[1]"));

        //sortable
        public WebElement FirstListElement => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]"));
        public WebElement SortableBanner => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[1]"));
        public WebElement FiveListElement => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[5]"));
        public WebElement SortableHeadline => Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[1]"));

        //navigateToInteractions
        public WebElement InteractionsButton => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[5]/div"));
        public WebElement Sortable => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[1]"));
        public WebElement Selectable => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[2]"));
        public WebElement Resizable => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[3]"));
        public WebElement Dropable => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[4]"));
        public WebElement Draggable => Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]"));

    }
}

