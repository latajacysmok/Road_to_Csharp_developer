using Plant;
using Animal;
using GamesElement;
using GameMechanism;
using System.Drawing;

namespace GameBoard
{
    public class SpawnRepository
    {
        private int _high;
        private int _width; 
        public List<IOrganism> organism = new List<IOrganism>
        {
            new Grass(),
            new Dandelion(),
            new Guarana(),
            new Nightshade(),
            new PineBorscht(),
            new Wolf(),
            new Sheep(),
            new Fox(),
            new Turtle(),
            new Antelope(),
            new CyberSheep()
        };

        public SpawnRepository(Board board)
        {
            _high = board.Height;
            _width = board.Width;
            AddingOrganismSpawn(board);
        }

        private void AddingOrganismSpawn(Board board)
        {
            SpawnOrganizm(board);
        }

        private void SpawnOrganizm(Board board)
        {
            foreach (IOrganism being in organism)
            {
                AddingOrganizmSpawnPlace(board, being);
            }
        }

        private void AddingOrganizmSpawnPlace(Board board, IOrganism being)
        {
            //ID i position  zbiór koelkcji typu abstrakcyjnego
            // utwórz public List<IOrganism> organism = new List<IOrganism>() odrazu dodaj organizmy w sensie obiekty Popatrz na materiały z Interface i zadziała xD Zwróć

            Spawn spawn = new Spawn(_high, _width);
            Point currentPosition = being.Position;

            // Modifying the Position array
            being.Position = new Point(spawn.Column, spawn.Row);

            board.EmptyGameBoard[spawn.Column, spawn.Row] = being.Id;
        }
    }
}
