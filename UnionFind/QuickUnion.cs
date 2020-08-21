using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class QuickUnion<T> : IUnionFind<T>
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
            return parents[sets[value]];
        }

        public bool Union(T value, T oldValue)
        {
            int newSet = sets[value];
            int oldSet = sets[oldValue];
            if(newSet == oldSet)
            {
                return false;
            }
            List<KeyValuePair<T, int>> setsForDelete = new List<KeyValuePair<T, int>>();
            foreach(KeyValuePair<T, int> set in sets)
            {
                if(set.Value == oldSet)
                {
                    setsForDelete.Add(set);
                }
            }
            for(int i = 0; i < setsForDelete.Count; i ++)
            {
                sets.Remove(setsForDelete[i].Key);
                sets.Add(setsForDelete[i].Key, newSet);
            }
            return true;
        }

        public bool AreConnected(T value, T otherValue)
        {
            return sets[value] == sets[otherValue];
        }
    }
}
