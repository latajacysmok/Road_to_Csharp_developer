using System.Drawing;

namespace Rectangle
{
    class RectangleBuilder
    {
        RectangleDimensions rectangleDimensions = new RectangleDimensions();

        public int RectangleHeight()
        {
            Console.Write("Dear User, give me please a height number of your rectangle: ");
            return rectangleDimensions.TakeNumber();
        }
        public int RectangleWeight()
        {
            Console.Write("Dear User, give me please a weight number of your rectangle: ");
            return rectangleDimensions.TakeNumber();
        }

        public string[,] RectangleConstruction()
        {
            int height = RectangleHeight();
            int weight = RectangleWeight();

            string[,] rectangle = new string[height, weight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    rectangle[i, j] = "#";
                }
            }
            return rectangle;
        }

        public void RectangleDisplay(string[,] rectangle)
        {
            Console.WriteLine("-------------------\n");
            for (int i = 0; i < rectangle.GetLength(0); i++)
            {
                for (int j = 0; j < rectangle.GetLength(1); j++)
                {
                    Console.Write(rectangle[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
