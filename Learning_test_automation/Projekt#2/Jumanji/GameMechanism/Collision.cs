using GamesElement;
using System.Drawing;

namespace GameMechanism
{
    public class Collision
    {
        Board _board;
        Point location;

        public Collision(Board board)
        {
            _board = board;
            
        }

        public Point IfBeCollision(int rowValue, int columnValue, List<IOrganism> _organismCollection, IOrganism organism)
        {
            Point newPowition = new Point(rowValue, columnValue);

            foreach (Organism someOrganism in _organismCollection)
            {
                if (someOrganism.Position == newPowition)
                {
                    Console.WriteLine("Uwaga mamy kolizje");
                    return new Point(organism.Position.X, organism.Position.Y);
                }
            }
            if (organism is AnimalOrganism) { _board.EmptyGameBoard[organism.Position.X, organism.Position.Y] = "0"; }          
            return new Point(rowValue, columnValue);
        }
    }
}
