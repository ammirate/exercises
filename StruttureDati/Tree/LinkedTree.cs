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
                TreeNode<T> temp = (TreeNode<T>)p;
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


        public int depth(IPosition<T> v) {
            ITreePosition<T> node = checkPosition(v);
            int d = 0;

            ITreePosition<T> temp = node;

            while (temp.getParent() != null) {
                temp = temp.getParent();
                d++;
            }
            return d;
        }


        public int numberLeaves(LinkedTree<T> subTree, IPosition<T> v) {
            if (isExternal(v)) {
                return 1;
            }

            else {
                int sum = 0;
                IEnumerable<IPosition<T>> L = subTree.children(v);
                IEnumerator<IPosition<T>> en = L.GetEnumerator();

                while (en.MoveNext()) {
                    ITreePosition<T> node = checkPosition(en.Current);
                    sum += numberLeaves(subTree, node);
                }

                return sum;
            }
        }


        public bool ancestor(IPosition<T> v, IPosition<T> w) {
            ITreePosition<T> node1 = checkPosition(v);
            ITreePosition<T> node2 = checkPosition(w);

            if (node1 == node2) {
                return true;
            }
            while (node2.getParent() != null) {
                node2 = node2.getParent();
                if (node1 == node2) {
                    return true;
                }
            }
            return false;
        }

        // Lowest Common Ancestor
        public IPosition<T> lca(IPosition<T> v, IPosition<T> w) {
            int depth1 = depth(v);
            int depth2 = depth(w);

            ITreePosition<T> deepest = depth1 > depth2 ? checkPosition(v) : checkPosition(w);
            ITreePosition<T> highest = depth1 <= depth2 ? checkPosition(v) : checkPosition(w);

            int biggestDepth = Math.Max(depth1, depth2);
            int smallestDepth = biggestDepth == depth1 ? depth2 : depth1;

            while (biggestDepth > smallestDepth) {
                deepest = deepest.getParent();
                biggestDepth--;
            }

            do {
                if (deepest == highest) {
                    return highest;
                }
                deepest = deepest.getParent();
                highest = highest.getParent();
            } while (deepest != null && highest != null);

            return null;
        }


        public IEnumerable<IPosition<T>> path(IPosition<T> v, IPosition<T> w) {
            IPositionList<IPosition<T>> vPath = new NodePositionList<IPosition<T>>();

            IPosition<T> lcAncestor = lca(v, w);

            ITreePosition<T> v1 = checkPosition(v);
            ITreePosition<T> w1 = checkPosition(w);

            while (v1.getParent() != lcAncestor) {
                vPath.addLast(v1);
                v1 = v1.getParent();
            }

            while (w1.getParent() != lcAncestor) {
                vPath.addLast(w1);
                w1 = w1.getParent();
            }

            vPath.addLast(lcAncestor);
            return vPath;
        }
    }
}
