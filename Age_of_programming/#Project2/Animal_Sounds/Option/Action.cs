using Animals;

namespace Option
{
    public class Action
    {
        Validation validation = new Validation();
        public void Train(List<Animal> list)
        {
            if (list.Count == 0) Console.WriteLine("\n\t***Nie posiadasz zwierząt do tresury!***\n\n");
            else
            {
                PrintAnimalsList(list);
                Console.Write("Podaj numer zwierzecia do tresury: ");
                int numer = validation.GetAmount();
                Console.Write("Podaj ile razy ma dac glos:");
                int amount = validation.GetAmount();

                Train(list[numer - 1], amount);
            }          
        }

        private void Train(Animal animal, int ileRazy)
        {
            for (int i = 0; i < ileRazy; i++)
            {
                animal.GiveVoice();
            }
            Console.WriteLine("\n");
        }

        public void PrintAnimalsList(List<Animal> lista)
        {
            if (lista.Count == 0) Console.WriteLine("\n\t***Lista jest pusta!***\n\n");
            else
            {
                Console.WriteLine("\n\tZwierzeta:\n");

                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {lista[i]}");
                }
            }
        }

        private void PrintTypeOfAnimals()
        {
            Console.WriteLine("Wybierz rodzaj zwierzecia:");
            Console.WriteLine("#1 - Pies");
            Console.WriteLine("#2 - Kot");
            Console.WriteLine("#3 - Świnka morska");
        }

        public void Add(List<Animal> flockList)
        {
            PrintTypeOfAnimals();

            Animal animal = default;
            switch (validation.ValidateOptionNumber())
            {
                case 1:
                    animal = new Dog();
                    break;
                case 2:
                    animal = new Cat();
                    break;
                case 3:
                    animal = new GuineaPig();
                    break;
            }

            if (animal != default) flockList.Add(animal);

            PrintAnimalsList(flockList);
        }
       
        public void Delete(List<Animal> flockList)
        {
            if (flockList.Count == 0) Console.WriteLine("\n\t***Nie posiadasz zwierząt do usunięcia!***\n\n");
            else
            {
                PrintAnimalsList(flockList);
                Console.Write("Podaj numer zwierzecia do usunięcia: ");
                int numer = validation.GetAmount();
                flockList.RemoveAt(numer - 1);
                PrintAnimalsList(flockList);
            }
        }
    }
}
