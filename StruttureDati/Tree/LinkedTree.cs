using System;
using System.Collections.Generic;
using StruttureDati.ListeConcatenate;

namespace StruttureDati.Tree {
    public class LinkedTree<T> : ITree<T> {

        private ITreePosition<T> ROOT;
        private int n;

        public LinkedTree() {
            n = 0;
            ROOT = null;
        }



        private ITreePosition<T> checkPosition(IPosition<T> p) {
            if (p == null) {
                throw new ArgumentNullException("Position is NULL");
            }
            try {
                ITreePosition<T> temp = (ITreePosition<T>)p;
                return temp;
            } catch (InvalidCastException e) {
                throw new ArgumentException("Position is not valid!");
            }
        }

        public bool isEmpty() {
            return n == 0;
        }

        public int size() {
            return n;
        }

        public IEnumerator<T> iterator() {
            IEnumerable<IPosition<T>> pos = positions();
            IPositionList<T> elements = new NodePositionList<T>();

            foreach (IPosition<T> p in pos) {
                elements.addLast(p.element());
            }
            return elements.GetEnumerator();
        }

        public IEnumerable<IPosition<T>> positions() {
            IPositionList<IPosition<T>> L = new NodePositionList<IPosition<T>>();
            if (!isEmpty()) {
                preOrder(this.ROOT, L);
             }
            return L;
        }

        public IPosition<T> root() {
            if (isEmpty()) {
                throw new InvalidOperationException("Cannot retrieve root from empty tree");
            }
            return this.ROOT;
        }

        public IPosition<T> parent(IPosition<T> v) {
            ITreePosition<T> temp = checkPosition(v);
            return temp.getParent();
        }

        public IEnumerable<IPosition<T>> children(IPosition<T> v) {
            if (isExternal(v)) {
                throw new InvalidOperationException("Cannot retrieve children from leaf node");
            }
            ITreePosition<T> temp = checkPosition(v);
            return temp.getChildren();
        }

        public bool isInternal(IPosition<T> v) {
            ITreePosition<T> temp = checkPosition(v);
            return temp.getChildren() != null && temp.getChildren().size() > 0;
        }

        public bool isExternal(IPosition<T> v) {
            return !isInternal(v);
        }

        public bool isRoot(IPosition<T> v) {
            ITreePosition<T> temp = checkPosition(v);
            return temp.getParent() == null;
        }

        public void addRoot(T element) {
            if (!isEmpty()) {
                throw new InvalidOperationException("Cannot add root to non empty tree");
            }
            this.ROOT = new TreeNode<T>(element, null, null); ;
            n = 1;
        }

        public T replace(IPosition<T> v, T element) {
            ITreePosition<T> temp = checkPosition(v);
            T toReturn = temp.element();
            temp.setElement(element);
            return toReturn;
        }

        public IPosition<T> insertChild(IPosition<T> v, T element) {
            ITreePosition<T> temp = checkPosition(v);
            if (temp.getChildren() == null) {
                temp.setChildren(new NodePositionList<ITreePosition<T>>());
            }
            ITreePosition<T> toReturn = new TreeNode<T>(element, temp, null);
            temp.getChildren().addLast(toReturn);
            n++;
            return toReturn;
        }


        public void preOrder(IPosition<T> v, IPositionList<IPosition<T>> list) {
            ITreePosition<T> temp = checkPosition(v);
            list.addLast(temp);
            if (isInternal(temp)) {
                foreach (IPosition<T> c in temp.getChildren()) {
                    preOrder(c, list);
                }
            }
        }
    }
}
