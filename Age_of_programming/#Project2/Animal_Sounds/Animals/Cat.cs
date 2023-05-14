using System.Xml.Linq;

namespace Animals
{
    public class Cat : Animal
    {
        private static int idCounter = 0;
        private int id;

        public Cat() : base()
        {
            idCounter++;
            id = idCounter;
        }
        public override void GiveVoice()
        {
            Console.Write("Miał ");
        }

        public override string ToString()
        {
            return "Twój kot wabi się: " + name + $" to Twój kot numer: {id}." + "\n";
        }

    }
}
