using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Liste {


    /*.
    Inserimento, cancellazione e ricerca avvengono solo in una posizione: viene cancellato 
    sempre l'oggetto che è stato inserito per ultimo.

    Inserimento e cancellazione avvengono secondo una strategia LIFO (last in first out):
    - Inserimento: un nuovo oggetto viene inserito in cima allo stack
    - Cancellazione: viene cancellato sempre l'oggetto in cima allo stack
    */
    public interface IStack<T> { //

        void push(T element);

        T top();

        T pop();

        int size();

        bool isEmpty();

    }

}
