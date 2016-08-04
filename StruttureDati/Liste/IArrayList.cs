using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IArrayList<T> {

    bool isEmpty();

    int size();

    void add(T el);

    void add(T el, int i);

    T set(T el, int i);

    T get(int i);

    T remove(int el);

}

