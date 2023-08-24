using Animal;
using GameBoard;
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
        Verifier verifier = new Verifier();
        Random random = new Random();
        
        public Move(Board board, List<IOrganism> organismCollection)
        {
            _board = board;
            _height = board.Height;
            _width = board.Width;
            _organismCollection = organismCollection;
            collision = new Collision(_board, this);
        }

        public void MakeMove()
        {
            ChangingStatusFromNewToOld();
            for (int i = 0; i < _organismCollection.Count; i++)
            {
                if (verifier.IfAnimal(_organismCollection[i]) && _organismCollection[i].IfNew == false) { AnimalMove(_organismCollection[i]); }
                else if (_organismCollection[i].IfNew == false) { PlantMove(_organismCollection[i]); }
            }
        }

        private void AnimalMove(IOrganism organism)
        {
            Point oranismLocation = FindOrganismAvailableLocation(organism);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = "O";

            organism.Position = new Point(oranismLocation.X, oranismLocation.Y);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = organism.Id;           
        }

        private void PlantMove(IOrganism organism)
        {
            WhetherToReproducePlant(organism); 
        }

        public Point FindOrganismAvailableLocation(IOrganism organism)
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

        private List<Point> SelectFieldsOnGameBoard(IOrganism organism)//tutaj
        {
            List<Point> allPossiblePlayingFieldsToMakeMove = new List<Point>();

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (j == 0 && i == 0) { continue; }
                    else 
                    {
                        allPossiblePlayingFieldsToMakeMove.Add(new Point(organism.Position.X + i, organism.Position.Y + j));
                        /*try { allPossiblePlayingFieldsToMakeMove.Add(new Point(organism.Position.X + i, organism.Position.Y + j)); }
                        catch (Exception ArgumentOutOfRangeException) { Console.WriteLine("punkt poza planszą"); } */
                    }
                }
            }

            return allPossiblePlayingFieldsToMakeMove;
        }

        private bool IfOrganismOffBoard(int rowValue = 0, int columnValue = 0)
        {
            return 0 <= rowValue && rowValue < _width && 0 <= columnValue && columnValue < _height;
        }

        private Point ChoosingPlace(List<Point> availableField)
        {         
            int placeDraw = random.Next(availableField.Count);
            return availableField[placeDraw];//tutaj błąd!
        }       
        
        public void WhetherToReproducePlant(IOrganism organism)
        {
            if (random.Next(2) == 1) { new Reproduction(organism, _organismCollection, _board, FindOrganismAvailableLocation(organism)); }
        }

        private void ChangingStatusFromNewToOld()
        {
            foreach (var organism in _organismCollection)
            {
                organism.IfNew = false;
            }
        }
    }
}
