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
        private IWebDriver driver;
        private HomePageBookRoomSection home;

        private readonly ScenarioContext _scenarioContext;

        public TestsHomePageBookRoomSectionStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            home = new HomePageBookRoomSection(driver);
            _scenarioContext = scenarioContext;
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

        [When(@"Check the title of the headline rooms article")]
        public void WhenCheckTheTitleOfTheHeadlineRoomsArticle()
        {
            var headingBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.HeadingBookRoomArticle.Text);

            // Store the value in ScenarioContext
            _scenarioContext["headingBookRoomArticle"] = headingBookRoomArticle;
        }

        [Then(@"The headline rooms article is ""([^""]*)""")]
        public void ThenTheHeadlineRoomsArticleIs(string single)
        {
            var actualTitle = _scenarioContext["headingBookRoomArticle"] as string;

            Assert.AreEqual(single, actualTitle);
        }

        [When(@"Check the amount of points in the room article")]
        public void WhenCheckTheAmountOfPointsInTheRoomArticle()
        {
            var pointsBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => home.PointsItemBookRoomArticle);

            _scenarioContext["pointsBookRoomArticle"] = pointsBookRoomArticle;
        }

        [Then(@"The room article have (.*) points")]
        public void ThenTheRoomArticleHavePoints(int p0)
        {
            var pointsBookRoomArticle = _scenarioContext["pointsBookRoomArticle"] as System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement>;

            Assert.AreEqual(3, pointsBookRoomArticle.Count());
        }

        [When(@"Check if a photo of the room section appears")]
        public void WhenCheckIfAPhotoOfTheRoomAppears()
        {
            var imgBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ImgBookRoomArticle);

            _scenarioContext["imgBookRoomArticle"] = imgBookRoomArticle;
        }

        [Then(@"A photo of the room will appear in the room section")]
        public void ThenAPhotoOfTheRoomWillAppearInTheRoomSection()
        {
            var imgBookRoomArticle = _scenarioContext["imgBookRoomArticle"] as OpenQA.Selenium.IWebElement;

            Assert.True(imgBookRoomArticle.Enabled);
        }

        [When(@"Check if there is a wheelchair icon in the room section")]
        public void WhenCheckIfThereIsAWheelchairIconInTheRoomSection()
        {
            var wheelchairIcone = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.WheelchairIcone);

            _scenarioContext["wheelchairIcone"] = wheelchairIcone;
        }

        [Then(@"A icon of the wheelchair will appear in the room section")]
        public void ThenAIconOfTheWheelchairWillAppearInTheRoomSection()
        {
            var wheelchairIcone = _scenarioContext["wheelchairIcone"] as OpenQA.Selenium.IWebElement;

            Assert.True(wheelchairIcone.Enabled);
        }

        [When(@"Check if appear right content in the room book article")]
        public void WhenCheckIfAppearRightContentInTheRoomBookArticle()
        {
            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                           .Until(_ => home.ContentBookRoomArticle.Text);

            _scenarioContext["contentBookRoomArticle"] = contentBookRoomArticle;
        }

        [Then(@"A content of the room book article is right")]
        public void ThenAContentOfTheRoomBookArticleIsRight()
        {
            var contentBookRoomArticle = _scenarioContext["contentBookRoomArticle"] as String;

            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [When(@"Check if room booking button has correct text in the room book section")]
        public void WhenCheckIfRoomBookingButtonHasCorrectTextInTheRoomBookSection()
        {
            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton.Text);

            _scenarioContext["bookThisRoomButton"] = bookThisRoomButton;
        }

        [Then(@"A text from room booking button has correct")]
        public void ThenATextFromRoomBookingButtonHasCorrect()
        {
            var bookThisRoomButton = _scenarioContext["bookThisRoomButton"] as String;

            bookThisRoomButton.Should().Match("Book this room");
        }

        [When(@"Check if room booking button appear")]
        public void WhenCheckIfRoomBookingButtonAppear()
        {
            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton);

            _scenarioContext["bookThisRoomButton"] = bookThisRoomButton;
        }

        [Then(@"A room booking button appear")]
        public void ThenARoomBookingButtonAppear()
        {
            var bookThisRoomButton = _scenarioContext["bookThisRoomButton"] as OpenQA.Selenium.IWebElement;

            bookThisRoomButton.Enabled.Should().BeTrue("The book button should be enabled.");
        }

        [When(@"Click book this room button from room section")]
        public void WhenClickBookThisRoomButtonFromRoomSection()
        {
            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton);

            bookThisRoomButton.Click();
        }

        [When(@"Calendar should appear")]
        public void WhenCalendarShouldAppear()
        {
            var roomInfoSection = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.RoomInfoSection);

            roomInfoSection.Should().HaveCount(2);
        }

        [When(@"Click book date button")]
        public void WhenClickBookDateButton()
        {
            var bookDateButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                           .Until(_ => home.BookDateButton);

            bookDateButton.Click();
        }

        [Then(@"Appear alert book notification with (.*) alerts")]
        public void ThenAppearAlertBookNotificationWithAlerts(int p0)
        {
            var alertBookNotification = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.AlertBookNotification);

            alertBookNotification.Enabled.Should().BeTrue("The notification alert should be enabled.");

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                           .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(9);
        }

        [When(@"Click book date cancel button")]
        public void WhenClickBookDateCancelButton()
        {
            var bookDateCancelButton = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.BookDateCancelButton);

            bookDateCancelButton.Click();
        }

        [Then(@"Calendar disappear")]
        public void ThenCalendarDisappear()
        {
            Action calendarNotDisplay = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDisplay.Should().Throw<NoSuchElementException>("The element should not be present.");
        }
    }
}
