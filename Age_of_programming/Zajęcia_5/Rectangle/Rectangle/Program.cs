namespace Rectangle
{
    class Program
    {
        static public void Main(string[] args)
        {
            RectangleBuilder rectangleBuilder = new RectangleBuilder();
            string[,] rectangle = rectangleBuilder.RectangleConstruction();
            rectangleBuilder.RectangleDisplay(rectangle); 
        }
    }
}
