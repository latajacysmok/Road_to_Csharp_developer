namespace Data
{
    public class ListOfPeopleAssignedToPlaces
    {
        IDictionary<string, List<string>> peopleAssignedToPlaces;
        List<string> placesList;
        public ListOfPeopleAssignedToPlaces(string osoba, string miejsce)
        {
            IDictionary<string, List<string>> peopleAssignedToPlaces = new Dictionary<string, List<string>>();
            placesList = new List<string>();
        }

        public void GetPlaces(string miejsce)
        {
            placesList.Add(miejsce);
        }

        public void AssigningPeopleToPlaces(string osoba, List<string> placesList)
        {
            peopleAssignedToPlaces.Add(osoba, placesList);
        }

        public void PrintOut()
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("\nSZCZEGÓŁY: ");
            foreach(var item in peopleAssignedToPlaces)
            {
                Console.WriteLine($"\t- {item.Key}: {item.Value}");
            }
        }
    }
}
