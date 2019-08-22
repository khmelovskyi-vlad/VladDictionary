using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladDictionary
{
    class VladDictionary<TElement>
    {
        public VladDictionary()
        {
            dictionary = new List<HashBox>[uint.MaxValue/maxUIntDivider];
        }
        private List<HashBox>[] dictionary;
        const int maxUIntDivider = 65537;
        HashBox hashBox;
        int indexList;

        public void Add(TElement value, TElement key)
        {
            NewHashBoxAndIndexList(value, key);
            if (dictionary[indexList] == null)
            {
                dictionary[indexList] = new List<HashBox>();
                dictionary[indexList].Add(hashBox);
            }
            else
            {
                foreach (var existedHashBox in dictionary[indexList])
                {
                    if(existedHashBox.HashCode == value.GetHashCode() && existedHashBox.Value.Equals(value) && existedHashBox.Key.Equals(key))
                    {
                        return;
                    }
                }
                dictionary[indexList].Add(hashBox);
            }
        }
        public void Remove(TElement value, TElement key)
        {
            NewHashBoxAndIndexList(value, key);
            if (dictionary[indexList] == null)
            {
                return;
            }
            foreach (var existedHashBox in dictionary[indexList])
            {
                if (existedHashBox.HashCode == value.GetHashCode() && existedHashBox.Value.Equals(value) && existedHashBox.Key.Equals(key))
                {
                    dictionary[indexList].Remove(existedHashBox);
                    return;
                }
            }
        }
        public bool Contains(TElement value, TElement key)
        {
            NewHashBoxAndIndexList(value, key);
            if (dictionary[indexList] == null)
            {
                return false;
            }
            foreach (var existedHashBox in dictionary[indexList])
            {
                if (existedHashBox.HashCode == value.GetHashCode() && existedHashBox.Value.Equals(value) && existedHashBox.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        private void NewHashBoxAndIndexList(TElement value, TElement key)
        {
            hashBox = new HashBox(value, value.GetHashCode(), key);
            indexList = value.GetHashCode() / maxUIntDivider;
        }
        private struct HashBox
        {
            public HashBox(TElement value, int hashCode, TElement key)
            {
                this.Value = value;
                this.HashCode = hashCode;
                this.Key = key;
            }
            public TElement Value;
            public int HashCode;
            public TElement Key;
        }
    }
}
