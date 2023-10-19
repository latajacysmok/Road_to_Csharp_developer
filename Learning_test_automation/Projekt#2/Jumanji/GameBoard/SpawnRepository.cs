using Plant;
using Animal;
using GamesElement;
using GameMechanism;
using System.Drawing;
using System.ComponentModel;

namespace GameBoard
{
    public class SpawnRepository
    {
        private int _high;
        private int _width;

        public List<IOrganism> organisms = new List<IOrganism>
        {
            new Grass(),
/*            new Dandelion(),
            new Guarana(),
            new Nightshade(),
            new PineBorscht(),*/
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Wolf(),
            new Sheep(),
            new Sheep(),
            new Fox(),
            new Fox(),
            /*            new Turtle(),
                        new Turtle(),
                        new Antelope(),
                        new Antelope(),
                        new CyberSheep(),*/
            //_container.GetInstance<IOrganism>()
            //new CyberSheep()
        };        

        public SpawnRepository(Board board)
        {
            _high = board.Height;
            _width = board.Width;

            organisms = SetOrderOfMovement();
            IteratingThroughAllOrganisms(board);
        }

        private List<IOrganism> SetOrderOfMovement()
        {
            var sortedAnimals = organisms.OfType<IAnimalOrganism>()
                                         .OrderByDescending(animal => animal.Initiative)
                                         .ToList();

            var remainingPlants = organisms.Except(sortedAnimals).ToList();

            return sortedAnimals.Cast<IOrganism>()
                                .Concat(remainingPlants)
                                .ToList();
        }

        private void IteratingThroughAllOrganisms(Board board)
        {         
            foreach (IOrganism being in organisms)
            {
                AddingOrganizmSpawnPlace(board, being);
            }
        }

        private void AddingOrganizmSpawnPlace(Board board, IOrganism being)
        {
            Spawn spawn = new Spawn(_high, _width);
            Point currentPosition = being.Position;

            // Modifying the Position array
            being.Position = new Point(spawn.Column, spawn.Row);

            board.GameBoard[spawn.Column, spawn.Row] = being.Id;
        }
    }
}
