using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDriver;

namespace TestStarter
{
    public class TestStarter
    {
        static IWebDriver driver;
        static string url = TestData.webUrlAdress;


        static public void Main(String[] args)
        {
            driver = new ChromeDriver();
            SeleniumDriver.SeleniumDriver seleniumDriver = new SeleniumDriver.SeleniumDriver(driver);
            seleniumDriver.OpenHomePageWebSite(url);

            Console.WriteLine("Main Method");
        }
    }
}
