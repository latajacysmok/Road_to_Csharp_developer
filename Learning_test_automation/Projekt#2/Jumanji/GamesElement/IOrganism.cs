using System.Drawing;

namespace GamesElement
{
    public interface IOrganism
    {
        int Strength { get; set; }
        string Id { get; set; }
        Point Position { get; set; }
        bool IfNew { get; set; }
        void PerformAction();
        void Interact();
    }
}
