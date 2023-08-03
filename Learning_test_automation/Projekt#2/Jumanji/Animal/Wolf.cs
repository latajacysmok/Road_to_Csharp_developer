using GamesElement;

namespace Animal
{
    public class Wolf : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Wolf()
        {
            Strength = 9;
            initiative = 5;
            Id = "A1";
            getAnimalType = AnimalType.Wolf;
        }
        public override void PerformAction()
        {
            //Console.WriteLine("Wolf doesn't take any action.");
        }

        public override void Interact()
        {
            //Console.WriteLine("Wolf does nothing during the collision.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Wolf does have special movement.");
        }
    }
}
