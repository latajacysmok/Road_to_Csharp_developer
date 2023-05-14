using System.Diagnostics.Metrics;

namespace Animals
{
    public class Dog : Animal
    {
        private static int idCounter = 0;
        private int id;

        public Dog() : base()
        {
            idCounter++;
            id = idCounter;
        }
        public override void GiveVoice()
        {
            Console.Write("Bark ");
        }

        public override string ToString()
        {
            return "Twój pies wabi się: " + name + $" to Twój pies numer: {id}" +"\n";
        }
    }
}
