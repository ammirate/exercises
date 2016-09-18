using System;
using System.Collections.Generic;


public class SortedListPriorityQueue<K, V> : IPriorityQueue<K, V> {

    private IPositionList<Entry<K, V>> entries;
    private IComparer<K> comparator;


    public SortedListPriorityQueue() {
        entries = new NodePositionList<Entry<K,V>>();
        comparator = new DefaultComparator<K>();
    }

    public void setComparator(IComparer<K> comp) {
        if (isEmpty()) {
            throw new InvalidOperationException("Cannot set a new comparator. Queue is not empty.");
        }
        this.comparator = comp;
    }

    private bool checkKey(K key) {
        bool res  = false;
        try {
            res = this.comparator.Compare(key, key) == 0;
        } catch (Exception e) {
            throw new InvalidOperationException("Key not valid.");
        }
        return res;
    }


    public Entry<K, V> insert(K k, V v) {
        checkKey(k);

        Entry<K,V> e = new Entry<K, V>(k, v);
        if (isEmpty()) {
            entries.addFirst(e);
        } else {
            foreach (IPosition<Entry<K,V>> temp in entries.positions()) {
                if (comparator.Compare(e.key, temp.element().key) <= 0) {
                    entries.addBefore(temp, e);
                    return e;
                }
            }
            entries.addLast(e);
            
        }
        return e;
    }


    public bool isEmpty() {
        return entries.isEmpty();
    }


    public Entry<K, V> min() {
        if (isEmpty()) {
            throw new InvalidOperationException("Priority Queue is empty");
        }
        return entries.first().element();
    }


    public Entry<K, V> removeMin() {
        Entry<K, V> temp = min();
        entries.remove(entries.first());
        return temp;
    }


    public int size() {
        return entries.size();
    }
}

