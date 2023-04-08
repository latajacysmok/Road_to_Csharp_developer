using Option;

namespace Data
{
    public class Person
    {
        Security option = new Security();
        private string Name { get; }
        private string LastName { get; }
        public string Individual { get; }

        public Person()
        {
            Name = GetLoadName();
            LastName = GetLoadLastname();
            Individual = GetLoadPerson();
        }

        private void PrintOutPerson()
        {
            //Console.WriteLine($"Imię: {Name}, Nazwisko: {LastName}, Ilość odwiedzonych miejsc: {places.Amount}");
        }

        private string GetLoadName()
        {
            Console.Write("Podaj imie: ");
            string name = option.GetName();

            return name;
        }

        private string GetLoadLastname()
        {
            Console.Write("Podaj nazwisko: ");
            string lastName = option.GetName();

            return lastName;
        }
        private string GetLoadPerson()
        {
            return $"{Name} {LastName}";
        }
    }
}
