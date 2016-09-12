using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ElementIterator<T> : IEnumerator<T> {

    private IPositionList<T> list;
    private IPosition<T> cursor;


    public ElementIterator(IPositionList<T> L) {
        this.list = L;
        this.Reset();
    }

    public T Current {
        get {
            if (cursor == null) {
                throw new ArgumentOutOfRangeException("No more elements");
            }
            T temp = this.cursor.element();
            cursor = (cursor == list.last()) ? null : list.next(cursor);
            return temp;
        }
    }

    object IEnumerator.Current {
        get {
            return Current;
        }
    }


    public void Dispose() {

    }

    public bool MoveNext() {
        return cursor != null; ;
    }

    public void Reset() {
        this.cursor = list.isEmpty() ? null : this.list.first();
    }
}

