using Option;

namespace Data
{
    public class ListOfPeople
    {
        Security option = new Security();
        Person person = new Person();
        private List<string> listaOsob;

        public ListOfPeople()
        {
            listaOsob = new List<string>();
        }

        public void AddPerson()
        {
            listaOsob.Add(person.Individual);
        }

        public void PrintOut()
        {
            Console.WriteLine("OSOBY: ");
            for (int i = 0; i < listaOsob.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listaOsob[i]}");
            }
        }

        public void DeletePerson()
        {
            PrintOut();
            Console.Write("Podaj numer osoby: ");
            int numer = option.GetNumber();
            listaOsob.RemoveAt(numer - 1);//potrzebujemy index
        }

        public string SelectPerson()
        {
            PrintOut();
            Console.Write("Podaj numer osoby: ");
            int numer = option.GetNumber();
            return listaOsob[numer - 1];//potrzebujemy index
        }
    }
}
