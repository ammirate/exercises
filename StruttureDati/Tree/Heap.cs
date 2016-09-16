using System;
using System.Collections.Generic;

/// <summary>
/// An Heap is a Complete Binary Tree having an ordering relationship among its nodes.
/// In particular, every node has a key smaller or equal than its children.
/// Everytime a node is added, the heap has to be processed to revalidate such rule. 
/// </summary>
/// <typeparam name="K">Parametric type for nodes' keys</typeparam>
/// <typeparam name="V">Parametric type for nodes' values</typeparam>
public class Heap<K, V> : IPriorityQueue<K, V> {

    private ICompleteBinaryTree<Entry<K, V>> heap;
    IComparer<K> comp;


    public Heap() {
        heap = new CompleteBinaryTree<Entry<K,V>>();
        comp = new DefaultComparator<K>();
    }

    public Heap(IComparer<K> c) {
        heap = new CompleteBinaryTree<Entry<K, V>>();
        comp = c;
    }


    public Entry<K, V> insert(K k, V v) {
        checkKey(k);
        Entry<K, V> temp = new Entry<K, V>(k, v);
        upHeap(heap.add(temp));
        return temp;
    }

    private void checkKey(K k) {
        try {
            if (k == null || comp.Compare(k, k) != 1) {
                throw new ArgumentException("Key is not valid");
            }
        } catch (InvalidCastException e) {
            throw new InvalidOperationException("Key is not valid");
        }
    }

    private void upHeap(IPosition<Entry<K, V>> position) {
        IPosition<Entry<K, V>> parent;

        while (!heap.isRoot(position)) {
            parent = heap.parent(position);

            if (comp.Compare(parent.element().key, position.element().key) <= 0) {
                break;
            } else {
                swap(position, parent);
                position = parent;
            }
        }
    }

    private void swap(IPosition<Entry<K, V>> position, IPosition<Entry<K, V>> parent) {
        Entry<K, V> temp = position.element();
        heap.replace(position, parent.element());
        heap.replace(parent, temp);
    }

    public bool isEmpty() {
        return heap.isEmpty();
    }

    public Entry<K, V> min() {
        return heap.root().element();
    }

    public Entry<K, V> removeMin() {
        if (isEmpty()) {
            throw new InvalidOperationException("heap is empty");
        }
        Entry<K, V> min = heap.root().element();
        if (size() == 1) {
            heap.remove();
        } else {
            heap.replace(heap.root(), heap.remove());
            heapDown(heap.root());
        }
        return min;
    }



    private void heapDown(IPosition<Entry<K, V>> position) {
        while (heap.isInternal(position)) {

            IPosition<Entry<K, V>> smallerChild;

            if (!heap.hasRight(position)) {
                smallerChild = heap.left(position);
            }
            else {
                if (comp.Compare(heap.left(position).element().key, heap.right(position).element().key) < 1) {
                    smallerChild = heap.left(position);
                } else {
                    smallerChild = heap.right(position);
                }
            }

            if (comp.Compare(smallerChild.element().key, position.element().key) < 1) {
                swap(smallerChild, position);
                position = smallerChild;
            } else {
                break;
            }
        }
    }

    public int size() {
        return heap.size();
    }

}

