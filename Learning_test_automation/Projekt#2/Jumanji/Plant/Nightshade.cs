using GamesElement;

namespace Plant
{
    public class Nightshade : PlantOrganism
    {
        public Nightshade()
        {
            strength =99;
            id = "P4";
            getPlantType = PlantType.Nightshade;
        }
        public override void OrganismAction()
        {
            //Console.WriteLine("Nightshade doesn't take any action.");
        }

        public override void OrganismCollision()
        {
            Console.WriteLine("The animal that ate the plant dies.");
        }
    }
}
