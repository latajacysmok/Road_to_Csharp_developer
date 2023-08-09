using Animal;
using GamesElement;
using Plant;
using System;
using System.Drawing;

namespace GameMechanism
{
    public class Move
    {
        private int _height;
        private int _width;
        Board _board;
        Collision collision;
        private List<IOrganism> _organismCollection;
        Random random = new Random();
        
        public Move(Board board, List<IOrganism> organismCollection)
        {
            _board = board;
            _height = board.Height;
            _width = board.Width;
            _organismCollection = organismCollection;
            collision = new Collision(_board);
        }

        private bool IfAnimal(IOrganism organism)
        {
            if (organism is AnimalOrganism) { return true; }
            else { return false;  }      
        }
        
        private void AnimalMove(IOrganism organism)
        {
            List<Point> selectAvailableField = SelectAvailableField(organism);
            Point availableField = ChoosingPlace(selectAvailableField);
            Point oranismLocation = collision.IfBeCollision(availableField.X, availableField.Y, _organismCollection, organism);

            organism.Position = new Point(oranismLocation.X, oranismLocation.Y);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = organism.Id;
        }
        
        private void PlantMove(IOrganism organism)
        {
            List<Point> selectAvailableField = SelectAvailableField(organism);
            Point availableField = ChoosingPlace(selectAvailableField);
            Point oranismLocation = collision.IfBeCollision(availableField.X, availableField.Y, _organismCollection, organism);

            //organism.Position = new Point(oranismLocation.X, oranismLocation.Y);

            //Utworzenie nowego obiektu danej rośliny na powyższym miejscu
            Reproduction reproduction = new Reproduction(organism, oranismLocation, _organismCollection);
        }


        public void MakeMove()
        {
            for (int i = 0; i < _organismCollection.Count; i++)//var organism in _organismCollection
            {
                if (IfAnimal(_organismCollection[i])) { AnimalMove(_organismCollection[i]); }
                else 
                {
                    if (WhetherToReproducePlant()) { PlantMove(_organismCollection[i]); }
                }               
            }
        }

        private List<Point> SelectAvailableField(IOrganism organism)
        {
            List<Point> availableField = new List<Point>();
            int rowValue = (int)organism.Position.X;
            int columnValue = (int)organism.Position.Y;
            List<Point> allPossiblePlayingDieldsToMakeMove = new List<Point>()
                                                                {
                                                                    new Point(rowValue + 1, columnValue),
                                                                    new Point(rowValue + 1, columnValue + 1),
                                                                    new Point(rowValue, columnValue + 1),
                                                                    new Point(rowValue - 1, columnValue + 1),
                                                                    new Point(rowValue - 1, columnValue),
                                                                    new Point(rowValue - 1, columnValue - 1),
                                                                    new Point(rowValue , columnValue - 1),
                                                                    new Point(rowValue + 1, columnValue - 1),
                                                                };

            foreach(Point point in allPossiblePlayingDieldsToMakeMove)
            {
                if (!IfOrganismOffBoard(point.X, point.Y)) { availableField.Remove(point); }          
                else { availableField.Add(point); }
            }

            /*if (IfOrganismOffBoard(rowValue + 1)) { SelectionLocation(rowValue + 1, columnValue, availableField, organism); }

            if (rowValue + 1 < _height && columnValue + 1 < _width) { SelectionLocation(rowValue + 1, columnValue + 1, availableField, organism); }

            if (columnValue + 1 < _width) { SelectionLocation(rowValue, columnValue + 1, availableField, organism); }

            if (0 <= rowValue - 1 && columnValue + 1 <= _width) { SelectionLocation(rowValue - 1, columnValue + 1, availableField, organism); }

            if (0 <= rowValue - 1) { SelectionLocation(rowValue - 1, columnValue, availableField, organism); }

            if (0 <= rowValue - 1 && 0 <= columnValue - 1) { SelectionLocation(rowValue - 1, columnValue - 1, availableField, organism); }

            if (0 <= columnValue - 1) { SelectionLocation(rowValue, columnValue - 1, availableField, organism); }

            if (rowValue + 1 < _height && 0 <= columnValue - 1) { SelectionLocation(rowValue + 1, columnValue - 1, availableField, organism); }*/

            return availableField;
        }

        private bool IfOrganismOffBoard(int rowValue = 0, int columnValue = 0)
        {
            return 0 <= rowValue && rowValue < _height && 0 <= columnValue && columnValue < _height;
        }

        private Point ChoosingPlace(List<Point> availableField)
        {         
            int placeDraw = random.Next(availableField.Count);
            return availableField[placeDraw];
        }
        private bool WhetherToReproducePlant()
        {
            int whetherToReproduce = random.Next(2);
            return whetherToReproduce == 1;
        }
    }
}
