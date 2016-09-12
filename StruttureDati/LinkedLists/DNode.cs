

public class DNode<T> : IPosition<T> {

    private T el;
    private DNode<T> prev, next;

    public DNode(T element, DNode<T> prev, DNode<T> next) {
        this.el = element;
        this.prev = prev;
        this.next = next;
    }

    public T element() { return el; }
    public DNode<T> getNext() { return next; }
    public DNode<T> getPrev() { return prev; }
    public void setElement(T element) { this.el = element; }
    public void setPrev(DNode<T> newPrev) { this.prev = newPrev; }
    public void setNext(DNode<T> newNext) { this.next = newNext; }
}

