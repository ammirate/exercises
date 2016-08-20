using StruttureDati.ListeConcatenate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Tree {

    public class TreeNode<T> : ITreePosition<T> {

        private ITreePosition<T> parent;
        private IPositionList<ITreePosition<T>> children;
        private T el;

        public TreeNode(T element, ITreePosition<T> parent, IPositionList<ITreePosition<T>> children) {
            this.el = element;
            this.children = children;
            this.parent = parent;
        }

        public T element() {
            return el;
        }

        public IPositionList<ITreePosition<T>> getChildren() {
            return children;
        }

        public ITreePosition<T> getParent() {
            return parent;
        }

        public void setChildren(IPositionList<ITreePosition<T>> children) {
            this.children = children;
        }

        public void setElement(T element) {
            this.el = element;
        }

        public void setParent(ITreePosition<T> parent) {
            this.parent = parent;
        }
    }
}
