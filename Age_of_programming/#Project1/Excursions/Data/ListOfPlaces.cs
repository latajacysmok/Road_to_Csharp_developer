using Data;
using System.Diagnostics.Metrics;

namespace Option
{
    public class ListOfPlaces
    {
        private List<Place> places;

        public ListOfPlaces()
        {
            places = new List<Place>();
        }

        public void AddPlace()
        {
            Place place = new Place();
            place.LoadLocation();
            places.Add(place);
        }
        public void AddPlace(Place place)
        {
            places.Add(place);
        }

        public void PrintOut()
        {
            Console.WriteLine("MIEJSCA:");
            for (int i = 0; i < places.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                places[i].PrintOutLocation();
            }
        }

        public void ClearPlace()
        {
            PrintOut();
            Console.Write("podaj numer miejsca:");
            int numer = int.Parse(Console.ReadLine());
            places.RemoveAt(numer - 1);//potrzebujemy index
        }

        public int Amount
        {
            get
            {
                return places.Count;
            }
        }

        public Place SelectPlace()
        {
            PrintOut();
            Console.Write("podaj numer miejsca:");
            int numer = int.Parse(Console.ReadLine());
            return places[numer - 1];//potrzebujemy index
        }
    }
}