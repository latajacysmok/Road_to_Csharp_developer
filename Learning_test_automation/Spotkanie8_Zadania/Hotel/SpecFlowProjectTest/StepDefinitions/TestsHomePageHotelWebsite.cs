using Locators.HomePage.BookRoomSection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectTest.StepDefinitions
{
    [Binding]
    public class TestsHomePageHotelWebsite
    {
        string automationintestingWebUrlAdress = "https://automationintesting.online/";

        private IWebDriver driver;
        private HomePageBookRoomSection home;

        public TestsHomePageHotelWebsite()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            home = new HomePageBookRoomSection(driver);
        }

        [Given(@"Go to the home page of the hotel website")]
        public void GivenGoToTheHomePageOfTheHotelWebsite()
        {
            driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => _.Url);

            Assert.AreEqual(homeUrl, automationintestingWebUrlAdress);
        }
    }
}
