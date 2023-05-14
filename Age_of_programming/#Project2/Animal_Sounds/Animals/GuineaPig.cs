namespace Animals
{
    public class GuineaPig : Animal
    {
        private static int idCounter = 0;
        private int id;

        public GuineaPig() : base()
        {
            idCounter++;
            id = idCounter;
        }
        public override void GiveVoice()
        {
            Console.Write("Quełełe ");
        }

        public override string ToString()
        {
            return "Twoja świnka morska wabi się: " + name + $" to Twója świnka numer: {id}" + "\n";
        }
    }
}
