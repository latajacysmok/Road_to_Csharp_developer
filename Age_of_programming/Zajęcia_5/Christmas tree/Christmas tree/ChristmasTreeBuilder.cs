namespace Christmas_tree
{
    class ChristmasTreeBuilder
    {
        public void ChristmasTreeConstruction(int height)
        {
            int weight = height *2;
            int numberOfDotsInDrawing = weight - 1;
            int numberOfChristmasTreeStars = 0;
            int trunkPosition = 0;
            for (int i = 1; i <= height; i++, numberOfDotsInDrawing--, numberOfChristmasTreeStars++)
            {
                if (i == 1) trunkPosition = i + numberOfDotsInDrawing -1;
                Console.Write(String.Concat(Enumerable.Repeat(".", numberOfDotsInDrawing)));
                Console.Write(String.Concat(Enumerable.Repeat("*", i + numberOfChristmasTreeStars)));
                Console.WriteLine();
            }
            ChristmasTreeTrunk(trunkPosition);
        }

        private void ChristmasTreeTrunk(int trunkPosition)
        {
            Console.Write(String.Concat(Enumerable.Repeat(".", trunkPosition)));
            Console.WriteLine("#");
        }
    }
}
