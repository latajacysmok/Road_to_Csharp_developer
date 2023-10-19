using System.Drawing;

namespace GamesElement
{
    public abstract class Organism : IOrganism
    {
        public  int Strength { get; set; }
        public  string Id { get; set; }

        protected Point position;
        public Point Position { get; set; }
        public bool IfNew { get; set; }
        public abstract void PerformAction();
        public abstract void Interact();
    }
}
