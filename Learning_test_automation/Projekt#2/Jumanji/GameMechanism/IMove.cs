using GamesElement;
using System.Drawing;

namespace GameMechanism
{
    public interface IMove
    {
        IBoard Board { get; }

        void MakeMove();

        void AnimalMove(IOrganism organism);

        void PlantMove(IOrganism organism);

        Point FindOrganismAvailableLocation(IOrganism organism);

        Point SelectNewPosition(IOrganism organism);

        List<Point> SelectAvailableField(IOrganism organism);

        List<Point> SelectFieldsOnGameBoard(IOrganism organism);

        bool IfOrganismOffBoard(int rowValue = 0, int columnValue = 0);

        Point ChoosingPlace(List<Point> availableField);

        void WhetherToReproducePlant(IOrganism organism);

        void ChangingStatusFromNewToOld();
    }
}
