using System;

namespace Objectivity
{
    class Co_ordinates
    {
        private static int pointNumber = 0;
        public Co_ordinates() 
        {
            pointNumber++;
        }
        public Point TakePointCo_ordinates()
        {
            Point point = new Point();
            string order;

            if (pointNumber == 1) order = "first";
            else if (pointNumber == 2) order = "second";
            else if (pointNumber == 3) order = "third";
            else
            {
                Console.WriteLine("Nie powinno mnie tu być");
                order = "Dupppa!!!";
            }

            Console.Write($"Dear user, please give me the {order} point coordinate 'x': ");
            point.x = ItNumber();
            Console.Write($"Dear user, please give me the {order} point coordinate 'y': ");
            point.y = ItNumber();
            Console.WriteLine("Your fist point: ({0},{1})", point.x, point.y);
            Console.WriteLine("---\n");

            return (point);
        }

        private double ItNumber()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number)) return number;
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }
    }
}
