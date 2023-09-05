using GamesElement;
using System.Drawing;

namespace GameMechanism
{
    public interface ICollision
    {
        public Point HandleCollision(Point newPosition, List<IOrganism> organisms, IOrganism organism);
    }
}
