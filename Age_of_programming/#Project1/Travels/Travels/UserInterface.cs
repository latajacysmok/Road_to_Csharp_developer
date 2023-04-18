using Option;
using Data;

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

                wybor = option.GetNumber();
                switch (wybor)
                {
                    case 1:
                        osoby.PrintOut();
                        break;
                    case 2:
                        miejsca.PrintOut();
                        break;
                    case 3:
                        osoby.AddPerson();
                        break;
                    case 4:
                        miejsca.AddPlace();
                        break;
                    case 5:
                        osoby.DeletePerson();
                        break;                  
                    case 6:
                        miejsca.ClearPlace();
                        break;
                    case 7:
                        //pobrać osobe z punktu 3 i przypisać włażnie do jakiego miejsca?
                        //osoby.PrintOut();
                        List<Place> listaMiejsc = miejsca.TakePlaceList();
                        string osoba = osoby.ToString();
                        break;
                    case 8:
                        //osoba = osoby.SelectPerson();
                        //osoba.ListDetails();
                        break;
                    case 9:
                        option.LeaveProgramme();
                        break; 
                }
            }
        }
    }
}
