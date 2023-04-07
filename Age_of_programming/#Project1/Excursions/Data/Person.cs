namespace Data
{
    public class Person
    {
        public string Name { get; }
        public string LastName { get; }

        public Person()
        {
            Name = GetLoadName();
            LastName = GetLoadLastname();
        }

        public void ListPeople()
        {
            Console.WriteLine($"Imię: {Name}, Nazwisko: {LastName}, Ilość miejsc: {places.Amount}");
        }

        private string GetLoadName()
        {
            Console.Write("Podaj imie: ");
            string name = Console.ReadLine();
            return name;
        }

        private string GetLoadLastname()
        {
            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();
            return lastName;
        }
    }
}