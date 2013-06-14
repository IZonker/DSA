using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Hashtables
{
    public class LinearProbingHashST<TKey, TValue> 
    {
        private static int INIT_CAPACITY = 10;

        private int N;           // number of key-value pairs in the symbol table
        private int M;           // size of linear probing table
        public TKey[] keys;      // the keys
        private TValue[] vals;    // the values


        // create an empty hash table - use 16 as default size
        public LinearProbingHashST()
            : this(INIT_CAPACITY)
        {

        }

        // create linear proving hash table of given capacity
        public LinearProbingHashST(int capacity)
        {
            M = capacity;

            keys = new TKey[M];
            vals = new TValue[M];

            for (int i = 0; i < M; i++)
            {
                keys[i] = default(TKey);
                vals[i] = default(TValue);
            }
        }

        // return the number of key-value pairs in the symbol table
        public int size()
        {
            return N;
        }

        // is the symbol table empty?
        public bool isEmpty()
        {
            return size() == 0;
        }

        // does a key-value pair with the given key exist in the symbol table?
        public bool contains(TKey key)
        {
            return get(key) != null;
        }

        // hash function for keys - returns value between 0 and M-1
        private int hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        // resize the hash table to the given capacity by re-hashing all of the keys
        private void resize(int capacity)
        {
            LinearProbingHashST<TKey, TValue> temp = new LinearProbingHashST<TKey, TValue>(capacity);
            for (int i = 0; i < M; i++)
            {
                if (keys[i] != null)
                {
                    temp.put(keys[i], vals[i]);
                }
            }
            keys = temp.keys;
            vals = temp.vals;
            M = temp.M;
        }

        // insert the key-value pair into the symbol table
        public void put(TKey key, TValue val)
        {
            if (val == null) delete(key);

            // double table size if 50% full
            if (N >= M / 2) resize(2 * M);

            int i;
            for (i = hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key)) { vals[i] = val; return; }
            }
            keys[i] = key;
            vals[i] = val;
            N++;
        }

        // insert the key-value pair into the symbol table
        public void put(TKey key, TValue val, int hash)
        {
            if (val == null) delete(key);

            // double table size if 50% full
            //if (N >= M / 2) resize(2 * M);

            int i;
            for (i = hash; keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key)) { vals[i] = val; return; }
            }
            keys[i] = key;
            vals[i] = val;
            N++;
        }

        // return the value associated with the given key, null if no such value
        public TValue get(TKey key)
        {
            for (int i = hash(key); keys[i] != null; i = (i + 1) % M)
                if (keys[i].Equals(key))
                    return vals[i];
            return default(TValue);
        }

        // delete the key (and associated value) from the symbol table
        public void delete(TKey key)
        {
            if (!contains(key)) return;

            // find position i of key
            int i = hash(key);
            while (!key.Equals(keys[i]))
            {
                i = (i + 1) % M;
            }

            // delete key and associated value
            keys[i] = default(TKey);
            vals[i] = default(TValue);

            // rehash all keys in same cluster
            i = (i + 1) % M;
            while (keys[i] != null)
            {
                // delete keys[i] an vals[i] and reinsert
                TKey keyToRehash = keys[i];
                TValue valToRehash = vals[i];
                keys[i] = default(TKey);
                vals[i] = default(TValue);
                N--;
                put(keyToRehash, valToRehash);
                i = (i + 1) % M;
            }

            N--;

            // halves size of array if it's 12.5% full or less
            if (N > 0 && N <= M / 8) resize(M / 2);

        }

        // return all of the keys as in Iterable
        public IEnumerable<TKey> Keys()
        {
            Queue<TKey> queue = new Queue<TKey>();
            for (int i = 0; i < M; i++)
                if (keys[i] != null) queue.Enqueue(keys[i]);
            return queue;
        }
    }
}
