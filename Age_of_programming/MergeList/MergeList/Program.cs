using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeList
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var list1 = new List<int>();
            var list2 = new List<int>();
            for (int i=0; i<10; i++)
            {
                list1.Add(random.Next(100));
                list2.Add(random.Next(100));
            }
            list1.Sort();
            list2.Sort();
            WriteList(list1);
            WriteList(list2);
            WriteList(Merge(list1,list2));
            WriteList(list1);
            WriteList(list2);
            Console.WriteLine("-----------------------");
            WriteList(MergeWithDeleteItems(list1, list2));
            WriteList(list1);
            WriteList(list2);

            Console.ReadKey();
        }

        static List<int> MergeWithDeleteItems(List<int> list1, List<int> list2)
        {
            var result = new List<int>();
            while (0 < list1.Count && 0 < list2.Count)
            {
                if (list1[0] <= list2[0])
                {
                    result.Add(list1[0]);
                    list1.RemoveAt(0);
                }
                else
                {
                    result.Add(list2[0]);
                    list2.RemoveAt(0);
                }
            }
            if (list1.Count > 0)
            {
                result.AddRange(list1);
                list1.Clear();
            }

            if (list2.Count > 0)
            {
                result.AddRange(list2);
                list2.Clear();
            }
            return result;
        }
        static List<int> Merge(List<int> list1, List<int> list2)
        {
            var result = new List<int>();

            int i1 = 0;
            int i2 = 0;
            while (i1 < list1.Count && i2 < list2.Count)
            {
                if(list1[i1]<=list2[i2])
                {
                    result.Add(list1[i1]);
                    i1++;
                }
                else
                {
                    result.Add(list2[i2]);
                    i2++;
                }
            }
            while (i1 < list1.Count)
            {
                result.Add(list1[i1]);
                i1++;
            }
            while (i2 < list2.Count)
            {
                result.Add(list2[i2]);
                i2++;
            }
            return result;
        }

        static void WriteList(List<int> list)
        {
            if (list == null) Console.WriteLine("[] - empty list.");
            else
            {
                Console.Write('[');
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i]);
                    if (i < list.Count - 1) Console.Write(", ");
                    else Console.WriteLine("]");
                }
            }          
        }
    }
}
