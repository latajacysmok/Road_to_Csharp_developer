using GamesElement;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Linq;

namespace GameMechanism
{
    public class Move : IMove
    {
        private int _height;
        private int _width;
        private IBoard _board;
        public IBoard Board 
        {
            get { return _board; }
        }

        private List<IOrganism> _organismCollection;

        Random random = new Random();
        private readonly ICollision _collision;

        private readonly IVerifier _verifier;

        public Move(IBoard board, List<IOrganism> organismCollection, IVerifier verifier)
        {
            _board = board;
            _height = board.Height;
            _width = board.Width;
            _organismCollection = organismCollection;
            _verifier = verifier;
            _collision = new Collision(board, this);
        }

        public void MakeMove()
        {
            ChangingStatusFromNewToOld();
            for (int i = 0; i < _organismCollection.Count; i++)
            {
                if (_verifier.IfAnimal(_organismCollection[i]) && _organismCollection[i].IfNew == false) { AnimalMove(_organismCollection[i]); }
                else if (_organismCollection[i].IfNew == false) { PlantMove(_organismCollection[i]); }
            }
        }

        public void AnimalMove(IOrganism organism)
        {
            Point oranismLocation = FindOrganismAvailableLocation(organism);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = "O";

            organism.Position = new Point(oranismLocation.X, oranismLocation.Y);

            _board.GameBoard[organism.Position.X, organism.Position.Y] = organism.Id;           
        }

        public void PlantMove(IOrganism organism)
        {
            WhetherToReproducePlant(organism); 
        }

        public Point FindOrganismAvailableLocation(IOrganism organism)
        {
            Point newPosition = SelectNewPosition(organism);

            return _collision.HandleCollision(newPosition, _organismCollection, organism);
        }

        public Point SelectNewPosition(IOrganism organism) 
        {
            List<Point> selectAvailableField = SelectAvailableField(organism);
            Point availableField = ChoosingPlace(selectAvailableField);
            return new Point(availableField.X, availableField.Y);
        }




        public List<Point> SelectAvailableField(IOrganism organism)
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

        public List<Point> SelectFieldsOnGameBoard(IOrganism organism)//tutaj
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

        public bool IfOrganismOffBoard(int rowValue = 0, int columnValue = 0)
        {
            return 0 <= rowValue && rowValue < _width && 0 <= columnValue && columnValue < _height;
        }

        public Point ChoosingPlace(List<Point> availableField)
        {         
            int placeDraw = random.Next(availableField.Count);
            return availableField[placeDraw];//tutaj błąd!
        }       
        
        public void WhetherToReproducePlant(IOrganism organism)
        {
            if (random.Next(2) == 1) { new Reproduction(organism, _organismCollection, _board, FindOrganismAvailableLocation(organism)); }
        }

        public void ChangingStatusFromNewToOld()
        {
            foreach (var organism in _organismCollection)
            {
                organism.IfNew = false;
            }
        }
    }
}
