using GamesElement;

namespace Animal
{
    public class Fox : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public Fox()
        {
            strength = 3;
            initiative = 7;
            id = "A3";
            getAnimalType = AnimalType.Fox;
        }
        public override void OrganismAction()
        {
            Console.WriteLine("Good sense of smell: a fox will never move into a field occupied by an organism stronger than it.");
        }

        public override void OrganismCollision()
        {
            //Console.WriteLine("Fox does nothing during the collision.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Fox does have special movement.");
        }
    }
}
