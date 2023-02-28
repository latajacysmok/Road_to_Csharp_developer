﻿/*Zadanie 2 - Aplikacja konsolowa do przeliczania BMI:
Stwórz nową solucję oraz projekty, które uważasz, że będą potrzebne
Wymagania aplikacji: 
użytkownik podaje wagę
użytkownik podaje wzrost
skorzystaj ze wzoru do obliczania BMI

BMI = waga / (wzrost)^2

przyjmij zakres : 18,5 – 24,9  jako prawidłowy, a zakres poniżej jako niedowagę, a zakres powyżej jako nadwagę
wyświetl informacje dla użytkownika*/

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
            Console.Write($"Dear {name}, give me your weight: ");
            int userWeight = int.Parse(Console.ReadLine());
            Console.Write($"Dear {name}, tell me your height(in meters): ");
            double userHeight = double.Parse(Console.ReadLine());
            double bmi = CalculatorBMI(userWeight, userHeight);
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
    public static double CalculatorBMI(int userWeight, double userHeight)
    {
        double bmi = userWeight / (Math.Pow(2.0, (double)userHeight));
        return bmi;
    }

    public static string Result(double bmi)
    {
        if (bmi < 18.5) return "underweight";
        else if (24.9 < bmi) return "overweight";
        else return "weight normal";

    }

}


