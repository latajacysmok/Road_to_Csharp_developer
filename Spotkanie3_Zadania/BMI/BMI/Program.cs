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
            int weight;
            double height;

            Console.Write($"Dear {name}, give me your weight: ");
            weight = ItNumber();     //TODO: daj zabezpieczniea na np ujemna waga albo 100 metrów wzrostu.

            Console.Write($"Dear {name}, tell me your height(in meters): ");
            height = ItNumber();    //TODO: daj zabezpieczniea na np ujemna waga albo 100 metrów wzrostu.

            double bmi = BmiCalculation(weight, height);
            Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {EstimateWeight(bmi)}.");
            EndProgramme(name);
        }
    }
    public static double BmiCalculation(int weight, double height)
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
    public static int ItNumber()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int ifExit)) return ifExit;
            else
            {
                Console.Write($"{ifExit.ToString()} is not a number, please try again: ");
            }
        }
    }

    public static void GoOutOrStay(int ifExit, string name)
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