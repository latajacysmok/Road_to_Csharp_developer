namespace Objectivity
{
    class Triangle
    {
        SideLength sideLength = new SideLength();   

        public bool IsTriangle(Point p1, Point p2, Point p3)
        {
            double sideLengthP1P2 = sideLength.CalculateLengthOfSegment(p1, p2);
            double sideLengthP1P3 = sideLength.CalculateLengthOfSegment(p1, p3);
            double sideLengthP2P3 = sideLength.CalculateLengthOfSegment(p2, p3);

            bool isSideOfTriangleA = sideLengthP1P2 + sideLengthP2P3 > sideLengthP1P3;
            bool isSideOfTriangleB = sideLengthP2P3 + sideLengthP1P3 > sideLengthP1P2;
            bool isSideOfTriangleC = sideLengthP1P3 + sideLengthP1P2 > sideLengthP2P3;

            return isSideOfTriangleA && isSideOfTriangleB && isSideOfTriangleC;
        }

        public double PerimeterOfTriangle(Point p1, Point p2, Point p3)
        {
            double a = sideLength.CalculateLengthOfSegment(p1, p2);
            double b = sideLength.CalculateLengthOfSegment(p2, p3);
            double c = sideLength.CalculateLengthOfSegment(p3, p1);

            return a + b + c;
        }
    }
}
