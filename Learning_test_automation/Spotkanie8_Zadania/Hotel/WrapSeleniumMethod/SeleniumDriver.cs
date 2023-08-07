 using Locators.HomePage.BookRoomSection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System;
using System.Security.Cryptography;
using System.Xml.XPath;
using System.Drawing;

namespace SeleniumDriver
{
    public class SeleniumDriver : ISeleniumDriver
    {
        public readonly IWebDriver driver;

        public SeleniumDriver(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void OpenHomePageWebSite(string webUrlAdress)
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(webUrlAdress);

            string homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                .Until(_ => _.Url);

            homeUrl.Should().Be(webUrlAdress);
        }

        public void CountElementsOfGivenCollection(ReadOnlyCollection<IWebElement> collection, int amount)
        {
            var collectionOfElements = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => collection);

            collectionOfElements.Should().HaveCount(amount);
        }

        public void ClickButton(IWebElement buttonToClick)
        {
            var button = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                           .Until(_ => buttonToClick);

            button.Enabled.Should().BeTrue("The button should be enabled.");

            button.Click();
        }

        public void ItemShouldBeEnabled(IWebElement lookForItem)
        {          
            var alertBookNotification = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => lookForItem);

            alertBookNotification.Enabled.Should().BeTrue("The notification alert should be enabled.");
        }
        
        public void EnteringDataIntoField(IWebElement lookForField, string inputText)
        {
            var field = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => lookForField);

            field.Enabled.Should().BeTrue("The field should be enabled.");

            field.SendKeys(inputText);

            string textFromField = field.GetAttribute("value");

            textFromField.Should().Contain(inputText);
        }

        public void ComparingTexts(IWebElement lookForItem, string searchText)
        {
            var textFromSomeItem = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => lookForItem.Text);

            textFromSomeItem.Should().Be(searchText);
        }

        public IWebElement DayOfMonthSelection(IWebElement packingForNumberOfDayAndAvailability, int numberDayOfMonth)
        {
            IWebElement specificDay = packingForNumberOfDayAndAvailability.FindElement(By.XPath($"//div[@class='rbc-date-cell']/button[@class='rbc-button-link' and text()='{numberDayOfMonth}']"));

            while (IsDayAvailable(specificDay, By.XPath(".//div[@class='rbc-event-content']")))
            {
                specificDay = packingForNumberOfDayAndAvailability.FindElement(By.XPath($"//div[@class='rbc-date-cell']/button[@class='rbc-button-link' and text()='{numberDayOfMonth + 1}']"));
            }
            
            return specificDay;
        }

        private bool IsDayAvailable(IWebElement day, By unavailableDays)
        {
            try
            {
                day.FindElement(unavailableDays);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void MarkingDateOfBookingRoom(IWebElement firstDay, IWebElement lastDay)
        {
            Actions actions = new Actions(driver);

            actions.ClickAndHold(firstDay);

            Point offset = new Point((lastDay.Location.X - firstDay.Location.X) / 2, (lastDay.Location.Y - firstDay.Location.Y) / 2);
            actions.MoveByOffset(offset.X, offset.Y)
                    .MoveToElement(lastDay)
                    .Release()
                    .Perform();
        }

        public void WaitFor(int amount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(amount);
        }
    }
}