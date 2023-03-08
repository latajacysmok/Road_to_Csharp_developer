using System.Linq.Expressions;
using System.Xml.Linq;

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
            double weight = WeightChecker(name);
            double height = HeightChecker(name);
            double bmi = BmiCalculation(weight, height);

            Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {EstimateWeight(bmi)}.");
            EndProgramme(name);
        }
    }
    public static double BmiCalculation(double weight, double height)
    {
        double bmi = weight / PowerCalculation(height);
        return bmi;                                               
    }

    public static double PowerCalculation(double height)
    {
        double pow = Math.Pow(2.0, (double)height);    
        return pow;                                        
    }

    public static string EstimateWeight(double bmi)                
    {
        switch (bmi)
        {
            case < 18.5:
                return "underweight";
            case > 24.9:
                return "overweight";
            default:
                return "weight in standard";
        }
    }

    public static void EndProgramme(string name)
    {
        while(true)
        {
            Console.WriteLine($"{name} do you want to continue: ");
            Console.WriteLine("If yes enter: '1'.");
            Console.WriteLine("If no enter: '2'.");
            GoOutOrStay(ItNumber(), name);
            break;
        }
    }
    public static double ItNumber()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double number)) return number;
            else Console.Write($"{number.ToString()} is not a number, please try again: ");
        }
    }

    public static double WeightChecker(string name)
    {
        while (true)
        {
            Console.Write($"Dear {name}, give me your weight: ");
            double weight = ItNumber();
            if (weight > 0 && weight < 251) return weight;
            else Console.WriteLine("The given weight value is invalid. Lets try again.");
        } 
    }

    public static double HeightChecker(string name)
    {
        while (true)
        {
            Console.Write($"Dear {name}, tell me your height(in meters): ");
            double height = ItNumber();
            if (height > 0 && height < 3) return height;
            else Console.WriteLine("The given height value is invalid. Lets try again.");
        }
    }

    public static void GoOutOrStay(double ifExit, string name)
    {
        while (true)
        {
            if (ifExit == 1)
            {
                Console.WriteLine($"So let's get started again {name}.");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Clear();
                break;
            }
            else if (ifExit == 2)
            {
                Console.WriteLine($"See you soon {name}.");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine($"Your number is: {ifExit}.The given number must equal 1 if you want to continue and 2 if you want to end the program. Try again");
                ItNumber();
            }    
        }
    }   
}