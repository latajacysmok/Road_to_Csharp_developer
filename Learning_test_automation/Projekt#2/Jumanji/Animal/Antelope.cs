using GamesElement;


namespace Animal
{
    public class Antelope : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Antelope()
        {
            strength = 4;
            initiative = 4;
            id = "A5";
            getAnimalType = AnimalType.Antelope;
        }
        public override void OrganismAction()
        {
            Console.WriteLine("Movement range is 2 squares.");
        }

        public override void OrganismCollision()
        {
            Console.WriteLine("50% chance to flee from combat. It then moves to an unoccupied adjacent space");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Antelope does have special movement.");
        }
    }
}
