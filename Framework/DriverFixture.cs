#define A
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;


namespace SeleniumFramework.Framework
{
    public static class DriverFixture
    {
        public static IWebDriver driver { get; private set; }
        
        //Инициализация браузера (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, dynamic options = null)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    if (options != null) driver = new ChromeDriver(options);
                    else driver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    if (options != null) driver = new FirefoxDriver(options);
                    else driver = new FirefoxDriver();
                    break;
                case Browser.Safari:
                    if (options != null) driver = new SafariDriver(options);
                    else driver = new SafariDriver();
                    break;
                case Browser.Edge:
                    if (options != null) driver = new EdgeDriver(options);
                    else driver = new EdgeDriver();
                    break;
            }
            return driver;
        }

        //Инициализация браузера + настройка размера окна (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, WSize Size, dynamic options = null)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    if (options != null) driver = new ChromeDriver(options);
                    else driver = new ChromeDriver();
                    Window(driver, Size);
                    break;
                case Browser.Firefox:
                    if (options != null) driver = new FirefoxDriver(options);
                    else driver = new FirefoxDriver();
                    Window(driver, Size);
                    break;
                case Browser.Safari:
                    if (options != null) driver = new SafariDriver(options);
                    else driver = new SafariDriver();
                    Window(driver, Size);
                    break;
                case Browser.Edge:
                    if (options != null) driver = new EdgeDriver(options);
                    else driver = new EdgeDriver();
                    Window(driver, Size);
                    break;
            }
            return driver;
        }

        //Инициализация браузера + переход по ссылке (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, string url, dynamic options = null)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    if (options != null) driver = new ChromeDriver(options);
                    else driver = new ChromeDriver();
                    Url(driver, url);
                    break;
                case Browser.Firefox:
                    if (options != null) driver = new FirefoxDriver(options);
                    else driver = new FirefoxDriver();
                    Url(driver, url);
                    break;
                case Browser.Safari:
                    if (options != null) driver = new SafariDriver(options);
                    else driver = new SafariDriver();
                    Url(driver, url);
                    break;
                case Browser.Edge:
                    if (options != null) driver = new EdgeDriver(options);
                    else driver = new EdgeDriver();
                    Url(driver, url);
                    break;
            }
            return driver;
        }

        //Инициализация браузера + настройка размера окна + переход по ссылке (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, WSize Size, string url, dynamic options = null)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    if (options != null) driver = new ChromeDriver(options);
                    else driver = new ChromeDriver();
                    Url(driver, url);
                    Window(driver, Size);
                    break;
                case Browser.Firefox:
                    if (options != null) driver = new FirefoxDriver(options);
                    else driver = new FirefoxDriver();
                    Url(driver, url);
                    Window(driver, Size);
                    break;
                case Browser.Safari:
                    if (options != null) driver = new SafariDriver(options);
                    else driver = new SafariDriver();
                    Url(driver, url);
                    Window(driver, Size);
                    break;
                case Browser.Edge:
                    if (options != null) driver = new EdgeDriver(options);
                    else driver = new EdgeDriver();
                    Url(driver, url);
                    Window(driver, Size);
                    break;
            }
            return driver;
        }

        //Работа с размером окна
        public static void Window(this IWebDriver driver, WSize Size)
        {
            switch (Size)
            {
                case WSize.Full: driver.Manage().Window.FullScreen(); break;
                case WSize.Max: driver.Manage().Window.Maximize(); break;
                case WSize.Min: driver.Manage().Window.Minimize(); break;                   
            }
        }

        public static Point WinPos(this IWebDriver driver)
        {
            return driver.Manage().Window.Position;
        }

        public static Size WinSize(this IWebDriver driver)
        {
            return driver.Manage().Window.Size;
        }

        //Упрощенный интерфейс INavigation
        public static void Url(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Refresh(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void Back(this IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void Forward(this IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        //Упрощенный интерфейс ITargetLocator
        public static IWebElement ActiveElement(this IWebDriver driver)
        {
            return driver.SwitchTo().ActiveElement();
        }

        public static IAlert SwitchAlert(this IWebDriver driver)
        {
            return driver.SwitchTo().Alert();
        }

        public static IWebDriver DefaultContent(this IWebDriver driver)
        {
            return driver.SwitchTo().DefaultContent();
        }
        //Работа с фреймами
        public static IWebDriver Frame(this IWebDriver driver, IWebElement frameElement)
        {
            return driver.SwitchTo().Frame(frameElement);
        }

        public static IWebDriver Frame(this IWebDriver driver, int frameIndex)
        {
            return driver.SwitchTo().Frame(frameIndex);
        }

        public static IWebDriver Frame(this IWebDriver driver, string frameName)
        {
            return driver.SwitchTo().Frame(frameName);
        }

        public static IWebDriver NewWindow(this IWebDriver driver, WindowType typeHint)
        {
            return driver.SwitchTo().NewWindow(typeHint);
        }

        public static IWebDriver ParentFrame(this IWebDriver driver)
        {
            return driver.SwitchTo().ParentFrame();
        }

        public static IWebDriver Window(this IWebDriver driver, string windowName)
        {
            return driver.SwitchTo().Window(windowName);
        }
    }

    public enum Browser
    {
        Chrome,
        Firefox,
        Safari,
        Edge
    }

    public enum WSize
    {
        Full,
        Max,
        Min
    }
}
