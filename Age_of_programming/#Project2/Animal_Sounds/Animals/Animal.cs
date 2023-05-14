namespace Animals
{
    public abstract class Animal
    {
        public string name;

        public Animal()
        {
            name = InputName();
        }
        public abstract void GiveVoice();

        public string InputName()
        {
            Console.Write("Podaj proszę, imie zwierzecia: ");
            return Console.ReadLine();
        }

    }
}