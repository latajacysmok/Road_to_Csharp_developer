using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace Locators.HomePage.BookRoomSection
{
    public class HomePageBookRoomSection
    {
        public readonly IWebDriver driver;
        public IWebElement LogoHotel => driver.FindElement(By.XPath(@"//img[@class = 'hotel-logoUrl']"));
        public IWebElement DescriptionHotel => driver.FindElement(By.XPath(@"//div[@class = 'row hotel-description']/div[@class = 'col-sm-10']"));
        public IWebElement LetMeHackButton => driver.FindElement(By.XPath(@"//button[@class = 'btn btn-primary']"));
        
        public IWebElement HeadingBookRoomSection => driver.FindElement(By.XPath(@"//h2[contains(text(), 'Rooms')]"));
        public IWebElement ImgBookRoomArticle => driver.FindElement(By.XPath(@"//img[@class = 'img-responsive hotel-img']"));
        public IWebElement HeadingBookRoomArticle => driver.FindElement(By.XPath("//div[@class = 'col-sm-7']/h3"));
        public IWebElement WheelchairIcone => driver.FindElement(By.XPath(@"//span[@class = 'fa fa-wheelchair wheelchair']"));
        public IWebElement ContentBookRoomArticle => driver.FindElement(By.XPath(@"//div[@class = 'col-sm-7']/p"));
        public IWebElement PointsBookRoomArticle => driver.FindElement(By.XPath(@"//div[@class = 'col-sm-7']/ul"));
        public ReadOnlyCollection <IWebElement> PointsItemBookRoomArticle => driver.FindElements(By.XPath(@"//div[@class = 'col-sm-7']/ul/li"));
        public IWebElement BookThisRoomButton => driver.FindElement(By.XPath(@"//div[@class = 'col-sm-7']/button"));
        public IWebElement BookDateButton => driver.FindElement(By.XPath(@"//button[@class = 'btn btn-outline-primary float-right book-room']"));
        public IWebElement AlertBookNotification => driver.FindElement(By.XPath(@"//div[@class = 'alert alert-danger']"));
        public ReadOnlyCollection <IWebElement> AlertBookNotificationPoints => driver.FindElements(By.XPath(@"//div[@class = 'alert alert-danger']/p"));
        public IWebElement BookDateCancelButton => driver.FindElement(By.XPath(@"//button[@class = 'btn btn-outline-danger float-right book-room']"));
        public IWebElement Calendar => driver.FindElement(By.XPath(@"//div[@class = 'rbc-calendar']"));
        public IWebElement FirstNameFieldFromRoomSection => driver.FindElement(By.XPath(@"//input[@name= 'firstname']"));
        public IWebElement LastNameFieldFromRoomSection => driver.FindElement(By.XPath(@"//input[@name= 'lastname']"));
        public ReadOnlyCollection <IWebElement> RoomInfoSection => driver.FindElements(By.XPath(@"//div[@class= 'row hotel-room-info']"));
        public IWebElement EmailFieldFromRoomSection => driver.FindElement(By.XPath(@"//input[@name= 'email']"));

        public HomePageBookRoomSection(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        
        public void ClickBookThisRoomButtonFromRoomSection()
        {
            var bookThisRoomButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => BookThisRoomButton);

            bookThisRoomButton.Click();

            var roomInfoSection = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => RoomInfoSection);

            roomInfoSection.Should().HaveCount(2);
        }
        
        public void ClickBookDateButtonFromRoomSection()
        {
            var bookDateButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                           .Until(_ => BookDateButton);

            bookDateButton.Click();
        }
        
        public void AlertBookNotificationAppear()
        {
            var alertBookNotification = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => AlertBookNotification);

            alertBookNotification.Enabled.Should().BeTrue("The notification alert should be enabled.");
        }

    }
}


