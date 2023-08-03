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

        private bool IfMakeMove(IOrganism organism)
        {
            if (organism is AnimalOrganism) { return true; }
            else
            {              
                if (WhetherToReproducePlant()) { return true; }
                else { return false; }
            }         
        }


        public void MakeMove()
        {
            foreach (var organism in _organismCollection)
            {
                if(IfMakeMove(organism))
                {
                    List<Point> selectAvailableField = SelectAvailableField(organism);
                    Point availableField = ChoosingPlace(selectAvailableField);

                    organism.Position = new Point(availableField.X, availableField.Y);

                    _board.EmptyGameBoard[organism.Position.X, organism.Position.Y] = organism.Id;
                }
                else { continue; }
                
            }
        }

        private List<Point> SelectAvailableField(IOrganism organism)
        {
            List<Point> availableField = new List<Point>();
            int rowValue = (int)organism.Position.X;
            int columnValue = (int)organism.Position.Y;

            if (IfOrganismOffBoard(rowValue + 1)) { SelectionLocation(rowValue + 1, columnValue, availableField, organism); }

            if (rowValue + 1 < _height && columnValue + 1 < _width) { SelectionLocation(rowValue + 1, columnValue + 1, availableField, organism); }

            if (columnValue + 1 < _width) { SelectionLocation(rowValue, columnValue + 1, availableField, organism); }

            if (0 <= rowValue - 1 && columnValue + 1 <= _width) { SelectionLocation(rowValue - 1, columnValue + 1, availableField, organism); }

            if (0 <= rowValue - 1) { SelectionLocation(rowValue - 1, columnValue, availableField, organism); }

            if (0 <= rowValue - 1 && 0 <= columnValue - 1) { SelectionLocation(rowValue - 1, columnValue - 1, availableField, organism); }

            if (0 <= columnValue - 1) { SelectionLocation(rowValue, columnValue - 1, availableField, organism); }

            if (rowValue + 1 < _height && 0 <= columnValue - 1) { SelectionLocation(rowValue + 1, columnValue - 1, availableField, organism); }

            return availableField;
        }

        private bool IfOrganismOffBoard(int rowValue = 0, int columnValue = 0)
        {
            return 0 <= rowValue && rowValue < _height && 0 <= columnValue && columnValue < _height;
        }

        private void SelectionLocation(int rowValue, int columnValue, List<Point> availableField, IOrganism organism)
        {
            Point location = collision.IfBeCollision(rowValue, columnValue, _organismCollection, organism);

            availableField.Add(location);
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
