public interface IBTPosition<T> : IPosition<T> {

    void setElement(T o);

    IBTPosition<T> getLeft();

    void setLeft(IBTPosition<T> v);

    IBTPosition<T> getRight();

    void setRight(IBTPosition<T> v);

    IBTPosition<T> getParent();

    void setParent(IBTPosition<T> v);
}

