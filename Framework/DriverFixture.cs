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
            GetWebDriver(Browser: Browser, options: options);
            Window(driver, Size);
            return driver;
        }

        public static IWebDriver GetWebDriver(Browser Browser, int width, int height, dynamic options = null)
        {
            GetWebDriver(Browser: Browser, options: options);
            Window(driver, width, height);            
            return driver;
        }

        //Инициализация браузера + переход по ссылке (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, string url, dynamic options = null)
        {
            GetWebDriver(Browser: Browser, options: options);
            Url(driver, url);            
            return driver;
        }

        //Инициализация браузера + настройка размера окна + переход по ссылке (опции браузера - необязательный параметр)
        public static IWebDriver GetWebDriver(Browser Browser, WSize Size, string url, dynamic options = null)
        {
            GetWebDriver(Browser: Browser, options: options);
            Window(driver, Size);
            Url(driver, url);
            return driver;
        }

        public static IWebDriver GetWebDriver(Browser Browser, int width, int height, string url, dynamic options = null)
        {
            GetWebDriver(Browser: Browser, options: options);
            Window(driver, width, height);
            Url(driver, url);
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

        public static void Window(this IWebDriver driver, int width, int height)
        {
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Window.Size = new Size(width, height);
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

        public static IWebDriver SwitchWindow(this IWebDriver driver, string windowName)
        {
            return driver.SwitchTo().Window(windowName);
        }

        //Работа с Cookie
        public static void AddCookie(this IWebDriver driver, Cookie cookie)
        {
            driver.Manage().Cookies.AddCookie(cookie);
        }

        public static void AddCookie(this IWebDriver driver, string key, string value)
        {
            driver.Manage().Cookies.AddCookie(new Cookie(key, value));
        }

        public static void DelAllCookies(this IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void DelCookie(this IWebDriver driver, Cookie cookie)
        {
            driver.Manage().Cookies.DeleteCookie(cookie);
        }

        public static void DelCookieName(this IWebDriver driver, string name)
        {
            driver.Manage().Cookies.DeleteCookieNamed(name);
        }

        public static Cookie GetCookieName(this IWebDriver driver, string name)
        {
            return driver.Manage().Cookies.GetCookieNamed(name);
        }

        public static ReadOnlyCollection<Cookie> GetAllCookie(this IWebDriver driver, string name)
        {
            return driver.Manage().Cookies.AllCookies;
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
