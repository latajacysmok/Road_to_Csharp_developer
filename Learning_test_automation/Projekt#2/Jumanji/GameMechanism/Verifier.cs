using GamesElement;

namespace GameBoard
{
    public class Verifier
    {
        public int GetSizeOfPlayField()
        {
            int amount;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out amount))
                {
                    if (IsGameBoardRightSize(amount)) break;
                    else continue;
                }
                else Console.Write($"This is not a number: {amount}. Please try again: ");
            }
            return amount;
        }

        private bool IsGameBoardRightSize(int size)
        {
            if (0 < size & size < 101) return true;
            else
            {
                Console.Write("I can't accept this value. Size should be bigger than 0 and smaller than 101. Please try again: ");
                return false;
            }
        }

        public bool IfAnimal(IOrganism organism)
        {
            if (organism is AnimalOrganism) { return true; }
            else { return false; }
        }
    }
}