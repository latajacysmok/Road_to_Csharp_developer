using Animal;
using GamesElement;
using Plant;
using System;

namespace GameMechanism
{
    public class Move
    {
        private int _height;
        private int _width;
        Board _board;
        private List<Organism> _organismCollection;
        Random random = new Random();
        
        public Move(Board board, List<Organism> organismCollection)
        {
            _board = board;
            _height = board.Height;
            _width = board.Width;
            _organismCollection = organismCollection;
        }

        private bool IfMakeMove(Organism organism)
        {
            if (organism is AnimalOrganism)
            {
                _board.EmptyGameBoard[organism.Position[0], organism.Position[1]] = "0";
            }
            else
            {              
                if (WhetherToReproducePlant()) { return true; }
                else { return false; }
            }
            return true;
        }


        public void MakeMove()
        {
            foreach (var organism in _organismCollection)
            {
                if(IfMakeMove(organism))
                {
                    List<int[]> selectAvailableField = SelectAvailableField(organism.Position);
                    int[] availableField = ChoosingPlace(selectAvailableField);

                    organism.SetPosition(availableField[0], availableField[1]);

                    _board.EmptyGameBoard[GetOrganizmLocation(organism)[0], GetOrganizmLocation(organism)[1]] = organism.Id;
                }
                else { continue; }
                
            }
        }
        public int[] GetOrganizmLocation(Organism organism)
        {
            return organism.GetPosition();
        }
        
        public List<int[]> SelectAvailableField(int[] organizmPosition)
        {
            List<int[]> availableField = new List<int[]>();
            int rowValue = (int)organizmPosition[0];
            int columnValue = (int)organizmPosition[1];

            if (rowValue + 1 < _height) { SelectionLocation(rowValue + 1, columnValue, availableField); }

            if (rowValue + 1 < _height && columnValue + 1 < _width) { SelectionLocation(rowValue + 1, columnValue + 1, availableField); }

            if (columnValue + 1 < _width) { SelectionLocation(rowValue, columnValue + 1, availableField); }

            if (0 <= rowValue - 1 && 0 <= columnValue - 1) { SelectionLocation(rowValue - 1, columnValue - 1, availableField); }

            if (0 <= rowValue - 1) { SelectionLocation(rowValue - 1, columnValue, availableField); }

            if (0 <= rowValue - 1 && 0 <= columnValue + 1) { SelectionLocation(rowValue - 1, columnValue - 1, availableField); }

            if (0 <= columnValue - 1) { SelectionLocation(rowValue, columnValue - 1, availableField); }

            if (0 <= rowValue - 1 && columnValue + 1 <= _height) { SelectionLocation(rowValue - 1, columnValue + 1, availableField); }

            return availableField;
        }

        public void SelectionLocation(int rowValue, int columnValue, List<int[]> availableField)
        {
            int[] location = new int[] { rowValue, columnValue };
            availableField.Add(location);
        }

        public int[] ChoosingPlace(List<int[]> availableField)
        {         
            int placeDraw = random.Next(availableField.Count);
            return availableField[placeDraw];
        }
        public bool WhetherToReproducePlant()
        {
            int whetherToReproduce = random.Next(2);
            return whetherToReproduce == 1;
        }
    }
}
