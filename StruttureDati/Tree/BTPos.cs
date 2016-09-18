using System;
using System.Collections.Generic;

/// <summary>
/// Position for Complete Binary Tree
/// </summary>
/// <typeparam name="T">Generic Type</typeparam>
public class BTPos<T> : IPosition<T> {

    private T el;
    private int index;

    public BTPos(T el, int index) {
        this.el = el;
        this.index = index;
    }

    public T element() {
        return el;
    }

    public T setElement(T element) {
        T temp = this.el;
        this.el = element;
        return temp;
    }

    public int getIndex() {
        return index;
    }
}

