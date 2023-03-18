// See https://aka.ms/new-console-template for more information
Console.Write("Witaj w prostej grze w kości, podaj swoje imie: ");
string name = Console.ReadLine();

while (true)
{
    Random dice = new Random();
    int wynikGracza = 0;
    int wynikKomputera = 0;

    Console.WriteLine();
    Console.WriteLine($"Aby rzucić kością {name}, musisz wciśnąć \"Enter\".");  
    Console.ReadKey();
    wynikGracza = dice.Next(1, 6);
    Console.WriteLine();
    Console.WriteLine("---------------------");
    Console.WriteLine();
    Console.WriteLine($"{name}, Twój wynik to: {wynikGracza}");
    Console.WriteLine();
    Console.WriteLine("---------------------");
    Console.WriteLine();
    Console.WriteLine("Teraz kolej komputera");
    wynikKomputera = dice.Next(1, 6);
    for (int i = 0; i < 3; i++)
    {
        System.Threading.Thread.Sleep(1000);
        Console.Write('.');
    }
    System.Threading.Thread.Sleep(1000);
    Console.Write("\b");
    Console.Write("\b");
    Console.Write("\b");
    //Console.WriteLine();
    Console.WriteLine($"Wynik komputrea to: {wynikKomputera}");
    Console.WriteLine();
    Console.WriteLine("---------------------");
    Console.WriteLine();
    if (wynikKomputera > wynikGracza) Console.WriteLine($"Niestety {name}, przegrałeś z komuterem :(:(:(");
    else if (wynikKomputera < wynikGracza) Console.WriteLine($"Hurra {name}, pokanałeś tą kupę złomu!!!");
    else Console.WriteLine($"Remis {name}");
    Console.WriteLine();
    Console.WriteLine("---------------------");
    Console.WriteLine();
    Console.WriteLine("Chcesz spróbować jeszcze raz?[T/N]");
    char ifContinue = char.Parse(Console.ReadLine());
    if (ifContinue == 'N') break;
    Console.WriteLine();
    Console.WriteLine("To zaczynamy jeszcze raz.");
    Console.WriteLine();
    Console.WriteLine("---------------------");
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine("Żegnaj!!!");
Console.ReadKey();
