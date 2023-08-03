using GamesElement;

namespace Plant
{
    public class Dandelion : PlantOrganism
    {
        Random random = new Random();

        public Dandelion()
        {
            Strength = 0;
            Id = "P2";
            getPlantType = PlantType.Dandelion;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Grass doesn't take any action.");
        }

        public void Spread()
        {
            for (int i = 0; i < 3; i++)
            {
                if(IfSpread())
                {
                    //rozmnóż w bezpośredniej okolicy;
                }
            }
        }

        private bool IfSpread()
        {
            int minValue = 0;
            int maxValue = 1;
            bool ifSpread;
            if (random.Next(minValue, maxValue + 1) == 1) return true;
            else return false;
        }

        public override void Interact()
        {
            //Console.WriteLine("Grass does nothing during the collision.");
        }
    }
}
