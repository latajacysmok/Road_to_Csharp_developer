using Infrastructure;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OutputInformation
{
    class Program
    {
        static public void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.GetSelectionOfOptionsFromMenu();
        }
    }
}
