public interface IBinaryTree<T> : ITree<T> {

    bool hasLeft(IPosition<T> v);
    IPosition<T> left(IPosition<T> v); //throws InvalidPositionException, BoundaryViolationException;

    bool hasRight(IPosition<T> v);
    IPosition<T> right(IPosition<T> v); //throws InvalidPositionException, BoundaryViolationException;
}

