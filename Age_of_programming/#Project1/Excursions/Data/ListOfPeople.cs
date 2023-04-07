using Data;

namespace Option
{
    public class ListOfPeople
    {
        private List<Person> osoby;

        public ListOfPeople()
        {
            osoby = new List<Person>();
        }

        public static void ListPeople(List<Person> osoby)
        {
            for (int i = 0; i < osoby.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                osoby[i].ListPeople();
            }
        }

        public void AddPerson()
        {
            person.LoadPerson();
            osoby.Add(person);
        }

        public void PrintOut()
        {
            Console.WriteLine("OSOBY:");
            for (int i = 0; i < osoby.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                osoby[i].ListPeople();
            }
        }

        public void DeletePerson()
        {
            PrintOut();
            Console.Write("podaj numer osoby:");
            int numer = int.Parse(Console.ReadLine());
            osoby.RemoveAt(numer - 1);//potrzebujemy index
        }

        public Person SelectPerson()
        {
            PrintOut();
            Console.Write("podaj numer osoby:");
            int numer = int.Parse(Console.ReadLine());
            return osoby[numer - 1];//potrzebujemy index
        }
    }
}
