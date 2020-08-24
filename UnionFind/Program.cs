using System;
using System.Collections.Generic;
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
            for(int i = 1; i < 22; i ++)
            {
                friendsList.Add(friends[i]);
            }
            //foreach(string friend in friends)
            //{
            //    friendsList.Add(friend);
            //}
            QuickFind<string> Find = new QuickFind<string>(friendsList);

            string[] union;
            for(int i = 22; i < friends.Length; i ++)
            {
                union = friends[i].Split(',');
                Find.Union(union[0], union[1]);
            }

            var thing = Find.printBiggestGroup();
            var other = Find.printSmallestGroup();

            Find.AreConnected("Phoebe", "Racheal");
            Find.AreConnected("Jim", "Creed");
            Find.AreConnected("Michael", "Pam");
            Find.AreConnected("Chandler", "Creed");
        }
    }
}
