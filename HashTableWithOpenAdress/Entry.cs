using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    //Хранилище для значения и ключа.
    class Entry<Tkey,Tvalue> where Tkey : IEquatable<Tkey>
    {
        public Tvalue Data { get; private set; }
        public ProxyKey<Tkey> Key { get; set; }
        public int HashCode { get; set; }
        public Entry(Tkey key,Tvalue data)
        {
            Data = data;
            Key = new ProxyKey<Tkey>(key);
        }

    }
}
