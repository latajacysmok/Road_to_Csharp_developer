using GamesElement;

namespace Animal
{
    public class CyberSheep : AnimalOrganism
    {
        private int initiative;
        public override int Initiative { get { return initiative; } }

        public CyberSheep()
        {
            Strength = 11;
            initiative = 4;
            Id = "A6";
            getAnimalType = AnimalType.Cyber_Sheep;
        }
        public override void PerformAction()
        {
            Console.WriteLine("Its primary goal is the extermination of pine borscht. He always heads towards the nearest borscht and tries to eat it. If there is no borscht on the board, it pretends to be ordinary sheep.");
        }

        public override void Interact()
        {
            Console.WriteLine("He eats borscht sosnowski.");
        }

        public override void OrganismMovement()
        {
            //Console.WriteLine("Cyber_Sheep does have special movement.");
        }
    }
}
