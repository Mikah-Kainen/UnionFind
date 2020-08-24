using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            //var names = new List<string>() { "Billy", "Sarah", "Kristen", "Zach" };

            //var uf = new QuickUnion<string>(names);

            //int original = uf.Find("Sarah");
            //bool isTrue = uf.Union("Billy", "Sarah");
            //int later = uf.Find("Sarah");
            //bool isFalse = uf.Union("Sarah", "Billy");
            //uf.Union("Sarah", "Kristen");
            //bool shouldTrue = uf.AreConnected("Billy" , "Kristen");

            /*
            string[] splitvalues = "hello,blah".Split(',');

            Questions:
            what is the longest/smallest friend group?
            is Phoebe friends with Racheal;
            is Jim with Creed
            is Michael with Pam
            is Chandler with Creed
            how many friend groups are there

            list every person in every friend group
            " friend group 1: bla bla bla"
            */


            var friends = File.ReadAllLines("..\\..\\..\\Friends.txt");
            List<string> friendsList = new List<string>();
            for (int i = 1; i < 22; i++)
            {
                friendsList.Add(friends[i]);
            }
            //foreach(string friend in friends)
            //{
            //    friendsList.Add(friend);
            //}
            QuickFind<string> Find = new QuickFind<string>(friendsList);

            string[] union;
            for (int i = 22; i < friends.Length; i++)
            {
                union = friends[i].Split(',');
                Find.Union(union[0], union[1]);
            }

            int smallestGroup = int.MaxValue;
            int largestGroup = int.MinValue;
            foreach (int size in Find.sizes)
            {
                if(size != 0 && size < smallestGroup)
                {
                    smallestGroup = size;
                }
                if(size > largestGroup)
                {
                    largestGroup = size;
                }
            }

            List<string> smallestGroupList = new List<string>();
            List<string> largestGroupList = new List<string>();
            foreach(string friend in Find.values)
            {
                if(Find.sizes[Find.sets[Find.map[friend]]] == smallestGroup)
                {
                    smallestGroupList.Add(friend);
                }
                if(Find.sizes[Find.sets[Find.map[friend]]] == largestGroup)
                {
                    largestGroupList.Add(friend);
                }
            }
            foreach(string friend in largestGroupList)
            {
                Console.WriteLine($"LargestFriendGroup: {friend}");
            }
            Console.WriteLine();

            foreach(string friend in smallestGroupList)
            {
                Console.WriteLine($"SmallestFriendGroup: {friend}");
            }
            Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine();
            Console.WriteLine($"Phoebe,Rachel: {Find.AreConnected("Phoebe", "Rachel")}");
            Console.WriteLine($"Jim,Creed: {Find.AreConnected("Jim", "Creed")}");
            Console.WriteLine($"Michael,Pam: {Find.AreConnected("Michael", "Pam")}");
            Console.WriteLine($"Chandler,Creed: {Find.AreConnected("Chandler", "Creed")}");

            Console.WriteLine($"FriendGroupCount: {Find.friendGroupCount}");
            Console.WriteLine();

            int currentFriendGroup = 0;
            while (currentFriendGroup < Find.values.Count)
            {
                if(Find.sizes[currentFriendGroup] != 0)
                {
                    foreach(string friend in Find.values)
                    {
                        if(Find.sets[Find.map[friend]] == currentFriendGroup)
                        {
                            Console.WriteLine($"FriendGroup{currentFriendGroup}: {friend}");
                        }
                    }
                    Console.WriteLine();
                }
                currentFriendGroup++;
            }
        }
    }
}
