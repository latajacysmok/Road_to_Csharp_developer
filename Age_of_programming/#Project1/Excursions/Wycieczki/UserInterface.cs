using System;

namespace Excursions
{
    class UserInterface
    {
        public void Menu()
        {
            //Console.WriteLine("╗╣");
            var osoby = new ListOfPeople();
            var miejsca = new ListOfPlaces();

            int wybor = 0;
            while (wybor != 9)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1 - wypisz osoby");
                Console.WriteLine("2 - wypisz miejsca");
                Console.WriteLine("3 - dodaj osobe");
                Console.WriteLine("4 - usun osobe");
                Console.WriteLine("5 - dodaj miejsce");
                Console.WriteLine("6 - usun miejsce");
                Console.WriteLine("7 - dodaj miejsce do osoby");
                Console.WriteLine("8 - wypisz szczegoly osoby");
                Console.WriteLine("9 - wyjscie");

                wybor = int.Parse(Console.ReadLine());
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
                        osoby.DeletePerson();
                        break;
                    case 5:
                        miejsca.AddPlace();
                        break;
                    case 6:
                        miejsca.Usun();
                        break;
                    case 7:
                        Person osoba = osoby.SelectPerson();
                        Place miejsce = miejsca.SelectPlace();
                        osoba.AddPlace(miejsce);
                        break;
                    case 8:
                        osoba = osoby.SelectPerson();
                        osoba.ListDetails();
                        break;
                }

            }
        }
    }
}
