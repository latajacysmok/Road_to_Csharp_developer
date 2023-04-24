using Option;
using System;

namespace Data
{
    public class Person
    {
        private static int idCounter = 0;
        private int id;
        private string Name { get; }
        private string LastName { get; }

        private ListOfPlaces places;

        public Person(string name, string lastName)
        {
            this.id = ++idCounter;
            Name = name;
            LastName = lastName;
            places = new ListOfPlaces();
        }

        public Person() : this(GetName(), GetLastname())
        {

        }

        public void AddPlace(Place place)
        {
            places.AddItem(place);
        }

        public void ShowDetails()
        {
            Console.WriteLine(ToString());
            places.PrintOut();
            //wypisuje imie, i nazwisko
            //i liste miejsc gdzie byla dana osoba
        }

        public override string ToString()
        {
            return $"{id}: {Name} {LastName}";
        }

        private static string GetName()
        {
            Console.Write("Podaj imie: ");
            string name = Security.GetName();

            return name;
        }

        private static string GetLastname()
        {
            Console.Write("Podaj nazwisko: ");
            string lastName = Security.GetName();

            return lastName;
        }
       
    }
}
