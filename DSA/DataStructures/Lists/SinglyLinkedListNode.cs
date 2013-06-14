using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Lists
{
    public class SinglyLinkedListNode<T>
    {
        public T Value { get; set; }

        public SinglyLinkedListNode<T> NextNode { get; set; }

        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
