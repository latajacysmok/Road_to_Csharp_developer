namespace GamesElement
{
    public class Board
    {
        public int Height { get; set; }

        public int Width { get; set; }

        private string[,] emptyGameBoard;
        public string[,] EmptyGameBoard
        {
            get { return emptyGameBoard; }
        }

        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            emptyGameBoard = CreateEmptyGameBoard(Height, Width);
        }
        public string[,] CreateEmptyGameBoard(int height, int width)
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