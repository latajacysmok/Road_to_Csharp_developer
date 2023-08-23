using GamesElement;

namespace Plant
{
    public class PineBorscht : PlantOrganism
    {
        public PineBorscht()
        {
            Strength = 10;
            Id = "P5";
            getPlantType = PlantType.Pine_borscht;
            IfNew = true;
        }
        public override void PerformAction()
        {
            Console.WriteLine("He kills all animals in his neighborhood except for the cyber-sheep.");
        }

        public override void Interact()
        {
            Console.WriteLine("The animal that ate the plant dies. Only the cyber-hero is immune.");
        }
    }
}
