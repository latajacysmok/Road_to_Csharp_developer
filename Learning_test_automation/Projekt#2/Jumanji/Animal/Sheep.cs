using GamesElement;

namespace Animal
{
    public class Sheep : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Sheep()
        {
            strength = 4;
            initiative = 4;
            id = "A2";
            getAnimalType = AnimalType.Sheep;
        }
        public override void OrganismAction()
        {
            //Console.WriteLine("Sheep doesn't take any action.");
        }

        public override void OrganismCollision()
        {
            //Console.WriteLine("Sheep does nothing during the collision.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Sheep does have special movement.");
        }
    }
}
