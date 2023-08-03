using GamesElement;

namespace Plant
{
    public class Grass : PlantOrganism
    {
        public Grass()
        {
            Strength = 0;
            Id = "P1";
            getPlantType = PlantType.Grass;
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
