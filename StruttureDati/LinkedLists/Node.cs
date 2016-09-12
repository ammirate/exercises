using System;
using System.Collections.Generic;


class Node<T> {

    internal T element;
    internal Node<T> prev;
    internal Node<T> next;


    public Node(T el) {
        this.element = el;
        this.prev = null;
        this.next = null;
    }
}

