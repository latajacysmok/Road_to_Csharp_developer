using Option;
using Data;
using System;

namespace Travels
{
    public class UserInterface
    {
        public void Menu()
        {
            Security option = new Security();
            var osoby       = new ListOfPeople();
            var miejsca     = new ListOfPlaces();

            int wybor = 0;
            while (wybor != 9)
            {
                Console.WriteLine("\n\t-MENU-");
                Console.WriteLine("1 - Wypisz osoby.");
                Console.WriteLine("2 - Wypisz miejsca.");
                Console.WriteLine("3 - Dodaj osobe.");
                Console.WriteLine("4 - Dodaj miejsce.");
                Console.WriteLine("5 - Usun osobe.");               
                Console.WriteLine("6 - Usun miejsce.");
                Console.WriteLine("7 - Dodaj miejsce do osoby.");
                Console.WriteLine("8 - Wypisz szczegoly osoby.");
                Console.WriteLine("9 - Wyjscie.");

                wybor = Security.GetNumber();
                switch (wybor)
                {
                    case 1:
                        osoby.PrintOut();
                        if (osoby == null) break;
                        break;
                    case 2:
                        miejsca.PrintOut();
                        if (miejsca == null) break;
                        break;
                    case 3:
                        osoby.AddItem(new Person());
                        break;
                    case 4:
                        miejsca.AddPlace();
                        break;
                    case 5:
                        osoby.Delete(osoby.PeopleList);
                        break;                  
                    case 6:
                       miejsca.Delete(miejsca.PlacesList);
                        break;
                    case 7:
                        Person osoba = osoby.Select(osoby.PeopleList);
                        if (osoba == null) // Check if SelectPerson returned null (due to an empty list)
                        {
                            break; // Exit the case 7 block
                        }
                        Place miejsce = miejsca.Select(miejsca.PlacesList);
                        if (miejsce == null) break;
                        osoba.AddPlace(miejsce);
                        break;
                    case 8:
                        osoba = osoby.Select(osoby.PeopleList);
                        osoba.ShowDetails();
                        break;
                    case 9:
                        Security.LeaveProgramme();
                        break; 
                }
            }
        }
    }
}
