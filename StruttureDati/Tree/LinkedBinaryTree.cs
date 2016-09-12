using System;
using System.Collections.Generic;
public class LinkedBinaryTree<T> : IBinaryTree<T> {

    private IBTPosition<T> ROOT;
    private int n;

    public LinkedBinaryTree() {
        n = 0;
    }

    public void addRoot(T element) {
        if (ROOT != null) {
            throw new InvalidOperationException("Cannot add root to non-empty Btree");
        }
        ROOT = new BTNode<T>(element, null, null, null);
        n++;
    }

    private IBTPosition<T> checkPosition(IPosition<T> p) {
        if (p == null) {
            throw new ArgumentNullException("Position is null");
        }
        try {
            IBTPosition<T> temp = (IBTPosition<T>)p;
            return temp;
        } catch (InvalidCastException) {
            throw new ArgumentException("Position does not belong to a binary tree");
        }
    }


    public IEnumerable<IPosition<T>> children(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        IPositionList<IPosition<T>> toReturn = new NodePositionList<IPosition<T>>();
        if (hasLeft(v)) {
            toReturn.addLast(left(v));
        }
        if (hasRight(v)) {
            toReturn.addLast(right(v));
        }
        return toReturn;
    }

    public bool hasLeft(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        return temp.getLeft() != null;
    }

    public bool hasRight(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        return temp.getRight() != null;
    }

    public bool isExternal(IPosition<T> v) {
        return !hasLeft(v) && !hasRight(v);
    }

    public bool isInternal(IPosition<T> v) {
        return !isExternal(v);
    }

    public IPosition<T> insertChild(IPosition<T> v, T element) {
        IBTPosition<T> temp = checkPosition(v);

        IPosition<T> toReturn;

        if (isExternal(v)) {
            toReturn = insertLeft(v, element);
        } else {
            if (hasLeft(v) && !hasRight(v)) {
                toReturn = insertRight(v, element);
            } else if (!hasLeft(v) && hasRight(v)) {
                toReturn = insertLeft(v, element);
            } else {
                throw new InvalidOperationException("Cannot add a child to the node.");
            }
        }
        n++;
        return toReturn;
    }


    public bool isEmpty() {
        return n == 0;
    }

    public bool isRoot(IPosition<T> v) {
        return ROOT == checkPosition(v);
    }

    public IEnumerator<T> iterator() {
        throw new NotImplementedException();
    }

    public IEnumerable<IPosition<T>> positions() {
        throw new NotImplementedException();
    }

    public IPosition<T> left(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        return temp.getLeft();
    }

    public IPosition<T> parent(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        return temp.getParent();
    }

    public T replace(IPosition<T> v, T element) {
        IBTPosition<T> temp = checkPosition(v);
        T toReturn = temp.element();
        temp.setElement(element);
        return toReturn;
    }

    public IPosition<T> right(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        return temp.getRight();
    }

    public IPosition<T> root() {
        return ROOT;
    }

    public int size() {
        return n;
    }

    public IPosition<T> insertLeft(IPosition<T> v, T el) {
        if (isInternal(v)) {
            if (hasLeft(v)) {
                throw new InvalidOperationException("the node has already a left child");
            }
        }
        IBTPosition<T> temp = checkPosition(v);
        IBTPosition<T> left = new BTNode<T>(el, temp, null, null);
        temp.setLeft(left);
        n++;
        return left;
    }

    public IPosition<T> insertRight(IPosition<T> v, T el) {
        if (isInternal(v)) {
            if (hasRight(v)) {
                throw new InvalidOperationException("the node has already a right child");
            }
        }
        IBTPosition<T> temp = checkPosition(v);
        IBTPosition<T> right = new BTNode<T>(el, temp, null, null);
        temp.setRight(right);
        n++;
        return right;
    }

    /**
    * Remove the position in input and attach its child to its parent.
    * throws an exception if the node has two children.
    */
    public IPosition<T> remove(IPosition<T> v) {
        IBTPosition<T> temp = checkPosition(v);
        if (hasLeft(v) && hasRight(v)) {
            throw new InvalidOperationException("Cannot remove a node with two children");
        }
        IBTPosition<T> parentNode = checkPosition(parent(v));
        IBTPosition<T> child = checkPosition(hasLeft(v) ? left(v) : right(v));

        if (left(parentNode) == v) {
            parentNode.setLeft(child);
        } else {
            parentNode.setRight(child);
        }
        temp.setParent(null);
        return temp;
    }

    /**
    *
    */
    public void attach(IPosition<T> v, IBinaryTree<T> leftSubTree, IBinaryTree<T> rightSubTree) {
        if (isInternal(v)) {
            throw new InvalidOperationException("Cannot attach any subtree to a non-leaf node");
        }
        IBTPosition<T> node = checkPosition(v);
        node.setLeft(checkPosition(leftSubTree.root()));
        node.setRight(checkPosition(rightSubTree.root()));
    }




    // PRINTING METHODS 
    private const string SEPARATOR = "---";

    public void printPreOrder(IPosition<T> v, int lvl) {
        string spaces = printedDepth(lvl, SEPARATOR);
        Console.WriteLine(spaces + "|" + v.element().ToString() + "|");

        foreach (IPosition<T> child in children(v)) {
            printPreOrder(child, lvl + 1);
        }
    }


    public void printPostOrder(IPosition<T> v, int lvl) {
        foreach (IPosition<T> child in children(v)) {
            printPreOrder(child, lvl + 1);
        }
        string spaces = printedDepth(lvl, SEPARATOR);
        Console.WriteLine(spaces + "|" + v.element().ToString() + "|");
    }

    public void printInOrder(IPosition<T> v, int lvl) {
        if (v == null) {
            return;
        }

        IPosition<T> leftChild = hasLeft(v) ? left(v) : null;
        printInOrder(leftChild, lvl + 1);

        string spaces = printedDepth(lvl, SEPARATOR);
        Console.WriteLine(spaces + "|" + v.element().ToString() + "|");


        IPosition<T> rightChild = hasRight(v) ? right(v) : null;
        printInOrder(rightChild, lvl + 1);

    }

    private string printedDepth(int lvl, string symbol) {
        string toReturn = "";
        for (int i = 0; i < lvl; i++) {
            toReturn += symbol;
        }
        return toReturn;
    }
}