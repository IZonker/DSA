using DSA.DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Puzzles
{
    public static partial class Puzzles
    {
        public static void RemoveDuplicates<T>(this SinglyLinkedList<T> list) where T : IComparable<T>
        {
            SinglyLinkedListNode<T> current = list.Head;
            SinglyLinkedListNode<T> previous = null;
            var l = new List<T>();

            while (current != null)
            {
                if (l.Contains(current.Value))
                {
                    previous.NextNode = current.NextNode;
                }
                else
                {
                    l.Add(current.Value);
                    previous = current;
                }
                current = current.NextNode;
            }
        }

        /// <summary>
        /// Input: (3 -> 1 -> 5), (5 -> 9 -> 2)
        /// Output: 8 -> 0 -> 8
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="carry"></param>
        /// <returns></returns>
        public static SinglyLinkedListNode<int> AddLists<T>(SinglyLinkedListNode<int> node1, SinglyLinkedListNode<int> node2, int carry)
        {
            if(node1 == null && node2 == null)
                return null;

            var result = new SinglyLinkedListNode<int>(carry);
            var value = carry;

            if(node1 != null)
                value+= node1.Value;

            if(node2 != null)
                value += node2.Value;

            result.Value = value%10;

            var more = AddLists<T>(node1 == null ? null : node1.NextNode, 
                                   node2 == null ? null : node2.NextNode,
                                   value >= 10 ? 1 : 0);
            result.NextNode = more;

            return result;
        }
    }
}
