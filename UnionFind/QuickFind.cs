using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UnionFind
{
    public class QuickFind<T>
    {

        private int[] sets;
        private Dictionary<T, int> map;
        public List<T> values;

        public QuickFind(List<T> values)
        {
            this.values = values;
            sets = new int[values.Count];
            values = new List<T>();
        }

        public int Find(T value)
        {
            return sets[map[value]];
        }
        public bool Union(T value, T unionValue)
        {
            int newSet = sets[map[value]];
            int oldSet = sets[map[unionValue]];
            if(oldSet == newSet)
            {
                return false;
            }
            foreach(T Value in values)
            {
                if(sets[map[Value]] == oldSet)
                {
                    sets[map[Value]] = newSet;
                }
            }
            return true;
        }
        public bool AreConnected(T value, T otherValue)
        {
            return sets[map[value]] == sets[map[otherValue]];
        }

    }
}
