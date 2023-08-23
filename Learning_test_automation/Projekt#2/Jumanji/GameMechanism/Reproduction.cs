using Animal;
using GamesElement;
using Plant;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Numerics;

namespace GameMechanism
{
    public class Reproduction
    {
        IOrganism _organism;
        Point _oranismLocation;
        private List<IOrganism> _organismCollection;
        private Board _board;

        public Reproduction(IOrganism organism, List<IOrganism> organismCollection, Board board)
        {
            _organism = organism;
            _oranismLocation = organism.Position;
            _organismCollection = organismCollection;
            _board = board;
            OrganismReproduces();
        }
        
        private void OrganismReproduces()
        {
            switch (_organism)
            {
                case (Grass):
                    IOrganism newGrass = new Grass();
                    newGrass.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newGrass);
                    _board.GameBoard[newGrass.Position.X, newGrass.Position.Y] = newGrass.Id;
                    break;
                case (Dandelion):
                    IOrganism newDandelion = new Dandelion();
                    newDandelion.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newDandelion);
                    _board.GameBoard[newDandelion.Position.X, newDandelion.Position.Y] = newDandelion.Id;
                    break;
                case (Guarana):
                    IOrganism newGuarana = new Guarana();
                    newGuarana.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newGuarana);
                    _board.GameBoard[newGuarana.Position.X, newGuarana.Position.Y] = newGuarana.Id;
                    break;
                case (Nightshade):
                    IOrganism newNightshade = new Nightshade();
                    newNightshade.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newNightshade);
                    _board.GameBoard[newNightshade.Position.X, newNightshade.Position.Y] = newNightshade.Id;
                    break;
                case (PineBorscht):
                    IOrganism newPineBorscht = new PineBorscht();
                    newPineBorscht.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newPineBorscht);
                    _board.GameBoard[newPineBorscht.Position.X, newPineBorscht.Position.Y] = newPineBorscht.Id;
                    break;
                case (Wolf):
                    IOrganism newWolf = new Wolf();
                    newWolf.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newWolf);
                    _board.GameBoard[newWolf.Position.X, newWolf.Position.Y] = newWolf.Id;
                    break;
                case (Sheep):
                    IOrganism newSheep = new Sheep();
                    newSheep.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newSheep);
                    _board.GameBoard[newSheep.Position.X, newSheep.Position.Y] = newSheep.Id;
                    break;
                case (Fox):
                    IOrganism newFox = new Fox();
                    newFox.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newFox);
                    _board.GameBoard[newFox.Position.X, newFox.Position.Y] = newFox.Id;
                    break;
                case (Turtle):
                    IOrganism newTurtle = new Turtle();
                    newTurtle.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newTurtle);
                    _board.GameBoard[newTurtle.Position.X, newTurtle.Position.Y] = newTurtle.Id;
                    break;
                case (Antelope):
                    IOrganism newAntelope = new Antelope();
                    newAntelope.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newAntelope);
                    _board.GameBoard[newAntelope.Position.X, newAntelope.Position.Y] = newAntelope.Id;
                    break;
                case (CyberSheep):
                    IOrganism newCyberSheep = new CyberSheep();
                    newCyberSheep.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newCyberSheep);
                    _board.GameBoard[newCyberSheep.Position.X, newCyberSheep.Position.Y] = newCyberSheep.Id;
                    break;
                default:
                    break;
            }
        }
    }
}
