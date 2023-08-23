using GamesElement;

namespace Plant
{
    public class Guarana : PlantOrganism
    {
        public Guarana()
        {
            Strength = 0;
            Id = "P3";
            getPlantType = PlantType.Guarana;
            IfNew = true;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Guarana doesn't take any action.");
        }

        public override void Interact()
        {
            Console.WriteLine("Increases the power of the animal that ate this plant by 3.");
        }
    }
}
