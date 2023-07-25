using GamesElement;

namespace Plant
{
    public class Guarana : PlantOrganism
    {
        public Guarana()
        {
            strength = 0;
            id = "P3";
            getPlantType = PlantType.Guarana;
        }
        public override void OrganismAction()
        {
            //Console.WriteLine("Guarana doesn't take any action.");
        }

        public override void OrganismCollision()
        {
            Console.WriteLine("Increases the power of the animal that ate this plant by 3.");
        }
    }
}
