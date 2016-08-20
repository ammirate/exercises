using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.ListeConcatenate {
    public class ElementIterator<T> : IEnumerator<T> {

        private IPositionList<T> list;
        private IPosition<T> cursor;


        public ElementIterator(IPositionList<T> L) {
            this.list = L;
            this.Reset();
        }

        public T Current {
            get {
                T temp = cursor.element();
                if (cursor == null) {
                    throw new ArgumentOutOfRangeException("No more elements");
                }
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
            return cursor == null;
        }

        public void Reset() {
            cursor = list.isEmpty() ? null : list.first();
        }
    }
}
