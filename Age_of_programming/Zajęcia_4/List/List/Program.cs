/*np 1 1 2 3 4 5 5 6

i 1 2 4 6 7 7 8 9 9

i mamy zrobic z tego jedna tez posortowana

oczywiscie najprosciej po prostu do nowej listy dodac liste1 i liste2 a potem posortowac

ale trodniejsza wersja jest taka zeby dodawac do nowej listy w taki sposob zeby od razu byla posortowabn bez koniecznosci sorowania*/

using System.Collections.Generic;

List<int> firstList = new List<int>()
                    {
                        1,
                        1,
                        2,
                        3,
                        4,
                        5,
                        5,
                        6
                    };
List<int> secondList = new List<int>()
                    {
                        1,
                        2,
                        4,
                        6,
                        7,
                        7,
                        8,
                        9,
                        9
                    };

List<int> finalList = new List<int>();

for (int i = 0; i < (firstList.Count + secondList.Count); i++)
{
    if (!firstList.Any())
    { 
        finalList.Add(secondList[i]);
        secondList.RemoveAt(i);
    }
    else if (!secondList.Any())
    {
        finalList.Add(firstList[i]);
        firstList.RemoveAt(i);
    }
    else
    {
        finalList.Add(Math.Min(firstList[i], secondList[i]));
        if (firstList.Min() < secondList.Min()) firstList.RemoveAt(i);
        else secondList.RemoveAt(i);
    }
    i--;
}
Console.WriteLine("Nasza nowa lista to: ");
finalList.ForEach(Console.WriteLine);
Console.ReadKey();
