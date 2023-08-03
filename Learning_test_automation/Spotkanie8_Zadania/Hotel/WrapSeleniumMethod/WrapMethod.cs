 using Locators.HomePage.BookRoomSection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace WrapSeleniumMethod
{
    public class WrapMethod
    {
        HomePageBookRoomSection home;
        public readonly IWebDriver driver;

        public WrapMethod(IWebDriver webDriver)
        {
            driver = webDriver;
            home = new HomePageBookRoomSection(driver);
        }

        public string OpenHomePageWebSiteCorrectly(string automationintestingWebUrlAdress)
        {
            var home = new HomePageBookRoomSection(driver);
            home.driver.Navigate().GoToUrl(automationintestingWebUrlAdress);

            return new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                .Until(_ => _.Url);
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

        public void WaitFor(int amount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(amount);
        }
    }
}