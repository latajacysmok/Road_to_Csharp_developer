﻿using System.Linq.Expressions;

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

            while (true)
            {
                Console.Write($"Dear {name}, give me your weight: ");
                if(int.TryParse(Console.ReadLine(), out weight)) break;
                else Console.WriteLine($"This is not a number: {weight.GetType()}. Try again, please.");
            }

            while (true)
            {
                Console.Write($"Dear {name}, tell me your height(in meters): ");
                if (double.TryParse(Console.ReadLine(), out height)) break;
                else Console.WriteLine($"This is not a number: {weight.GetType()}. Try again, please.");
            }

            double bmi = BmiCalculation(weight, height);
            Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {WeightRating(bmi)}");
            Console.Write($"{name} do you want to continue[y/n]: ");
            if (Console.ReadLine().ToLower() == "y")
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

    public static string WeightRating(double bmi)
    {
        switch (bmi)
        {
            case < 18.5:
                return "underweight";
                break;
            case > 24.9:
                return "overweight";
                break;
            default:
                return "weight in standard";
                break;
        }
    }
}