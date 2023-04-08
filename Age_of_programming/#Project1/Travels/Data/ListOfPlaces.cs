using Option;
namespace Data
{
    public class ListOfPlaces
    {
        Security option = new Security();
        private List<string> placesList;
        Place place = new Place();

        public ListOfPlaces()
        {
            placesList = new List<string>();
        }

        public void AddPlace()
        {
            placesList.Add(place.LoadSpot);
        }

        public void PrintOut()
        {
            Console.WriteLine("MIEJSCA: ");
            for (int i = 0; i < placesList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placesList[i]}");
            }
        }

        public void ClearPlace()
        {
            PrintOut();
            Console.Write("Podaj numer miejsca: ");
            int numer = option.GetNumber();
            placesList.RemoveAt(numer - 1);//potrzebujemy index
        }

        public string SelectPlace()
        {
            PrintOut();
            Console.Write("Podaj numer miejsca: ");
            int numer = option.GetNumber();
            return placesList[numer - 1];//potrzebujemy index
        }
    }
}
