using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.ListeConcatenate {

    public interface IDeque<T> {

        void addFirst(T el);

        void addLast(T el);

        T removeFirst(); 

        T removeLast();

        T getFirst();

        T getLast();

        int size();

        bool isEmpty();
    }
}
