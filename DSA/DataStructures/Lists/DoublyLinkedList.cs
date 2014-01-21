using System;
using System.Collections.Generic;

namespace DSA.DataStructures.Lists
{
    public class DoublyLinkedList<T> : CollectionBase<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }

        public DoublyLinkedListNode<T> Tail { get; private set; }

        public bool IsEmpty
        {
            get 
            { 
                return Head == null; 
            }
        }

        public void AddFirst(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.NextNode = Head;
                Head.PreviousNode = node;
                Head = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.PreviousNode = Tail;
                Tail.NextNode = node;
                Tail = node;
            }

            Count++;
        }

        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (node == Tail)
            {
                Tail.NextNode = newNode;
                newNode.PreviousNode = Tail;
            }
            else
            {
                newNode.NextNode = node.NextNode;
                newNode.PreviousNode = node;
                node.NextNode = newNode;
            }

            Count++;
        }

        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (node == Head)
            {
                Head.PreviousNode = newNode;
                newNode.NextNode = Head;
                Head = newNode;
            }
            else
            {
                node.PreviousNode.NextNode = newNode; 
                node.PreviousNode = newNode;
                newNode.NextNode = node;
            }

            Count++;
        }

        public bool RemoveFirst()
        {
            if (IsEmpty)
                return false;

            if (Head.NextNode == null)
            {
                Clear();
            }
            else if (Head.NextNode == Tail)
            {
                Head = Tail;
                Tail.PreviousNode = null;
                Count--;
            }
            else
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;
                Count--;
            }

            return false;
        }

        public bool RemoveLast()
        {
            if (IsEmpty)
                return false;

            if (Head.NextNode == null)
            {
                Clear();
            }
            else if (Tail.PreviousNode == Head)
            {
                Tail.PreviousNode = null;
                Head = Tail;
                Count--;
            }
            else
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;
                Count--;
            }

            return true;
        }

        public override bool Remove(T value)
        {
            if (IsEmpty)
                return false;

            if (Head.NextNode == null && object.Equals(Head.Value, value))
            {
                Clear();
            }
            else
            {
                var node = Head;
                while (node != null && !object.Equals(node.Value, value))
                {
                    node = node.NextNode; 
                }

                if (node == null)
                    return false;

                if (node == Head)
                {
                    Head = Head.NextNode;
                    Head.PreviousNode = null;
                }
                else if (node == Tail)
                {
                    Tail = Tail.PreviousNode;
                    Tail.NextNode = null;
                }
                else
                {
                    node.PreviousNode.NextNode = node.NextNode;
                    node.NextNode = node.PreviousNode;
                }

                Count--;
            }

            return true;
        }

        public override void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }
        }

        public override void Add(T item)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public override T[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
