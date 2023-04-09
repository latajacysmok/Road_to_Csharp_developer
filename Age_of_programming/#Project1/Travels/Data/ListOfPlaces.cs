using Option;
namespace Data
{
    public class ListOfPlaces
    {
        Security option = new Security();
        private List<Place> placesList;

        public ListOfPlaces()
        {
            placesList = new List<Place>();
        }

        public void AddPlace()
        {
            Place place = new Place();
            placesList.Add(place.GetSpot());
        }

        public void PrintOut()
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("\tMIEJSCA: ");
            for (int i = 0; i < placesList.Count; i++)
            {
                Console.WriteLine($"\t-{i + 1}- {placesList[i]}");
            }
        }

        public void ClearPlace()
        {
            PrintOut();
            Console.Write("Podaj numer miejsca: ");//zmienić komunikat
            int numer = option.GetNumber();
            placesList.RemoveAt(numer - 1);//potrzebujemy index
        }

        public Place SelectPlace()
        {
            PrintOut();
            Console.Write("Podaj numer miejsca: ");
            int numer = option.GetNumber();
            return placesList[numer - 1];//potrzebujemy index
        }
    }
}
