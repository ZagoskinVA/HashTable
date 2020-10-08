
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Введите слово  в аргумент командной строки");
                return;
            }
            var str = @"dict.txt";
            var list = new List<string>();

            using (var sr = new StreamReader(new FileStream(str, FileMode.Open)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            var hashTable = new HashTableWithOpenAdress<string, string>(list.Count);
            Stopwatch sp = new Stopwatch();

            foreach (var item in list)
            {
                hashTable.Add(item, item);
            }
            string data;
            int count;
            sp.Start();
            var b = hashTable.GetData(args[0], out data,out count);
            sp.Stop();
            var time = sp.Elapsed;
            if (b)
            {
                Console.WriteLine("Найдено");
                Console.WriteLine($"Значение: {data}");
                Console.WriteLine($"Затрачено времени: {time} ");
                Console.WriteLine($"Колличество вычислений хэша {count}");
            }
            else
            {
                Console.WriteLine("Не найден");
            }
        }
    }
}
