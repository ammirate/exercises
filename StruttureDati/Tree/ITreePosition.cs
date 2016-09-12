public interface ITreePosition<T> : IPosition<T> {

    void setElement(T element);

    void setParent(ITreePosition<T> parent);

    ITreePosition<T> getParent();

    void setChildren(IPositionList<ITreePosition<T>> children);

    IPositionList<ITreePosition<T>> getChildren();
}