using GamesElement;
using System.Drawing;

namespace GameMechanism
{
    public class Collision
    {
        Board _board;
        //Point location;

        public Collision(Board board)
        {
            _board = board;      
        }

        public Point IfBeCollision(int rowValue, int columnValue, List<IOrganism> _organismCollection, IOrganism organism)
        {
            Point newPosition = new Point(rowValue, columnValue);

            foreach (Organism someOrganism in _organismCollection)
            {
                if (someOrganism.Position == newPosition)
                {
                    Console.WriteLine($"Uwaga mamy kolizja organizmu: {organism.Id} z organizmem: {someOrganism.Id}");
                    return new Point(organism.Position.X, organism.Position.Y);
                }
            }
            if (organism is IAnimalOrganism) { _board.GameBoard[organism.Position.X, organism.Position.Y] = "0"; }          
            return new Point(rowValue, columnValue);
        }
    }
}
