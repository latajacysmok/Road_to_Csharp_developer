using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Locators.HomePage.BookRoomSection;
using SeleniumDriver;

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
            seleniumDriver.OpenHomePageWebSite(url);

        }

        [Test]
        public void Should_HaveCorrectTitleRoomsSection()
        {
            seleniumDriver.CompareTexts(home.HeadingBookRoomSection, "Rooms");
        }

        [Test]
        public void Should_HaveCorrectHeadlineRoomsArticle()
        {
            seleniumDriver.CompareTexts(home.HeadingBookRoomArticle, "single");
        }

        [Test]
        public void Should_HaveRightAmountUnOrderList()
        {
            seleniumDriver.CheckNumberOfItemsInCollection(home.PointsItemBookRoomArticle, 3);
        }

        [Test]
        public void Should_AppearImg()
        {
            seleniumDriver.ItemShouldBeEnabled(home.ImgBookRoomArticle);
        }

        [Test]
        public void Should_AppearWheelchairIcone()
        {
            seleniumDriver.ItemShouldBeEnabled(home.WheelchairIcone);
        }

        [Test]
        public void Should_AppearRightContentBookRoomArticle()
        {
            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.ContentBookRoomArticle.Text);

            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [Test]
        public void Should_RoomBookingButtonHasCorrectText()
        {
            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => home.BookThisRoomButton.Text);

            bookThisRoomButton.Should().Match("Book this room");
        }

        [Test]
        public void Should_RoomBookingButtonAppear()
        {
            seleniumDriver.ItemShouldBeEnabled(home.BookThisRoomButton);
        }

        [Test]
        public void Should_CalendarDisappear_When_ClickCancelButtonOnBookDateWindow()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.ClickButton(home.BookDateCancelButton);

            Action calendarNotDisplay = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDisplay.Should().Throw<NoSuchElementException>("The element should not be present.");
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_BookDateWithoutEnterAnyDate()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithNotEnoughLongFirstName()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.FirstNameFieldFromRoomSection, "St");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyFirstNameWithCorrectData()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputOnlyLastName()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 7);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputWrongEmailAdress()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.EmailFieldFromRoomSection, "hWDPna50%BoTrocheSieBoje");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 9);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightEmailAdress()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputNotEnoughLongPhoneNumber()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 8);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputTooLongPhoneNumber()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.PhoneNumberFieldFromRoomSection, "070088891070088891070088891");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 8);
        }

        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightPhoneNumber()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 7);
        }
        
        [Test]
        public void Should_AlertBookNotificationAppear_When_InputRightDateToAllField()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);

            seleniumDriver.EnterDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.EnterDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.EnterDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.EnterDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            seleniumDriver.ClickButton(home.BookDateButton);

            seleniumDriver.WaitFor(10);

            seleniumDriver.ItemShouldBeEnabled(home.AlertBookNotification);

            seleniumDriver.CheckNumberOfItemsInCollection(home.AlertBookNotificationPoints, 2);
        }
        
        [Test]
        public void Should_RightBookRoom()
        {
            seleniumDriver.ClickButton(home.BookThisRoomButton);

            seleniumDriver.CheckNumberOfItemsInCollection(home.RoomInfoSection, 2);

            seleniumDriver.ItemShouldBeEnabled(home.Calendar);


            seleniumDriver.EnterDataIntoField(home.FirstNameFieldFromRoomSection, "Stefek");

            seleniumDriver.EnterDataIntoField(home.LastNameFieldFromRoomSection, "PierdziBący");

            seleniumDriver.EnterDataIntoField(home.EmailFieldFromRoomSection, "spokoAdres@giewno.com");

            seleniumDriver.EnterDataIntoField(home.PhoneNumberFieldFromRoomSection, "07008889101");

            int day = 15;
            var firstDay = seleniumDriver.DayOfMonthSelection(home.PackingForNumberOfDayAndAvailability, day);
            var lastDay = seleniumDriver.DayOfMonthSelection(home.PackingForNumberOfDayAndAvailability, day - 2);

            seleniumDriver.MarkDateOfBookRoom(firstDay, lastDay);

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