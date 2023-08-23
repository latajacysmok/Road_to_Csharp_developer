using GamesElement;
using System.Drawing;
using System.Linq;

namespace GameMechanism
{
    public class Collision
    {
        Board _board;

        public Collision(Board board)
        {
            _board = board;      
        }

        public Point HandleCollision(Point newPosition, List<IOrganism> organisms, IOrganism organism)
        {
            IOrganism organismWithWhichCollisionOccurs = WithWhoBeCollision(newPosition, organisms);

            if (organismWithWhichCollisionOccurs != null) 
            {
                BeCollision(organism, organismWithWhichCollisionOccurs, organisms);
                return organism.Position;
            }
            // TODO: powstanie jeszcze else ale jeszcze nie zabrałem się za interakcje pomiędzy poszczególnymi gatunkami to na óźniej
            
            return newPosition;
        }

        private IOrganism WithWhoBeCollision(Point newPosition, List<IOrganism> organisms)
        {
            return organisms.FirstOrDefault(org => org.Position == newPosition);
        }
        
        private void BeCollision(IOrganism organism, IOrganism otherOrganism, List<IOrganism> organismCollection)
        {

            if (IfSameAnimalSpecies(organism.Id, otherOrganism.Id) && (organism is IAnimalOrganism)) 
            {
                Console.WriteLine("Spotykają się dwa zwierzątka");
                Reproduction reproduction = new Reproduction(organism, organismCollection, _board); }
        }

        private bool IfSameAnimalSpecies(string firstOrganism, string secendOrganism)
        {
            return firstOrganism == secendOrganism;
        }
    }
}
