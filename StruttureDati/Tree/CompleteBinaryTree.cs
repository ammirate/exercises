using System;
using System.Collections.Generic;

/// <summary>
/// Tutti i nodi dell'albero binario completo sono memorizzati in un array list A.
/// La radice è memorizzata all'indice 1, mentre l'elemento all'indice 0 è deliberatamente null.
/// Per ogni nodo v memorizzato all'indice i:
///     - il suo figlio sinistro è memorizzato all'indice 2i
///     - il suo figlio destro è memorizzato all'indice 2i + 1
/// </summary>
/// <typeparam name="T">Generic Type</typeparam>
class CompleteBinaryTree<T> : ICompleteBinaryTree<T> {

    private ArrayList<IPosition<T>> BT;

    public CompleteBinaryTree() {
        BT = new ArrayList<IPosition<T>>();
        BT.add(default(IPosition<T>), 0);
    }

    private BTPos<T> checkPosition(IPosition<T> p) {
        if (p == null) {
            throw new InvalidOperationException("Position is null");
        }
        try {
            BTPos<T> temp = (BTPos<T>)p;
            return temp;
        } catch (InvalidCastException) {
            throw new InvalidOperationException("Position does not belong to a complete binary tree structure");
        }
    }

    public bool isEmpty() {
        return BT.size() == 1; // the first element will contain always null
    }


    public IPosition<T> root() {
        if (isEmpty())
            throw new InvalidOperationException("Cannot retrieve root from an empty tree");
        return BT.get(1);
    }

    public int size() {
        return BT.size() - 1;
    }

    public void addRoot(T element) {
        if (!isEmpty()) {
            throw new InvalidOperationException("Cannot add a root to non-empty tree");
        }
        if (size() == 0) {
            BT.set(new BTPos<T>(element, 1), 1);
        }
    }

    public IEnumerable<IPosition<T>> children(IPosition<T> v) {
        IPositionList<IPosition<T>> toReturn = new NodePositionList<IPosition<T>>();
        return toReturn;
        // DA COMPLETARE
    }

    public bool hasLeft(IPosition<T> v) {
        BTPos<T> temp = checkPosition(v);
        // left node, if any, could be found at 2i
        return 2 * temp.getIndex() <= size();
    }

    public bool hasRight(IPosition<T> v) {
        BTPos<T> temp = checkPosition(v);
        // right node, if any, could be found at 2i+1
        return 2 * temp.getIndex() + 1 <= size();
    }

    public IPosition<T> right(IPosition<T> v) {
        if (isExternal(v) || !hasRight(v)) {
            throw new InvalidOperationException("No right node");
        }   
        BTPos<T> p = checkPosition(v);
        return BT.get(2 * p.getIndex() + 1);
    }


    public bool isExternal(IPosition<T> v) {
        return !isInternal(v);
    }

    public bool isInternal(IPosition<T> v) {
        return hasLeft(v);
    }


    public IPosition<T> insertChild(IPosition<T> v, T element) {
        if (isInternal(v)) {
            throw new InvalidOperationException("Cannot add a child to non-leaf node");
        }
        return add(element);
    }


    public bool isRoot(IPosition<T> v) {
        BTPos<T> p = checkPosition(v);
        return p == BT.get(1);
    }

    public IEnumerator<T> iterator() {
        throw new NotImplementedException();
    }

    public IPosition<T> left(IPosition<T> v) {
        if (isExternal(v)) {
            throw new InvalidOperationException("Cannot retrieve left node from leaf node");
        }
        BTPos<T> p = checkPosition(v);
        return BT.get(2*p.getIndex());
    }

    public IPosition<T> parent(IPosition<T> v) {
        if (isRoot(v)) {
            throw new InvalidOperationException("Cannot retrieve parent from root node");
        }
        BTPos<T> p = checkPosition(v);
        return BT.get(p.getIndex() / 2);
    }

    public IEnumerable<IPosition<T>> positions() {
        throw new NotImplementedException();
    }

    public T remove() {
        if (isEmpty()) {
            throw new InvalidOperationException("Cannot remove any node because the tree is empty");
        }
        int n = size();
        return BT.remove(n - 1).element(); //remove the last leaf from right to left
    }

    public T replace(IPosition<T> v, T element) {
        BTPos<T> temp = checkPosition(v);
        return temp.setElement(element);
    }

    public IPosition<T> add(T el) {
        int n = BT.size();
        BTPos<T> p = new BTPos<T>(el, n);
        BT.add(p);
        return p;
    }


    public IPosition<T> sibling(IPosition<T> v) {
        BTPos<T> temp = checkPosition(v);
        int parent = temp.getIndex() / 2;
        return BT.get(2 * parent + 1);
    }
}

