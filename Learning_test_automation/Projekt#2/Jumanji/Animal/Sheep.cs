using GamesElement;

namespace Animal
{
    public class Sheep : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Sheep()
        {
            Strength = 4;
            initiative = 4;
            Id = "A2";
            getAnimalType = AnimalType.Sheep;
            IfNew = true;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Sheep doesn't take any action.");
        }

        public override void Interact()
        {
            //Console.WriteLine("Sheep does nothing during the collision.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Sheep does have special movement.");
        }
    }
}
