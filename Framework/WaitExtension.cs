using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.Framework
{
    public static class WaitExtension
    {
        //Инициализация ожидания
        public static WebDriverWait GetWait(IWebDriver driver, TimeSpan time)
        {
            return new WebDriverWait(driver, time);
        }

        public static WebDriverWait GetWait(IWebDriver driver, int time)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(time));
        }

        public static WebDriverWait GetWait(IClock clock, IWebDriver driver, TimeSpan timeout, TimeSpan sleepInterval)
        {
            return new WebDriverWait(clock, driver, timeout, sleepInterval);
        }

        //Неявные ожидания
        public static TimeSpan ImplicitWait(this IWebDriver driver, int second = 15)
        {
            return driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
        }

        public static TimeSpan ImplicitWait(this IWebDriver driver, TimeSpan timeout)
        {
            return driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        public static TimeSpan PageLoad(this IWebDriver driver, int second = 15)
        {
            return driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(second);
        }

        public static TimeSpan PageLoad(this IWebDriver driver, TimeSpan timeout)
        {
            return driver.Manage().Timeouts().PageLoad = timeout;
        }

        public static TimeSpan AsynchJavaScript(this IWebDriver driver, int second = 15)
        {
            return driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(second);
        }

        public static TimeSpan AsynchJavaScript(this IWebDriver driver, TimeSpan timeout)
        {
            return driver.Manage().Timeouts().AsynchronousJavaScript = timeout;
        }

        //Явные ожидания
        public static IAlert AlertIsPresent(this WebDriverWait wait)
        {
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static IWebElement ElVisible(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement ElExists(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static IWebElement ElClickable(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement ElClickable(this WebDriverWait wait, IWebElement element)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static bool ElSelected(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeSelected(locator));
        }

        public static bool ElSelected(this WebDriverWait wait, IWebElement element)
        {
            return wait.Until(ExpectedConditions.ElementToBeSelected(element));
        }

        public static bool ElSelected(this WebDriverWait wait, IWebElement element, bool selected)
        {
            return wait.Until(ExpectedConditions.ElementToBeSelected(element, selected));
        }

        public static IWebDriver FrameAvailableSwitch(this WebDriverWait wait, string frameLocator)
        {
            return wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
        }

        public static IWebDriver FrameAvailableSwitch(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        public static bool InvisibleElLocated(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static bool InvisibleElText(this WebDriverWait wait, By locator, string text)
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        }

        public static ReadOnlyCollection<IWebElement> PresenceElementsLocated(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        public static bool StalenessOf(this WebDriverWait wait, IWebElement element)
        {
            return wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public static bool TextPresentElement(this WebDriverWait wait, IWebElement element, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public static bool TextPresentElementLocated(this WebDriverWait wait, By locator, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public static bool TextPresentElementValue(this WebDriverWait wait, By locator, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementValue(locator, text));
        }

        public static bool TextPresentElementValue(this WebDriverWait wait, IWebElement element, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
        }

        public static bool TitleContains(this WebDriverWait wait, string title)
        {
            return wait.Until(ExpectedConditions.TitleContains(title));
        }

        public static bool TitleIs(this WebDriverWait wait, string title)
        {
            return wait.Until(ExpectedConditions.TitleIs(title));
        }

        public static bool UrlContains(this WebDriverWait wait, string fraction)
        {
            return wait.Until(ExpectedConditions.UrlContains(fraction));
        }

        public static bool UrlMatches(this WebDriverWait wait, string regex)
        {
            return wait.Until(ExpectedConditions.UrlMatches(regex));
        }

        public static bool UrlToBe(this WebDriverWait wait, string url)
        {
            return wait.Until(ExpectedConditions.UrlToBe(url));
        }
        
        public static ReadOnlyCollection<IWebElement> VisibleElLocated(this WebDriverWait wait, By locator)
        {
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public static ReadOnlyCollection<IWebElement> VisibleElLocated(this WebDriverWait wait, ReadOnlyCollection<IWebElement> elements)
        {
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }
    }
}