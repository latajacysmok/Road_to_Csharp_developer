using GamesElement;

namespace Plant
{
    public class Dandelion : PlantOrganism
    {
        Random random = new Random();

        public Dandelion()
        {
            strength = 0;
            id = "P2";
            getPlantType = PlantType.Dandelion;
        }
        public override void OrganismAction()
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

        public override void OrganismCollision()
        {
            //Console.WriteLine("Grass does nothing during the collision.");
        }
    }
}
