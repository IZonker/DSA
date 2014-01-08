using System;

namespace DSA.DataStructures.Trees
{
    public class AVLTree<TKey, TValue> : BinarySearchTree<TKey, TValue> where TKey : IComparable
    {
        public override void Add(TKey key, TValue value = default(TValue))
        {
            if (Root == null)
            {
                Root = new AVLTreeNode<TKey, TValue>(key, value);
            }
            else
            {
                InsertNode(key, value);
            }
        }

        private void InsertNode(TKey key, TValue value)
        {

        }

        public override bool Remove(TKey key)
        {
            return base.Remove(key);
        }

        private int Height(AVLTreeNode<TKey, TValue> node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        public int GetBalanceFactor(AVLTreeNode<TKey, TValue> node)
        {
            return Height(node.Left as AVLTreeNode<TKey, TValue>) - Height(node.Right as AVLTreeNode<TKey, TValue>);
        }

    }
}
