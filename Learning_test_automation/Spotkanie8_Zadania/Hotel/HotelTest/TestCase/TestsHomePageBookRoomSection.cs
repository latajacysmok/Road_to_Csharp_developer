using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Locators.HomePage.BookRoomSection;
using WrapSeleniumMethod;

namespace HotelTest.TestCase
{
    public class TestsHomePageBookRoomSection
    {
        string automationintestingWebUrlAdress = "https://automationintesting.online/";
        
        HomePageBookRoomSection home;
        IWebDriver driver;
        WrapMethod wrapMethod;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            home = new HomePageBookRoomSection(driver);
            wrapMethod = new WrapMethod(driver);
        }

        [Test]
        public void Should_OpenHomePageWebSite()
        {
            string homeUrl = wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            Assert.AreEqual(homeUrl, automationintestingWebUrlAdress);
        }

        [Test]
        public void Should_HaveCorrectTitleRoomsSection()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ComparingTexts(home.HeadingBookRoomSection, "Rooms");
        }

        [Test]
        public void Should_HaveCorrectHeadlineRoomsArticle()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ComparingTexts(home.HeadingBookRoomArticle, "single");
        }

        [Test]
        public void Should_HaveRightAmountUnOrderList()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.CountElementsOfGivenCollection(home.PointsItemBookRoomArticle, 3);
        }

        [Test]
        public void Should_AppearImg()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ItemShouldBeEnabled(home.ImgBookRoomArticle);
        }

        [Test]
        public void Should_AppearWheelchairIcone()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ItemShouldBeEnabled(home.WheelchairIcone);
        }

        [Test]
        public void Should_AppearRightContentBookRoomArticle()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ContentBookRoomArticle.Text);

            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [Test]
        public void Should_RoomBookingButtonHasCorrectText()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton.Text);

            bookThisRoomButton.Should().Match("Book this room");
        }

        [Test]
        public void Should_RoomBookingButtonAppear()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ItemShouldBeEnabled(home.BookThisRoomButton);
        }

        [Test]
        public void Should_CalendarDisappear_When_ClickCancelButtonOnBookDateWindow()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.ClickButton(home.BookDateCancelButton);

            Action calendarNotDisplay = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDisplay.Should().Throw<NoSuchElementException>("The element should not be present.");
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_BookDateWithoutEnterAnyDate()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithNotEnoughLongFirstName()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "St");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithCorrectData()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyLastName()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputWrongEmailAdress()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.EmailFieldFromRoomSection, "hWDPna50%BoTrocheSieBoje");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightEmailAdress()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputNotEnoughLongPhoneNumber()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputTooLongPhoneNumber()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891070088891070088891");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightPhoneNumber()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightDateToAllField()
        {
            wrapMethod.OpenHomePageWebSiteCorrectly(automationintestingWebUrlAdress);

            wrapMethod.ClickButton(home.BookThisRoomButton);

            wrapMethod.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            wrapMethod.ItemShouldBeEnabled(home.Calendar);

            wrapMethod.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            wrapMethod.EnteringDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            wrapMethod.EnteringDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            wrapMethod.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            wrapMethod.ClickButton(home.BookDateButton);

            wrapMethod.WaitFor(10);

            wrapMethod.ItemShouldBeEnabled(home.AlertBookNotification);

            wrapMethod.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 2);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}