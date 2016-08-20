using StruttureDati.ListeConcatenate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Tree {
    public interface ITree<T> {

        bool isEmpty();
        int size();
        IEnumerator<T> iterator();
        IEnumerable<IPosition<T>> positions();

        IPosition<T> root(); //throw EmptyTreeException
        IPosition<T> parent(IPosition<T> v); //throes BoundaryViolationException
        IEnumerable<IPosition<T>> children(IPosition<T> v);

        bool isInternal(IPosition<T> v);
        bool isExternal(IPosition<T> v);
        bool isRoot(IPosition<T> v);

        void addRoot(T element); //throw NonEmptyTreeException
        T replace(IPosition<T> v, T element);
        IPosition<T> insertChild(IPosition<T> v, T element);
    }
}
