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
            Point oranismLocation = FindOrganismAvailableLocation(organism);// UWAGA!!! należy popracować nad Rozmnażaniem bo teraz nowe zwierze powstaje w miejsu starego a nie w wolnym możliwym 

            _board.GameBoard[organism.Position.X, organism.Position.Y] = "O";

            organism.Position = new Point(oranismLocation.X, oranismLocation.Y);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = organism.Id;           
        }
        
        private void PlantMove(IOrganism organism)
        {
            Point oranismLocation = FindOrganismAvailableLocation(organism);

            if (organism.IfNew == false) { Reproduction reproduction = new Reproduction(organism, _organismCollection, _board); }  
        }

        private Point FindOrganismAvailableLocation(IOrganism organism)
        {
            Point newPosition = SelectNewPosition(organism);

            return collision.HandleCollision(newPosition, _organismCollection, organism);
        }

        private Point SelectNewPosition(IOrganism organism) 
        {
            List<Point> selectAvailableField = SelectAvailableField(organism);
            Point availableField = ChoosingPlace(selectAvailableField);
            return new Point(availableField.X, availableField.Y);
        }


        public void MakeMove()
        {
            ChangingStatusFromNewToOld();
            for (int i = 0; i < _organismCollection.Count; i++)
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
            
            List<Point> allPossiblePlayingFieldsToMakeMove = SelectFieldsOnGameBoard(organism);
            
            foreach(Point point in allPossiblePlayingFieldsToMakeMove)
            {
                if (!IfOrganismOffBoard(point.X, point.Y)) { availableField.Remove(point); }          
                else { availableField.Add(point); }
            }

            return availableField;
        }

        private List<Point> SelectFieldsOnGameBoard(IOrganism organism)
        {
            List<Point> allPossiblePlayingFieldsToMakeMove = new List<Point>();

            int rowValue = (int)organism.Position.X;
            int columnValue = (int)organism.Position.Y;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (j == 0 && i == 0) { continue; }
                    else { allPossiblePlayingFieldsToMakeMove.Add(new Point(rowValue + i, columnValue + j)); }
                }
            }

            return allPossiblePlayingFieldsToMakeMove;
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
        
        private void ChangingStatusFromNewToOld()
        {
            foreach (var organism in _organismCollection)
            {
                organism.IfNew = false;
            }
        }
        private bool WhetherToReproducePlant()
        {
            int whetherToReproduce = random.Next(2);
            return whetherToReproduce == 1;
        }
    }
}
