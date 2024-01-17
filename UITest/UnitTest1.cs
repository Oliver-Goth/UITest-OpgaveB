using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using NuGet.Frameworks;

namespace UITest
{
    [TestClass]
    public class SeleniumU1
    {
        private static readonly string DriverDir = "C:\\Webdrivers";
        private static IWebDriver driver;

        // initialized the webdriver
        [ClassInitialize]

        public static void Setup(TestContext testContext)
        {
            driver = new ChromeDriver(DriverDir);
        }

        // Cleans up the driver after it is initialized
        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Dispose();
        }

        // Runs before each test
        [TestInitialize]
        public void Setup()
        {
            // Always goes back to the post before running tests
            driver.Navigate().GoToUrl(Constants.Url + "index.html");
        }

        [TestMethod]
        public void TestAddPostToRun()
        {
            Assert.AreEqual("app", driver.Title);

            // Gets House list and checks if it has elements
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            ReadOnlyCollection<IWebElement> table = wait.Until(house => house.FindElements(By.ClassName("bg-primary")));
            Assert.IsTrue(table.Count > 0);
        }
    }
}