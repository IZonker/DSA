using System;

namespace DSA.DataStructures.Trees
{
    public class AVLTreeNode<TKey, TValue> : BinaryTreeNode<TKey, TValue> where TKey : IComparable
    {
        public AVLTreeNode(TKey key, TValue value)
            :base(key, value)
        {
            Height = 1;
        }

        public int Height { get; set; }
     
    }
}
