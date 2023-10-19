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
            IfNew = true;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Grass doesn't take any action.");
        }

        public override void Interact()
        {
            //Console.WriteLine("Grass does nothing during the collision.");
        }
    }
}
