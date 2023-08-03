using GamesElement;

namespace Animal
{
    public class Turtle : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Turtle()
        {
            Strength = 2;
            initiative = 1;
            Id = "A4";
            getAnimalType = AnimalType.Turtle;
        }
        public override void PerformAction()
        {
            Console.WriteLine("In 75% of cases, it does not change its position.");
        }

        public override void Interact()
        {
            Console.WriteLine("Repels attacks from <5 strength animals. The striker must return to his previous square.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Turtle does have special movement.");
        }
    }
}
