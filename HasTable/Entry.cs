using System;
namespace HashTable
{
    //Хранилище для значения и ключа.
    public class Entry<Tkey,Tvalue> where Tkey: IEquatable<Tkey>
    {
        public Tkey Key { get; }
        public Tvalue Data { get; }
        public int HashCode { get; }
        public Entry(Tkey key, Tvalue data, int hascode)
        {
            Key = key;
            Data = data;
            HashCode = hascode;
        }
    }
}
