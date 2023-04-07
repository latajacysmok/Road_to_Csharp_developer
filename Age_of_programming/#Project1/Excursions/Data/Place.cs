using Option;

namespace Data
{
    public class Place
    {
        Security option = new Security();
        public string Spot { get; }
        public string Country { get; }

        public Place()
        {
            Spot = GetLoadPlace();
            Country = GetLoadLastCountry();
        }

        public Place(string country)
        {
            Spot = "brak";
            Country = country;
        }

        public void PrintOutLocation()
        {
            Console.WriteLine("{0}, kraj: {1}", Spot, Country);
        }

        private string GetLoadPlace()
        {        
            Console.Write("Podaj miejsce: ");
            string place = option.GetName();
            return place;
        }

        private string GetLoadLastCountry()
        {
            Console.Write("Podaj kraj: ");
            string country = option.GetName();
            return country;
        }
    }
}
