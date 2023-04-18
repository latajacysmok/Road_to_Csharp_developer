using Option;

namespace Data
{
    public class ListOfPeople
    {
        Security option = new Security();
        private List<Person> listaOsob;

        public ListOfPeople()
        {
            listaOsob = new List<Person>();
        }

        public void AddPerson()
        {
            Person person = new Person(true);
            listaOsob.Add(person.GetPerson());
        }

        public void PrintOut()
        {
            Console.WriteLine("\n---------");
            Console.WriteLine("OSOBY: ");
            for (int i = 0; i < listaOsob.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listaOsob[i]}");
            }
            Console.WriteLine("");
        }

        public List<Person> TakePeopleList()
        {
            return listaOsob;
        }

        public void DeletePerson()
        {
            PrintOut();
            int numer = option.GetNumber();
            listaOsob.RemoveAt(numer - 1);
        }

        public Person SelectPerson()
        {
            PrintOut();
            int numer = option.GetNumber();
            return listaOsob[numer - 1];
        }
    }
}
