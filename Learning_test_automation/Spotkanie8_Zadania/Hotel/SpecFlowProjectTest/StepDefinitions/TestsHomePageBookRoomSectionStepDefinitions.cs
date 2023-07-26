using NUnit.Framework;
using Locators.HomePage.BookRoomSection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Gherkin.Ast;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTest.StepDefinitions
{
    [Binding]
    public class TestsHomePageBookRoomSectionStepDefinitions
    {
        string automationintestingWebUrlAdress = "https://automationintesting.online/";

        private IWebDriver driver;
        private HomePageBookRoomSection home;

        private readonly ScenarioContext _scenarioContext;

        public TestsHomePageBookRoomSectionStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            home = new HomePageBookRoomSection(driver);
            _scenarioContext = scenarioContext;
        }


        [Given(@"Go to the home page of the hotel website")]
        public void GivenGoToTheHomePageOfTheHotelWebsite()
        {          
            driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => _.Url);

            Assert.AreEqual(homeUrl, automationintestingWebUrlAdress);
        }

        [When(@"Check the title of the rooms section")]
        public void WhenCheckTheTitleOfTheRoomsSection()
        {
            var headingBookRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => home.HeadingBookRoomSection.Text);

            // Store the value in ScenarioContext
            _scenarioContext["headingBookRoomSection"] = headingBookRoomSection;
        }

        [Then(@"The section title is ""([^""]*)""")]
        public void ThenTheSectionTitleIs(string rooms)
        {
            var actualTitle = _scenarioContext["headingBookRoomSection"] as string;

            Assert.AreEqual(rooms, actualTitle);
        }
    }
}
