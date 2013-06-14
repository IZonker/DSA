using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Hashtables
{
    public class SeparateChainingHashST<TKey, TValue>
    {
        private static int INIT_CAPACITY = 4;

        // largest prime <= 2^i for i = 3 to 31
        // not currently used for doubling and shrinking
        // private static final int[] PRIMES = {
        //    7, 13, 31, 61, 127, 251, 509, 1021, 2039, 4093, 8191, 16381,
        //    32749, 65521, 131071, 262139, 524287, 1048573, 2097143, 4194301,
        //    8388593, 16777213, 33554393, 67108859, 134217689, 268435399,
        //    536870909, 1073741789, 2147483647
        // };

        private int N;                                // number of key-value pairs
        private int M;                                // hash table size
        private SequentialSearchST<TKey, TValue>[] st;  // array of linked-list symbol tables


        // create separate chaining hash table
        public SeparateChainingHashST()
            :this(INIT_CAPACITY)
        {
            
        }

        // create separate chaining hash table with M lists
        public SeparateChainingHashST(int M)
        {
            this.M = M;
            st = (SequentialSearchST<TKey, TValue>[])new SequentialSearchST<TKey, TValue>[M];
            for (int i = 0; i < M; i++)
                st[i] = new SequentialSearchST<TKey, TValue>();
        }

        // resize the hash table to have the given number of chains b rehashing all of the keys
        private void resize(int chains)
        {
            SeparateChainingHashST<TKey, TValue> temp = new SeparateChainingHashST<TKey, TValue>(chains);
            for (int i = 0; i < M; i++)
            {
                foreach (TKey key in st[i].keys())
                {
                    temp.put(key, st[i].get(key));
                }
            }
            this.M = temp.M;
            this.N = temp.N;
            this.st = temp.st;
        }

        // hash value between 0 and M-1
        private int hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        // return number of key-value pairs in symbol table
        public int size()
        {
            return N;
        }

        // is the symbol table empty?
        public bool isEmpty()
        {
            return size() == 0;
        }

        // is the key in the symbol table?
        public bool contains(TKey key)
        {
            return get(key) != null;
        }

        // return value associated with key, null if no such key
        public TValue get(TKey key)
        {
            int i = hash(key);
            return st[i].get(key);
        }

        public TValue get(TKey key, int hash)
        {
            return st[hash].get(key);
        }

        // insert key-value pair into the table
        public void put(TKey key, TValue val)
        {
            if (val == null) { delete(key); return; }

            // double table size if average length of list >= 10
            if (N >= 10 * M) resize(2 * M);

            int i = hash(key);
            if (!st[i].contains(key)) N++;
            st[i].put(key, val);
        }

        // insert key-value pair into the table
        public void put(TKey key, TValue val, int hash)
        {
            if (val == null) { delete(key); return; }

            // double table size if average length of list >= 10
            if (N >= 10 * M) resize(2 * M);


            if (!st[hash].contains(key)) N++;
            st[hash].put(key, val);
        }

        // delete key (and associated value) if key is in the table
        public void delete(TKey key)
        {
            int i = hash(key);
            if (st[i].contains(key)) N--;
            st[i].delete(key);

            // halve table size if average length of list <= 1
            if (M > INIT_CAPACITY && N <= 2 * M) resize(M / 2);
        }

        // return keys in symbol table as an Iterable
        public IEnumerable<TKey> keys()
        {
            Queue<TKey> queue = new Queue<TKey>();
            for (int i = 0; i < M; i++)
            {
                foreach (TKey key in st[i].keys())
                    queue.Enqueue(key);
            }
            return queue;
        }

    }
}
