using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    interface IUnionFind<T>
    {
        int Find(T value);
    }
}
