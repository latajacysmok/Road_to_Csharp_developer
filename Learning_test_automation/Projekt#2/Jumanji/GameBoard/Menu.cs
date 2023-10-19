using GamesElement;
using GameMechanism;

namespace GameBoard
{
    public class Menu: IMenu
    {        
        GameBoardRepository gameBoardRepository = new GameBoardRepository();
        private readonly IVerifier _verifier;
        private readonly IMove _move;

        public Menu(IVerifier verifier, IMove move)
        {
            _verifier = verifier;
            _move = move;
        }
        public void StartOfGame()
        {
            Board board = gameBoardRepository.GameBoardDimensions();
            
            SpawnRepository spawnRepository = new SpawnRepository(board);


            foreach (IOrganism item in spawnRepository.organisms)
            {
                Console.WriteLine(item.ToString());
            }

            gameBoardRepository.DrawGameBoard();

            _move.MakeMove();

            foreach (IOrganism item in spawnRepository.organisms)
            {
                Console.WriteLine(item.ToString());
            }

            gameBoardRepository.DrawGameBoard();           
            Console.ReadKey();
        }
    }
}
