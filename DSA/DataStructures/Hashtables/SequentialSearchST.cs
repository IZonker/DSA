using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Hashtables
{
    public class SequentialSearchST<TKey, TValue>
    {
        private int N;           // number of key-value pairs
        private Node first;      // the linked list of key-value pairs

        // a helper linked list data type
        private class Node
        {
            public TKey key;
            public TValue val;
            public Node next;

            public Node(TKey key, TValue val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }

        // return number of key-value pairs
        public int size() { return N; }

        // is the symbol table empty?
        public bool isEmpty() { return size() == 0; }

        // does this symbol table contain the given key?
        public bool contains(TKey key)
        {
            return get(key) != null;
        }

        // return the value associated with the key, or null if the key is not present
        public TValue get(TKey key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                Console.WriteLine(x.key);
                if (key.Equals(x.key)) return x.val;
                
            }
            return default(TValue);
        }

        // add a key-value pair, replacing old key-value pair if key is already present
        public void put(TKey key, TValue val)
        {
            if (val == null) { delete(key); return; }
            for (Node x = first; x != null; x = x.next)
                if (key.Equals(x.key)) { x.val = val; return; }
            first = new Node(key, val, first);
            N++;
        }

        // remove key-value pair with given key (if it's in the table)
        public void delete(TKey key)
        {
            first = delete(first, key);
        }

        // delete key in linked list beginning at Node x
        // warning: function call stack too large if table is large
        private Node delete(Node x, TKey key)
        {
            if (x == null) return null;
            if (key.Equals(x.key)) { N--; return x.next; }
            x.next = delete(x.next, key);
            return x;
        }


        // return all keys as an Iterable
        public IEnumerable<TKey> keys()
        {
            Queue<TKey> queue = new Queue<TKey>();
            for (Node x = first; x != null; x = x.next)
                queue.Enqueue(x.key);
            return queue;
        }
    
    }
}
