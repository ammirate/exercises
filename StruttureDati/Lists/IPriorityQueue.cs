
public interface IPriorityQueue<K, V> {

    int size();
    bool isEmpty();

    Entry<K, V> min();

    Entry<K, V> insert(K k, V v);
    Entry<K, V> removeMin();
}

