﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.ListeConcatenate {
    public interface IPositionList<T> {
        int size();
        bool isEmpty();
        IPosition<T> first(); // throws EmptyListException
        IPosition<T> last();  // throws EmptyListException
        IPosition<T> next(IPosition<T> p); //throws BoundaryViolationException, InvalidPositionException
        IPosition<T> prev(IPosition<T> p); //throws BoundaryViolationException, InvalidPositionException
        void addFirst(T element);
        void addLast(T element);
        void addAfter(IPosition<T> p, T element);  //throws InvalidPositionException
        void addBefore(IPosition<T> p, T element); //throws InvalidPositionException
        T set(IPosition<T> p, T element);
        T remove(IPosition<T> p);
    }
}
