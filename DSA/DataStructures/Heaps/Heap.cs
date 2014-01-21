using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.Heaps
{
    public enum HeapStrategy
    {
        Min,
        Max
    }

    public class Heap<T> : CollectionBase<T> where T : IComparable<T>
    {
        private const int MinSize = 4;

        private T[] _heap;

        public Heap(HeapStrategy heapStrategy, int size)
        {
            HeapStrategy = heapStrategy;
            _heap = new T[size];
        }

        public Heap(): this(HeapStrategy.Min, MinSize){}

        public HeapStrategy HeapStrategy { get; private set; }

        public override void Add(T item)
        {
            if (Count == _heap.Length)
            {
                Array.Resize(ref _heap, 2 * _heap.Length);
            }

            _heap[Count++] = item;

            if (HeapStrategy == HeapStrategy.Min)
            {
                MinHeapify();
            }
            else
            {
                MaxHeapify();
            }
        }

        public override void Clear()
        {
            Count = 0;
            _heap = new T[MinSize];
        }

        public override bool Contains(T item)
        {
            return false;
        }

        public override bool Remove(T item)
        {
            return false;
        }

        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        private void MaxHeapify()
        {
            throw new NotImplementedException();
        }

        private void MinHeapify()
        {
            throw new NotImplementedException();
        }


        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _heap[i];
            }
        }
    }
}
