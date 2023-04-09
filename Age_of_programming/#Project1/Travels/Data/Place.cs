using Option;
using System.Xml.Linq;

namespace Data
{
    public class Place
    {
        Security option = new Security();
        private string Spot { get; }
        private string Country { get; }

        public Place()
        {
            Spot = GetPlace();
            Country = GetCountry();
        }

        public Place(string spot, string country)
        {
            Spot = spot;
            Country = country;
        }

        public Place(string country)
        {
            Spot = "Brak";
            Country = country;
        }

        public override string ToString()
        {
            return $"\n- Miejsce: {Spot},\n- Kraj: {Country}.";
        }

        private string GetPlace()
        {
            Console.Write("Podaj miejsce: ");
            string place = option.GetName();
            return place;
        }

        private string GetCountry()
        {
            Console.Write("Podaj kraj: ");
            string country = option.GetName();
            return country;
        }
        public Place GetSpot()
        {
            return new Place(Spot, Country);
        }
    }
}