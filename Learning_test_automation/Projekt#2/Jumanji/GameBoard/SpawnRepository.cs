using Plant;
using Animal;
using GamesElement;
using GameMechanism;

namespace GameBoard
{
    public class SpawnRepository
    {
        private int _high;
        private int _width;
        public List<Organism> organism = new List<Organism>();

        public SpawnRepository(Board board)
        {
            _high = board.Height;
            _width = board.Width;
            AddingOrganismSpawn(board);
        }

        private void AddingOrganismSpawn(Board board)
        {
            AddingGrassSpawn(board);
            AddingDandelionSpawn(board);
            AddingGuaranaSpawn(board);
            AddingNightshadeSpawn(board);
            AddingPineBorschtSpawn(board);

            AddingWolfSpawn(board);
            AddingSheepSpawn(board);
            AddingFoxSpawn(board);
            AddingTurtleSpawn(board);
            AddingAntelopeSpawn(board);
            AddingCyberSheepSpawn(board);
        }

        //Plant
        private void AddingGrassSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Grass grass = new Grass();

            // Accessing the Position array
            int[] currentPosition = grass.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            grass.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = grass.Id;

            organism.Add(grass);
        }

        private void AddingDandelionSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Dandelion dandelion = new Dandelion();

            // Accessing the Position array
            int[] currentPosition = dandelion.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            dandelion.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = dandelion.Id;

            organism.Add(dandelion);
        }

        private void AddingGuaranaSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Guarana guarana = new Guarana();

            // Accessing the Position array
            int[] currentPosition = guarana.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            guarana.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = guarana.Id;

            organism.Add(guarana);
        }

        private void AddingNightshadeSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Nightshade nightshade = new Nightshade();

            // Accessing the Position array
            int[] currentPosition = nightshade.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            nightshade.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = nightshade.Id;

            organism.Add(nightshade);
        }

        private void AddingPineBorschtSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            PineBorscht pineBorscht = new PineBorscht();

            // Accessing the Position array
            int[] currentPosition = pineBorscht.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            pineBorscht.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = pineBorscht.Id;

            organism.Add(pineBorscht);
        }

        //Animal

        private void AddingWolfSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Wolf wolf = new Wolf();

            // Accessing the Position array
            int[] currentPosition = wolf.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            wolf.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = wolf.Id;

            organism.Add(wolf);
        }
        private void AddingSheepSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Sheep sheep = new Sheep();

            // Accessing the Position array
            int[] currentPosition = sheep.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            sheep.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = sheep.Id;

            organism.Add(sheep);
        }

        private void AddingFoxSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Fox fox = new Fox();

            // Accessing the Position array
            int[] currentPosition = fox.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            fox.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = fox.Id;

            organism.Add(fox);

        }

        private void AddingTurtleSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Turtle turtle = new Turtle();

            // Accessing the Position array
            int[] currentPosition = turtle.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            turtle.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = turtle.Id;

            organism.Add(turtle);
        }

        private void AddingAntelopeSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            Antelope antelope = new Antelope();

            // Accessing the Position array
            int[] currentPosition = antelope.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            antelope.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = antelope.Id;

            organism.Add(antelope);
        }

        private void AddingCyberSheepSpawn(Board board)
        {
            Spawn spawn = new Spawn(_high, _width);
            CyberSheep cyberSheep = new CyberSheep();

            // Accessing the Position array
            int[] currentPosition = cyberSheep.Position;

            // Modifying the Position array
            int[] newPosition = { spawn.Column, spawn.Row };
            cyberSheep.Position = newPosition;

            board.EmptyGameBoard[spawn.Column, spawn.Row] = cyberSheep.Id;

            organism.Add(cyberSheep);
        }
    }
}
