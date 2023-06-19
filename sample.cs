IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://www.omgtu.ru/");

IWebDriver driver = DriverFixture.GetWebDriver(Browser.Chrome, WSize.Max, "https://www.omgtu.ru/");
