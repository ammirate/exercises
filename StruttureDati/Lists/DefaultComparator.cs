
using System;
using System.Collections.Generic;

public class DefaultComparator<T> : IComparer<T> {

    public int Compare(T x, T y) {
        return ((IComparable<T>)x).CompareTo(y);
    }
}

