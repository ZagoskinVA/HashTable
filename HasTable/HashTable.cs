using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    // Хэш таблица с цепочками.
    public class HashTable<Tkey,Tvalue> where Tkey : IEquatable<Tkey>
    {
        public List<Entry<Tkey,Tvalue>> [] Entries { get; private set; }
        private List<Tkey> keys;
        private readonly int capacity;
        public HashTable(int count)
        {
            Entries = new List<Entry<Tkey, Tvalue>>[count];
            capacity = count;
            keys = new List<Tkey>();
        }
        public void Add(Tkey key,Tvalue value) 
        {
            var hashCode = GetHashCode(key);
            if (keys.Count == 0 || Entries[hashCode] == null) 
            {
                keys.Add(key);

                var entry = new Entry<Tkey, Tvalue>(key, value, hashCode);
                Entries[hashCode] = new List<Entry<Tkey, Tvalue>>
                {
                    entry
                };
            }
            else 
            {
                var entry = new Entry<Tkey, Tvalue>(key, value, hashCode);
                Entries[hashCode].Add(entry);
            }
        }
        public bool GetData(Tkey key , out Tvalue data) 
        {
            data = default(Tvalue);
            var hash = GetHashCode(key);
            try
            {
                var list = Entries[hash];
                data = list.Find(x => x.Key.Equals(key)).Data;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private int GetHashCode(Tkey key) 
        {
            var result = (key.GetHashCode() & 0x7fffffff) % capacity;
            return result;
        }
    }
}
