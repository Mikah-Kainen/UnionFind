using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    interface IUnionFind<T>
    {
        int Find(T value);
        bool Union(T value, T otherValue);
        bool AreConnected(T value, T otherValue);
    }
}
