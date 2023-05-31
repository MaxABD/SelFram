using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.Framework
{
    class SelFram
    {
        public IWebElement ActualWebElement { get; }
        private IWebDriver driver;
        private readonly WebDriverWait wait;

        public SelFram(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        //Поиск элемента
        public IWebElement Id(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(path)));
            return driver.FindElement(By.Id(path));
        }

        public IWebElement Name(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(path)));
            return driver.FindElement(By.Name(path));
        }

        public IWebElement LT(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(path)));
            return driver.FindElement(By.LinkText(path));
        }

        public IWebElement PLT(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(path)));
            return driver.FindElement(By.PartialLinkText(path));
        }

        public IWebElement Xpath(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            return driver.FindElement(By.XPath(path));
        }

        public IWebElement Tag(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(path)));
            return driver.FindElement(By.TagName(path));
        }

        public IWebElement Class(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(path)));
            return driver.FindElement(By.ClassName(path));
        }

        public IWebElement Css(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(path)));
            return driver.FindElement(By.CssSelector(path));  
        }

        //Поиск элементов
        public ReadOnlyCollection<IWebElement> Id2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(path)));
            return driver.FindElements(By.Id(path));
        }

        public ReadOnlyCollection<IWebElement> Name2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(path)));
            return driver.FindElements(By.Name(path));
        }

        public ReadOnlyCollection<IWebElement> LT2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(path)));
            return driver.FindElements(By.LinkText(path));
        }

        public ReadOnlyCollection<IWebElement> PLT2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(path)));
            return driver.FindElements(By.PartialLinkText(path));
        }

        public ReadOnlyCollection<IWebElement> Xpath2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            return driver.FindElements(By.XPath(path));
        }

        public ReadOnlyCollection<IWebElement> Tag2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(path)));
            return driver.FindElements(By.TagName(path));
        }

        public ReadOnlyCollection<IWebElement> Class2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(path)));
            return driver.FindElements(By.ClassName(path));
        }

        public ReadOnlyCollection<IWebElement> Css2(string path)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(path)));
            return driver.FindElements(By.CssSelector(path));
        }
                
                
    }
    /*
    public interface MyIWebElement : IWebElement
    {
        //string GetAttribute(string attributeName);
        string GaT(string attributeName);
    }
    */
}
