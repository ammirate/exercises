public class BTNode<T> : IBTPosition<T> {

    private IBTPosition<T> left;
    private IBTPosition<T> right;
    private IBTPosition<T> parent;
    private T el;

    public BTNode(T el, IBTPosition<T> parent, IBTPosition<T> left, IBTPosition<T> right) {
        this.el = el;
        this.parent = parent;
        this.left = left;
        this.right = right;
    }

    public T element() {
        return this.el;
    }

    public IBTPosition<T> getLeft() {
        return this.left;
    }

    public IBTPosition<T> getParent() {
        return this.parent;
    }

    public IBTPosition<T> getRight() {
        return this.right;
    }

    public void setElement(T o) {
        this.el = o;
    }

    public void setLeft(IBTPosition<T> v) {
        this.left = v;
    }

    public void setParent(IBTPosition<T> v) {
        this.parent = v;
    }

    public void setRight(IBTPosition<T> v) {
        this.right = v;
    }
}


