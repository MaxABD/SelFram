using System;
using System.Linq;
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
    public static class ElementExtension
    {
        //public static IWebElement ActualWebElement { get; }
        //private static IWebDriver driver { get; }
        //private static WebDriverWait wait;
        
        //Поиск элемента        
        public static IWebElement Id(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.Id(path)));
        }

        public static IWebElement Id(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement Name(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.Name(path)));
        }

        public static IWebElement Name(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement LT(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.LinkText(path)));
        }

        public static IWebElement LT(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement PTL(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.PartialLinkText(path)));
        }

        public static IWebElement PTL(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement XPath(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.XPath(path)));
        }

        public static IWebElement XPath(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement Tag(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.TagName(path)));
        }

        public static IWebElement Tag(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement Class(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.ClassName(path)));
        }

        public static IWebElement Class(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static IWebElement Css(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.CssSelector(path)));
        }

        public static IWebElement Css(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(locator));
        }

        //Поиск массива элементов
        public static ReadOnlyCollection<IWebElement> Id2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.Id(path)));
        }

        public static ReadOnlyCollection<IWebElement> Id2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> Name2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.Name(path)));
        }

        public static ReadOnlyCollection<IWebElement> Name2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> LT2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.LinkText(path)));
        }

        public static ReadOnlyCollection<IWebElement> LT2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> PLT2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.PartialLinkText(path)));
        }

        public static ReadOnlyCollection<IWebElement> PLT2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> XPath2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.XPath(path)));
        }

        public static ReadOnlyCollection<IWebElement> XPath2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> Tag2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.TagName(path)));
        }

        public static ReadOnlyCollection<IWebElement> Tag2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> Class2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.ClassName(path)));
        }

        public static ReadOnlyCollection<IWebElement> Class2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static ReadOnlyCollection<IWebElement> Css2(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(By.CssSelector(path)));
        }

        public static ReadOnlyCollection<IWebElement> Css2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }

        public static void SK(this IWebElement element, string text)
        {
            element.SendKeys(text);            
        }

        public static void SK(this IWebDriver driver, IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void TextClear(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void TextClear(this IWebDriver driver, IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        //Работа с Alert
        public static string AlertText(this IWebDriver driver)
        {
            return driver.SwitchTo().Alert().Text;
        }

        public static void AlertOK(this IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }

        public static void AlertDismiss(this IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public static void AlertSK(this IWebDriver driver, string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

    }      
}
