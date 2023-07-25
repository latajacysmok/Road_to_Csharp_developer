using GamesElement;

namespace Plant
{
    public class Grass : PlantOrganism
    {
        public Grass()
        {
            strength = 0;
            id = "P1";
            getPlantType = PlantType.Grass;
        }
        public override void OrganismAction()
        {
            //Console.WriteLine("Grass doesn't take any action.");
        }

        public override void OrganismCollision()
        {
            //Console.WriteLine("Grass does nothing during the collision.");
        }
    }
}
