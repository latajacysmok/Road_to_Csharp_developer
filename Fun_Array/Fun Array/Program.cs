Console.Write("Uzytkowniku podaj wielkość tablicy: ");
int wielkoscTablicy = int.Parse(Console.ReadLine());
bool playAgain = true;
int[] superTablica = new int[wielkoscTablicy];
Random random = new Random();
int min = 1;
int max = 100;
int greatestElements;
int smallestElements;
String response;

while (playAgain)
{
    for (int i = 0; i < superTablica.Length; i++)
    {
        superTablica[i] = random.Next(min, max + 1);
    }

    greatestElements = superTablica[0];
    smallestElements = superTablica[0];
    Console.WriteLine(string.Join("\n", superTablica));
    Console.WriteLine("\nNajwiększy element tablicy to: {0}", superTablica.Max());
    Console.WriteLine("Najmniejszy element tablicy to: {0}", superTablica.Min());
    Console.WriteLine("\n**************************************************\n\n");

    foreach (int greatestItem in superTablica)
    {
        if (greatestItem > greatestElements)
        {
            greatestElements = greatestItem;
        }
        if (smallestElements > greatestItem)
        {
            smallestElements = greatestItem;
        }
    }
    Console.WriteLine("Uwaga max policzony récznie: {0}", greatestElements);
    Console.WriteLine("Uwaga min policzony récznie: {0}", smallestElements);
    Console.WriteLine("Ilość elementów to: {0}", superTablica.Length);
    Console.WriteLine("Średnia ze wszystkoch elementów to: {0}", superTablica.Average());

    Console.WriteLine("Would you like to play again (Y/N): ");
    response = Console.ReadLine();
    response = response.ToUpper();

    if (response == "Y")
    {
        playAgain = true;
    }
    else
    {
        playAgain = false;
    }
}
