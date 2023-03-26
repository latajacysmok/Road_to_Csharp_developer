using System;

namespace Objectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Co_ordinates co_ordinates = new Co_ordinates();

            var p1 = co_ordinates.TakePointCo_ordinates();
            var p2 = co_ordinates.TakePointCo_ordinates();
            var p3 = co_ordinates.TakePointCo_ordinates();

            Triangle triangle = new Triangle();
            Console.WriteLine("Obwod: " + triangle.PerimeterOfTriangle(p1, p2, p3));

            string ifTraingle = triangle.IsTriangle(p1, p2, p3) ? "The points you give can define a triangle." : "The points you specify cannot define a triangle.";
            Console.WriteLine(ifTraingle);

            Console.ReadKey();
        }
    }
}
