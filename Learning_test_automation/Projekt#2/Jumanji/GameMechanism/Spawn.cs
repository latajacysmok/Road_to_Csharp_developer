using System.Data.Common;
using System.Drawing;

namespace GameMechanism
{
    public class Spawn
    {
        private int _high;
        private int _width;
        private Point coordinates = new Point(0,0);
        Random random = new Random();

        private static List<Point> organismPosition = new List<Point>();
        public List<Point> OrganismPosition { get; }

        public int Column { get; set; }
        public int Row { get; set; }
        public Spawn(int high, int width)
        {
            _high = high;
            _width = width;
            GetSelectionPosition(_high, _width);
        }

        private int GetRandomSpawnLocation(int scope)
        {       
            int minValue = 0; 
            int maxValue = scope - 1; 

            return random.Next(minValue, maxValue); 
        }

        private void GetSelectionPosition(int high, int width)
        {
            while (true)
            {
                Column = GetRandomSpawnLocation(high);
                Row = GetRandomSpawnLocation(width);
                if (IsOverlayLocation(Column, Row)) { continue; }
                else { break; }
            }
            coordinates.X = Column;
            coordinates.Y = Row;
            LoadPosition();
        }

        private void LoadPosition()
        {
            organismPosition.Add(coordinates);
        }

        private bool IsOverlayLocation(int column, int row)
        {
            Point arrayToFind = new Point(column, row);
            if (organismPosition.Any(_ => _.Equals(arrayToFind))) { return true; }
            else { return false; }
        }
    }
}