using System;


public class NodeStack<T> : IStack<T> {

    private int Size;
    private Node<T> Top;

    public NodeStack() {
        Size = 0;
        Top = new Node<T>(default(T));
    }


    public bool isEmpty() {
        return Size == 0;
    }

    public int size() {
        return Size;
    }

    public T top() {
        if (isEmpty()) {
            throw new InvalidOperationException("Stack is empty");
        }
        return Top.next.element;
    }


    public void push(T element) {
        Node<T> newTop = new Node<T>(element);
        newTop.next = Top.next;
        Top.next = newTop;
        Size++;
    }


    public T pop() {
        if (isEmpty()) {
            throw new InvalidOperationException("Stack is empty");
        }
        Node<T> toPop = Top.next;
        Top.next = toPop.next;
        T toReturn = toPop.element;
        Size--;
        return toPop.element;
    }
}