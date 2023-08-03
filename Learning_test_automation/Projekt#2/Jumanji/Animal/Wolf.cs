using GamesElement;

namespace Animal
{
    public class Wolf : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Wolf()
        {
            strength = 9;
            initiative = 5;
            id = "A1";
            getAnimalType = AnimalType.Wolf;
        }
        public override void OrganismAction()
        {
            //Console.WriteLine("Wolf doesn't take any action.");
        }

        public override void OrganismCollision()
        {
            //Console.WriteLine("Wolf does nothing during the collision.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Wolf does have special movement.");
        }
    }
}
