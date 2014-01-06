using System;
using System.Collections.Generic;

namespace DSA.DataStructures.Trees
{
    public class BinarySearchTree<TKey, TValue> where TKey: IComparable
    {
        public BinaryTreeNode<TKey, TValue> Root { get; set; }

        /// <summary>
        /// O(log N) for balanced trees
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value = default(TValue))
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<TKey, TValue>(key, value);
            }
            else
            {
                InsertNode(key, value);
            }
        }

        /// <summary>
        /// O(log N)
        /// </summary>
        /// <param name="key"></param>
        public bool Remove(TKey key)
        {
            BinaryTreeNode<TKey, TValue> nodeToRemove = Root;
            BinaryTreeNode<TKey, TValue> parentNode = null;

            if (key.CompareTo(Root.Key) == 0)
            { 
                Root = null;
                return true;
            }

            while (nodeToRemove != null && key.CompareTo(nodeToRemove.Key) != 0)
            {
                parentNode = nodeToRemove;
                if (key.CompareTo(nodeToRemove.Key) > 0)
                    nodeToRemove = nodeToRemove.Right;
                if (key.CompareTo(nodeToRemove.Key) < 0)
                    nodeToRemove = nodeToRemove.Left;
            }

            if (nodeToRemove == null)
                return false;
           
            if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                if (parentNode.Key.CompareTo(nodeToRemove.Key) < 0)
                    parentNode.Left = null;
                else
                    parentNode.Right = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                if (nodeToRemove.Key.CompareTo(parentNode.Key) < 0)
                    parentNode.Left = nodeToRemove.Right;
                else
                    parentNode.Right = nodeToRemove.Left;
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Key.CompareTo(parentNode.Key) < 0)
                    parentNode.Left = nodeToRemove.Left;
                else
                    parentNode.Right = nodeToRemove.Left;
            }
            else
            {
                // nodeToRemove has both a left and right subtree
                var largestValue = nodeToRemove.Left;

                // find the largest value in the left subtree of nodeToRemove
                while (largestValue.Right != null)
                {
                    largestValue = largestValue.Right;
                }

                // find the parent of the largest value in the left subtree of nodeToDelete and sets its right property to null.
                FindParent(largestValue.Key, Root).Right = null;

                // set value of nodeToRemove to the value of largestValue
                nodeToRemove.Value = largestValue.Value;
            }

            return true;
        }

        public BinaryTreeNode<TKey, TValue> Find(TKey key)
        {
            return Find(key, Root);
        }

        public BinaryTreeNode<TKey, TValue> Find(TKey key, BinaryTreeNode<TKey, TValue> root)
        {
            if (root == null)
                return null;

            if (key.CompareTo(root.Key) > 0)
                return Find(key, root.Right);
            if (key.CompareTo(root.Key) < 0)
                return Find(key, root.Left);
            
            return root;
        }

        private BinaryTreeNode<TKey, TValue> FindParent(TKey key, BinaryTreeNode<TKey, TValue> root)
        {
            if (key.CompareTo(root.Key) < 0)
            {
                if (root.Left == null)
                    return null;

                return key.CompareTo(root.Left.Key) == 0 ? root : FindParent(key, root.Left);
            }

            if (root.Right == null)
                return null;

            return key.CompareTo(root.Right.Key) == 0 ? root : FindParent(key, root.Right);
        }

        /// <summary>
        /// O(log N) for balanced trees
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void InsertNode(TKey key, TValue value = default(TValue))
        {
            var current = Root;

            while(true)
            {
                if (key.CompareTo(current.Key) < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current.Left = new BinaryTreeNode<TKey, TValue>(key, value);
                        return;
                    }
                }
                else if (key.CompareTo(current.Key) > 0)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current.Right = new BinaryTreeNode<TKey, TValue>(key, value);
                        return;
                    }
                }
                else
                    return;
                
            }
        }

        public void Print()
        {
            if(Root!=null)
                Console.WriteLine(Root.ToString());
        }

        public int Size()
        {
            return Size(Root);
        }

        public int Size(BinaryTreeNode<TKey, TValue> node)
        {
            if (node == null)
                return 0;

            return 1 + Size(node.Left) + Size(node.Right);
        }

        public List<TKey> PreorderTraversal(BinaryTreeNode<TKey, TValue> node, List<TKey> list)
        {
            if (node != null)
            {
                list.Add(node.Key);
                InorderTraversal(node.Left, list);
                InorderTraversal(node.Right, list);
            }
            return list;
        }

        public List<TKey> InorderTraversal(BinaryTreeNode<TKey, TValue> node, List<TKey> list)
        {
            if (node != null)
            {
                InorderTraversal(node.Left, list);
                list.Add(node.Key);
                InorderTraversal(node.Right, list);
            }
            return list;
        }

        public List<TKey> PostorderInorderTraversal(BinaryTreeNode<TKey, TValue> node, List<TKey> list)
        {
            if (node != null)
            {
                InorderTraversal(node.Left, list);
                InorderTraversal(node.Right, list);
                list.Add(node.Key);
            }
            return list;
        }

        public List<TValue> BreadthFirstTraversal(BinaryTreeNode<TKey, TValue> node)
        {
            var unvisited = new Queue<BinaryTreeNode<TKey, TValue>>();
            var visited = new List<TValue>();

            while (node != null)
            {
                visited.Add(node.Value);
                if (node.Left != null)
                {
                    unvisited.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    unvisited.Enqueue(node.Right);
                }

                node = unvisited.Count > 0 ? unvisited.Dequeue() : null;
            }

            return visited;
        }
    }
}
