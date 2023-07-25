namespace GameMechanism
{
    public class Spawn
    {
        private int _high;
        private int _width;
        private int column;
        private int row;
        private int[] coordinates = new int[2];
        private List<int[]> organismPosition = new List<int[]>();
        Random random = new Random();

        public List<int[]> OrganismPosition { get { return organismPosition; } }

        public int Column { get { return column; } }
        public int Row { get { return row; } }
        public Spawn(int high, int width)
        {
            _high = high;
            _width = width;
            SelectionPostion(_high, _width);
        }

        private int ChoiceOfSpawnLocation(int scope)
        {       
            int minValue = 0; 
            int maxValue = scope - 1; 

            return random.Next(minValue, maxValue + 1); 
        }

        private void SelectionPostion(int high, int width)
        {
            while (true)
            {
                column = ChoiceOfSpawnLocation(high);
                row = ChoiceOfSpawnLocation(width);
                if (IsOverlayLocation(column, row)) { continue; }
                else { break; }
            }
            coordinates[0] = column;
            coordinates[1] = row;
            LoadPosition();
        }

        private void LoadPosition()
        {
            organismPosition.Add(coordinates);
        }

        private bool IsOverlayLocation(int column, int row)
        {
            int[] arrayToFind = new int[] { column, row};
            if (organismPosition.Any(arr => arr.SequenceEqual(arrayToFind))) { return true; }
            else { return false; }
        }
    }
}
