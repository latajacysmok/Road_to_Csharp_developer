class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to BMI Calculator");
        Console.WriteLine("We will now calculate your BMI");
        Console.WriteLine("-------------------------");
        Console.Write("Dear user, write me your name: ");
        string name = Console.ReadLine();
        while (true)
        {
            int userWeight;
            double userHeight;

            while (true)
            {
                Console.Write($"Dear {name}, give me your weight: ");
                if(int.TryParse(Console.ReadLine(), out userWeight)) break;
                else Console.WriteLine($"This is not a number: {userWeight.ToString()}. Try again, please.");
            }

            while (true)
            {
                Console.Write($"Dear {name}, tell me your height(in meters): ");
                if (double.TryParse(Console.ReadLine(), out userHeight)) break;
                else Console.WriteLine($"This is not a number: {userWeight.ToString()}. Try again, please.");
            }

            double bmi = BmiCalculation(userWeight, userHeight);
            Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {Result(bmi)}");
            Console.Write($"{name} do you want to continue[y/n]: ");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine($"So let's get started again {name}.");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Clear();
            }             
            else 
            {
                Console.WriteLine($"See you soon {name}.");
                break;
            }

        }
    }
    public static double BmiCalculation(int weight, double height)
    {
        double bmi = weight / (Math.Pow(2.0, (double)height));
        return bmi;
    }

    public static string Result(double bmi)
    {
        if (bmi < 18.5) return "underweight";
        else if (24.9 < bmi) return "overweight";
        else return "weight normal";

    }

}



