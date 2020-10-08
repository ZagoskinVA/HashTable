using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace HashTable
{
    public class Program
    {
    	static void Main(string[] args)
    	{
    		if (args.Length == 0)
              return;
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
            var hashTable = new HashTable<string, string>(list.Count);
            Stopwatch sp = new Stopwatch();
            foreach (var item in list)
            {
                hashTable.Add(item, item);
            }
            string data;
            sp.Start();
            var b = hashTable.GetData(args[0], out data);
            sp.Stop();
            if(!b)
            	Console.WriteLine("Такого слова нет");	
            else
            {
                Console.WriteLine("Найдено");
                Console.WriteLine($"Значение: {data}");
            	Console.WriteLine($"Времени затрачено: {sp.Elapsed}");
        	}

    	}
    }
}