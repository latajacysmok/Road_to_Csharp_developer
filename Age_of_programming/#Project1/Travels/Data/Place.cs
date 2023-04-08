using Option;

namespace Data
{
    public class Place
    {
        Security option = new Security();
        private string Spot { get; }
        private string Country { get; }
        public string LoadSpot { get; }

        public Place()
        {
            Spot = GetLoadPlace();
            Country = GetLoadLastCountry();
            LoadSpot = GetLoadSpot();
        }

        public Place(string country)
        {
            Spot = "Brak";
            Country = country;
        }

        private void PrintOutLocation()
        {
            Console.WriteLine($"\n- Miejsce: {Spot},\n- Kraj: {Country}.");
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
        private string GetLoadSpot()
        {
            return $" Miejsce: {Spot}, Kraj: {Country}";
        }
    }
}