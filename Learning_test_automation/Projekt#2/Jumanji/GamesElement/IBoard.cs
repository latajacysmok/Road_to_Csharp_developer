namespace GamesElement
{
    public interface IBoard
    {
        int Height { get; set; }
        int Width { get; set; }

        public string[,] GameBoard { get; }

        string[,] CreateEmptyGameBoard(int height, int width);       
    }
}
