using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels
{
    class Program
    {
        static void Main(string[] args)
        {
            //+------------+-------------+----------+
            //| Imie       | Nazwisko    | Wiek     |
            //+------------+-------------+----------+
            //| Jan        | Kowalski    | 12 lat   |
            //| Adam       | Nowak       | 32 lat   |
            //+------------+-------------+----------+
            //Console.WriteLine("| {d2:0} |", imie);

            UserInterface userInterface = new UserInterface();
            userInterface.Menu();


        }
    }
}
