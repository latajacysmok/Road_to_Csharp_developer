using Option;
using System;

namespace Data
{
    public class Place
    {
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

        private string GetPlace()
        {
            Console.Write("Podaj miejsce: ");
            string place = Security.GetName();
            return place;
        }

        private string GetCountry()
        {
            Console.Write("Podaj kraj: ");
            string country = Security.GetName();
            return country;
        }
        public Place GetSpot()
        {
            return new Place(Spot, Country);
        }
    }
}