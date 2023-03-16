namespace BMI
{
    class Data
    {
        Option appOption = new Option();
        public double WeightChecker(string name)
        {
            while (true)
            {
                Console.Write($"Dear {name}, give me your weight: ");
                double weight = appOption.ItNumber();
                if (weight > 0 && weight < 251) return weight;
                else Console.WriteLine("The given weight value is invalid. Lets try again.");
            }
        }

        public double HeightChecker(string name)
        {
            while (true)
            {
                Console.Write($"Dear {name}, tell me your height(in meters): ");
                double height = appOption.ItNumber();
                if (height > 0 && height < 3) return height;
                else Console.WriteLine("The given height value is invalid. Lets try again.");
            }
        }
    }
}
