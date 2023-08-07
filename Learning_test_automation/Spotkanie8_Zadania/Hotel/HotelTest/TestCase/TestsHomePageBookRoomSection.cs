using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Locators.HomePage.BookRoomSection;
using SeleniumDriver;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace HotelTest.TestCase
{
    public class TestsHomePageBookRoomSection
    {     
        HomePageBookRoomSection home;
        IWebDriver driver;
        ISeleniumDriver seleniumDriver;

        readonly string url = TestData.webUrlAdress;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            home = new HomePageBookRoomSection(driver);
            seleniumDriver = new SeleniumDriver.SeleniumDriver(driver);
        }

        [Test]
        public void Should_OpenHomePageWebSite()
        {
            seleniumDriver.OpenHomePageWebSite(url);
        }

        [Test]
        public void Should_HaveCorrectTitleRoomsSection()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ComparingTexts(home.HeadingBookRoomSection, "Rooms");
        }

        [Test]
        public void Should_HaveCorrectHeadlineRoomsArticle()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ComparingTexts(home.HeadingBookRoomArticle, "single");
        }

        [Test]
        public void Should_HaveRightAmountUnOrderList()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.CountElementsOfGivenCollection(home.PointsItemBookRoomArticle, 3);
        }

        [Test]
        public void Should_AppearImg()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ItemShouldBeEnabled(home.ImgBookRoomArticle);
        }

        [Test]
        public void Should_AppearWheelchairIcone()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ItemShouldBeEnabled(home.WheelchairIcone);
        }

        [Test]
        public void Should_AppearRightContentBookRoomArticle()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ContentBookRoomArticle.Text);

            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [Test]
        public void Should_RoomBookingButtonHasCorrectText()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton.Text);

            bookThisRoomButton.Should().Match("Book this room");
        }

        [Test]
        public void Should_RoomBookingButtonAppear()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ItemShouldBeEnabled(home.BookThisRoomButton);
        }

        [Test]
        public void Should_CalendarDisappear_When_ClickCancelButtonOnBookDateWindow()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.ClickButton(home.BookDateCancelButton);

            Action calendarNotDisplay = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDisplay.Should().Throw<NoSuchElementException>("The element should not be present.");
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_BookDateWithoutEnterAnyDate()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithNotEnoughLongFirstName()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "St");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithCorrectData()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyLastName()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputWrongEmailAdress()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.EmailFieldFromRoomSection, "hWDPna50%BoTrocheSieBoje");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightEmailAdress()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputNotEnoughLongPhoneNumber()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputTooLongPhoneNumber()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891070088891070088891");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightPhoneNumber()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 7);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightDateToAllField()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.EnteringDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.EnteringDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CountElementsOfGivenCollection(home.AlertBookNotificationPoints, 2);
        }
        
        [Test]
        public void Should_RightBookRoom()
        {
            seleniumDriver.OpenHomePageWebSite(url);

            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CountElementsOfGivenCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);


            seleniumDriver.EnteringDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.EnteringDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.EnteringDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.EnteringDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            int day = 15;
            var firstDay = seleniumDriver.DayOfMonthSelection(home.PackingForNumberOfDayAndAvailability, day);
            var lastDay = seleniumDriver.DayOfMonthSelection(home.PackingForNumberOfDayAndAvailability, day - 2);

            seleniumDriver.MarkingDateOfBookingRoom(firstDay, lastDay);

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.BookingSuccessfulWindow);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}