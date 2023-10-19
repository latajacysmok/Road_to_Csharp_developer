using GamesElement;
using GameMechanism;

namespace GameBoard
{
    public class GameBoardRepository
    {
        Verifier verifier = new Verifier(); 

        public Board gameWorld;
        public Board GameBoardDimensions()
        {
            Console.WriteLine("Dear user, please provide the dimensions of the game board: ");
            
            Console.Write("- Height: ");
            int height = verifier.GetSizeOfPlayField();
            
            Console.Write("- Width: ");
            int width = verifier.GetSizeOfPlayField();

            gameWorld = new Board(height, width);

            return gameWorld;
        }

        public void DrawGameBoard()
        {
            int rowLength = gameWorld.Height;
            int colLength = gameWorld.Width;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", gameWorld.GameBoard[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
