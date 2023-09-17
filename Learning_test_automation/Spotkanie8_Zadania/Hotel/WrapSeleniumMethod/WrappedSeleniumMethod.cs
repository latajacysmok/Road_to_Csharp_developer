 using Locators.HomePage.BookRoomSection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using Logger;
using Microsoft.VisualBasic;

namespace SeleniumDriver
{
    
    public class WrappedSeleniumMethod : ISeleniumDriver
    {
        public readonly IWebDriver driver;
        //public readonly NLogger nLogger;
        NLogger nLogger = new NLogger();


        public WrappedSeleniumMethod(IWebDriver webDriver)
        {
            driver = webDriver;
            //NLogger nLogger = new NLogger();
        }

        public void OpenHomePageWebSite(string webUrlAdress)
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(webUrlAdress);

            try
            {
                nLogger.Info($"Opening the website: {webUrlAdress}");

                string homeUrl = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                    .Until(_ => _.Url);

                homeUrl.Should().Be(webUrlAdress);

                nLogger.Info("Website opened successfully.");
            }
            catch (Exception ex)
            {
                nLogger.Error($"An error occurred while opening the website: {ex.Message}");
                throw;
            }
            Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");
        }

        public void CountElementsOfGivenCollection(ReadOnlyCollection<IWebElement> collection, int amount)
        {
            try
            {
                nLogger.Info($"Start count items from collection: {collection}");


                var collectionOfElements = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => collection);

                collectionOfElements.Should().HaveCount(amount);

                nLogger.Info($"Collection: {collection} have: {amount} items.");

            }
            catch (Exception ex)
            {
                nLogger.Error($"An error occurred while count elements from collection: {ex.Message}. Collection: {collection} have: {collection.Count} items but we expect: {amount}.");
                throw;
            }
        }

        public void ClickButton(IWebElement buttonToClick)
        {
            try
            {
                nLogger.Info($"Click the button: {buttonToClick}");

                var button = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                          .Until(_ => buttonToClick);

                button.Enabled.Should().BeTrue("The button should be enabled.");

                button.Click();

                nLogger.Info("The button was clicked successfully.");

            }
            catch (Exception ex)
            {
                nLogger.Error($"An error occurred while click the button: {ex.Message}");
                throw;
            }            
        }

        public void ItemShouldBeEnabled(IWebElement lookForItem)
        {
            try
            {
                nLogger.Info($"Lookinng for element: {lookForItem}");


                var alertBookNotification = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => lookForItem);

                alertBookNotification.Enabled.Should().BeTrue("The notification alert should be enabled.");

                nLogger.Info("The element was clicked successfully.");
            }
            catch (Exception ex)
            {
                nLogger.Error($"The item has been found: {ex.Message}");
                throw;
            }       
        }
        
        public void EnteringDataIntoField(IWebElement lookForField, string inputText)
        {
            try
            {
                nLogger.Info($"Lookinng for element: {lookForField}");


                var field = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                            .Until(_ => lookForField);

                field.Enabled.Should().BeTrue("The field should be enabled.");

                field.SendKeys(inputText);

                string textFromField = field.GetAttribute("value");

                textFromField.Should().Contain(inputText);

                nLogger.Info("The element has been found and text has been entered into it.");
            }

            catch (Exception ex)
            {
                nLogger.Error($"Data entry into the field failed: {ex.Message}");
                throw;
            }            
        }

        public void ComparingTexts(IWebElement lookForItem, string searchText)
        {
            try
            {
                nLogger.Info($"Comparing text: {searchText}");

                var textFromSomeItem = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(_ => lookForItem.Text);

                textFromSomeItem.Should().Be(searchText);

                nLogger.Info($"The text: {searchText} is the same as text: {textFromSomeItem}.");

            }
            catch (Exception ex)
            {
                nLogger.Error($"Text: {searchText} is different than the one you're looking for. Exception appear: {ex.Message}");
                throw;
            }
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
                nLogger.Info("Searching for an available day.");
                day.FindElement(unavailableDays);
                nLogger.Info($"The available day: {day} found successfully.");

                return true;
            }
            catch (NoSuchElementException)
            {
                nLogger.Error($"Day: {day}, is not available.");
                return false;
            }
        }


        public void MarkingDateOfBookingRoom(IWebElement firstDay, IWebElement lastDay)
        {
            try
            {
                nLogger.Info("The room booking date.");
                Actions actions = new Actions(driver);

                actions.ClickAndHold(firstDay);

                Point offset = new Point((lastDay.Location.X - firstDay.Location.X) / 2, (lastDay.Location.Y - firstDay.Location.Y) / 2);
                actions.MoveByOffset(offset.X, offset.Y)
                        .MoveToElement(lastDay)
                        .Release()
                        .Perform();
                nLogger.Info("The room booking date passed.");
            }
            catch (Exception ex)
            {
                nLogger.Error($"The room booking date failed: {ex}");
                throw;
            }


        }

        public void WaitFor(int amount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(amount);
        }
    }
}