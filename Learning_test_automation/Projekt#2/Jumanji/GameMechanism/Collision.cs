using GamesElement;
using System.Drawing;
using System.Linq;

namespace GameMechanism
{
    public class Collision : ICollision
    {
        IBoard _board;
        IMove _move;

        public Collision(IBoard board, IMove move)
        {
            _board = board;
            _move = move;;
        }

        public Point HandleCollision(Point newPosition, List<IOrganism> organisms, IOrganism organism)
        {
            IOrganism organismWithWhichCollisionOccurs = WithWhoBeCollision(newPosition, organisms);

            if (organismWithWhichCollisionOccurs != null) 
            {
                BeCollision(organism, organismWithWhichCollisionOccurs, organisms);
                return organism.Position;
            }
            else { Console.WriteLine("Obyło się bez kolizji"); }
            
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
                Reproduction reproduction = new Reproduction(organism, organismCollection, _board, _move.FindOrganismAvailableLocation(organism));
            }
            else { Console.WriteLine("Wywiązuję się jakaś interakcja ale jeszcze tego nie obsłużyłem winc nie wiadomo czy ktoś umira ucieka czy co jeszcze."); }
        }

        private bool IfSameAnimalSpecies(string firstOrganism, string secendOrganism)
        {
            return firstOrganism == secendOrganism;
        }
    }
}
