using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArrayList<T> : IArrayList<T> {

    private int CAPACITY = 10;
    private T[] list;
    private int n;

    public ArrayList() {
        list = new T[CAPACITY];
        n = 0;
    }

    public int size() {
        return n;
    }

    public bool isEmpty() {
        return n == 0;
    }


    private void expand() {
        CAPACITY *= 2;
        T[] newList = new T[CAPACITY];
        for (int i = 0; i < size(); i++) {
            newList[i] = list[i];
        }
        list = newList;
    }

    public void add(T el) {
        add(el, size());
    }

    public void add(T el, int index) {
        if (index < 0 || index > size()) {
            throw new IndexOutOfRangeException();
        }

        if (size() == CAPACITY - 1) {
            expand();
        }

        for(int i = size() - 1; i >= index; i--) {
            list[i + 1] = list[i];
        }
        list[index] = el;
        n++;
    }

    public T get(int i) {
        checkIndex(i);
        return list[i];
    }

    public T set(T el, int i) {
        checkIndex(i);
        T temp = list[i];
        list[i] = el;
        return temp;
    }

    public T remove(int index) {
        checkIndex(index);
        T temp = list[index];

        for (int i = index; i <= size()-1; i++) {
            list[i] = list[i + 1];
        }
        n--;
        return temp;
    }

    private void checkIndex(int i) {
        if (i < 0 || i >= size()) {
            throw new IndexOutOfRangeException();
        }
    }

    public static implicit operator List<T>(ArrayList<T> v) {
        throw new NotImplementedException();
    }
}

