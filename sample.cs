IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://www.omgtu.ru/");

IWebDriver driver = DriverFixture.GetWebDriver(Browser.Chrome, WSize.Max, "https://www.omgtu.ru/");

        //Поиск элемента
        public static IWebElement Id(this IWebDriver driver, string path, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElement(By.Id(path)));
        }
        //Перезагрузка метода Id
        public static IWebElement Id(this IWebDriver driver, By locator, int timeout = 15)
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
        //Перезагрузка метода Id2
        public static ReadOnlyCollection<IWebElement> Id2(this IWebDriver driver, By locator, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(driver => driver.FindElements(locator));
        }
