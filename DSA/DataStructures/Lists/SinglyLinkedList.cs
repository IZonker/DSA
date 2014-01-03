using System;
using System.Collections;

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

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// O(n)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
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


        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

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

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        public void print()
        {

            var node = Head;
            while (node != null)
            {
                Console.Write(node.Value);
                node = node.NextNode;
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
            SinglyLinkedListNode<T> current = Head;
            SinglyLinkedListNode<T> result = null;

            while(current!=null)
            {
                var next = current.NextNode;
                
                current.NextNode = result;
                result = current;
                
                current = next;
            }

            Head = result;
        }
    }
}
