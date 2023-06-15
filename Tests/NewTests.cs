using System;
using System.Threading;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Framework;
using System.Linq;

namespace SeleniumFramework
{
    [TestFixture]
    class NewTests
    {
        static IWebDriver driver = DriverFixture.GetWebDriver(Browser.Chrome, WSize.Max);
        static WebDriverWait wait = WaitExtension.GetWait(driver, 15);

        [SetUp]
        public void Setup()
        {
            driver.Url("https://chercher.tech/practice/implicit-wait-example");
        }

        [Test]
        public void Test1()
        {
            ReadOnlyCollection<IWebElement> Animals = driver.Css2("#q input");
            do
            {
                driver.ImplicitWait();
                Animals = driver.Css2("#q input");
            } while (Animals.Count != 6);
            Thread.Sleep(1000);
        }

        [Test]
        public void Test2()
        {
            driver.Url("https://chercher.tech/practice/drag-drop.html");

            wait.ElVisible(By.Id("box1"));

            IWebElement to = driver.Id("destination");
            IWebElement to2 = driver.XPath("//div[@data-drop-target][1]");

            ReadOnlyCollection<IWebElement> Red = driver.XPath2("//div[@class=\"box red\"]");
            ReadOnlyCollection<IWebElement> Blue = driver.XPath2("//div[@class=\"box navy\"]");
            ReadOnlyCollection<IWebElement> Orange = driver.XPath2("//div[@class=\"box orange\"]");
            ReadOnlyCollection<IWebElement> Green = driver.XPath2("//div[@class=\"box green\"]");

            ReadOnlyCollection<IWebElement> All = driver.XPath2("//div[@data-drop-target]/div");

            foreach (IWebElement from in Red)
            {
                driver.DragAndDrop(from, to);
                Thread.Sleep(500);
            }

            foreach (IWebElement from in Blue)
            {
                driver.DragAndDrop(from, to);
                Thread.Sleep(500);
            }

            foreach (IWebElement from in Orange)
            {
                driver.DragAndDrop(from, to);
                Thread.Sleep(500);
            }

            foreach (IWebElement from in Green)
            {
                driver.DragAndDrop(from, to);
                Thread.Sleep(500);
            }

            Random ran = new Random();
            int[] Array = Enumerable.Range(0, All.Count).OrderBy(x => ran.Next()).ToArray();
            int j = 0;

            foreach (IWebElement i in All)
            {
                IWebElement from = All[Array[j]];
                driver.DragAndDrop(from, to2);
                Thread.Sleep(500);
                j++;
            }
            Thread.Sleep(1000);
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}