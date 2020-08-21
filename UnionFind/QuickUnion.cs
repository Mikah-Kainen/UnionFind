using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class QuickUnion<T> : IUnionFind<T>
    {
        private int[] parents;
        private Dictionary<T, int> map;
        public List<T> values;

        public QuickUnion(List<T> values)
        {
            this.values = values;
            parents = new int[values.Count];
            map = new Dictionary<T, int>();
            for(int i = 0; i < values.Count; i ++)
            {
                parents[i] = i;
                map.Add(values[i], i);
            }
        }

        public int Find(T value)
        {
            int currentValue = map[value];
            while(currentValue != parents[currentValue])
            {
                currentValue = parents[currentValue];
            }
            return currentValue;
        }

        public bool Union(T value, T oldValue)
        {
            if (AreConnected(value, oldValue))
            {
                return false;
            }
            parents[map[oldValue]] = map[value];
            return true;
        }

        public bool AreConnected(T value, T otherValue)
        {
            return Find(value) == Find(otherValue);
        }
    }
}
