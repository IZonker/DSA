using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.DataStructures
{
    public abstract class CollectionBase : IEnumerable
    {
        public int Count { get; protected set; }

        abstract public IEnumerator GetEnumerator();
    }
}
