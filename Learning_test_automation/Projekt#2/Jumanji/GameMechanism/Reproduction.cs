using Animal;
using GamesElement;
using Plant;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;

namespace GameMechanism
{
    public class Reproduction
    {
        IOrganism _organism;
        Point _oranismLocation;
        Point _spawnPlaceForNewOrganism;
        private List<IOrganism> _organismCollection;
        private Board _board;


        public Reproduction(IOrganism organism, List<IOrganism> organismCollection, Board board, Point spawnPlaceForNewOrganism)
        {
            _organism = organism;
            _oranismLocation = organism.Position;
            _organismCollection = organismCollection;
            _spawnPlaceForNewOrganism = spawnPlaceForNewOrganism;
            _board = board;
            OrganismReproduces();
        }

        private void OrganismReproduces()
        {       
            switch (_organism)
            {
                case (Grass):                                  
                    IOrganism newGrass = new Grass();
                    FindSpawnPlace(newGrass);
                    break;
                case (Dandelion):
                    IOrganism newDandelion = new Dandelion();
                    FindSpawnPlace(newDandelion);                   
                    break;
                case (Guarana):
                    IOrganism newGuarana = new Guarana();
                    FindSpawnPlace(newGuarana);
                    break;
                case (Nightshade):
                    IOrganism newNightshade = new Nightshade();
                    FindSpawnPlace(newNightshade);
                    break;
                case (PineBorscht):
                    IOrganism newPineBorscht = new PineBorscht();
                    FindSpawnPlace(newPineBorscht);
                    break;
                case (Wolf):
                    IOrganism newWolf = new Wolf();
                    FindSpawnPlace(newWolf);
                    break;
                case (Sheep):
                    IOrganism newSheep = new Sheep();
                    FindSpawnPlace(newSheep);
                    break;
                case (Fox):
                    IOrganism newFox = new Fox();
                    FindSpawnPlace(newFox);
                    break;
                case (Turtle):
                    IOrganism newTurtle = new Turtle();
                    FindSpawnPlace(newTurtle);
                    break;
                case (Antelope):
                    IOrganism newAntelope = new Antelope();
                    FindSpawnPlace(newAntelope);
                    break;
                case (CyberSheep):
                    IOrganism newCyberSheep = new CyberSheep();
                    FindSpawnPlace(newCyberSheep);
                    break;
                default:
                    break;
            }
        }

        private void FindSpawnPlace(IOrganism newIOrganism)
        {
            newIOrganism.Position = _spawnPlaceForNewOrganism; //FindOrganismAvailableLocation(_organism);
            _organismCollection.Add(newIOrganism);
            _board.GameBoard[newIOrganism.Position.X, newIOrganism.Position.Y] = newIOrganism.Id;
        }
    }
}
