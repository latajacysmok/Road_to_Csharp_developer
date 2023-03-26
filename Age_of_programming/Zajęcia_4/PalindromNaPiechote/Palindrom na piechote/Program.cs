//string czyPalindrom = "1001";
while(true)
{
    Console.Write("Podaj słowo do sprawdzenia czy jest ono palindromem: ");
    string textFromUser = Console.ReadLine();
    //int wordLength = czyPalindrom.Length;
    bool palindrom = true;
    /*if (wordLength % 2 == 0)
    {
        wordLength = wordLength / 2;
    }
    else
    {
        wordLength = wordLength / 2 + 1;
    } to zamieniłęm na i <= wordLength / 2 w for poniżej(to jest to samo!!!)*/
    for (int i = 0; i <= textFromUser.Length / 2; i++)
    {
        if (textFromUser[i] != textFromUser[textFromUser.Length - i - 1])
        {
            Console.WriteLine($"Podany wyraz: \"{textFromUser}\" nie jest palindromem!!!");
            palindrom = false;
            break;
        }
    }
    
    if (palindrom)
    {
        Console.WriteLine($"Wyraz \"{textFromUser}\" jest palindromem!!!");
    } 
    
    Console.WriteLine("Czy chcesz sprawdzić kolejne słowo?[T/N]");
    char continuePlaying = char.Parse(Console.ReadLine());
    if (continuePlaying == 'N')
    {
        Console.WriteLine("Do zobaczenia niebawem.");
        break;
    }
    
}

Console.ReadKey();