namespace GamesElement
{
    public class Board
    {
        private int _height;
        public int Height
        {
            get { return _height; }
        }

        private int _width;

        public int Width
        {
            get { return _width; }
        }

        private string[,] emptyGameBoard;
        public string[,] EmptyGameBoard
        {
            get { return emptyGameBoard; }
        }

        public Board(int height, int width)
        {
            _height = height;
            _width = width;
            emptyGameBoard = CreatingEmptyGameBoard(_height, _width);
        }
        public string[,] CreatingEmptyGameBoard(int height, int width)
        {
            string[,] emptyGameBoard = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    emptyGameBoard[i, j] = "O";
                }
            }
            return emptyGameBoard;
        }
    }
}