using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumDriver
{
    public interface ISeleniumDriver
    {
        void OpenHomePageWebSite(string webUrlAdress);

        void CheckNumberOfItemsInCollection(ReadOnlyCollection<IWebElement> collection, int amount);

        void ClickButton(IWebElement buttonToClick);

        void ItemShouldBeEnabled(IWebElement lookForItem);

        void EnterDataIntoField(IWebElement lookForField, string inputText);

        void CompareTexts(IWebElement lookForItem, string searchText);

        void WaitFor(int amount);

        IWebElement DayOfMonthSelection(IWebElement packingForNumberOfDayAndAvailability, int numberDayOfMonth);

        void MarkDateOfBookRoom(IWebElement firstDay, IWebElement lastDay);
    }
}
