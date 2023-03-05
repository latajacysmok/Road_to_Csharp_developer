
Console.Write("Cześć Użytkowniku jak masz na imie: ");
string imie = Console.ReadLine();
Console.WriteLine("");
while (true) 
{
    Console.Write("Cześć {0}, podaj mi proszę pierwszą liczbę do moich obliczeń: ", imie);
    int pierwsza_liczba = int.Parse(Console.ReadLine());
    Console.Write("Dziękuję {0}, teraz podaj drugą: ", imie);
    int druga_liczba = int.Parse(Console.ReadLine());
    Console.Write("Dziękuję {0}, teraz podaj mi działanie jakie mam wykonać, z racji że jestem prostym kalkulatorem masz do wyboru: " +
        "+, -, *, /, %, potege, pierwiastek i wartosc bezwzgledna: ", imie);
    string znak = Console.ReadLine();
    Console.WriteLine("Oto moje skomplikowane obliczenia: ");
    // Można dodać w switchu wyjście z pętli, czyli np. case EXIT, zmienna znak można zrobić poza pętlą
    switch (znak)
    {
        case "+":
            Console.WriteLine("{0} + {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba + druga_liczba);
            break;
        case "-":
            Console.WriteLine("{0} - {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba - druga_liczba);
            break;
        case "*":
            Console.WriteLine("{0} * {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba * druga_liczba);
            break;
        case "/":
            Console.WriteLine("{0} / {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba / druga_liczba);
            break;
        case "%":
            Console.WriteLine("{0} % {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba % druga_liczba);
            break;
        case "potege":
            Console.WriteLine("{0}^{1} = {2}", pierwsza_liczba, druga_liczba, Math.Pow(pierwsza_liczba, druga_liczba));
            break;
        case "pierwiastek":
            Console.WriteLine("sqrt({0}) = {1}", pierwsza_liczba, Math.Sqrt(pierwsza_liczba));
            Console.WriteLine("sqrt({0}) = {1}", druga_liczba, Math.Sqrt(druga_liczba));
            break;
        case "wartosc bezwzgledna":
            Console.WriteLine("|{0}| = {1}", pierwsza_liczba, Math.Abs(pierwsza_liczba));
            Console.WriteLine("|{0}| = {1}", druga_liczba, Math.Abs(druga_liczba));
            break;
        default:
            Console.WriteLine("{0}... nie no coś namieszałeś", znak);
            break;
    }

    Console.Write("Chcesz wyjść z programu[Tak/Nie]: ");
    string czyWyjsc = Console.ReadLine();
    if (czyWyjsc.ToUpper() == "TAK")
    {
        Console.WriteLine("*******************");
        Console.WriteLine("");
        Console.WriteLine("Do zobaczenia {0}!", imie);
        break;
    }
    else
    {
        Console.WriteLine("*************************");
        Console.WriteLine("");
        Console.WriteLine("To zaczynijmy jeszcze raz:");
        Console.WriteLine("*************************");
        Console.WriteLine("");
    }
}

Console.Beep(8000, 100);
Console.ReadKey();
