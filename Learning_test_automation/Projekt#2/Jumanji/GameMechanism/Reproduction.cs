using GamesElement;
using Plant;
using System.Drawing;
using System.Numerics;

namespace GameMechanism
{
    public class Reproduction
    {
        IOrganism _organism;
        Point _oranismLocation;
        private List<IOrganism> _organismCollection;

        public Reproduction(IOrganism organism, Point oranismLocation, List<IOrganism> organismCollection)
        {
            _organism = organism;
            _oranismLocation = oranismLocation;
            _organismCollection = organismCollection;
            PlantDispersal();
        }

        private void PlantDispersal()
        {
            if(IfPlant(_organism))
            {
                TypePlantThatReproduces(_organism);
            }
        }
        
        private void TypePlantThatReproduces(IOrganism organism)
        {
            switch (organism.Id)
            {
                case ("P1"):
                    IOrganism newGrass = new Grass();
                    newGrass.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newGrass);
                    break;
                case ("P2"):
                    IOrganism newDandelion = new Dandelion();
                    newDandelion.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newDandelion);
                    break;
                case ("P3"):
                    IOrganism newGuarana = new Guarana();
                    newGuarana.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newGuarana);
                    break;
                case ("P4"):
                    IOrganism newNightshade = new Nightshade();
                    newNightshade.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newNightshade);
                    break;
                case ("P5"):
                    IOrganism newPineBorscht = new PineBorscht();
                    newPineBorscht.Position = new Point(_oranismLocation.X, _oranismLocation.Y);
                    _organismCollection.Add(newPineBorscht);
                    break;
                default:
                    break;
            }
        }

        private bool IfPlant(IOrganism organism)
        {
            if (organism is PlantOrganism) { return true; }
            else { return false; }
        }
    }
}
