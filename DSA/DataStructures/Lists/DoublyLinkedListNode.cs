using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Lists
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode<T> NextNode { get; set; }

        public DoublyLinkedListNode<T> PreviousNode { get; set; }

        public T Value { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
