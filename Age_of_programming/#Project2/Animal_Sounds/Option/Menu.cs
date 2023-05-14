using Animals;

namespace Option
{
    public class Menu
    {
        Validation validation = new Validation();
        Action action = new Action();
        public void SelectionOfOptions()
        {
            List<Animal> lista = new List<Animal>();
            int choice;
            while (true)
            {
                Console.WriteLine("\t***Menu***");
                Console.WriteLine("1 - Wypisz zwierzeta");
                Console.WriteLine("2 - Dodaj zwierze");
                Console.WriteLine("3 - Usuń zwierze");
                Console.WriteLine("4 - Tresuj wybrane zwierze");
                Console.WriteLine("5 - Koniec programu\n");

                choice = validation.ValidateOptionNumber();

                switch (choice)
                {
                    case 1:
                        action.PrintAnimalsList(lista);
                        break;
                    case 2:
                        action.Add(lista);
                        break;
                    case 3:
                        action.Delete(lista);
                        break;
                    case 4:
                        action.Train(lista);
                        break;
                    case 5:
                        validation.LeaveProgramme();
                        break;
                }
            }
        }
    }
}