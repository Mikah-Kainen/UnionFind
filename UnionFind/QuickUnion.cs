using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class QuickUnion<T>
    {
        private int[] parents;
        private Dictionary<T, int> sets;
        public List<T> values;

        public QuickUnion(List<T> values)
        {
            this.values = values;
            parents = new int[values.Count];
            sets = new Dictionary<T, int>();
        }

        public int Find(T value)
        {

        }

        public bool Union(T value, T unionValue)
        {

        }

        public bool AreConnected(T value, T otherValue)
        {

        }
    }
}
