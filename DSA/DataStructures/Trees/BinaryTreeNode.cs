using System;

namespace DSA.DataStructures.Trees
{
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public BinaryTreeNode<TKey, TValue> Left { get; set; }

        public BinaryTreeNode<TKey, TValue> Right { get; set; }

        public BinaryTreeNode(){}

        public BinaryTreeNode(TKey key, TValue value = default(TValue))
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            var nodeString = "[ " + Key + " ";

            if (Left == null && Right == null)
            {
                nodeString += " + ";
            }

            if (Left != null)
            {
                nodeString += "Left: " + Left.ToString();
            }

            if (Right != null)
            {
                nodeString += "Right: " + Right.ToString();
            }

            nodeString += "] ";

            return nodeString;
        }
    }
}
