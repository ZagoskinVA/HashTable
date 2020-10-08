using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{

    class ProxyKey<Tkey> where Tkey : IEquatable<Tkey>
    {
        public Tkey Key { get;}
        // Кол-во вычислений хэша
        public int Count { get;  set; } = 0;
        public ProxyKey(Tkey key)
        {
            Key = key;
        }
        public override int GetHashCode()
        {
        	return Math.Abs(Key.GetHashCode() + Count.GetHashCode());
        }




    }
}
