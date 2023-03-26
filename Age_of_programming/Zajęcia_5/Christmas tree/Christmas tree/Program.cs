using Christmas_tree;

namespace ChristmasTree
{
    class Program
    {
        static public void Main(string[] args)
        {
            ChristmasTreeHeight christmasTreeHeight = new ChristmasTreeHeight();
            int height = christmasTreeHeight.TakeNumber();
            ChristmasTreeBuilder christmasTreeBuilder = new ChristmasTreeBuilder();
            christmasTreeBuilder.ChristmasTreeConstruction(height);
            Console.ReadKey();
        }
    }
}


