using GamesElement;
using System.Drawing;

namespace GameMechanism
{
    public interface IVerifier
    {
        int GetSizeOfPlayField();
        bool IsGameBoardRightSize(int size);
        bool IfAnimal(IOrganism organism);
    }
}
