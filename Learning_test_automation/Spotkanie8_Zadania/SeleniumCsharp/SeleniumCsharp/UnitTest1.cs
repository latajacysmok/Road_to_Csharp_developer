using AutomaticTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace SeleniumCsharp
{
    public class Tests
    {
        String automationintesting_url = "https://automationintesting.online/";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void EnterToWeb()
        {
                var home = new HomePage(driver);
                home.driver.Navigate().GoToUrl(automationintesting_url);

                var homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(drv => drv.Url);
                
                Assert.AreEqual(homeUrl, automationintesting_url);              
        }

        [Test]
        public void CheckTitleRoomsSection()
        {

                var home = new HomePage(driver);
                home.driver.Navigate().GoToUrl(automationintesting_url);

                var headingBookRoomSection = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(drv => home.HeadingBookRoomSection.Text);
                
                Assert.AreEqual("Rooms", headingBookRoomSection);
        }

        public void CheckHeadlineRoomsArticle()
        {

            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var headingBookRoomArticleText = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.HeadingBookRoomArticle.Text);

            Assert.AreEqual("single", headingBookRoomArticleText);
        }

        [Test]
        public void CheckAmountUnOrderList()
        {
                var home = new HomePage(driver);
                home.driver.Navigate().GoToUrl(automationintesting_url);

                var pointsBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(drv => home.PointsItemBookRoomArticle);
                
                Assert.AreEqual(3, pointsBookRoomArticle.Count());
        }

        [Test]
        public void CheckEnableImg()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var imgBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.ImgBookRoomArticle);

            Assert.True(imgBookRoomArticle.Enabled);
        }

        [Test]
        public void CheckEnableWheelchairIcone()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var wheelchairIcone = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.WheelchairIcone);

            Assert.True(wheelchairIcone.Enabled);
        }

        [Test]
        public void CheckContentBookRoomArticle()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var contentBookRoomArticle = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.ContentBookRoomArticle.Text);

            //Assert.True(contentBookRoomArticle.StartsWith("Aenean") && contentBookRoomArticle.EndsWith("ante."));
            contentBookRoomArticle.Should().StartWith("Aenean").And.EndWith("ante.").And.Contain("accumsan").And.HaveLength(146);
        }

        [Test]
        public void CheckTextRoomBookingButton()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.BookThisRoomButton.Text);
            
            //Assert.AreEqual("Book this room", bookThisRoomButton);
            bookThisRoomButton.Should().Match("Book this room");
        }
        
        [Test]
        public void CheckEnableRoomBookingButton()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.BookThisRoomButton);
            
            //Assert.True(bookThisRoomButton.Enabled);
            bookThisRoomButton.Enabled.Should().BeTrue("The book button should be enabled.");
        }

        [Test]
        public void CheckEnableAlertBookNotification()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.BookThisRoomButton);
            
            bookThisRoomButton.Click();

            var bookDateButton = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(drv => home.BookDateButton);

            bookDateButton.Click();

            var alertBookNotification = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(drv => home.AlertBookNotification);
            
            //Assert.True(alertBookNotification.Enabled);
            alertBookNotification.Enabled.Should().BeTrue("The notification alert should be enabled.");


            var alertBookNotificationPoints = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(drv => home.AlertBookNotificationPoints);

            alertBookNotificationPoints.Should().HaveCount(9);
        }
        
        [Test]
        public void CheckCancelButtonOnBookDateWindow()
        {
            var home = new HomePage(driver);
            home.driver.Navigate().GoToUrl(automationintesting_url);

            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(drv => home.BookThisRoomButton);
            
            bookThisRoomButton.Click();
            
            var calendar = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(drv => home.Calendar);

            calendar.Enabled.Should().BeTrue("The calendar should be enabled.");

            var bookDateCancelButton = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(drv => home.BookDateCancelButton);

            bookDateCancelButton.Click();

            Action calendarNotDispaly = () => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));

            calendarNotDispaly.Should().Throw<NoSuchElementException>("The element should not be present.");
        }

        [TearDown] 
        public void CloseBrowser() 
        {
            driver.Quit();
        }
    }
}