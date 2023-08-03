using GamesElement;


namespace Animal
{
    public class Antelope : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Antelope()
        {
            Strength = 4;
            initiative = 4;
            Id = "A5";
            getAnimalType = AnimalType.Antelope;
        }
        public override void PerformAction()
        {
            Console.WriteLine("Movement range is 2 squares.");
        }

        public override void Interact()
        {
            Console.WriteLine("50% chance to flee from combat. It then moves to an unoccupied adjacent space");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Antelope does have special movement.");
        }
    }
}
