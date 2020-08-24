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
        public int friendGroupCount { get; private set; }
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
            friendGroupCount = values.Count;
        }

        public int FriendGroupSize(T value)
        {
            int friendGroup = map[value];
            int count = 0;
            foreach(T Value in values)
            {
                if(sets[map[Value]] == friendGroup)
                {
                    count++;
                }
            }
            return count;
        }
        
        public int FindBiggestGroup()
        {
            int largestValue = 0;
            int largestGroup = -1;

            int temp;
            foreach (T value in values)
            {
                temp = FriendGroupSize(value);
                if (temp > largestValue)
                {
                    largestValue = temp;
                    largestGroup = sets[map[value]];
                }
            }
            return largestGroup;
        }

        public int FindSmallestGroup()
        {
            int smallestValue = 0;
            int smallestGroup = int.MaxValue;

            int temp;
            foreach (T value in values)
            {
                temp = FriendGroupSize(value);
                if (temp < smallestValue)
                {
                    smallestValue = temp;
                    smallestGroup = sets[map[value]];
                }
            }
            return smallestGroup;
        }
        public List<T> FindGroupMembers(int group)
        {
            List<T> groupMembers = new List<T>();
            foreach(T value in values)
            {
                if(map[value] == group)
                {
                    groupMembers.Add(value);
                }
            }
            return groupMembers;
        }

        public List<T> printBiggestGroup()
        {
            List<T> biggestGroup = FindGroupMembers(FindBiggestGroup());
            foreach(T value in biggestGroup)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            return biggestGroup;
        }

        public List<T> printSmallestGroup()
        {
            List<T> smallestGroup = FindGroupMembers(FindSmallestGroup());
            foreach (T value in smallestGroup)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            return smallestGroup;
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
            friendGroupCount--;
            return true;
        }
        public bool AreConnected(T value, T otherValue)
        {
            return sets[map[value]] == sets[map[otherValue]];
        }

    }
}
