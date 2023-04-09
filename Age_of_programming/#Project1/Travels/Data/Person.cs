using Option;
using System.Xml.Linq;

namespace Data
{
    public class Person
    {
        Security option = new Security();

        private static int idCounter = 0;
        private int id;
        private string Name { get; }
        private string LastName { get; }

        public Person(string name, string lastName)
        {
            this.id = ++idCounter;
            Name = name;
            LastName = lastName;
        }

        public Person(bool ifForList)
        {
            Name = GetName();
            LastName = GetLastname();
        }

        public override string ToString()
        {
            return $"{id}: {Name} {LastName}";
        }

        /*List<Person> listaOsob = new List<Person>();
        Person person1 = new Person("John", "Doe");
        Person person2 = new Person("Jane", "Smith");
        listaOsob.Add(person1);
        listaOsob.Add(person2);
        Console.WriteLine(person1); // output: "1: John Doe"
        Console.WriteLine(person2); // output: "2: Jane Smith"*/

        public string GetName()
        {
            Console.Write("Podaj imie: ");
            string name = option.GetName();

            return name;
        }

        public string GetLastname()
        {
            Console.Write("Podaj nazwisko: ");
            string lastName = option.GetName();

            return lastName;
        }
        public Person GetPerson()
        {
            return new Person(Name, LastName);
        }
    }
}
