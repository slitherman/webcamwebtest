
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace webcamwebtest
{
    [TestClass]
    public class UnitTest1
    {


        public IWebDriver? _driver;

        [TestInitialize]
        public void setup()
        {
            _driver = new ChromeDriver("C:\\webdrivers");
            _driver?.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");



        }
        [TestCleanup]
        public void cleanup()
        {
            _driver?.Dispose();
            _driver?.Quit();
        }

        [TestMethod]
        public void GetFirstItem()
        {
            WebDriverWait driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            // Find the button element with ID "getbtn"
            IWebElement? click = _driver?.FindElement(By.Id("getbtn"));
            click?.Click();

            IWebElement tbodyelement = _driver?.FindElement(By.Id("itemids"));
            var tableitemswait = driverWait.Until(x => x.FindElements(By.Name("itemrows")));

            IWebElement? firstitem = tableitemswait.FirstOrDefault();
            string? cellValue = firstitem?.Text;


            Assert.AreEqual("cannon 1920 1080 1", cellValue);
        }
        [TestMethod]
        public void DeleteLastItem()
        {
            var driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            IWebElement? deleteinput = _driver?.FindElement(By.Id("deleteinput"));
            deleteinput?.SendKeys("5");
            IWebElement? deletebtn = _driver?.FindElement(By.Id("btndelete"));
            deletebtn?.Click();
            var tableitemswait = driverWait.Until(x => x.FindElements(By.Name("itemrows")));
            IWebElement? lastitem = tableitemswait.LastOrDefault();
            string? cellValue = lastitem?.Text;
            Assert.AreEqual("sony 1920 1080 4", cellValue);

        }
    }
}