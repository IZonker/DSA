using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.Trees
{
    public interface IBinaryTreeNode<TKey, TValue> where TKey: IComparable
    {
        IBinaryTreeNode<TKey, TValue> Left { get; set; }

        IBinaryTreeNode<TKey, TValue> Right { get; set; }

        TKey Key { get; set; }

        TValue Value { get; set; }
    }
}
