namespace Rectangle
{
    class RectangleDimensions
    {
       public int TakeNumber()
        {
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number < 1) Console.WriteLine("User, you entered a value that is too small, enter something greater than zero!");
                    else return number;
                }    
                else Console.WriteLine($"This is not a number. Try again, please.");
            }  
        }
    }
}
