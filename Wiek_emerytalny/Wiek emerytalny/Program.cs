//sprawdzenie czy osoba ma wiek emerytarty
//int wiek
//plec
//czy prawa w slurzbach


using System.Text.RegularExpressions;
using System.Threading.Channels;

Regex rx = new Regex(@"(^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\W+]).+$)");
Console.Write("Witaj użytkowniku, aby się zalogować na portal podaj swój Login: ");
string login = Console.ReadLine();
Console.Write("Witaj {0}, teraz podaj hasło: ", login);
string haslo = Console.ReadLine();
if (haslo.Length >= 8)
{
    if (rx.IsMatch(haslo))
    {
        Console.WriteLine("Gratuluje {0}, udało Ci się zalogować", login);
        Console.WriteLine();
        
        Console.Write("Teraz {0}, podaj swóją płeć[M/K]: ", login);
        char gender = char.Parse(Console.ReadLine());
        
        Console.Write("Teraz {0}, podaj swój wiek: ", login);
        int wiek = int.Parse(Console.ReadLine()); 
        
        Console.Write("Czy pracowałeś w szczególnych warunkach lub w szczególnym charakterze co jest zdefiniowane w art. 32 ust. 1 ustawy" +
                    " o emeryturach i rentach z Funduszu Ubezpieczeń Społecznych z dnia 17 grudnia 1998 r[Tak/Nie]: ");
        string zawod = Console.ReadLine();
        
        bool czyWsluzbach = zawod == "Tak" ? true : false;
        bool czyMan = gender == 'M' ? true : false;

        if ((czyMan && czyWsluzbach) || (!czyMan && !czyWsluzbach))
        {
            string result = (60 <= wiek) ? "Jesteś emerytem!!!" : "Brakuję Ci {0} jeszcze {1} lat do emerytury";
            Console.WriteLine(result, login, 60 - wiek);
        }
        else if (czyMan && !czyWsluzbach)
        {
            string result = (65 <= wiek) ? "Jesteś emerytem!!!" : "Brakuję Ci {0} jeszcze {1} lat do emerytury";
            Console.WriteLine(result, login, 65 - wiek);
        }
        else if (!czyMan && czyWsluzbach)
        {
            string result = (55 <= wiek) ? "Jesteś emerytką!!!" : "Brakuję Ci {0} jeszcze {1} lat do emerytury";
            Console.WriteLine(result, login, 55 - wiek);
        }
        else
        {
            Console.WriteLine("Coś kolego źle wpisaleś!");
        }

    }
    else
    {
        Console.WriteLine("Przykro mi {0}, Twoje hasło powinno zawierać duże, małe litery, cyfry oraz znaki specjalne", login);
    }
}
else
{
    Console.WriteLine("Przykro mi {0}, Twoje hasło jest za krótkie", login);
}

Console.ReadKey();
