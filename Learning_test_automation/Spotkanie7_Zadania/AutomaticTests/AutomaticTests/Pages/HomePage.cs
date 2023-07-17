using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTests.Pages
{
    public class HomePage
    {
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "hotel-logoUrl")]
        public IWebElement LogoHotel { get; set; }
    }
}
