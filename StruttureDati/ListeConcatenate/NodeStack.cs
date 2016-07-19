using StruttureDati.Liste;
using System;


namespace StruttureDati.ListeConcatenate {

    public class NodeStack<T> : IStack<T> {

        private int _size;
        private Node<T> _top;

        public NodeStack() {
            _size = 0;
            _top = new Node<T>(default(T));
        }


        public bool isEmpty() {
            return _size == 0;
        }

        public int size() {
            return _size;
        }

        public T top() {
            if (isEmpty()) {
                throw new InvalidOperationException("Stack is empty");
            }
            return _top.next.element;
        }


        public void push(T element) {
            Node<T> newTop = new Node<T>(element);
            newTop.next = _top.next;
            _top.next = newTop;
            _size++;
        }


        public T pop() {
            if (isEmpty()) {
                throw new InvalidOperationException("Stack is empty");
            }
            Node<T> toPop = _top.next;
            _top.next = toPop.next;
            T toReturn = toPop.element;
            _size--;
            return toPop.element;
        }

    }

}
