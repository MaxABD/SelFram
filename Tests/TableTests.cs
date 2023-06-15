using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFramework.Framework;

namespace SeleniumFramework
{
    class TableTests
    {
        static IWebDriver driver = DriverFixture.GetWebDriver(Browser.Chrome, WSize.Max);
        [SetUp]
        public void Setup()
        {            
            driver.Url("https://chercher.tech/practice/table");
        }

        [Test]
        public void Test()
        {
            IWebElement table = driver.Tag("table");
            string Output = table.OutputCell("Title", 3);
            throw new Exception(Output);
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}