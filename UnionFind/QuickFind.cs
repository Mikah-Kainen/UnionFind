using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UnionFind
{
    public class QuickFind<T> : IUnionFind<T>
    {

        private int[] sets;
        private Dictionary<T, int> map;
        public List<T> values;

        public QuickFind(List<T> values)
        {
            this.values = values;
            map = new Dictionary<T, int>();
            sets = new int[values.Count];
            for(int i = 0; i < values.Count; i ++)
            {
                map.Add(values[i], i);
                sets[i] = i;
            }
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

            //if (AreConnected(value, unionValue))
            //{
            //    return false;
            //}

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
