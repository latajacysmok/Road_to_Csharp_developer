namespace Christmas_tree
{
    class ChristmasTreeHeight
    {
        public int TakeNumber()
        {
            int number;
            Console.Write("Now please give me a number my good friend: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number < 1)
                    {
                        Console.Write($"This {number} is to small. Try again, please: ");
                        continue;
                    }
                    else return number;
                }
                else Console.Write($"This {number} is not a number. Try again, please: ");
            }          
        }
    }
}
