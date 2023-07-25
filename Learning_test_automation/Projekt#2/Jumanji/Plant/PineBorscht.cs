using GamesElement;

namespace Plant
{
    public class PineBorscht : PlantOrganism
    {
        public PineBorscht()
        {
            strength = 10;
            id = "P5";
            getPlantType = PlantType.Pine_borscht;
        }
        public override void OrganismAction()
        {
            Console.WriteLine("He kills all animals in his neighborhood except for the cyber-sheep.");
        }

        public override void OrganismCollision()
        {
            Console.WriteLine("The animal that ate the plant dies. Only the cyber-hero is immune.");
        }
    }
}
