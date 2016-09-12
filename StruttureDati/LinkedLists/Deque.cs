using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Deque<T> : IDeque<T> {

        private Node<T> head;
        private Node<T> trail;
        private int _size;

        public Deque() {
            _size = 0;
            head = new Node<T>(default(T));
            trail = new Node<T>(default(T));

            head.prev = trail;
            trail.next = head;
        }


        public void addFirst(T el) {
            Node<T> newFirst = new Node<T>(el);
            Node<T> first = head.prev;

            newFirst.prev = first;
            if (first != null)
                first.next = newFirst;

            head.prev = newFirst;
            newFirst.next = head;
            _size++;
        }

        public void addLast(T el) {
            Node<T> newLast = new Node<T>(el);
            Node<T> last = trail.next;

            // last is not the last anymore, because its prev becomes newLast
            if (last != null)
                last.prev = newLast;
            newLast.prev = trail;

            newLast.next = last;
            trail.next = newLast;
            _size++;
        }

        public T getFirst() {
            if (isEmpty()) {
                throw new InvalidOperationException("Deque is empty");
            }
            return head.prev.element;
        }

        public T getLast() {
            if (isEmpty()) {
                throw new InvalidOperationException("Deque is empty");
            }
            return trail.next.element;
        }

        public bool isEmpty() {
            //return _size == 0;
            return head.prev == trail && trail.next == head;
        }

        public T removeFirst() {
            if (isEmpty()) {
                throw new InvalidOperationException("Deque is empty");
            }
            Node<T> first = head.prev;
            Node<T> second = first.prev;
            
            second.next = head;
            head.prev = second;

            T temp = first.element;
            first = default(Node<T>);
            _size--;
            return temp;
        }

        public T removeLast() {
            if (isEmpty()) {
                throw new InvalidOperationException("Deque is empty");
            }

            Node<T> last = trail.next;
            Node<T> secondLast = trail.next.next;

            trail.next = secondLast;
            secondLast.prev = trail;

            T temp = last.element;
            last = default(Node<T>);
            _size--;
            return temp;
        }

        public int size() {
            return _size;
        }
    }

