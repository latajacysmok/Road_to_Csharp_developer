﻿using GamesElement;
using GameMechanism;

namespace GameBoard
{
    public class Menu
    {        
        GameBoardRepository gameBoardRepository = new GameBoardRepository();

        public Menu(IVerifier verifier)
        {
            
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

            Move move = new Move(board, spawnRepository.organisms);

            move.MakeMove();

            foreach (IOrganism item in spawnRepository.organisms)
            {
                Console.WriteLine(item.ToString());
            }

            gameBoardRepository.DrawGameBoard();           
            Console.ReadKey();
        }
    }
}
