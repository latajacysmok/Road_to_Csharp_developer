using GamesElement;

namespace Plant
{
    public class Nightshade : PlantOrganism
    {
        public Nightshade()
        {
            Strength =99;
            Id = "P4";
            getPlantType = PlantType.Nightshade;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Nightshade doesn't take any action.");
        }

        public override void Interact()
        {
            Console.WriteLine("The animal that ate the plant dies.");
        }
    }
}
