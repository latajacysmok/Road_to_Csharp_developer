using Option;

namespace Data
{
    public class ValueStorage
    {
        Performer appOption = new Performer();

        private string name;
        public double Weight { get; }
        public double Height { get; }
        public string Name { get; }

        public ValueStorage()
        {
            Name = GetName();
            Weight = GetWeightChecker(name);
            Height = GetHeightChecker(name);
        }

        private string GetName()
        {
            while (true)
            {
                name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name)) break;
                else Console.Write("Dear user, you have entered an empty value, please enter your name: ");
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1);
        }

        private double GetWeightChecker(string name)
        {
            while (true)
            {
                Console.Write($"Dear {name}, give me your weight: ");
                double weight = appOption.ItNumber();
                if (weight > 0 && weight < 251) return weight;
                else Console.WriteLine("The given weight value is invalid. Lets try again.");
            }
        }

        private double GetHeightChecker(string name)
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