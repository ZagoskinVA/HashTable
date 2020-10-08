using HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HashTable
{
    //Хэш таблица с открытой адрессацией
    class HashTableWithOpenAdress<Tkey,Tvalue> where Tkey : IEquatable<Tkey>
    {

        public Entry<Tkey,Tvalue>[] Entries { get; private set; }
        public List<ProxyKey<Tkey>> Keys { get; private set; }
        private readonly int capacity;
        public HashTableWithOpenAdress(int count)
        {
            Entries = new Entry<Tkey, Tvalue>[count*10];
            Keys = new List<ProxyKey<Tkey>>();
            capacity = count * 10;
        }
        public void Add(Tkey key, Tvalue data)
        {
            var entry = new Entry<Tkey, Tvalue>(key,data);
            var hash = GetHashCode(entry.Key);
            if (Keys.Count == 0)
            {
                Keys.Add(entry.Key);
                Entries[hash] = entry;
                return;

            }
            while (Entries[hash] != null  && !Entries[hash].Equals(hash))
            {
                entry.Key.Count += 1;
                hash = GetHashCode(entry.Key);
            }
            entry.HashCode = hash;
            Keys.Add(entry.Key);
            Entries[hash] = entry;
        }
        private int GetHashCode(ProxyKey<Tkey> key)
        {
            var result = key.GetHashCode() % capacity;

            return result;
        }

        public bool GetData(Tkey key,out Tvalue data,out int count)
        {
            count = 0;
            data = default(Tvalue);
            var proxyKey = new ProxyKey<Tkey>(key);
            var hash = GetHashCode(proxyKey);
            while (true)
            {
                ProxyKey<Tkey> currentKey;

                try
                {
                    currentKey = Entries[hash].Key;

                }

                
                catch
                {
                    return false;
                }
                              
                if (currentKey.Key.Equals(key))
                {

                    count = currentKey.Count+1;
                    data = Entries[hash].Data;
                    return true;
                }
                proxyKey.Count++;
                hash = GetHashCode(proxyKey);
            }



        }
    }
}
