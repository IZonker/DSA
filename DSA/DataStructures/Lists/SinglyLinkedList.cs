using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures.Lists
{
    public class SinglyLinkedList<T> : CollectionBase
    {
        public SinglyLinkedListNode<T> Head { get; private set; }

        public SinglyLinkedListNode<T> Tail { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return Head == null;
            }
        }        

        public void AddFirst(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);
            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.NextNode = Head;
                Head = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);
            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.NextNode = node;
                Tail = node;
            }

            Count++;
        }

        public bool RemoveFirst()
        {
            if(IsEmpty) 
                return false;

            if (Count == 1)
            {
                Clear();
            }
            else
            {
                Head = Head.NextNode;
                Count--;
            }           

            return true;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (node == Head && node == Tail)
            {
                Head.NextNode = newNode;
                Tail = newNode;
            }
            else if (node == Tail)
            {
                Tail.NextNode = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
            }

            Count++;
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T Value)
        {
            var newNode = new SinglyLinkedListNode<T>(Value);

            if (node == Head )
            {
                newNode.NextNode = Head;
                Head = newNode;
            }
            else
            {
                var previousNode = Head;
                while (previousNode.NextNode != node)
                {
                    previousNode = previousNode.NextNode;
                }
                newNode.NextNode = previousNode.NextNode;
                previousNode.NextNode = newNode;               
            }

            Count++;
        }

        public bool RemoveLast()
        {
            if (IsEmpty)
                return false;

            if (Count == 1)
            {
                Clear();
            }
            else
            {
                 var node = Head;
                 while (node != null)
                 {
                     if (node.NextNode == Tail)
                     {
                         Tail = node;
                         Tail.NextNode = null;
                         break;
                     }
                     node = node.NextNode;
                 }
                 Count--;
            }
            
            return true;
        }

        public bool Remove(T value)
        {
            if (IsEmpty)
                return false;

            
            var node = Head;
            if(object.Equals(node.Value, value))
            {
                if (node == Tail)
                {
                    Clear();
                }
                else
                {
                    Head = node.NextNode;
                    Count--;
                }
                return true;
            }

            while (node.NextNode != null && !object.Equals(node.NextNode.Value, value))
            {
                node = node.NextNode;
            }

            if(object.Equals(node.NextNode.Value, value))
            {
                if (node.NextNode == Tail)
                {
                    node.NextNode = null;
                    Tail = node;
                }
                else
                {
                    node.NextNode = node.NextNode.NextNode;
                }

                Count--;
                return true;
            }
            
            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            int index=0;
            T[] array = new T[Count];
            foreach (T value in this)
            {
                array[index++] = value;
            }
            return array;
        }

        public override IEnumerator GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            } 
        }
    }
}
