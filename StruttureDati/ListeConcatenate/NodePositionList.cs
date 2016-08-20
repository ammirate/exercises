using System;
using System.Collections;
using System.Collections.Generic;

namespace StruttureDati.ListeConcatenate {
    public class NodePositionList<T> : IPositionList<T> {

        private DNode<T> header, trailer;
        protected int n;

        public NodePositionList() {
            this.n = 0;
            this.header = new DNode<T>(default(T), null, null);
            this.trailer = new DNode<T>(default(T), header, null);
            header.setNext(trailer);
        }

        public int size() {
            return n;
        }

        public bool isEmpty() {
            return header.getNext() == trailer;
        }

        public IPosition<T> first() {
            if (isEmpty()) {
                throw new InvalidOperationException("List is empty");
            }
            return header.getNext();
        }

        public IPosition<T> last() {
            if (isEmpty()) {
                throw new InvalidOperationException("List is empty");
            }
            return trailer.getPrev();
        }


        protected DNode<T> checkPosition(IPosition<T> p) {
            if (p == null || p == trailer || p == header) {
                throw new ArgumentException("Posizione non valida");
            }
            try {
                DNode<T> temp = (DNode<T>)p;
                if (temp.getNext() == null || temp.getPrev() == null) {
                    throw new ArgumentException("Posizione non appartenente a una lista");
                }
                return temp;
            } catch (Exception e) {
                throw new InvalidCastException();
            }
         }

        public void addAfter(IPosition<T> p, T element) {
            DNode<T> pos = checkPosition(p);
            DNode<T> nextPos = pos.getNext();
            DNode<T> temp = new DNode<T>(element, pos, nextPos);
            pos.setNext(temp);
            nextPos.setPrev(temp);
            n++;
        }

        public void addBefore(IPosition<T> p, T element) {
            DNode<T> pos = checkPosition(p);
            DNode<T> prevPos = pos.getPrev();
            DNode<T> temp = new DNode<T>(element, prevPos, pos);
            pos.setPrev(temp);
            prevPos.setNext(temp);
            n++;
        }

        public void addFirst(T element) {
            DNode<T> temp = new DNode<T>(element, header, header.getNext());
            header.getNext().setPrev(temp);
            header.setNext(temp);
            n++;
        }

        public void addLast(T element) {
            DNode<T> temp = new DNode<T>(element, trailer.getPrev(), trailer);
            trailer.getPrev().setNext(temp);
            trailer.setPrev(temp);
            n++;
        }

        public IPosition<T> next(IPosition<T> p) {
            DNode<T> node = checkPosition(p).getNext();
            if (node == trailer) {
                throw new ArgumentOutOfRangeException();
            }
            return node;
        }

        public IPosition<T> prev(IPosition<T> p) {
            DNode<T> node = checkPosition(p).getPrev();
            if (node == header) {
                throw new ArgumentOutOfRangeException();
            }
            return node;
        }

        public T remove(IPosition<T> p) {
            DNode<T> temp = checkPosition(p);
            temp.getPrev().setNext(temp.getNext());
            temp.getNext().setPrev(temp.getPrev());
            T toReturn = temp.element();
            temp = null;
            n--;
            return toReturn;
        }

        public T set(IPosition<T> p, T element) {
            DNode<T> temp = checkPosition(p);
            T toReturn = temp.element();
            temp.setElement(element);
            return toReturn;
        }

        public IEnumerator<T> GetEnumerator() {
            return new ElementIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new ElementIterator<T>(this);
        }

        public IEnumerable<IPosition<T>> positions() {
            IPositionList<IPosition<T>> P = new NodePositionList<IPosition<T>>();

            if (!isEmpty()) {
                IPosition<T> p = first();
                while (true) {
                    P.addLast(p);
                    if (p == last()) {
                        break;
                    }
                    p = next(p);
                }
            }
            return P;
        }
    }
}
