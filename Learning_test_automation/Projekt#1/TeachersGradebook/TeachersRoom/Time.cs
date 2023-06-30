using System.Globalization;

namespace Infrastructure
{
    public class Time
    {
        public void GetDate()
        {
            DateTime applicationLaunchDate = DateTime.Now;
            var culture = new CultureInfo("de-DE");
            Console.WriteLine($"\t\t {applicationLaunchDate.ToString(culture)}");
        }     
    }
}
