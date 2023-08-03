using System.Drawing;

namespace GamesElement
{
    public abstract class Organism : IOrganism//Utworzyć Interface z propertkami i z tego Interface ma dziedzicyć ta obecna klasa
    {
        public  int Strength { get; set; }
        public  string Id { get; set; }

        protected Point position;
        public Point Position { get; set; }
        public abstract void PerformAction();
        public abstract void Interact();
    }
}
