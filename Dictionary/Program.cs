using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> my = new MyDictionary<int, string>(10);
            for (int i = 0; i < 22; i++)
            {
                my.Add(i, "My" + (i + 1));
            }
            my.DictionaryInfo();

            Console.WriteLine();
            Console.WriteLine(my.ContainsKey(11));
            Console.WriteLine(my.ContainsKey(110));

            my.Remove(1);
            Console.WriteLine();
            my.DictionaryInfo();

            Console.WriteLine();
            Console.WriteLine(my.ContainsValue("My11"));
            Console.WriteLine(my.ContainsValue("My110"));

            Console.WriteLine();
            my.Clear();
            my.DictionaryInfo();

            Console.WriteLine();
            Console.WriteLine(my.ContainsKey(11));

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                my.Add(i, "My" + (i + 1));
            }
            my.Remove(1);

            Console.WriteLine();
            my.DictionaryInfo();

            Console.ReadKey();
        }
    }
}
