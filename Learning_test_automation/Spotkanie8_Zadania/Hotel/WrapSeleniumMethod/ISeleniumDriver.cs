using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumDriver
{
    public interface ISeleniumDriver
    {
        void OpenHomePageWebSite(string webUrlAdress);

        void CountElementsOfGivenCollection(ReadOnlyCollection<IWebElement> collection, int amount);

        void ClickButton(IWebElement buttonToClick);

        void ItemShouldBeEnabled(IWebElement lookForItem);

        void EnteringDataIntoField(IWebElement lookForField, string inputText);

        void ComparingTexts(IWebElement lookForItem, string searchText);

        void WaitFor(int amount);

        IWebElement DayOfMonthSelection(IWebElement packingForNumberOfDayAndAvailability, int numberDayOfMonth);

        void MarkingDateOfBookingRoom(IWebElement firstDay, IWebElement lastDay);
    }
}
