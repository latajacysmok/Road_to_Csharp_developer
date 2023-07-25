using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Locators.HomePage;
using Locators.HomePage.BookRoomSection;

namespace Hotel.TestCase
{
    public class TestsHomePageBookRoomSection
    {
        string automationintestingWebUrlAdress = "https://automationintesting.online/";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Should_OpenHomePageWebSite()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => _.Url);

            Assert.AreEqual(homeUrl, automationintestingWebUrlAdress);
        }

        [Test]
        public void Should_HaveCorrectTitleRoomsSection()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var headingBookRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => home.HeadingBookRoomSection.Text);

            Assert.AreEqual("Rooms", headingBookRoomSection);
        }

        [Test]
        public void Should_HaveCorrectHeadlineRoomsArticle()
        {

            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var headingBookRoomArticleText = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.HeadingBookRoomArticle.Text);

            Assert.AreEqual("single", headingBookRoomArticleText);
        }

        [Test]
        public void Should_HaveRightAmountUnOrderList()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var pointsBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => home.PointsItemBookRoomArticle);

            Assert.AreEqual(3, pointsBookRoomArticle.Count());
        }

        [Test]
        public void Should_AppearImg()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var imgBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ImgBookRoomArticle);

            Assert.True(imgBookRoomArticle.Enabled);
        }

        [Test]
        public void Should_AppearWheelchairIcone()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var wheelchairIcone = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.WheelchairIcone);

            Assert.True(wheelchairIcone.Enabled);
        }

        [Test]
        public void Should_AppearRightContentBookRoomArticle()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ContentBookRoomArticle.Text);

            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [Test]
        public void Should_RoomBookingButtonHasCorrectText()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton.Text);

            bookThisRoomButton.Should().Match("Book this room");
        }

        [Test]
        public void Should_RoomBookingButtonAppear()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton);

            bookThisRoomButton.Enabled.Should().BeTrue("The book button should be enabled.");
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_BookDateWithoutEnterAnyDate()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            home.ClickBookThisRoomButtonFromRoomSection();

            home.ClickBookDateButtonFromRoomSection();

            home.AlertBookNotificationAppear();

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(9);
        }

        [Test]
        public void Should_CalendarDisappear_When_ClickCancelButtonOnBookDateWindow()
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            home.ClickBookThisRoomButtonFromRoomSection();

            var calendar = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.Calendar);

            calendar.Enabled.Should().BeTrue("The calendar should be enabled.");

            var bookDateCancelButton = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.BookDateCancelButton);

            bookDateCancelButton.Click();

            Action calendarNotDisplay = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDisplay.Should().Throw<NoSuchElementException>("The element should not be present.");
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstName()
        {
            var home = new HomePageBookRoomSection(driver);

            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(3));


            home.ClickBookThisRoomButtonFromRoomSection();

            var firstNameFieldFromRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.FirstNameFieldFromRoomSection);

            firstNameFieldFromRoomSection.Enabled.Should().BeTrue("The field with firstname should be enabled.");

            string textFirstname = "Stefek";
            firstNameFieldFromRoomSection.SendKeys(textFirstname);

            string textFromFirstNameFieldFromRoomSection = firstNameFieldFromRoomSection.GetAttribute("value");

            textFromFirstNameFieldFromRoomSection.Should().Contain(textFirstname);

            home.ClickBookDateButtonFromRoomSection();

            home.AlertBookNotificationAppear();

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyLastName()
        {
            var home = new HomePageBookRoomSection(driver);

            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(3));

            home.ClickBookThisRoomButtonFromRoomSection();

            var lastNameFieldFromRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.LastNameFieldFromRoomSection);

            lastNameFieldFromRoomSection.Enabled.Should().BeTrue("The field with firstname should be enabled.");

            string textFirstname = "PierdziBący";
            lastNameFieldFromRoomSection.SendKeys(textFirstname);

            string textFromFirstNameFieldFromRoomSection = lastNameFieldFromRoomSection.GetAttribute("value");

            textFromFirstNameFieldFromRoomSection.Should().Contain(textFirstname);

            home.ClickBookDateButtonFromRoomSection();

            home.AlertBookNotificationAppear();

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputWrongEmailAdress()
        {
            var home = new HomePageBookRoomSection(driver);

            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(3));

            home.ClickBookThisRoomButtonFromRoomSection();

            var emailFieldFromRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.EmailFieldFromRoomSection);

            emailFieldFromRoomSection.Enabled.Should().BeTrue("The field with firstname should be enabled.");

            string wrongEmailAdress = "hWDPna50%BoTrocheSieBoje";
            emailFieldFromRoomSection.SendKeys(wrongEmailAdress);

            string textFromEmailFieldFromRoomSection = emailFieldFromRoomSection.GetAttribute("value");

            textFromEmailFieldFromRoomSection.Should().Contain(wrongEmailAdress);

            home.ClickBookDateButtonFromRoomSection();

            home.AlertBookNotificationAppear();

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightEmailAdress()
        {
            var home = new HomePageBookRoomSection(driver);

            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(3));

            home.ClickBookThisRoomButtonFromRoomSection();

            var emailFieldFromRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.EmailFieldFromRoomSection);

            emailFieldFromRoomSection.Enabled.Should().BeTrue("The field with firstname should be enabled.");

            string rightEmailAdress = "spokoAdres@giewno.com";
            emailFieldFromRoomSection.SendKeys(rightEmailAdress);

            string textFromEmailFieldFromRoomSection = emailFieldFromRoomSection.GetAttribute("value");

            textFromEmailFieldFromRoomSection.Should().Contain(rightEmailAdress);

            home.ClickBookDateButtonFromRoomSection();

            home.AlertBookNotificationAppear();

            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(_ => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(8);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}